using Data.Models.OrderModels;
using Data.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.AgentModel
{
    public class Agent : UserTracking
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string? Type { get; set; }
        public string? Address { get; set; }
        public ICollection<SmeOrder> SmeOrders { get; set; }
        public ICollection<ResidentialOrder> ResidentialOrders { get; set; }

    }
}
