using Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AgentServices
{
    public interface IAgentService
    {
        Task<string> AddAgentAsync(AddAgentDto addAgentDto);
        Task<string> RemoveAgentAsync(Guid agentId);
        Task<IEnumerable<ViewAgentDto>> ViewAllAgentsAsync();
        Task ToggleAgentStatusAsync(string agentId, bool activate);
        Task<IEnumerable<ViewAgentDto>> ViewAllActiveAgentsAsync();

    }
}
