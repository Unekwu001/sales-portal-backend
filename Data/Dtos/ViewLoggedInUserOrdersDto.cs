using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos
{
    public class ViewLoggedInUserOrdersDto
    {
        public string Id { get; set; }
        public string NetworkCoverageLocationName { get; set; }
        public string Status { get; set; }
        public string Abbreviation { get; set; }
        public string OrderType { get; set; }
        public bool HasScheduledInstallation { get; set; }
        public bool AreDocumentsComplete { get; set; } 
    }
}
