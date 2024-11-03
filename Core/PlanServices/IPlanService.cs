using Data.Dtos;
using Data.ipNXContext;
using Data.Models.OrderModels;
using Data.Models.PlanModels;

namespace Core.PlanServices
{
    public interface IPlanService
    {
        IpNxDbContext PlanContext();
        Task AddPlanAsyncAndSaveChanges(Plan pricingPlan);
        Task AddPlanTypeAndSaveChangesAsync(Guid planId, PlanType planType);
        Task<IEnumerable<Plan>> GetAllPlanAsync();
        Task<IEnumerable<PlanType>> GetAllActivePlanTypesByPlanIdAsync(Guid planId);
        Task<PlanType> GetPlanTypeByIdAsync(Guid planTypeId);
        Task<string> DeactivateOrActivatePlanTypeAsync(Guid planTypeId, bool status);
        Task<bool> PlanTypeNameExistsAsync(Guid planId, string planTypeName);
        Task<IEnumerable<ViewAllPlanTypesDto>> ViewAllPlanTypesAsync();
        Task<Plan> GetPlanAsync(Guid planId);


    }

}
