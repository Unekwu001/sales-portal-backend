using Asp.Versioning;
using AutoMapper;
using Core.DashBoardServices;
using Core.PlanServices;
using Data.Dtos;
using Data.Models.WebsiteVisitModel;
using API.Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AdminDashBoardStatsController : ControllerBase
    {
        private readonly IDashBoardService _dashboardService;
        private readonly ILogger<AdminDashBoardStatsController> _logger;

        public AdminDashBoardStatsController(IDashBoardService dashboardService, ILogger<AdminDashBoardStatsController> logger)
        {
            _dashboardService = dashboardService;
            _logger = logger;
        }

        [HttpGet("admin/weekly-residential-signups")]
        public async Task<IActionResult> GetWeeklyResidentialSignups()
        {
            return await GetWeeklySignups("Residential");
        }

        [HttpGet("admin/weekly-sme-signups")]
        public async Task<IActionResult> GetWeeklySmeSignups()
        {
            return await GetWeeklySignups("SME");
        }

        [HttpGet("admin/weekly-total-signups")]
        public async Task<IActionResult> GetWeeklyTotalSignups()
        {
            return await GetWeeklySignups("Total");
        }
        private async Task<IActionResult> GetWeeklySignups(string type)
        {
            try
            {
                var currentDate = DateTime.UtcNow;
                var currentWeekStart = currentDate.AddDays(-(int)currentDate.DayOfWeek).Date;
                var previousWeekStart = currentWeekStart.AddDays(-7);

                int currentWeekSignUps = 0;
                int previousWeekSignUps = 0;

                if (type == "Residential")
                {
                    currentWeekSignUps = await _dashboardService.GetWeeklyResidentialSignUpCountAsync(currentWeekStart, currentWeekStart.AddDays(7));
                    previousWeekSignUps = await _dashboardService.GetWeeklyResidentialSignUpCountAsync(previousWeekStart, previousWeekStart.AddDays(7));
                }
                else if (type == "SME")
                {
                    currentWeekSignUps = await _dashboardService.GetWeeklySmeSignUpCountAsync(currentWeekStart, currentWeekStart.AddDays(7));
                    previousWeekSignUps = await _dashboardService.GetWeeklySmeSignUpCountAsync(previousWeekStart, previousWeekStart.AddDays(7));
                }
                else if (type == "Total")
                {
                    currentWeekSignUps = await _dashboardService.GetWeeklyTotalSignUpCountAsync(currentWeekStart, currentWeekStart.AddDays(7));
                    previousWeekSignUps = await _dashboardService.GetWeeklyTotalSignUpCountAsync(previousWeekStart, previousWeekStart.AddDays(7));
                }

                var difference = currentWeekSignUps - previousWeekSignUps;

                var signUpsForTheWeek = currentWeekSignUps;

                // Calculate percentage change
                var percentageChange = previousWeekSignUps == 0 ? 100 : (difference / (double)previousWeekSignUps) * 100;

                // Format trend message
                var trendMessage = percentageChange == 100 ? "No previous sign-ups to compare" : $"{percentageChange:+0;-0}% decrease from last week";

                if (currentWeekSignUps == 0)
                {
                    trendMessage = type == "Residential" ? "No residential sign-ups this week" :
                                   type == "SME" ? "No SME sign-ups this week" :
                                   "No sign-ups this week";
                }

                var result = new ViewWeeklySignUpDto
                {
                    SignUpsForTheWeek = signUpsForTheWeek.ToString("N0"),
                    Trend = trendMessage
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while trying to view weekly {type} sign-ups");
                return BadRequest(ipNXApiResponse.Failure($"An error occurred while trying to view {type} sign-up trends"));
            }
        }





        [HttpGet("admin/monthly-revenue")]
        public async Task<IActionResult> GetMonthlyRevenue()
        {
            try
            {
                var currentDate = DateTime.UtcNow;
                var currentMonthStart = new DateTime(currentDate.Year, currentDate.Month, 1);
                var previousMonthStart = currentMonthStart.AddMonths(-1);
                var nextMonthStart = currentMonthStart.AddMonths(1);

                var currentMonthRevenue = await _dashboardService.GetMonthlyRevenueAsync(currentMonthStart, nextMonthStart);
                var previousMonthRevenue = await _dashboardService.GetMonthlyRevenueAsync(previousMonthStart, currentMonthStart);

                var difference = currentMonthRevenue - previousMonthRevenue;
                var percentageChange = previousMonthRevenue == 0 ? 100 : (difference / previousMonthRevenue) * 100;
                var trendMessage = percentageChange == 100 ? "No previous revenue to compare" : $"{percentageChange:+0;-0}% than last month";

                var revenueForTheMonth = $"₦{currentMonthRevenue.ToString("N0")}";

                var result = new ViewRevenueDto
                {
                    RevenueForTheMonth = revenueForTheMonth,
                    Trend = trendMessage
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to view the monthly revenue");
                return BadRequest(ipNXApiResponse.Failure("An error occured while trying to view revenue Trends"));
            }
        }


        [HttpGet("admin/daily-sales-for-the-week")]
        public async Task<IActionResult> GetDayOfWeekPerformance()
        {
            try
            {
                var currentDate = DateTime.UtcNow;
                var currentMonthStart = new DateTime(currentDate.Year, currentDate.Month, 1, 0, 0, 0, DateTimeKind.Utc);
                var nextMonthStart = currentMonthStart.AddMonths(1);

                var dayOfWeekRevenue = await _dashboardService.GetSalesByDayOfWeekAsync(currentMonthStart, nextMonthStart);

                if (dayOfWeekRevenue.All(kvp => kvp.Value == 0))
                {
                    return NotFound(ipNXApiResponse.Failure("No sales have happened this week."));
                }

                // Get today's sales and yesterday's sales
                var todaySales = await _dashboardService.GetSalesForSpecificDayAsync(currentDate.Date);
                var yesterdaySales = await _dashboardService.GetSalesForSpecificDayAsync(currentDate.Date.AddDays(-1));

                // Calculate the trend
                string trend;
                if (yesterdaySales == 0)
                {
                    trend = "No sales data available for yesterday.";
                }
                else
                {
                    var percentageChange = ((todaySales - yesterdaySales) / yesterdaySales) * 100;
                    if (percentageChange > 0)
                    {
                        trend = $"+{percentageChange:F2}% increase in today's sales.";
                    }
                    else if (percentageChange < 0)
                    {
                        trend = $"{percentageChange:F2}% decrease in today's sales.";
                    }
                    else
                    {
                        trend = "No change in today's sales compared to yesterday.";
                    }
                }

                var response = new
                {
                    data = dayOfWeekRevenue,
                    trend = trend
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to view day of the week performance");
                return BadRequest(ipNXApiResponse.Failure("An error occurred while trying to view day of the week performance"));
            }
        }


        [HttpGet("admin/monthly-sales-for-the-year")]
        public async Task<IActionResult> GetMonthPerformance()
        {
            try
            {
                var currentDate = DateTime.UtcNow;
                var currentYearStart = new DateTime(currentDate.Year, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                var nextYearStart = currentYearStart.AddYears(1);

                var monthRevenue = await _dashboardService.GetSalesByMonthAsync(currentYearStart, nextYearStart);

                if (monthRevenue.All(kvp => kvp.Value == 0))
                {
                    return NotFound(ipNXApiResponse.Failure("No sales have happened this year."));
                }

                // Get current month's sales and previous month's sales
                var currentMonthStart = new DateTime(currentDate.Year, currentDate.Month, 1, 0, 0, 0, DateTimeKind.Utc);
                var previousMonthStart = currentMonthStart.AddMonths(-1);

                var currentMonthSales = await _dashboardService.GetSalesForSpecificMonthAsync(currentMonthStart);
                var previousMonthSales = await _dashboardService.GetSalesForSpecificMonthAsync(previousMonthStart);

                // Calculate the trend
                string trend;
                if (previousMonthSales == 0)
                {
                    trend = "No sales data available for the previous month.";
                }
                else
                {
                    var percentageChange = ((currentMonthSales - previousMonthSales) / previousMonthSales) * 100;
                    if (percentageChange > 0)
                    {
                        trend = $"+{percentageChange:F2}% increase in this month's sales.";
                    }
                    else if (percentageChange < 0)
                    {
                        trend = $"{percentageChange:F2}% decrease in this month's sales.";
                    }
                    else
                    {
                        trend = "No change in this month's sales compared to the previous month.";
                    }
                }

                var response = new
                {
                    data = monthRevenue,
                    trend = trend
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to view monthly performance");
                return BadRequest(ipNXApiResponse.Failure("An error occurred while trying to view monthly performance"));
            }
        }


        [HttpPost("website-visit")]
        public async Task<IActionResult> AddWebsiteVisit() 
        {
            try
            {
                var visit = new WebsiteVisit { VisitDate = DateTime.UtcNow };
                await _dashboardService.VisitAsync(visit);
                return Ok(ipNXApiResponse.Success("ipNX website was visited"));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Website could not be visited");
                return StatusCode(500, "We will be back online shortly");
            }
        }




        [HttpGet("website-visits-for-the-week")]
        public async Task<IActionResult> GetVisitCount()
        {
            try
            {
                var visits = await _dashboardService.GetVisitsForCurrentWeekAsync();

                var visitCounts = visits
                    .GroupBy(v => v.VisitDate.DayOfWeek)
                    .Select(g => new
                    {
                        Day = g.Key.ToString(),
                        Count = g.Count()
                    })
                    .ToList();

                var weekVisitCount = Enum.GetValues(typeof(DayOfWeek))
                    .Cast<DayOfWeek>()
                    .ToDictionary(d => d.ToString(), d => 0);

                foreach (var visit in visitCounts)
                {
                    weekVisitCount[visit.Day] = visit.Count;
                }

                return Ok(weekVisitCount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Could not retrieve website visits at this time");
                return StatusCode(500,"Could not retrieve website visits at this time");
            }



        }

        [Authorize]
        [HttpGet("top-sales")]
        public async Task<IActionResult> ViewTopSales()
        {
            try
            {

                var result = await _dashboardService.ViewTopThreeCustomersBySuccessfullyPlacedOrdersAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Could not display the top sales");
                return StatusCode(500, "An error occured while trying to  display the top sales");
            }
        }






    }
}
