
using API.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data.Dtos
{
    public class ViewPlanTypeDto : PlanTypeDto
    {
        public Guid Id { get; set; }  
        [NotMapped]
        public string? PriceInWords { get { return Price.ToString("N0"); } }

        [NotMapped]
        public string? BandSpeed { get { return $"{BandSpeedValue.ToString()} {BandSpeedUnit}"; } }

        [NotMapped]
        public string? SetUpChargeInWords { get { return $"{SetUpCharge.ToString("N0")}"; } }
    }



    public class PlanTypeDto
    {
        public string PlanTypeName { get; set; }
        public decimal Price { get; set; }       
        public BillingCycleEnum PaymentCycle { get; set; }
        public int BandSpeedValue { get; set; }
        public string BandSpeedUnit { get; set; }      
        public decimal SetUpCharge { get; set; }
        public string KeyFeature1 { get; set; }
        public string KeyFeature2 { get; set; }
        public string KeyFeature3 { get; set; }
        public string? DataAllowance { get; set; }

        [NotMapped]
        public string? SetUpChargeInWords { get { return $"{SetUpCharge.ToString("N0")}"; } }
    }
}
