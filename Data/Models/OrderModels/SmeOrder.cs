using Data.Dtos;
using Data.Enums;
using Data.Models.PlanModels;
using Data.Models.UserModels;
using Data.Utility;
using API.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Models.AgentModel;
using Data.Models.DiscountModel;

namespace Data.Models.OrderModels
{
    public class SmeOrder : UserTracking, IOrderDto
    {
        public string Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactPersonFirstName { get; set; }
        public string ContactPersonLastName { get; set; }
        public string ContactPersonEmail { get; set; }
        public string networkCoverageAddress { get; set; }

        [NotMapped]
        public string Password { get; set; }
        public string? TypeOfBusiness { get; set; }
        public string? ContactPersonPhoneNumber { get; set; }
        public string? ContactPersonAlternativePhoneNumber { get; set; }
        public string? CompanyStreetName { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public TypeOfBuildingSmeEnum? TypeOfBuilding { get; set; }
        public bool IsBillingAddressSameAsResidentialAddress { get; set; }

        [RequiredIfBillingIsNotSameAsSme]
        public SmeOrderBillingDetail? SmeBillingDetails { get; set; }
        public string? PassportPhotograph { get; set; }
        public string? LetterOfIntroduction { get; set; }
        public string? GovernmentId { get; set; }
        public string? UtilityBill { get; set; }
        public string? CertificateOfIncorporation { get; set; }
        public Guid PlanTypeId { get; set; }
        public bool IsFormCompleted { get; set; } = false;
        public OrderStatusEnum PaymentStatus { get; set; } = OrderStatusEnum.Pending;
        public string? PaymentReferenceNumber { get; set; }
        public bool HasRequestedInstallation { get; set; } = false;
        public bool HasRequestedToAddWifi { get; set; } = false;
        public string? AgentId { get; set; }
        public int? NumberOfMonthsPaidFor { get; set; }
        public decimal? SetUpCharge { get; set; }
        public decimal? TotalCostOfPlanType { get; set; }
        public decimal? TotalPaymentExpected { get; set; }
        public bool? IsSavedAndReadyForPayment { get; set; }
        public decimal? Discount { get; set; }
        public virtual PlanType PlanType { get; set; }
        public virtual Agent Agent { get; set; }
    }

}
