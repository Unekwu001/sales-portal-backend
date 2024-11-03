using Asp.Versioning;
using AutoMapper;
using Core.CustomerRequestServices;
using Core.EmailServices;
using Core.UserServices;
using Data.Models.CustomerRequestsModels;
using API.Data.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Core.OrderServices;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CustomerRequestsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRequestService _customerRequestService;
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;
        private readonly ILogger<CustomerRequestsController> _logger;
        private readonly IOrderService _orderService;

        public CustomerRequestsController(IMapper mapper, ICustomerRequestService customerRequestService, IEmailService emailService, IUserService userService, ILogger<CustomerRequestsController> logger, IOrderService orderService)
        {
            _mapper = mapper;
            _customerRequestService = customerRequestService;
            _emailService = emailService;
            _userService = userService;
            _logger = logger;
            _orderService = orderService;
        }

        [Authorize]
        [HttpPost("request-for-installation")]
        public async Task<IActionResult> RequestInstallation([FromBody] RequestForInstallationDto requestForInstallationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ipNXApiResponse.Failure("Invalid data"));
            }
            try
            {
                var (orderExists, order) = await _orderService.OrderExistAsync(requestForInstallationDto.OrderId);
                if (!orderExists)
                {
                    return NotFound(ipNXApiResponse.Failure("Order Not found"));
                }

                var userIdFromClaims = User.Claims.FirstOrDefault()?.Value;
                var userId = new Guid(userIdFromClaims);
                if (order.CreatedById != userId)
                {
                    return Unauthorized(ipNXApiResponse.Failure("You are not authorized to make this installation request"));
                }
                var installationRequest = _mapper.Map<RequestForInstallation>(requestForInstallationDto);
                installationRequest.CreatedById = userId;
                installationRequest.LastUpdatedById = userId;
                await _customerRequestService.SaveInstallationRequestAsync(installationRequest);
                await _orderService.MarkInstallationStatusAsTrueAsync(order);

                var userDetails = await _userService.UserExistsAsync(userId);
                var emailbodyforCustomer = $@"
<html>
    <body style='font-family: Arial, sans-serif; margin: 0; padding: 0; background-color: #f3f3f3;'>
        <div style='background-color: #f3f3f3; padding: 20px 0;'>
            <div style='max-width: 600px; margin: 0 auto; background-color: #ffffff; border-radius: 8px; overflow: hidden; box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);'>
                <!-- Logo Section -->
                <div style='text-align: center; padding: 20px;'>
                    <img src='https://res.cloudinary.com/ds5iyguss/image/upload/v1726506296/ipnx-logoo_skrbcx.png' alt='ipNX Logo' style='max-width: 150px;' />
                </div>
                
                <!-- Main Content -->
                <div style='padding: 30px;'>
                    <h1 style='color: #333; font-size: 22px; margin-bottom: 20px; text-align: center;'>Installation Scheduled</h1>
                    <p style='font-size: 14px; color: #555; line-height: 1.6;'>Dear {userDetails?.FirstName} {userDetails?.LastName},</p>
                    <p style='font-size: 14px; color: #555; line-height: 1.6;'>We are pleased to inform you that your installation for order ID <strong>{order?.Id}</strong> has been successfully scheduled.</p>
                    <p style='font-size: 14px; color: #555; line-height: 1.6;'>Below are the details of your installation:</p>

                    <!-- Installation Details -->
                    <div style='background-color: #f9f9f9; padding: 15px; border-radius: 6px; margin-top: 10px;'>
                        <ul style='font-size: 14px; color: #333; padding-left: 0; list-style-type: none;'>
                            <li style='margin-bottom: 10px;'><strong>Installation Date:</strong> {requestForInstallationDto?.InstallationDate:dd MMM, yyyy}</li>
                            <li style='margin-bottom: 10px;'><strong>Installation Time:</strong> {requestForInstallationDto?.InstallationDate:HH:mm tt}</li>
                        </ul>
                    </div>

                    <!-- Additional Info -->
                    <p style='font-size: 14px; color: #555; line-height: 1.6; margin-top: 20px;'>Please ensure you are available during the specified date and time. For more details, feel free to visit your dashboard.</p>
                    <p style='font-size: 14px; color: #555; line-height: 1.6;'>Thank you for choosing ipNX. We look forward to serving you!</p>
                    
                    <!-- Signature -->
                    <p style='font-size: 14px; color: #333; font-weight: bold;'>Best regards,</p>
                    <p style='font-size: 14px; color: #333;'>ipNX Nigeria Limited</p>
                </div>

                <!-- Footer -->
                <div style='background-color: #f1f1f1; padding: 20px; text-align: center; font-size: 12px; color: #888;'>
                    <p>&copy; {DateTime.Now.Year} ipNX Nigeria Limited. All rights reserved.</p>
                    <p><a href='https://www.ipnxnigeria.net/' style='color: #D71920; text-decoration: none;'>www.ipnxnigeria.net</a></p>
                </div>
            </div>
        </div>
    </body>
</html>
";







                var emailbodyforIpNXTeam = $@"
<html>
    <body style='font-family: Arial, sans-serif; background-color: #f9f9f9; margin: 0; padding: 0;'>
        <div style='background-color: #f9f9f9; width: 100%; padding: 20px;'>
            <div style='max-width: 600px; margin: 0 auto; border-radius: 10px; overflow: hidden; box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);'>
                <div style='text-align: center; padding: 20px;'>
                    <img src='https://res.cloudinary.com/ds5iyguss/image/upload/v1726506296/ipnx-logoo_skrbcx.png' alt='ipNX Logo' style='max-width: 180px;' />
                </div>
                <div style='padding: 30px;'>
                    <h1 style='color: #333; font-size: 26px; margin-bottom: 20px; text-align: center;'>Installation Scheduled</h1>
                    <p style='font-size: 16px; line-height: 1.6; color: #666;'>Dear Team,</p>
                    <p style='font-size: 16px; line-height: 1.6; color: #666;'>A new installation has been scheduled for the following customer:</p>
                    <ul style='font-size: 16px; line-height: 1.6; color: #666; list-style-type: none; padding-left: 0;'>
                        <li><strong>Customer Name:</strong> {userDetails?.FirstName} {userDetails?.LastName}</li>
                        <li><strong>Order Number:</strong> {order?.Id}</li>
                        <li><strong>Installation Date:</strong> {requestForInstallationDto?.InstallationDate:dd MMM, yyyy}</li>
                        <li><strong>Time Slot:</strong> {requestForInstallationDto?.InstallationDate:HH:mm tt}</li>
                        <li><strong>Customer's phone number:</strong> {userDetails?.PhoneNumber}</li>
                        <li><strong>Customer's address:</strong> {userDetails?.Address}</li>
                    </ul>
                    <p style='font-size: 16px; line-height: 1.6; color: #666;'>Please ensure the necessary arrangements are made for the installation.</p>
                    
                    <p style='font-size: 16px; color: #666;'>Thank you,</p>
                    <p style='font-size: 16px; font-weight: bold; color: #333;'>Administrator</p>
                </div>
                <div style='background-color: #f4f4f4; padding: 20px; text-align: center; font-size: 12px; color: #999;'>
                    <p>&copy; {DateTime.Now.Year} ipNX Nigeria Limited. All rights reserved.</p>
                    <p><a href='https://www.ipnxnigeria.net/' style='color: #D71920; text-decoration: none;'>www.ipnxnigeria.net</a></p>
                </div>
            </div>
        </div>
    </body>
</html>
";



                var recipients = new List<string> { "ist@ipnxnigeria.net" };
                await _emailService.SendEmailAsync(userDetails.Email, "Installation Scheduled", emailbodyforCustomer);
                await _emailService.SendMailToMultipleRecipientAsync(recipients, $"Installation Scheduled for {userDetails.FirstName} {userDetails.LastName}", emailbodyforIpNXTeam);
                return Ok(ipNXApiResponse.Success("Congratulations, installation has been scheduled!"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while customer attempted to request an installation");
                return BadRequest(ipNXApiResponse.Failure("An error occurred while processing the request"));
            }

        }







        [Authorize]
        [HttpPost("request-a-call")]
        public async Task<IActionResult> RequestForCallBack()
        {
            var userIdFromClaims = User.Claims.FirstOrDefault()?.Value;
            var userId = new Guid(userIdFromClaims);
            try
            {
                var callBackRequest = new RequestCallBack
                {
                    CreatedById = userId,
                    LastUpdatedById = userId
                };                        
                await _customerRequestService.SaveCallBackRequestAsync(callBackRequest);

                var userDetails = await _userService.UserExistsAsync(userId);

                var body = $@"
<html>
    <body style='font-family: Arial, sans-serif; margin: 0; padding: 0; background-color: #f3f3f3;'>
        <div style='background-color: #f3f3f3; padding: 20px 0;'>
            <div style='max-width: 600px; margin: 0 auto; background-color: #ffffff; border-radius: 8px; overflow: hidden; box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);'>
                <div style='text-align: center; padding: 20px;'>
                    <img src='https://res.cloudinary.com/ds5iyguss/image/upload/v1726506296/ipnx-logoo_skrbcx.png' alt='ipNX Logo' style='max-width: 150px; margin-bottom: 10px;' />
                  
                </div>
                <div style='padding: 30px;'>
                <h2 style='color: #333; font-size: 20px;'>Customer Callback Request</h2>
                    <p style='font-size: 14px; color: #555; line-height: 1.6;'>Dear team,</p>
                    <p style='font-size: 14px; color: #555; line-height: 1.6;'>A customer has requested a callback regarding their installation. Below are the customer details:</p>
                    <div style='background-color: #f9f9f9; padding: 15px; border-radius: 6px; margin-top: 10px;'>
                        <ul style='font-size: 14px; color: #333; padding-left: 0; list-style-type: none;'>
                            <li style='margin-bottom: 10px;'><strong>Customer Name:</strong> {userDetails.FirstName} {userDetails.LastName}</li>
                            <li style='margin-bottom: 10px;'><strong>Phone Number:</strong> {userDetails.PhoneNumber}</li>
                            <li style='margin-bottom: 10px;'><strong>Email:</strong> {userDetails.Email}</li>
                            <li style='margin-bottom: 10px;'><strong>Address:</strong> {userDetails.Address}</li>
                        </ul>
                    </div>
                    <p style='font-size: 14px; color: #555; line-height: 1.6; margin-top: 20px;'>Please contact the customer at your earliest convenience.</p>
                    
                    <!-- Signature -->
                    <p style='font-size: 14px; color: #333; font-weight: bold;'>Best regards,</p>
                    <p style='font-size: 14px; color: #333;'>Administrator</p>
                </div>

                <!-- Footer -->
                <div style='background-color: #f1f1f1; padding: 20px; text-align: center; font-size: 12px; color: #888;'>
                    <p>&copy; {DateTime.Now.Year} ipNX Nigeria Limited. All rights reserved.</p>
                    <p><a href='https://www.ipnxnigeria.net/' style='color: #D71920; text-decoration: none;'>www.ipnxnigeria.net</a></p>
                </div>
            </div>
        </div>
    </body>
</html>
";
                var recipients = new List<string>
                {
                    "ist@ipnxnigeria.net","worktools@ipnxnigeria.net","pfermac@ipnxnigeria.net"
                };
                await _emailService.SendMailToMultipleRecipientAsync(recipients, $"Call Request from {userDetails.FirstName}{userDetails.LastName}", body);
                
                return Ok(ipNXApiResponse.Success("Your call back request was submitted successfully. We will reach out to you as quickly as possible!"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while customer attempted to request a call");
                return BadRequest(ipNXApiResponse.Failure("An error occurred while processing the request"));
            }

        }



        [Authorize]
        [HttpPost("request-wifi-for-order")]
        public async Task<IActionResult> RequestForWifi(string orderId, bool activate)
        {
            var userIdFromClaims = User.Claims.FirstOrDefault()?.Value;
            var userId = new Guid(userIdFromClaims);
            try
            {

                var (orderExists, order) = await _orderService.OrderExistAsync(orderId);
                if (!orderExists)
                {
                    return NotFound(ipNXApiResponse.Failure("Order Not found"));
                }
                if (order.CreatedById != userId)
                {
                    return Unauthorized(ipNXApiResponse.Failure("You are not authorized to make this wifi request"));
                }
                await _orderService.MarkWifiRequestAsTrueOrFalseAsync(order, activate);
                return Ok(ipNXApiResponse.Success("wifi status was changed successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to change wifi status");
                return BadRequest(ipNXApiResponse.Failure("An error occurred while trying to change wifi status"));
            }

        }





    }
    

}
