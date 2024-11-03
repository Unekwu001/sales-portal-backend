
using Data.ipNXContext;
using Data.Models.CustomerRequestsModels;

namespace Core.CustomerRequestServices
{
    public class CustomerRequestService : ICustomerRequestService
    {

        private readonly IpNxDbContext _ipNXDbContext;

        public CustomerRequestService(IpNxDbContext ipNXDbContext)
        {
            _ipNXDbContext = ipNXDbContext;
        }

        public async Task SaveInstallationRequestAsync(RequestForInstallation requestForInstallation)
        {
            await _ipNXDbContext.InstallationRequests.AddAsync(requestForInstallation);
            await _ipNXDbContext.SaveChangesAsync();
        }

        public async Task SaveCallBackRequestAsync(RequestCallBack requestCallBack)
        {
            await _ipNXDbContext.CallBackRequests.AddAsync(requestCallBack);
            await _ipNXDbContext.SaveChangesAsync();
        }
    }
}
