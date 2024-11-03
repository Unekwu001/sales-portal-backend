using Data.Dtos;
using Data.Models.OrderModels;
using Data.Models.WebsiteVisitModel;

namespace Core.DashBoardServices
{
    public interface IDashBoardService
    {
        Task<int> GetWeeklyResidentialSignUpCountAsync(DateTime startDate, DateTime endDate);
        Task<int> GetWeeklySmeSignUpCountAsync(DateTime startDate, DateTime endDate);
        Task<int> GetWeeklyTotalSignUpCountAsync(DateTime startDate, DateTime endDate);
        Task<decimal> GetMonthlyRevenueAsync(DateTime startDate, DateTime endDate);
        Task<Dictionary<string, decimal>> GetSalesByDayOfWeekAsync(DateTime startDate, DateTime endDate);
        Task<decimal> GetSalesForSpecificDayAsync(DateTime specificDay);
        Task<IEnumerable<WebsiteVisit>> GetVisitsForCurrentWeekAsync();
        Task<Dictionary<string, decimal>> GetSalesByMonthAsync(DateTime startDate, DateTime endDate);
        Task<decimal> GetSalesForSpecificMonthAsync(DateTime specificMonth);
        Task VisitAsync(WebsiteVisit visit);
        Task<IEnumerable<TopThreeCustomersDto>> ViewTopThreeCustomersBySuccessfullyPlacedOrdersAsync();
    }
}
