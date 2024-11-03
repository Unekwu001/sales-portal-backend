using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos
{
    public class ViewAllSmeOrdersDto
    {
        public string Image {  get; set; }
        public string Name { get; set; }
        public string DateOrdered { get; set; }
        public string Amount { get; set; }
        public string OrderId { get; set; }
        public OrderStatusEnum Status { get; set; }
    }
}
