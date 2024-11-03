using Data.Dtos;
using Data.ipNXContext;
using Data.Models.OrderModels;
namespace Core.OrderServices
{
    public interface IOrderService
    {
        string GenerateOrderId();
        //Task<IEnumerable<ViewAllCustomerOrdersDto>> ViewAllCustomerOrdersAsync();
        Task<PaginatedList<ViewAllCustomerOrdersDto>> ViewAllCustomerOrdersAsync(int pageNumber, int pageSize);
        Task<ViewCustomerOrderByIdDto> GetOrderDetailsByIdAsync(string orderId);
        Task AddResidentialOrderAndSaveChangesAsync(ResidentialOrder residential);
        Task AddResidentialOrderBillingDetailsAndSaveAsync(ResidentialOrderBillingDetail residentialBillingDetail);
        Task<ResidentialOrderBillingDetail> ResidentialOrderBillingDetailsExistAsync(string residentialOrderId);
        Task<SmeOrderBillingDetail> SmeOrderBillingDetailsExistAsync(string smeOrderId);
        Task<ResidentialOrder> GetResidentialOrderByIdAsync(string orderId);
        Task<SmeOrder> GetSmeOrderByIdAsync(string orderId);
        Task<ResidentialOrderBillingDetail> GetResidentialOrderBillingDetailByEmailAsync(string billingEmail);
        Task AddSmeOrderAndSaveChangesAsync(SmeOrder sme);
        Task<SmeOrder> GetSmeOrderByEmailAsync(string smeEmail);
        Task AddSmeOrderBillingDetailsAndSaveChangesAsync(SmeOrderBillingDetail smeBillingDetail);
        Task<bool> NetworkCoverageAddressNameExistsForResidentialAsync(Guid userId, string networkCoverageAddress, Guid planTypeId, string email);
        Task<bool> NetworkCoverageAddressNameExistsForSmeAsync(Guid userId, string networkCoverageAddress, Guid planTypeId, string CompanyName);
        Task<bool> OrderPaymentIsConfirmedAsync(IOrderDto order, string paymentReferenceNumber);
        Task<(bool Exists, IOrderDto Order)> OrderExistAsync(string orderId);
        Task<IEnumerable<ViewLoggedInUserOrdersDto>> GetMyOrdersAsync(Guid loggedInUserId);
        IpNxDbContext OrderContext();
        Task SaveChangesAsync();
        Task<ViewOrderByIdDto> GetOrderByIdAsync(string orderId);
        Task MarkInstallationStatusAsTrueAsync(IOrderDto order);
        Task MarkWifiRequestAsTrueOrFalseAsync(IOrderDto order, bool activate);
        Task AttachAgentToOrderAsync(IOrderDto order, string agentId);
        Task ApproveOrderForPayment(ApproveForPaymentDto approveForPaymentDto);
        Task<(bool? IsReadyForPayment, OrderIsReadyForPayment Order)> IsOrderReadyForPayment(string orderId);
    }
}
