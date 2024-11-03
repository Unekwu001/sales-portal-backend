using Data.Models.PlanModels;
using Data.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Models.DiscountModel
{
    public class Discount : UserTracking
    {
        public Guid Id { get; set; }
        public IList<string> States {  get; set; } = new List<string>();
        public IList<string> Cities { get; set; } = new List<string>();
        public IList<string> Streets { get; set; } = new List<string>();

        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateTime? StartDate { get; set; }

        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateTime? EndDate { get; set; }
        public decimal Percentage { get; set; }
        public IList<Guid>? PlanTypeIds { get; set; }  //Here
        public virtual ICollection<PlanType> PlanTypes { get; set; }

    }
}
