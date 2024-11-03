using Data.Models.UserModels;
using API.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Models.DiscountModel;

namespace Data.Models.PlanModels
{
    public class PlanType : UserTracking
    {
        public Guid Id { get; set; }
        public string PlanTypeName { get; set; }
        public decimal Price { get; set; }

        [NotMapped]
        public string? PriceInWords { get { return Price.ToString("N0"); } }
        public BillingCycleEnum PaymentCycle { get; set; }
        public int BandSpeedValue { get; set; }
        public string BandSpeedUnit { get; set; }

        [NotMapped]
        public string? BandSpeed { get { return $"{BandSpeedValue.ToString()} {BandSpeedUnit}"; } }
        public decimal SetUpCharge { get; set; }
        public string KeyFeature1 { get; set; }
        public string KeyFeature2 { get; set;}
        public string KeyFeature3 { get; set;}
        public string? DataAllowance { get; set;}
        public Guid? DiscountId { get; set; } // Nullable to allow PlanTypes without discounts
        [NotMapped]
        public string? SetUpChargeInWords { get { return $"{SetUpCharge.ToString("N0")}"; } }

        public Guid PlanId { get; set; }
        public virtual Plan Plan { get; set; }
        public virtual Discount Discount { get; set; }
    }
}
