using Asp.Versioning;
using Core.AgentServices;
using Data.Dtos;
using API.Data.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private readonly IAgentService _agentService;
        private readonly ILogger<AgentsController> _logger;

        public AgentsController(IAgentService agentService, ILogger<AgentsController> logger)
        {
            _agentService = agentService;
            _logger = logger;
        }



        [HttpPost("add-agent")]
        public async Task<IActionResult> AddAgent([FromBody] AddAgentDto addAgentDto)
        {
            try
            {
                var result = await _agentService.AddAgentAsync(addAgentDto);
                return Ok(ipNXApiResponse.Success(result));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while attempting to add an agent");
                return BadRequest(ipNXApiResponse.Failure("An error occurred while attempting to add an agent"));
            }
        }





        [HttpDelete("remove-agent")]
        public async Task<IActionResult> RemoveAgent(Guid agentId)
        {
            try
            {
                var result = await _agentService.RemoveAgentAsync(agentId);
                if (result == null)
                {
                    return NotFound(ipNXApiResponse.Failure("Agent was not found"));
                }
                return Ok(ipNXApiResponse.Success(result));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while attempting to remove an agent");
                return BadRequest(ipNXApiResponse.Failure("An error occurred while attempting to delete an agent"));
            }
        }







        [HttpGet("view-all-agents")]
        public async Task<IActionResult> ViewAllAgents() 
        {
            try
            {
                var result = await _agentService.ViewAllAgentsAsync();
                if (!result.Any())
                {
                    return NotFound(ipNXApiResponse.Failure("No agent was not found"));
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while attempting to view all agents");
                return BadRequest(ipNXApiResponse.Failure("An error occurred while attempting to view all active agents"));
            }
        }


        [Authorize]
        [HttpPut("deactivate-or-activate-agent")]
        public async Task<IActionResult> ToggleAgentStatus(string agentId, bool activate)
        {
            try
            {

                var userIdFromClaims = User.Claims.FirstOrDefault()?.Value;
                var userId = new Guid(userIdFromClaims);
                await _agentService.ToggleAgentStatusAsync(agentId, activate);
                return Ok(ipNXApiResponse.Success("agent status was successfully changed"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to change agent status");
                return BadRequest(ipNXApiResponse.Failure("An error occurred while trying to change agent status"));
            }
        }


        [HttpGet("view-all-active-agents")]
        public async Task<IActionResult> ViewAllActiveAgents()
        {
            try
            {
                var result = await _agentService.ViewAllActiveAgentsAsync();
                if (!result.Any())
                {
                    return NotFound(ipNXApiResponse.Failure("No active agent was not found"));
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while attempting to view all active agents");
                return BadRequest(ipNXApiResponse.Failure("An error occurred while attempting to view all active agents"));
            }
        }


    }
}
