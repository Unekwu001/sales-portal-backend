using Data.Dtos;
using Data.Enums;
using Data.ipNXContext;
using Data.Models.DiscountModel;
using Data.Models.OrderModels;
using Data.Models.PlanModels;
using Data.Utility;
using GoogleApi.Entities.Search.Video.Common.Enums;
using Hangfire.Server;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace Core.OrderServices
{
    public class OrderService : IOrderService
    {

        private readonly IpNxDbContext _ipnxDbContext;
        private static readonly Random _random = new Random();
        private static int _orderCounter = 0;
        private readonly IHttpClientFactory _httpClientFactory;


        public OrderService(IpNxDbContext ipnxDbContext, IHttpClientFactory httpClientFactory)
        {
            _ipnxDbContext = ipnxDbContext;
            _httpClientFactory = httpClientFactory;
        }

        public IpNxDbContext OrderContext()
        {
            return _ipnxDbContext;
        }
        public string GenerateOrderId()
        {
            string newOrderId;
            do
            {
                newOrderId = $"ipNX{_random.Next(100000, 999999):D6}";
            }
            while (_ipnxDbContext.SmeOrders.Any(o => o.Id == newOrderId) && _ipnxDbContext.ResidentialOrders.Any(o => o.Id == newOrderId));

            return newOrderId;
        }



        public async Task<PaginatedList<ViewAllCustomerOrdersDto>> ViewAllCustomerOrdersAsync(int pageNumber, int pageSize)
        {
            // Fetch Residential Orders

            var residentialOrders = await (from ro in _ipnxDbContext.ResidentialOrders
                                           join a in _ipnxDbContext.Agents on ro.AgentId equals a.Id into agentGroup
                                           from a in agentGroup.DefaultIfEmpty() // Left join
                                           select new ViewAllCustomerOrdersDto
                                           {
                                               OrderId = ro.Id,
                                               Name = $"{ro.FirstName} {ro.LastName}",
                                               Image = ro.PassportPhotograph,
                                               DateOrdered = ro.CreatedOnUtc,
                                               Amount = ro.PlanType.Price.ToString("N0"),
                                               PaymentStatus = ro.PaymentStatus,
                                               AllDocumentsAreUploaded = !string.IsNullOrEmpty(ro.GovernmentId) && !string.IsNullOrEmpty(ro.PassportPhotograph) && !string.IsNullOrEmpty(ro.UtilityBill),
                                               OrderType = "Residential",
                                               HasRequestedInstallation = ro.HasRequestedInstallation,
                                               FormIsSavedAndReadyForPayment = ro.IsSavedAndReadyForPayment,
                                               WhoReferredYou = a != null ? a.Name : null,
                                               PhoneNumber = ro.PhoneNumber,
                                           }).ToListAsync();
           
            // Fetch SME Orders with Agent Name
            var smeOrders = await (from so in _ipnxDbContext.SmeOrders
                                   join a in _ipnxDbContext.Agents on so.AgentId equals a.Id into agentGroup
                                   from a in agentGroup.DefaultIfEmpty() // Left join
                                   select new ViewAllCustomerOrdersDto
                                   {
                                       OrderId = so.Id,
                                       Name = so.CompanyName,
                                       Image = so.PassportPhotograph,
                                       DateOrdered = so.CreatedOnUtc,
                                       Amount = so.PlanType.Price.ToString("N0"),
                                       PaymentStatus = so.PaymentStatus,
                                       AllDocumentsAreUploaded = !string.IsNullOrEmpty(so.GovernmentId) &&
                                                                !string.IsNullOrEmpty(so.PassportPhotograph) &&
                                                                !string.IsNullOrEmpty(so.UtilityBill) &&
                                                                !string.IsNullOrEmpty(so.LetterOfIntroduction) &&
                                                                !string.IsNullOrEmpty(so.CertificateOfIncorporation),
                                       OrderType = "SME",
                                       HasRequestedInstallation = so.HasRequestedInstallation,
                                       FormIsSavedAndReadyForPayment = so.IsSavedAndReadyForPayment,
                                       WhoReferredYou = a != null ? a.Name : null,
                                       PhoneNumber = so.ContactPersonPhoneNumber
                                   }).ToListAsync();

            // Combine and order the lists
            var allCustomerOrders = residentialOrders
                .Union(smeOrders)
                .OrderByDescending(c => c.DateOrdered)
                .ToList();

            // Get the total count before pagination
            var totalCount = allCustomerOrders.Count();

            // Apply pagination
            var paginatedOrders = allCustomerOrders
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(order => new ViewAllCustomerOrdersDto
                {
                    OrderId = order.OrderId,
                    Name = order.Name,
                    Image = order.Image,
                    DateOrdered = order.DateOrdered,
                    Amount = $"₦{order.Amount}",
                    PaymentStatus = order.PaymentStatus,
                    AllDocumentsAreUploaded = order.AllDocumentsAreUploaded,
                    OrderType = order.OrderType,
                    HasRequestedInstallation = order.HasRequestedInstallation,
                    FormIsSavedAndReadyForPayment = order.FormIsSavedAndReadyForPayment,
                    WhoReferredYou = order.WhoReferredYou,
                    PhoneNumber = order.PhoneNumber
                })
                .ToList();

            // Return paginated list
            return new PaginatedList<ViewAllCustomerOrdersDto>(paginatedOrders, totalCount, pageNumber, pageSize);
        }








        public async Task<ViewCustomerOrderByIdDto> GetOrderDetailsByIdAsync(string orderId) //for admin page
        {
            var residentialOrder = await _ipnxDbContext.ResidentialOrders.FirstOrDefaultAsync(o => o.Id == orderId);

            if (residentialOrder != null)
            {
                var plantypeId = residentialOrder.PlanTypeId;
                var planType = await _ipnxDbContext.PlanTypes.FirstOrDefaultAsync(pt => pt.Id == plantypeId);
                var plan = await _ipnxDbContext.Plans.FirstOrDefaultAsync(p => p.Id == planType.PlanId);
                var agent = await _ipnxDbContext.Agents.FirstOrDefaultAsync(o => o.Id == residentialOrder.AgentId);

                return new ViewCustomerOrderByIdDto
                {
                    CustomerType = "residential",
                    OrderReferenceNumber = residentialOrder.Id.ToString(),
                    PaymentReferenceNumber = residentialOrder.PaymentReferenceNumber,
                    OrderDateAndTime = DateFormater.FormatDateTime(residentialOrder.LastUpdatedOnUtc),
                    PlanName = plan.PlanName,
                    TermsAndConditions = "I Agree",
                    PlanTypeName = planType.PlanTypeName,
                    Price = $"₦{planType.Price.ToString("N0")}",
                    PlanModemAndInstallationAmount = $"₦{(planType.Price + planType.SetUpCharge).ToString("N0")}",
                    WhoReferredYou = agent?.Type ?? "null",
                    SalesAgentName =agent?.Name ?? "null",
                    CustomerName = $"{residentialOrder.FirstName} {residentialOrder.LastName}",
                    Gender = residentialOrder.Gender,
                    DateOfBirth = residentialOrder.DateOfBirth.ToString(),
                    Occupation = residentialOrder.Occupation,
                    Email = residentialOrder.Email,
                    PhoneNumber = residentialOrder.PhoneNumber,
                    Address = residentialOrder.networkCoverageAddress,
                    TypeOfBuilding = residentialOrder.TypeOfBuilding.ToString(),
                    BillingInformation = "Same as residential address",
                    Photograph = residentialOrder.PassportPhotograph,
                    GovernmentID = residentialOrder.GovernmentId,
                    UtilityBill = residentialOrder.UtilityBill,
                    PersonalDataConsent = "I give my consent",
                    PrivacyPolicy = "I agree",
                    NumberOfMonthsPaidFor = residentialOrder.NumberOfMonthsPaidFor
                };

            }

            var smeOrder = await _ipnxDbContext.SmeOrders.FirstOrDefaultAsync(o => o.Id == orderId);
            if (smeOrder != null)
            {
                var plantypeId = smeOrder.PlanTypeId;
                var planType = await _ipnxDbContext.PlanTypes.FirstOrDefaultAsync(pt => pt.Id == plantypeId);
                var plan = await _ipnxDbContext.Plans.FirstOrDefaultAsync(p => p.Id == planType.PlanId);
                var agent = await _ipnxDbContext.Agents.FirstOrDefaultAsync(o => o.Id == smeOrder.AgentId);

                return new ViewCustomerOrderByIdDto
                {
                    CustomerType = "sme",
                    OrderReferenceNumber = smeOrder.Id.ToString(),
                    PaymentReferenceNumber = smeOrder.PaymentReferenceNumber,
                    OrderDateAndTime = DateFormater.FormatDateTime(smeOrder.LastUpdatedOnUtc),
                    PlanName = plan.PlanName,
                    TermsAndConditions = "I Agree",
                    PlanTypeName = planType.PlanTypeName,
                    Price = $"₦{planType.Price.ToString("N0")}",
                    PlanModemAndInstallationAmount = $"₦{(planType.Price + planType.SetUpCharge).ToString("N0")}",
                    NumberOfMonthsPaidFor = smeOrder.NumberOfMonthsPaidFor, 
                    WhoReferredYou = agent?.Type ?? "null",
                    SalesAgentName = agent?.Name ?? "null",
                    CustomerName = $"{smeOrder.CompanyName}",
                    Email = smeOrder.ContactPersonEmail,
                    PhoneNumber = smeOrder.ContactPersonPhoneNumber,
                    Address = smeOrder.networkCoverageAddress,
                    TypeOfBuilding = smeOrder.TypeOfBuilding.ToString(),
                    BillingInformation = "",
                    Photograph = smeOrder.PassportPhotograph,
                    GovernmentID = smeOrder.GovernmentId,
                    CertificateOfIncorporation = smeOrder.CertificateOfIncorporation,
                    LetterOfIntroduction = smeOrder.LetterOfIntroduction,
                    UtilityBill = smeOrder.UtilityBill,
                    TypeOfBusiness = smeOrder.TypeOfBusiness,
                    PersonalDataConsent = "I give my consent",
                    PrivacyPolicy = "I agree"
                };
            }
            return null;
        }



        public async Task<ViewOrderByIdDto> GetOrderByIdAsync(string orderId) //for user ui
        {
            var residentialOrder = await _ipnxDbContext.ResidentialOrders.FirstOrDefaultAsync(o => o.Id == orderId);
            

            if (residentialOrder != null)
            {
                var residentialBillingDetails = await _ipnxDbContext.ResidentialOrderBillingDetails.FirstOrDefaultAsync(o => o.ResidentialId == residentialOrder.Id);
                var planType = await _ipnxDbContext.PlanTypes.FirstOrDefaultAsync(o => o.Id == residentialOrder.PlanTypeId);
                var agent = await _ipnxDbContext.Agents.FirstOrDefaultAsync(o => o.Id == residentialOrder.AgentId);
                return new ViewOrderByIdDto
                {
                    Id = residentialOrder.Id,
                    FirstName = residentialOrder.FirstName,
                    LastName = residentialOrder.LastName,
                    Email = residentialOrder.Email,
                    networkCoverageAddress = residentialOrder.networkCoverageAddress,
                    PhoneNumber = residentialOrder.PhoneNumber,
                    AlternativePhoneNumber = residentialOrder.AlternativePhoneNumber,
                    Occupation = residentialOrder.Occupation,
                    Gender = residentialOrder.Gender,
                    Nationality = residentialOrder.Nationality,
                    DateOfBirth = residentialOrder.DateOfBirth,
                    FlatNumber = residentialOrder.FlatNumber,
                    HouseNumber = residentialOrder.HouseNumber,
                    StreetName = residentialOrder.StreetName,
                    EstateName = residentialOrder.EstateName,
                    City = residentialOrder.City,
                    State = residentialOrder.State,
                    TypeOfBuilding = residentialOrder.TypeOfBuilding.ToString(),
                    IsBillingAddressSameAsResidentialAddress = residentialOrder.IsBillingAddressSameAsResidentialAddress,
                    PassportPhotograph = residentialOrder.PassportPhotograph,
                    GovernmentId = residentialOrder.GovernmentId,
                    UtilityBill = residentialOrder.UtilityBill,
                    PlanTypeId = residentialOrder.PlanTypeId,
                    PlanId = planType.PlanId,
                    IsFormCompleted = residentialOrder.IsFormCompleted,
                    HasRequestedInstallation = residentialOrder.HasRequestedInstallation,
                    HasRequestedToAddWifi = residentialOrder.HasRequestedToAddWifi,
                    AgentName = agent?.Name ?? "N/A",
                    PaymentStatus = residentialOrder.PaymentStatus,
                    PaymentReferenceNumber = residentialOrder.PaymentReferenceNumber,
                    Discount = residentialOrder.Discount,
                    ResidentialBillingDetails = new ResidentialOrderBillingDetail
                    {
                        FirstName = residentialBillingDetails.FirstName,
                        LastName = residentialBillingDetails.LastName,
                        State = residentialBillingDetails.State,
                        City = residentialBillingDetails.City,
                        Email = residentialBillingDetails.Email,
                        PhoneNumber = residentialBillingDetails.PhoneNumber,
                        StreetName = residentialBillingDetails.StreetName
                    }
                };
            };

            var smeOrder = await _ipnxDbContext.SmeOrders.FirstOrDefaultAsync(o => o.Id == orderId);
            if (smeOrder != null)
            {
                var smeBillingDetails = await _ipnxDbContext.SmeOrderBillingDetails.FirstOrDefaultAsync(o => o.SmeId == smeOrder.Id);
                var planType = await _ipnxDbContext.PlanTypes.FirstOrDefaultAsync(o => o.Id == smeOrder.PlanTypeId);
                var agent = await _ipnxDbContext.Agents.FirstOrDefaultAsync(o => o.Id == smeOrder.AgentId);
                return new ViewOrderByIdDto
                {
                    Id = smeOrder.Id,
                    CompanyName = smeOrder.CompanyName,
                    ContactPersonFirstName = smeOrder.ContactPersonFirstName,
                    ContactPersonLastName = smeOrder.ContactPersonLastName,
                    ContactPersonEmail = smeOrder.ContactPersonEmail,
                    ContactPersonPhoneNumber = smeOrder.ContactPersonPhoneNumber,
                    ContactPersonAlternativePhoneNumber = smeOrder.ContactPersonAlternativePhoneNumber,
                    State = smeOrder.State,
                    CompanyStreetName = smeOrder.CompanyStreetName,
                    City = smeOrder.City,
                    networkCoverageAddress = smeOrder.networkCoverageAddress,
                    TypeOfBusiness = smeOrder.TypeOfBusiness,
                    TypeOfBuilding = smeOrder.TypeOfBuilding.ToString(),
                    IsBillingAddressSameAsResidentialAddress = smeOrder.IsBillingAddressSameAsResidentialAddress,
                    CertificateOfIncorporation = smeOrder.CertificateOfIncorporation,
                    PassportPhotograph = smeOrder.PassportPhotograph,
                    LetterOfIntroduction = smeOrder.LetterOfIntroduction,
                    GovernmentId = smeOrder.GovernmentId,
                    UtilityBill = smeOrder.UtilityBill,
                    IsFormCompleted = smeOrder.IsFormCompleted,
                    HasRequestedInstallation = smeOrder.HasRequestedInstallation,
                    HasRequestedToAddWifi = smeOrder.HasRequestedToAddWifi,
                    AgentName =  agent?.Name ?? "N/A",
                    PlanTypeId = smeOrder.PlanTypeId,
                    PlanId = planType.PlanId,
                    PaymentStatus = smeOrder.PaymentStatus,
                    PaymentReferenceNumber = smeOrder.PaymentReferenceNumber,
                    Discount = smeOrder.Discount,
                    SmeBillingDetails = new SmeOrderBillingDetail
                    {
                        ContactPersonFirstName = smeBillingDetails.ContactPersonFirstName,
                        ContactPersonLastName = smeBillingDetails.ContactPersonLastName,
                        ContactPersonPhoneNumber = smeBillingDetails.ContactPersonPhoneNumber,
                        ContactPersonEmail = smeBillingDetails.ContactPersonEmail,
                        CompanyStreetName = smeBillingDetails.CompanyStreetName,
                        City = smeBillingDetails.City,
                        State = smeBillingDetails.State,
                    }
                };

            };
            return null;
        }


 
        public async Task AddResidentialOrderAndSaveChangesAsync(ResidentialOrder residential)
        {
            await _ipnxDbContext.ResidentialOrders.AddAsync(residential);
            await _ipnxDbContext.SaveChangesAsync();
        }


        public async Task<ResidentialOrderBillingDetail> ResidentialOrderBillingDetailsExistAsync(string residentialOrderId)
        {
            return await _ipnxDbContext.ResidentialOrderBillingDetails.FirstOrDefaultAsync(c => c.ResidentialId == residentialOrderId);
        }

        public async Task<SmeOrderBillingDetail> SmeOrderBillingDetailsExistAsync(string smeOrderId)
        {
            return await _ipnxDbContext.SmeOrderBillingDetails.FirstOrDefaultAsync(c => c.SmeId == smeOrderId);
        }

        public async Task AddResidentialOrderBillingDetailsAndSaveAsync(ResidentialOrderBillingDetail residentialBillingDetail)
        {
            await _ipnxDbContext.ResidentialOrderBillingDetails.AddAsync(residentialBillingDetail);
            await _ipnxDbContext.SaveChangesAsync();
        }



        public async Task<ResidentialOrder> GetResidentialOrderByIdAsync(string orderId)
        {
            return await _ipnxDbContext.ResidentialOrders.FindAsync(orderId);
        }

        public async Task<SmeOrder> GetSmeOrderByIdAsync(string orderId)
        {
            return await _ipnxDbContext.SmeOrders.FindAsync(orderId);
        }



        public async Task<ResidentialOrderBillingDetail> GetResidentialOrderBillingDetailByEmailAsync(string billingEmail)
        {
            return await _ipnxDbContext.ResidentialOrderBillingDetails.FirstOrDefaultAsync(x => x.Email == billingEmail);
        }




        public async Task AddSmeOrderAndSaveChangesAsync(SmeOrder sme)
        {
            await _ipnxDbContext.SmeOrders.AddAsync(sme);
            await _ipnxDbContext.SaveChangesAsync();
        }



        public async Task<SmeOrder> GetSmeOrderByEmailAsync(string smeEmail)
        {
            return await _ipnxDbContext.SmeOrders.FirstOrDefaultAsync(x => x.ContactPersonEmail == smeEmail);
        }



        public async Task AddSmeOrderBillingDetailsAndSaveChangesAsync(SmeOrderBillingDetail smeBillingDetail)
        {
            await _ipnxDbContext.SmeOrderBillingDetails.AddAsync(smeBillingDetail);
            await _ipnxDbContext.SaveChangesAsync();
        }


        public async Task<bool> NetworkCoverageAddressNameExistsForResidentialAsync(Guid userId, string networkCoverageAddress, Guid planTypeId, string email)
        {
            var existingNetworkCoverageAddressRecord = await _ipnxDbContext.ResidentialOrders
                .AnyAsync(r => r.CreatedById == userId && r.networkCoverageAddress.Contains(networkCoverageAddress)
                && r.PlanTypeId == planTypeId && r.Email == email && r.IsFormCompleted == false);

            if (existingNetworkCoverageAddressRecord)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> NetworkCoverageAddressNameExistsForSmeAsync(Guid userId, string networkCoverageAddress, Guid planTypeId, string CompanyName)
        {
            var existingNetworkCoverageAddressRecord = await _ipnxDbContext.SmeOrders
                .AnyAsync(r => r.CreatedById == userId && r.networkCoverageAddress.Contains(networkCoverageAddress)
                && r.PlanTypeId == planTypeId && r.CompanyName == CompanyName && r.IsFormCompleted == false);

            if (existingNetworkCoverageAddressRecord)
            {
                return true;
            }
            return false;
        }







        public async Task<bool> OrderPaymentIsConfirmedAsync(IOrderDto order, string paymentReferenceNumber)
        {
            var payStackResponse = await VerifyPayStackTransactionAsync(paymentReferenceNumber);

            if (payStackResponse)
            {
                await UpdateOrderStatusAsync(order, OrderStatusEnum.Successful, paymentReferenceNumber,true);
                return true;
            }
            else
            {
                await UpdateOrderStatusAsync(order, OrderStatusEnum.Failed, paymentReferenceNumber, false);
                return false;
            }
        }






        public async Task<(bool Exists, IOrderDto Order)> OrderExistAsync(string orderId)
        {
            var residentialOrder = await _ipnxDbContext.ResidentialOrders.FindAsync(orderId);
            if (residentialOrder != null)
            {
                return (true, residentialOrder);
            }

            var smeOrder = await _ipnxDbContext.SmeOrders.FindAsync(orderId);
            if (smeOrder != null)
            {
                return (true, smeOrder);
            }

            return (false, null);
        }





        public async Task UpdateOrderStatusAsync(IOrderDto order, OrderStatusEnum status, string paymentReferenceNumber, bool IsFormCompleted)
        {
            order.LastUpdatedOnUtc = DateTime.UtcNow;
            order.PaymentStatus = status;
            order.PaymentReferenceNumber = paymentReferenceNumber;
            order.IsFormCompleted = IsFormCompleted;
            await _ipnxDbContext.SaveChangesAsync();
        }






        private async Task<bool> VerifyPayStackTransactionAsync(string reference)
        {
            var secretKey = "sk_test_3acd687e1815c63e9beca72d7bd6a62ae4a1a49b";
            //var secretKey = "sk_live_a7bdc5f3dc05601e5bad18503df043334c14c314";
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://api.paystack.co");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", secretKey);

            HttpResponseMessage response = await client.GetAsync($"/transaction/verify/{reference}");
            response.EnsureSuccessStatusCode();

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }



        public async Task SaveChangesAsync()
        {
            await _ipnxDbContext.SaveChangesAsync();
        }


        public async Task<IEnumerable<ViewLoggedInUserOrdersDto>> GetMyOrdersAsync(Guid loggedInUserId)
        {
            var residentialOrders = await _ipnxDbContext.ResidentialOrders
                .Where(c => c.CreatedById == loggedInUserId)
                .ToListAsync();

            var smeOrders = await _ipnxDbContext.SmeOrders
                .Where(c => c.CreatedById == loggedInUserId)
                .ToListAsync();

            var allOrders = new List<ViewLoggedInUserOrdersDto>();

            allOrders.AddRange(residentialOrders.Select(order => new ViewLoggedInUserOrdersDto
            {
                 Id = order.Id,
                NetworkCoverageLocationName = order.networkCoverageAddress,
                Status = order.IsFormCompleted ? "Completed" : "Ongoing",
                Abbreviation = Abbreviations.GetLocationAbbreviation(order.networkCoverageAddress),
                OrderType = "residential",
                HasScheduledInstallation = order.HasRequestedInstallation,
                AreDocumentsComplete = !string.IsNullOrEmpty(order.GovernmentId) &&
                       !string.IsNullOrEmpty(order.PassportPhotograph) &&
                       !string.IsNullOrEmpty(order.UtilityBill)

            }));

            allOrders.AddRange(smeOrders.Select(order => new ViewLoggedInUserOrdersDto
            {
                Id = order.Id,
                NetworkCoverageLocationName = order.networkCoverageAddress,
                Status = order.IsFormCompleted ? "Completed" : "Ongoing",
                Abbreviation = Abbreviations.GetLocationAbbreviation(order.networkCoverageAddress),
                OrderType = "sme",
                HasScheduledInstallation = order.HasRequestedInstallation,
                AreDocumentsComplete = !string.IsNullOrEmpty(order.GovernmentId) &&
                       !string.IsNullOrEmpty(order.PassportPhotograph) &&
                       !string.IsNullOrEmpty(order.UtilityBill) &&
                       !string.IsNullOrEmpty(order.LetterOfIntroduction) &&
                       !string.IsNullOrEmpty(order.CertificateOfIncorporation)
            }));

            return allOrders;
        }



        public async Task MarkInstallationStatusAsTrueAsync(IOrderDto order)
        {
            order.HasRequestedInstallation = true;
            await SaveChangesAsync();
         
        }

        public async Task MarkWifiRequestAsTrueOrFalseAsync(IOrderDto order, bool activate)
        {
            order.HasRequestedToAddWifi = activate;
            await SaveChangesAsync();

        }

        public async Task AttachAgentToOrderAsync(IOrderDto order, string agentId)
        {
            order.AgentId = agentId;
            await SaveChangesAsync();

        }


        public async Task ApproveOrderForPayment(ApproveForPaymentDto approveForPaymentDto)
        {
            var residentialOrder = await _ipnxDbContext.ResidentialOrders.FindAsync(approveForPaymentDto.OrderId);

            if (residentialOrder != null)
            {
                var plantypeForRes = await _ipnxDbContext.PlanTypes.FindAsync(residentialOrder.PlanTypeId);

                residentialOrder.SetUpCharge = plantypeForRes.SetUpCharge;
                residentialOrder.NumberOfMonthsPaidFor = approveForPaymentDto.NumberOfMonthsPaidFor;
                residentialOrder.TotalCostOfPlanType = (plantypeForRes.Price  * approveForPaymentDto.NumberOfMonthsPaidFor);
                residentialOrder.TotalPaymentExpected = (plantypeForRes.Price * approveForPaymentDto.NumberOfMonthsPaidFor) + plantypeForRes.SetUpCharge;
                residentialOrder.AgentId = approveForPaymentDto?.AgentId;
                residentialOrder.IsSavedAndReadyForPayment = true;

                await _ipnxDbContext.SaveChangesAsync();             
            }
            else
            {
                var smeOrder = await _ipnxDbContext.SmeOrders.FindAsync(approveForPaymentDto.OrderId);
                var plantypeForSme = await _ipnxDbContext.PlanTypes.FindAsync(smeOrder?.PlanTypeId);
                if (smeOrder != null)
                {
                    smeOrder.SetUpCharge = plantypeForSme?.SetUpCharge;
                    smeOrder.NumberOfMonthsPaidFor = approveForPaymentDto.NumberOfMonthsPaidFor;
                    smeOrder.TotalCostOfPlanType = (plantypeForSme?.Price * approveForPaymentDto.NumberOfMonthsPaidFor);
                    smeOrder.TotalPaymentExpected = (plantypeForSme?.Price * approveForPaymentDto.NumberOfMonthsPaidFor) + plantypeForSme?.SetUpCharge;
                    smeOrder.IsSavedAndReadyForPayment = true;
                    smeOrder.AgentId = approveForPaymentDto?.AgentId;

                    await _ipnxDbContext.SaveChangesAsync();
                }
            }
            
        }


        public async Task<(bool? IsReadyForPayment, OrderIsReadyForPayment Order)> IsOrderReadyForPayment(string orderId)
        {
            var residentialOrder = await _ipnxDbContext.ResidentialOrders.FindAsync(orderId);
             
            if (residentialOrder != null)
            {
                var planType = await _ipnxDbContext.PlanTypes.FindAsync(residentialOrder.PlanTypeId);
                var plan = await _ipnxDbContext.Plans.FindAsync(planType.PlanId);
                var agent = await _ipnxDbContext.Agents.FindAsync(residentialOrder.AgentId);
                var resOrder = new OrderIsReadyForPayment
                {
                    OrderId = orderId,
                    IsSavedAndReadyForPayment = residentialOrder.IsSavedAndReadyForPayment,
                    PlanName = plan.PlanName,
                    PlanType = planType.PlanTypeName,
                    CostOfPlanType = planType.Price,
                    NumberOfMonthsPaidFor = residentialOrder.NumberOfMonthsPaidFor,
                    SetUpCharge = residentialOrder.SetUpCharge,
                    Discount = residentialOrder.Discount,
                    TotalPaymentExpected = residentialOrder.TotalPaymentExpected,
                    PaymentStatus = residentialOrder.PaymentStatus,
                    AgentName = agent?.Name ?? "Null",
                    AgentType = agent?.Type ?? "Null"
                };
                if (residentialOrder.IsSavedAndReadyForPayment != null && residentialOrder.IsSavedAndReadyForPayment != false)
                { 
                    return (true, resOrder);
                }
                return (false, resOrder);
            } 
            
            var smeOrder = await _ipnxDbContext.SmeOrders.FindAsync(orderId);
            if (smeOrder != null) 
            {
                var planType = await _ipnxDbContext.PlanTypes.FindAsync(smeOrder.PlanTypeId);
                var plan = await _ipnxDbContext.Plans.FindAsync(planType.PlanId);
                var agent = await _ipnxDbContext.Agents.FindAsync(smeOrder.AgentId);
                if (smeOrder != null)
                {
                    var smOrder = new OrderIsReadyForPayment
                    {
                        OrderId = orderId,
                        IsSavedAndReadyForPayment = smeOrder.IsSavedAndReadyForPayment,
                        PlanName = plan.PlanName,
                        PlanType = planType.PlanTypeName,
                        CostOfPlanType = planType.Price,
                        NumberOfMonthsPaidFor = smeOrder.NumberOfMonthsPaidFor,
                        SetUpCharge = smeOrder.SetUpCharge,
                        Discount = smeOrder.Discount,
                        TotalPaymentExpected = smeOrder.TotalPaymentExpected,
                        PaymentStatus = smeOrder.PaymentStatus,
                        AgentName = agent?.Name ?? "Null",
                        AgentType = agent?.Type ?? "Null"
                    };
                    if (smeOrder.IsSavedAndReadyForPayment != null && smeOrder.IsSavedAndReadyForPayment != false)
                    {
                        return (true, smOrder);
                    }
                    return (false, smOrder);
                }
            }
            return (false, null);
        }


    }
}


