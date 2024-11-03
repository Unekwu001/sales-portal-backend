using Data.Dtos;
using Data.Enums;
using Data.Models.PlanModels;
using Data.Models.UserModels;
using Data.Utility;
using API.Data.Dtos;
using API.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Data.Models.AgentModel;
using Data.Models.DiscountModel;

namespace Data.Models.OrderModels
{
    public class ResidentialOrder : UserTracking, IOrderDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string networkCoverageAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string? AlternativePhoneNumber { get; set; }
        public string? Occupation { get; set; }
        public GenderEnum? Gender { get; set; }
        public string? Nationality { get; set; }

        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateTime? DateOfBirth { get; set; }
        public string? FlatNumber { get; set; }
        public string? HouseNumber { get; set; }
        public string? StreetName { get; set; }
        public string? EstateName { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public TypeOfBuildingResidentialEnum? TypeOfBuilding { get; set; }
        public bool IsBillingAddressSameAsResidentialAddress { get; set; }

        [RequiredIfBillingIsNotSame]
        public ResidentialOrderBillingDetail? ResidentialBillingDetails { get; set; }
        public string? PassportPhotograph { get; set; }
        public string? GovernmentId { get; set; }
        public string? UtilityBill { get; set; }
        public Guid PlanTypeId { get; set; }
        public bool IsFormCompleted { get; set; } = false;
        public OrderStatusEnum PaymentStatus { get; set; } = OrderStatusEnum.Pending;
        public string? PaymentReferenceNumber { get; set; }
        public bool HasRequestedInstallation { get; set; } = false;
        public bool HasRequestedToAddWifi { get; set; } = false;
        public string? AgentId { get; set; }
        public decimal? Discount { get; set; }
        public int? NumberOfMonthsPaidFor {  get; set; }
        public decimal? SetUpCharge { get; set; }
        public decimal? TotalCostOfPlanType { get; set; }
        public decimal? TotalPaymentExpected { get; set; }
        public bool? IsSavedAndReadyForPayment { get; set; }
        public virtual PlanType PlanType { get; set; }
        public virtual Agent Agent { get; set; }



    }




}
