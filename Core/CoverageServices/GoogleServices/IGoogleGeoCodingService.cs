using API.Data.Dtos;
namespace Core.CoverageServices.GoogleServices
{
    public interface IGoogleGeoCodingService
    {
        Task<LatitudeAndLongitudeDto> GetCoordinatesAsync(string location);
        Task<IEnumerable<string>> GetSuggestionsFromGooglePlacesAsync(string userInput);
    }
}
