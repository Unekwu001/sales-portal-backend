using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos
{
    public class AddOrderDto
    {
        public Guid PlanTypeId { get; set; }
        public OrderStatusEnum StatusEnum { get; set; } 
    }
}
