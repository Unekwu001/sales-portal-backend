using Data.Enums;
using Data.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos
{
    public class ViewAllCustomerOrdersDto
    {
        public string OrderId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime DateOrdered { get; set; }
        public string FormattedDateOrdered => DateOrdered.ToCustomizedDateString();
        public string Amount { get; set; }
        public OrderStatusEnum PaymentStatus { get; set; }
        public bool AllDocumentsAreUploaded { get; set; }
        public bool HasRequestedInstallation { get; set; }
        public bool? FormIsSavedAndReadyForPayment { get; set; } 
        public string OrderType { get; set; } // To differentiate between SME and Residential
        public string WhoReferredYou { get; set; } 
        public string PhoneNumber { get; set; } 

    }
}
