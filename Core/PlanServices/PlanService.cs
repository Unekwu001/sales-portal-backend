
using Data.Dtos;
using Data.ipNXContext;
using Data.Models.OrderModels;
using Data.Models.PlanModels;
using Data.Utility;
using GoogleApi.Entities.Search.Common;
using Microsoft.EntityFrameworkCore;

namespace Core.PlanServices
{
    public class PlanService : IPlanService
    {
        private readonly IpNxDbContext _ipnxDbContext;

        public PlanService(IpNxDbContext context)
        {
            _ipnxDbContext = context;
        }

        public IpNxDbContext PlanContext()
        {
            return _ipnxDbContext;
        }
        public async Task AddPlanAsyncAndSaveChanges(Plan plan)
        {
            await _ipnxDbContext.Plans.AddAsync(plan);
            await _ipnxDbContext.SaveChangesAsync();
        }

        public async Task AddPlanTypeAndSaveChangesAsync(Guid planId, PlanType planType)
        {
            planType.PlanId = planId;
            await _ipnxDbContext.PlanTypes.AddAsync(planType);
            await _ipnxDbContext.SaveChangesAsync();
        }

        public async Task<Plan> GetPlanAsync(Guid planId)
        {
            return await _ipnxDbContext.Plans.FindAsync(planId);   
        }

        public async Task<IEnumerable<Plan>> GetAllPlanAsync()
        {
            return await _ipnxDbContext.Plans.ToListAsync();
        }

        public async Task<IEnumerable<PlanType>> GetAllActivePlanTypesByPlanIdAsync(Guid planId)
        {
            return await _ipnxDbContext.PlanTypes.Where(c => c.PlanId == planId && c.IsActive == true).ToListAsync();
        }

        public async Task<PlanType> GetPlanTypeByIdAsync(Guid planTypeId)
        {
            return  await _ipnxDbContext.PlanTypes.FirstOrDefaultAsync(pt => pt.Id == planTypeId);
        }

        public async Task<string> DeactivateOrActivatePlanTypeAsync(Guid planTypeId, bool activate)
        {
            var planType = await GetPlanTypeByIdAsync(planTypeId);
            if(planType == null)
            {
                return "PlanType does not exist";
            }
            planType.IsActive = activate;
            await _ipnxDbContext.SaveChangesAsync();
            return "PlanType status has been successfully changed";
        }



        public async Task<bool> PlanTypeNameExistsAsync(Guid planId, string planTypeName)
        {
            var existingPlanTypeNames = await _ipnxDbContext.PlanTypes
                .Where(pt => pt.PlanId == planId)
                .Select(pt => pt.PlanTypeName)
                .ToListAsync();

            const double similarityThreshold = 70.0; // you can change the threshold percentage here.

            foreach (var existingName in existingPlanTypeNames)
            {
                double similarity = Algorithms.CalculateSimilarityPercentage(existingName, planTypeName);

                if (similarity >= similarityThreshold)
                {
                    return true;
                }
            }

            return false;
        }



        public async Task<IEnumerable<ViewAllPlanTypesDto>> ViewAllPlanTypesAsync()
        {
            var result = await (from planType in _ipnxDbContext.PlanTypes
                                join plan in _ipnxDbContext.Plans on planType.PlanId equals plan.Id
                                select new ViewAllPlanTypesDto
                                {
                                    PlanTypeId = planType.Id,
                                    PlanTypeName = planType.PlanTypeName,
                                    IsActive = planType.IsActive.ToString(),
                                    DataAllowance = planType.DataAllowance,
                                    SetUpCharge = planType.SetUpCharge,
                                    BandSpeedUnit = planType.BandSpeedUnit,
                                    BandSpeedValue = planType.BandSpeedValue,
                                    KeyFeature1 = planType.KeyFeature1,
                                    KeyFeature2 = planType.KeyFeature2,
                                    KeyFeature3 = planType.KeyFeature3,
                                    PaymentCycle = planType.PaymentCycle,
                                    Price = planType.Price,
                                    PlanName = plan.PlanName
                                   
                                }).ToListAsync();

            return result;
        }


    }

}