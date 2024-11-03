using System.ComponentModel.DataAnnotations;

namespace API.Data.Dtos
{
    public class LocationDto
    {
        public string Location { get; set; } = string.Empty;
        //private string? _selectedLocation;

        //[Required(ErrorMessage = "Please type in a location")]
        //[MaxLength(100, ErrorMessage = "Location cannot exceed 100 characters.")]
        //public string? SelectedLocation
        //{
        //    get { return _selectedLocation; }
        //    set { _selectedLocation = value?.Trim(); } // Trim whitespace when setting the value
        //}
    }
}
