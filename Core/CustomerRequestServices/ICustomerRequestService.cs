using Data.Models.CustomerRequestsModels;

namespace Core.CustomerRequestServices
{
    public interface ICustomerRequestService
    {
        Task SaveInstallationRequestAsync(RequestForInstallation requestForInstallation);
        Task SaveCallBackRequestAsync(RequestCallBack requestCallBack);
    }
}
