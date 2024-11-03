
using Data.Models.CoverageModels;

namespace Core.CoverageServices
{
    public interface ICoverageService
    {
        Task<IEnumerable<CoverageLocation>> GetAllCoverageLocationsAsync();
        Task<bool> IsInCoverageAreaAsync(double latitude, double longitude);
        IQueryable<string> GetAllCoverageLocationStatesAsync();
        IQueryable<string> GetAllCoverageLocationLgasAsync(List<string> states);
        IQueryable<string> GetAllCoverageLocationStreetsAsync(List<string> lgas);

    }
}
