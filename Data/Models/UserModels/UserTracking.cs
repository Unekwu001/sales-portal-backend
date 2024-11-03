using System.Text.Json.Serialization;

namespace Data.Models.UserModels
{
    public abstract class UserTracking
    {
        [JsonIgnore]
        public Guid CreatedById { get; set; } = Guid.Empty;

        [JsonIgnore]
        public Guid LastUpdatedById { get; set; } = Guid.Empty;

        [JsonIgnore]
        public DateTime CreatedOnUtc { get; set; } = DateTime.UtcNow;

        [JsonIgnore]
        public DateTime LastUpdatedOnUtc { get; set; } = DateTime.UtcNow;

        [JsonIgnore]
        public bool IsActive { get; set; } = false;

    }
}
