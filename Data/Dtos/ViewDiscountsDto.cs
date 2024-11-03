using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos
{
    public class ViewDiscountsDto
    {
        public Guid Id { get; set; }
        public ICollection<Guid>? PlanTypeIds { get; set; }
        public List<string> States { get; set; } = new List<string>();
        public List<string> Cities { get; set; } = new List<string>();
        public List<string> Streets { get; set; } = new List<string>();
        public decimal Percentage { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<PlanTypeDetailDto> PlanTypeDetails { get; set; } // List of plan type names
        public string DiscountStatus { get; set; }
        public DateTime Date { get; set; }
    }
}
