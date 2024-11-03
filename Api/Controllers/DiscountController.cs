using Asp.Versioning;
using AutoMapper;
using Core.PlanServices;
using Data.Dtos;
using Data.Models.DiscountModel;
using Data.Models.PlanModels;
using API.Data.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.DiscountServices;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPlanService _planService;
        private readonly IDiscountService _discountService;
        private readonly ILogger<DiscountController> _logger;

        public DiscountController(IMapper mapper, IPlanService planService, IDiscountService discountService, ILogger<DiscountController> logger)
        {
            _mapper = mapper;
            _planService = planService;
            _discountService = discountService;
            _logger = logger;
        }

        [Authorize]
        [HttpPost("admin/add-a-discount")]
        public async Task<IActionResult> AddDiscount([FromBody] DiscountDto discountDto) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ipNXApiResponse.Failure("Invalid data"));
            }

            try
            {
                var userIdFromClaims = User.Claims.FirstOrDefault()?.Value;
                var userId = new Guid(userIdFromClaims);

                // Check if all provided PlanTypeIds exist
                var planTypes = new List<PlanType>();
                var planTypeIds = new List<Guid>();
                foreach (var id in discountDto.PlanTypeIds)
                {
                    var existingPlanType = await _planService.GetPlanTypeByIdAsync(id);
                    if (existingPlanType == null)
                    {
                        return NotFound(ipNXApiResponse.Failure($"Plan type with Id {id} was not found."));
                    }
                    planTypeIds.Add(id);
                }

                //var streetNameExists = await _discountService.StreetNameExistsAsync(discountDto.States,discountDto.Streets);
                //if (streetNameExists)
                //{
                //    return Conflict(ipNXApiResponse.Failure("A discount already exists for this street"));
                //}
                await _discountService.AddAndSaveDiscountAsync(discountDto, userId, planTypeIds);

                return Ok(ipNXApiResponse.Success("Discount has been added successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to add a discount");
                return BadRequest(ipNXApiResponse.Failure("An error occurred while trying to add a discount"));
            }
        }


        [Authorize]
        [HttpGet("view-all-discounts")]
        public async Task<IActionResult> ViewAllDiscounts()
        {
            try
            {
                var results = await _discountService.GetAllDiscountsAsync();
                return Ok(results);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to retrieve all discounts");
                return BadRequest(ipNXApiResponse.Failure("An error occurred while trying to retrieve all discounts"));
            }
        }

        [Authorize]
        [HttpGet("view-all-active-discounts")]
        public async Task<IActionResult> ViewAllActiveDiscounts()
        {
            try
            {
                var results = await _discountService.GetAllActiveDiscountsAsync();
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to retrieve all active discounts");
                return BadRequest(ipNXApiResponse.Failure("An error occurred while trying to retrieve all active discounts"));
            }
        }


        [Authorize]
        [HttpDelete("delete-discount")]
        public async Task<IActionResult> DeleteDiscount(Guid discountId)
        {
            try
            {
                await _discountService.DeleteDiscountsAsync(discountId);
                return Ok(ipNXApiResponse.Success("discount deleted successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to delete discounts");
                return BadRequest(ipNXApiResponse.Failure("An error occurred while trying to delete discounts"));
            }
        }


        [Authorize]
        [HttpPut("update-discount")]
        public async Task<IActionResult> UpdateDiscount(Guid discountId, UpdateDiscountDto updateDiscountDto)
        {
            try
            {
                
                var userIdFromClaims = User.Claims.FirstOrDefault()?.Value;
                var userId = new Guid(userIdFromClaims);
                await _discountService.UpdateDiscountsAsync(discountId, updateDiscountDto, userId);
                return Ok(ipNXApiResponse.Success("discount updated successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to update discounts");
                return BadRequest(ipNXApiResponse.Failure("An error occurred while trying to update discounts"));
            }
        }


        [Authorize]
        [HttpPut("deactivate-or-activate-discount")]
        public async Task<IActionResult> ToggleDiscountStatus(Guid discountId, bool activate)
        {
            try
            {

                var userIdFromClaims = User.Claims.FirstOrDefault()?.Value;
                var userId = new Guid(userIdFromClaims);
                await _discountService.ToggleDiscountStatusAsync(discountId,activate);
                return Ok(ipNXApiResponse.Success("discount status was successfully changed"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to change discount status");
                return BadRequest(ipNXApiResponse.Failure("An error occurred while trying to change discount status"));
            }
        }




    }
}
