using Asp.Versioning;
using AutoMapper;
using Core.PlanServices;
using Core.UserServices;
using Data.Dtos;
using Data.Models.OrderModels;
using Data.Models.PlanModels;
using API.Data.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PlansController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPlanService _planService;
        private readonly ILogger<PlansController> _logger;

        public PlansController(IMapper mapper, IPlanService planService, ILogger<PlansController> logger)
        {
            _mapper = mapper;
            _planService = planService;
            _logger = logger;
        }

        [Authorize]
        [HttpPost("admin/add-a-plan")]
        public async Task<IActionResult> AddPlan([FromBody] AddPlanDto addPlanDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ipNXApiResponse.Failure("Invalid data"));
            }
            try
            {
                var userIdFromClaims = User.Claims.FirstOrDefault()?.Value;
                var userId = new Guid(userIdFromClaims);
                var plan = _mapper.Map<Plan>(addPlanDto);
                plan.CreatedById = userId;
                plan.LastUpdatedById = userId;

                await _planService.AddPlanAsyncAndSaveChanges(plan);
                return Ok(ipNXApiResponse.Success("Plan was successfully added."));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while trying to add the plan");
                return BadRequest(ipNXApiResponse.Failure("An error occured while trying to add the plan"));
            }
        }




        [Authorize]
        [HttpPut("admin/update-a-plan/{planId}")]
        public async Task<IActionResult> UpdatePlan(Guid planId, [FromBody] AddPlanDto updatePlanDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ipNXApiResponse.Failure("Invalid data"));
            }
            try
            {
                var _context = _planService.PlanContext();
                var existingPlan = await _context.Plans.FindAsync(planId);

                if (existingPlan == null)
                {
                    return NotFound(ipNXApiResponse.Failure("Plan was not found."));
                }
                _context.Entry(existingPlan).CurrentValues.SetValues(updatePlanDto);

                var userIdFromClaims = User.Claims.FirstOrDefault()?.Value;
                var userId = new Guid(userIdFromClaims);

                existingPlan.LastUpdatedById = userId;
                existingPlan.LastUpdatedOnUtc = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                return Ok(ipNXApiResponse.Success("Plan was successfully updated."));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while trying to update the plan");
                return BadRequest(ipNXApiResponse.Failure("An error occured while trying to update the plan"));
            }
        }





        [HttpGet("view-all-plans")]
        public async Task<IActionResult> ViewPlans()
        {
            try
            {
                var result = await _planService.GetAllPlanAsync();
                var dto = _mapper.Map<IEnumerable<PlanDto>>(result);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while trying to view a plan");
                return BadRequest(ipNXApiResponse.Failure("An error occured while trying to view a plan"));
            }
        }








        [Authorize]
        [HttpPost("admin/add-a-planType/{planId}")]
        public async Task<IActionResult> AddPlanType(Guid planId, [FromBody] PlanTypeDto planTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ipNXApiResponse.Failure("Invalid data"));
            }
            var _context = _planService.PlanContext();
            var existingPlan = await _context.Plans.FindAsync(planId);
            try
            {
                if (existingPlan == null)
                {
                    return NotFound(ipNXApiResponse.Failure("Plan was not found."));
                }
                var planTypeNameExist = await _planService.PlanTypeNameExistsAsync(planId, planTypeDto.PlanTypeName);
                if (planTypeNameExist)
                {
                    return Conflict(ipNXApiResponse.Failure("The planType name is almost identical with an existing plantype name for this particular plan."));
                }
                
                var planType = _mapper.Map<PlanType>(planTypeDto);
                await _planService.AddPlanTypeAndSaveChangesAsync(planId, planType);

                return Ok(ipNXApiResponse.Success("Plan type has been added successfully"));
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "An error occured while trying to add the plan type");
                return BadRequest(ipNXApiResponse.Failure("An error occured while trying to add the plan type"));
            }
        }





        [Authorize]
        [HttpPut("admin/update-a-planType/{planTypeId}")]
        public async Task<IActionResult> UpdatePlanType(Guid planTypeId, [FromBody] PlanTypeDto planTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ipNXApiResponse.Failure("Invalid data"));
            }

            try
            {
                var userIdFromClaims = User.Claims.FirstOrDefault()?.Value;
                var userId = new Guid(userIdFromClaims);

                var existingPlanType = await _planService.GetPlanTypeByIdAsync(planTypeId);
                if (existingPlanType == null)
                {
                    return NotFound(ipNXApiResponse.Failure("Plan type was not found."));
                }
                var _context = _planService.PlanContext();
                _context.Entry(existingPlanType).CurrentValues.SetValues(planTypeDto);
                
                existingPlanType.CreatedById = userId;
                existingPlanType.CreatedOnUtc = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                 
                return Ok(ipNXApiResponse.Success("Plan type has been updated successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to update the plan type");
                return BadRequest(ipNXApiResponse.Failure("An error occurred while trying to update the plan type"));
            }
        }





        [HttpGet("view-active-plan-types/{planId}")]
        public async Task<IActionResult> ViewPlanTypes(Guid planId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ipNXApiResponse.Failure("Invalid data"));
            }
            try
            {
                var result = await _planService.GetAllActivePlanTypesByPlanIdAsync(planId);
                var dto = _mapper.Map<IEnumerable<ViewPlanTypeDto>>(result);

                return Ok(dto);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "An error occurred while trying to view active plans");
                return BadRequest(ipNXApiResponse.Failure("An error occurred while trying to view active plans"));

            }
        }




        [Authorize]
        [HttpPatch("admin/deactivate-or-activate-plantype/{planTypeId}")]
        public async Task<IActionResult> DeactivateOrActivatePlanType(Guid planTypeId, bool activate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ipNXApiResponse.Failure("Invalid data"));
            }
            try
            {
                var result = await _planService.DeactivateOrActivatePlanTypeAsync(planTypeId, activate);
                return Ok(ipNXApiResponse.Success(result));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while trying to deactivate/activate a plan type");
                return BadRequest(ipNXApiResponse.Failure("An error occured while trying to deactivate/activate a plan type"));
            }
        }



        [Authorize]
        [HttpGet("admin/view-all-planTypes")]
        public async Task<IActionResult> ViewAllPlanTypes()
        {
            try
            {
                var result = await _planService.ViewAllPlanTypesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while trying to view all plan types");
                return BadRequest(ipNXApiResponse.Failure("An error occured while trying to view all plan types"));
            }
        }



      






    }
}