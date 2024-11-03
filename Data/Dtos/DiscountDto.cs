using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Dtos
{
    public class DiscountDto : UpdateDiscountDto
    {
     
    }
    public class UpdateDiscountDto
    {
        public ICollection<string> States { get; set; }
        public ICollection<string> Cities { get; set; }
        public ICollection<string> Streets { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Percentage { get; set; }
        public IList<Guid> PlanTypeIds { get; set; }
    }
}
