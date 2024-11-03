
using Data.Models.CoverageModels;
using System.ComponentModel.DataAnnotations;

namespace API.Data.Dtos
{
    public class LatitudeAndLongitudeDto
    {
        [Required(ErrorMessage = "Longitude is required.")]
        //[Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180.")]
        public double UserLongitude { get; set; }

        [Required(ErrorMessage = "Latitude is required.")]
        //[Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90.")]
        public double UserLatitude { get; set; }

        public ICollection<CoverageLocation>? CloseCoverageLocations { get; set; } = null;
    }
}
