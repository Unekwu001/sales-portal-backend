using API.Data.Dtos;
using Core.PlanServices;
using Data.Dtos;
using Data.ipNXContext;
using Data.Models.DiscountModel;
using Data.Models.PlanModels;
using Data.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly IpNxDbContext _ipnxDbContext;
        private readonly IPlanService _planService;

        public DiscountService(IpNxDbContext ipnxDbContext, IPlanService planService)
        {
            _ipnxDbContext = ipnxDbContext;
            _planService = planService;
        }

        public async Task<IEnumerable<ViewDiscountsDto>> GetAllDiscountsAsync()
        {
            var discounts = await _ipnxDbContext.Discounts
                .OrderByDescending(d => d.CreatedOnUtc)
                .ToListAsync();

            var result = new List<ViewDiscountsDto>();

            foreach (var discount in discounts)
            {
                var planTypeDetails = new List<PlanTypeDetailDto>();

                // Check if PlanTypeIds is not null and has elements
                if (discount.PlanTypeIds != null && discount.PlanTypeIds.Any())
                {
                    try
                    {
                        var planTypes = await GetPlanTypesByIdsAsync(discount.PlanTypeIds);

                        if (planTypes != null && planTypes.Any())
                        {
                            planTypeDetails = planTypes.Select(pt => new PlanTypeDetailDto
                            {
                                PlanTypeName = pt.PlanTypeName,
                                Status = pt.IsActive ? "Active" : "Inactive"
                            }).ToList();
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log exception (add logging logic if required)
                        Console.WriteLine($"Error fetching plan types for discount {discount.Id}: {ex.Message}");
                        // Handle error: possibly skip or return a custom error response
                    }
                }
                result.Add(new ViewDiscountsDto
                {
                    Id = discount.Id,
                    States = discount.States?.ToList() ?? new List<string>(), // Handle null cases for States
                    Cities = discount.Cities?.ToList() ?? new List<string>(), // Handle null cases for Cities
                    Streets = discount.Streets?.ToList() ?? new List<string>(), // Handle null cases for Streets
                    Percentage = discount.Percentage,
                    StartDate = discount.StartDate,
                    EndDate = discount.EndDate,
                    PlanTypeDetails = planTypeDetails,
                    DiscountStatus = discount.IsActive ? "Active" : "Inactive",
                    Date = discount.CreatedOnUtc
                });
            }

            return result;
        }

        private async Task<List<PlanType>> GetPlanTypesByIdsAsync(IEnumerable<Guid> planTypeIds)
        {
            if (planTypeIds == null || !planTypeIds.Any())
            {
                return new List<PlanType>(); 
            }

            return await _ipnxDbContext.PlanTypes
                .Where(pt => planTypeIds.Contains(pt.Id)) 
                .ToListAsync();
        }

        public async Task DeleteDiscountsAsync(Guid discountId)
        {
            var discount = await _ipnxDbContext.Discounts.FindAsync(discountId);
            if (discount != null)
            {
                _ipnxDbContext.Discounts.Remove(discount);
                await _ipnxDbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Discount not found", nameof(discountId));
            }
        }

        public async Task UpdateDiscountsAsync(Guid discountId, UpdateDiscountDto updateDiscountDto, Guid userId)
        {
            var discount = await _ipnxDbContext.Discounts
                .Include(d => d.PlanTypes)
                .FirstOrDefaultAsync(d => d.Id == discountId);

            if (discount != null)
            {
                var startDateUtc = updateDiscountDto.StartDate.HasValue ? DateTime.SpecifyKind(updateDiscountDto.StartDate.Value, DateTimeKind.Utc) : (DateTime?)null;
                var endDateUtc = updateDiscountDto.EndDate.HasValue ? DateTime.SpecifyKind(updateDiscountDto.EndDate.Value, DateTimeKind.Utc) : (DateTime?)null;

                discount.EndDate = endDateUtc;
                discount.StartDate = startDateUtc;
                discount.Streets = updateDiscountDto.Streets.ToList();
                discount.Cities = updateDiscountDto.Cities.ToList();
                discount.States = updateDiscountDto.States.ToList();
                discount.Percentage = updateDiscountDto.Percentage;
                discount.LastUpdatedById = userId;
                discount.LastUpdatedOnUtc = DateTime.UtcNow;
                discount.PlanTypeIds = updateDiscountDto.PlanTypeIds;

                await _ipnxDbContext.SaveChangesAsync();
            }
        }


        public async Task ToggleDiscountStatusAsync(Guid discountId, bool activate) 
        {
            var discount = await _ipnxDbContext.Discounts.FindAsync(discountId);
            if (discount != null)
            {
                discount.IsActive = activate;
                await _ipnxDbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Discount not found", nameof(discountId));
            }
        }

        public async Task<IEnumerable<ViewDiscountsDto>> GetAllActiveDiscountsAsync()
        {
            // Fetch all active discounts and include their PlanTypes
            var discounts = await _ipnxDbContext.Discounts
                .Where(d => d.IsActive)
                .Include(d => d.PlanTypes) // Assuming PlanTypes is a navigation property
                .OrderByDescending(d => d.CreatedOnUtc)
                .ToListAsync();

            var result = new List<ViewDiscountsDto>();

            foreach (var discount in discounts)
            {
                var planTypeDetails = new List<PlanTypeDetailDto>();

                var planTypeIds = discount.PlanTypes.Select(pt => pt.Id).ToList();

                var planTypes = await Task.WhenAll(planTypeIds.Select(async id =>
                {
                    var existingPlanType = await _planService.GetPlanTypeByIdAsync(id);
                    return existingPlanType; // This may return null if not found
                }));

                var validPlanTypes = planTypes.Where(pt => pt != null).ToList();

                foreach (var planType in validPlanTypes)
                {
                    planTypeDetails.Add(new PlanTypeDetailDto
                    {
                        PlanTypeName = planType.PlanTypeName,
                        Status = planType.IsActive ? "Active" : "Inactive"
                    });
                }

                result.Add(new ViewDiscountsDto
                {
                    Id = discount.Id,
                    States = discount.States.ToList(),
                    Cities = discount.Cities.ToList(),
                    Streets = discount.Streets.ToList(),
                    Percentage = discount.Percentage,
                    StartDate = discount.StartDate,
                    EndDate = discount.EndDate,
                    PlanTypeDetails = planTypeDetails, 
                    DiscountStatus = discount.IsActive ? "Active" : "Inactive",
                    Date = discount.CreatedOnUtc
                });
            }

            return result;
        }



        public async Task<bool> StreetNameExistsAsync(string state, string streetName)
        {
            return await _ipnxDbContext.Discounts
                .AnyAsync(d => d.States.Any(s => s.ToLower() == state.ToLower())
                            && d.Streets.Any(st => st.ToLower() == streetName.ToLower()));
        }




        public async Task<Discount> FetchStreetNameDiscountAsync(string state, string streetName)
        {
            return await _ipnxDbContext.Discounts
                .FirstOrDefaultAsync(d => d.States.Any(s => s.ToLower() == state.ToLower())
                                        && d.Streets.Any(st => st.ToLower() == streetName.ToLower()));
        }



        

        public async Task AddAndSaveDiscountAsync(DiscountDto discountDto, Guid userId, List<Guid> planTypeIds)
        {

            var startDateUtc = discountDto.StartDate.HasValue? DateTime.SpecifyKind(discountDto.StartDate.Value, DateTimeKind.Utc) : (DateTime?)null;
            var endDateUtc = discountDto.EndDate.HasValue? DateTime.SpecifyKind(discountDto.EndDate.Value, DateTimeKind.Utc): (DateTime?)null;

            var discount = new Discount
            {

                EndDate = endDateUtc,
                StartDate = startDateUtc,
                Cities = discountDto.Cities.ToList(),
                CreatedById = userId,
                IsActive = false,
                Percentage = discountDto.Percentage,
                States = discountDto.States.ToList(),  
                Streets = discountDto.Streets.ToList(),
                PlanTypeIds = planTypeIds
            };
            await _ipnxDbContext.Discounts.AddAsync(discount);
            await _ipnxDbContext.SaveChangesAsync();      
        }





    }
}
