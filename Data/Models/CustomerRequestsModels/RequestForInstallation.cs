using Data.Models.UserModels;

namespace Data.Models.CustomerRequestsModels
{
    public class RequestForInstallation : UserTracking
    {
        public Guid Id { get; set; }
        private DateTime _installationDate;
        public DateTime InstallationDate
        {
            get => _installationDate;
            set => _installationDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }
        public string OrderId { get; set; }
    }
}
