using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos
{
    public class TopThreeCustomersDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public decimal TotalOrderValue { get; set; }
        public int OrderCount { get; set; }
    }
}
