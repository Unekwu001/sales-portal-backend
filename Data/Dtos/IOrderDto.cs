using Data.Enums;
using Data.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos
{
    public interface IOrderDto
    {
        string Id { get; set; } 
        OrderStatusEnum PaymentStatus { get; set; }
        DateTime LastUpdatedOnUtc { get; set; }
        string PaymentReferenceNumber { get; set; }
        bool IsFormCompleted { get; set; }
        Guid CreatedById { get; set; }
        bool HasRequestedInstallation { get; set; }
        bool HasRequestedToAddWifi { get; set; }
        string? AgentId { get; set; }
    }

}
