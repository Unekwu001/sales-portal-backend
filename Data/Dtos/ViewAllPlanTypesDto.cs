using API.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos
{
    public class ViewAllPlanTypesDto
    {
        public Guid PlanTypeId { get; set; }
        public string PlanTypeName { get; set; }
        public string IsActive {  get; set; }
        public decimal Price { get; set; }
        public string? PriceInWords { get { return Price.ToString("N0"); } }
        public BillingCycleEnum PaymentCycle { get; set; }
        public int BandSpeedValue { get; set; }
        public string BandSpeedUnit { get; set; }
        public string? BandSpeed { get { return $"{BandSpeedValue.ToString()} {BandSpeedUnit}"; } }
        public decimal SetUpCharge { get; set; }
        public string KeyFeature1 { get; set; }
        public string KeyFeature2 { get; set; }
        public string KeyFeature3 { get; set; }
        public string? DataAllowance { get; set; }

        [NotMapped]
        public string? SetUpChargeInWords { get { return $"{SetUpCharge.ToString("N0")}"; } }
        public string PlanName { get; set; } 

    }
}
