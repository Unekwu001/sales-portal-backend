using Data.Dtos;
using Data.Enums;
using Data.ipNXContext;
using Data.Models.OrderModels;
using Data.Models.WebsiteVisitModel;
using GoogleApi.Entities.Search.Common;
using GoogleApi.Entities.Search.Video.Common.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DashBoardServices
{

     public class DashBoardService : IDashBoardService
    {
        private readonly IpNxDbContext _ipnxDbContext;

        public DashBoardService(IpNxDbContext ipnxDbContext)
        {
            _ipnxDbContext = ipnxDbContext;
        }

        public async Task<decimal> GetMonthlyRevenueAsync(DateTime startDate, DateTime endDate)
        {

            startDate = DateTime.SpecifyKind(startDate, DateTimeKind.Utc);
            endDate = DateTime.SpecifyKind(endDate, DateTimeKind.Utc);

            var residentialRevenue = await _ipnxDbContext.ResidentialOrders
                .Where(o => o.PaymentStatus == OrderStatusEnum.Successful && o.CreatedOnUtc >= startDate && o.CreatedOnUtc < endDate)
                .Join(_ipnxDbContext.PlanTypes, o => o.PlanTypeId, pt => pt.Id, (o, pt) => pt.Price)
                .SumAsync(price => price);

            var smeRevenue = await _ipnxDbContext.SmeOrders
                .Where(o => o.PaymentStatus == OrderStatusEnum.Successful && o.CreatedOnUtc >= startDate && o.CreatedOnUtc < endDate)
                .Join(_ipnxDbContext.PlanTypes, o => o.PlanTypeId, pt => pt.Id, (o, pt) => pt.Price)
                .SumAsync(price => price);

            return residentialRevenue + smeRevenue;
        }


        public async Task<int> GetWeeklyResidentialSignUpCountAsync(DateTime startDate, DateTime endDate)
        {
            return await _ipnxDbContext.ResidentialOrders
                .Where(r => r.CreatedOnUtc >= startDate && r.CreatedOnUtc < endDate)
                .CountAsync();
        }

        public async Task<int> GetWeeklySmeSignUpCountAsync(DateTime startDate, DateTime endDate)
        {
            return await _ipnxDbContext.SmeOrders
                .Where(r => r.CreatedOnUtc >= startDate && r.CreatedOnUtc < endDate)
                .CountAsync();
        }

        public async Task<int> GetWeeklyTotalSignUpCountAsync(DateTime startDate, DateTime endDate)
        {
            var smeWeeklySignUps = await GetWeeklySmeSignUpCountAsync(startDate, endDate);
            var residentialWeeklySignUps = await GetWeeklyResidentialSignUpCountAsync(startDate, endDate);
            return smeWeeklySignUps + residentialWeeklySignUps; // This only sums current week data
        }


        public async Task<Dictionary<string, decimal>> GetSalesByDayOfWeekAsync(DateTime startDate, DateTime endDate)
        {
            startDate = DateTime.SpecifyKind(startDate, DateTimeKind.Utc);
            endDate = DateTime.SpecifyKind(endDate, DateTimeKind.Utc);

            // Get revenue for residential orders by day of the week
            var residentialRevenueByDayOfWeek = await (from o in _ipnxDbContext.ResidentialOrders
                                                       join pt in _ipnxDbContext.PlanTypes on o.PlanTypeId equals pt.Id
                                                       where o.CreatedOnUtc >= startDate && o.CreatedOnUtc < endDate
                                                             && o.PaymentStatus == OrderStatusEnum.Successful
                                                       group new { o, pt } by o.CreatedOnUtc.DayOfWeek into g
                                                       select new
                                                       {
                                                           DayOfWeek = g.Key,
                                                           TotalRevenue = g.Sum(x => x.pt.Price)
                                                       }).ToListAsync();

            // Get revenue for SME orders by day of the week
            var smeRevenueByDayOfWeek = await (from o in _ipnxDbContext.SmeOrders
                                               join pt in _ipnxDbContext.PlanTypes on o.PlanTypeId equals pt.Id
                                               where o.CreatedOnUtc >= startDate && o.CreatedOnUtc < endDate
                                                     && o.PaymentStatus == OrderStatusEnum.Successful
                                               group new { o, pt } by o.CreatedOnUtc.DayOfWeek into g
                                               select new
                                               {
                                                   DayOfWeek = g.Key,
                                                   TotalRevenue = g.Sum(x => x.pt.Price)
                                               }).ToListAsync();

            // Initialize dictionary for all days of the week
            var weekRevenue = Enum.GetValues(typeof(DayOfWeek))
                                   .Cast<DayOfWeek>()
                                   .ToDictionary(d => d.ToString(), d => 0m);

            // Combine residential revenue
            foreach (var revenue in residentialRevenueByDayOfWeek)
            {
                weekRevenue[revenue.DayOfWeek.ToString()] += revenue.TotalRevenue;
            }

            // Combine SME revenue
            foreach (var revenue in smeRevenueByDayOfWeek)
            {
                weekRevenue[revenue.DayOfWeek.ToString()] += revenue.TotalRevenue;
            }

            return weekRevenue;
        }



        public async Task<decimal> GetSalesForSpecificDayAsync(DateTime specificDay)
        {
            specificDay = DateTime.SpecifyKind(specificDay, DateTimeKind.Utc);
            var nextDay = specificDay.AddDays(1);

            var residentialRevenue = await (from o in _ipnxDbContext.ResidentialOrders
                                            join pt in _ipnxDbContext.PlanTypes on o.PlanTypeId equals pt.Id
                                            where o.CreatedOnUtc >= specificDay && o.CreatedOnUtc < nextDay
                                                  && o.PaymentStatus == OrderStatusEnum.Successful
                                            select pt.Price).SumAsync();

            var smeRevenue = await (from o in _ipnxDbContext.SmeOrders
                                    join pt in _ipnxDbContext.PlanTypes on o.PlanTypeId equals pt.Id
                                    where o.CreatedOnUtc >= specificDay && o.CreatedOnUtc < nextDay
                                          && o.PaymentStatus == OrderStatusEnum.Successful
                                    select pt.Price).SumAsync();

            return residentialRevenue + smeRevenue;
        }


        public async Task<Dictionary<string, decimal>> GetSalesByMonthAsync(DateTime startDate, DateTime endDate)
        {
            startDate = DateTime.SpecifyKind(startDate, DateTimeKind.Utc);
            endDate = DateTime.SpecifyKind(endDate, DateTimeKind.Utc);

            // Get revenue by month for residential orders
            var residentialRevenueByMonth = await (from o in _ipnxDbContext.ResidentialOrders
                                                   join pt in _ipnxDbContext.PlanTypes on o.PlanTypeId equals pt.Id
                                                   where o.CreatedOnUtc >= startDate && o.CreatedOnUtc < endDate
                                                         && o.PaymentStatus == OrderStatusEnum.Successful
                                                   group new { o, pt } by new { o.CreatedOnUtc.Year, o.CreatedOnUtc.Month } into g
                                                   select new
                                                   {
                                                       Year = g.Key.Year,
                                                       Month = g.Key.Month,
                                                       TotalRevenue = g.Sum(x => x.pt.Price)
                                                   }).ToListAsync();

            // Get revenue by month for SME orders
            var smeRevenueByMonth = await (from o in _ipnxDbContext.SmeOrders
                                           join pt in _ipnxDbContext.PlanTypes on o.PlanTypeId equals pt.Id
                                           where o.CreatedOnUtc >= startDate && o.CreatedOnUtc < endDate
                                                 && o.PaymentStatus == OrderStatusEnum.Successful
                                           group new { o, pt } by new { o.CreatedOnUtc.Year, o.CreatedOnUtc.Month } into g
                                           select new
                                           {
                                               Year = g.Key.Year,
                                               Month = g.Key.Month,
                                               TotalRevenue = g.Sum(x => x.pt.Price)
                                           }).ToListAsync();

            // Combine revenues
            var combinedRevenueByMonth = residentialRevenueByMonth.Concat(smeRevenueByMonth)
                                                                  .GroupBy(x => new { x.Year, x.Month })
                                                                  .Select(g => new
                                                                  {
                                                                      Year = g.Key.Year,
                                                                      Month = g.Key.Month,
                                                                      TotalRevenue = g.Sum(x => x.TotalRevenue)
                                                                  }).ToList();

            var monthRevenue = new Dictionary<string, decimal>();

            foreach (var revenue in combinedRevenueByMonth)
            {
                var monthName = new DateTime(revenue.Year, revenue.Month, 1).ToString("MMMM");
                monthRevenue[monthName] = revenue.TotalRevenue;
            }

            return monthRevenue;
        }



        public async Task<decimal> GetSalesForSpecificMonthAsync(DateTime specificMonth)
        {
            specificMonth = DateTime.SpecifyKind(specificMonth, DateTimeKind.Utc);
            var nextMonth = specificMonth.AddMonths(1);

            // Get total revenue for residential orders
            var residentialRevenue = await (from o in _ipnxDbContext.ResidentialOrders
                                            join pt in _ipnxDbContext.PlanTypes on o.PlanTypeId equals pt.Id
                                            where o.CreatedOnUtc >= specificMonth && o.CreatedOnUtc < nextMonth
                                                  && o.PaymentStatus == OrderStatusEnum.Successful
                                            select pt.Price).SumAsync();

            // Get total revenue for SME orders
            var smeRevenue = await (from o in _ipnxDbContext.SmeOrders
                                    join pt in _ipnxDbContext.PlanTypes on o.PlanTypeId equals pt.Id
                                    where o.CreatedOnUtc >= specificMonth && o.CreatedOnUtc < nextMonth
                                          && o.PaymentStatus == OrderStatusEnum.Successful
                                    select pt.Price).SumAsync();

            // Combine the revenues from residential and SME orders
            return residentialRevenue + smeRevenue;
        }




        public async Task<IEnumerable<WebsiteVisit>> GetVisitsForCurrentWeekAsync()
        {
            var today = DateTime.UtcNow.Date;
            var startOfWeek = today.AddDays(-(int)today.DayOfWeek);
            var endOfWeek = startOfWeek.AddDays(7);

            return await _ipnxDbContext.WebsiteVisits
                .Where(v => v.VisitDate >= startOfWeek && v.VisitDate < endOfWeek)
                .ToListAsync();
        }




        public async Task VisitAsync(WebsiteVisit visit)
        {
            await _ipnxDbContext.WebsiteVisits.AddAsync(visit);
            await _ipnxDbContext.SaveChangesAsync();
        }


        public async Task<IEnumerable<TopThreeCustomersDto>> ViewTopThreeCustomersBySuccessfullyPlacedOrdersAsync()
        {
            // Fetching successful SME orders
            var successfulSmeOrders = await _ipnxDbContext.SmeOrders
                .Where(order => order.PaymentStatus == OrderStatusEnum.Successful && order.PaymentReferenceNumber != null)
                .Select(order => new
                {
                    order.CreatedById,
                    order.PlanType.Price
                })
                .ToListAsync();

            // Fetching successful residential orders
            var successfulResidentialOrders = await _ipnxDbContext.ResidentialOrders
                .Where(order => order.PaymentStatus == OrderStatusEnum.Successful && order.PaymentReferenceNumber != null)
                .Select(order => new
                {
                    order.CreatedById,
                    order.PlanType.Price
                })
                .ToListAsync();

            // Concatenate orders and group by user
            var allSuccessfulOrders = successfulSmeOrders
                .Concat(successfulResidentialOrders)
                .GroupBy(order => order.CreatedById)
                .Select(group => new
                {
                    UserId = group.Key,
                    TotalOrderValue = group.Sum(order => order.Price),
                    OrderCount = group.Count()
                })
                .OrderByDescending(user => user.TotalOrderValue)
                .Take(3)
                .ToList();

            // Fetch top customers' details
            var topCustomers = await _ipnxDbContext.Users
                .Where(user => allSuccessfulOrders.Select(order => order.UserId).Contains(user.Id))
                .ToListAsync();

            // Joining orders with user details and creating DTOs
            var topCustomerDtos = allSuccessfulOrders.Join(
                topCustomers,
                order => order.UserId,
                user => user.Id,
                (order, user) => new TopThreeCustomersDto
                {
                    UserId = user.Id,
                    UserName = $"{user.FirstName} {user.LastName}",
                    Email = user.Email,
                    TotalOrderValue = order.TotalOrderValue,
                    OrderCount = order.OrderCount
                }
            ).ToList();

            return topCustomerDtos;
        }

        

    }




}

