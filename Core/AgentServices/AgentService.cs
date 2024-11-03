using Data.Dtos;
using Data.ipNXContext;
using Data.Models.AgentModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AgentServices
{
    public class AgentService : IAgentService
    {
        private readonly IpNxDbContext _ipnxDbContext;

        public AgentService(IpNxDbContext ipnxDbContext)
        {
            _ipnxDbContext = ipnxDbContext;
        }

        public async Task<string> AddAgentAsync(AddAgentDto addAgentDto)
        {
            var agent = new Agent
            {
                 Name = addAgentDto.Name,
                 Region = addAgentDto.Region,
                 Type = addAgentDto.Type,
                 Address = addAgentDto.Address,
            };
            await _ipnxDbContext.Agents.AddAsync(agent);
            await _ipnxDbContext.SaveChangesAsync();
            return "Agent added successsfully";

        }



        public async Task<string> RemoveAgentAsync(Guid agentId)
        {
            var agent = await _ipnxDbContext.Agents.FindAsync(agentId);
            if (agent == null)
            {
                return "Agent not found";
            }

            _ipnxDbContext.Agents.Remove(agent);
            await _ipnxDbContext.SaveChangesAsync();

            return "Agent removed successfully";
        }





        public async Task<IEnumerable<ViewAgentDto>> ViewAllAgentsAsync()
        {
            return await _ipnxDbContext.Agents
                .Select(agent => new ViewAgentDto
                {
                    Id = agent.Id,
                    Name = agent.Name,
                    Region = agent.Region,
                    Type = agent.Type,
                    Address = agent.Address ,
                    Date = agent.CreatedOnUtc,
                    Status = agent.IsActive ? "Active" : "Inactive"
                }).OrderByDescending(agent => agent.Date)
         .ToListAsync();
        }

        public async Task ToggleAgentStatusAsync(string agentId, bool activate)
        {
            var agent = await _ipnxDbContext.Agents.FindAsync(agentId);
            if (agent != null)
            {
                agent.IsActive = activate;
                await _ipnxDbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Agent not found", nameof(agentId));
            }
        }



        public async Task<IEnumerable<ViewAgentDto>> ViewAllActiveAgentsAsync()
        {
            return await _ipnxDbContext.Agents.Where(agent => agent.IsActive)
                .Select(agent => new ViewAgentDto
                {
                    Id = agent.Id,
                    Name = agent.Name,
                    Region = agent.Region,
                    Type = agent.Type,
                    Address = agent.Address,
                    Date = agent.CreatedOnUtc,
                    Status = agent.IsActive ? "Active" : "Inactive"
                }).OrderByDescending(agent => agent.Date)
         .ToListAsync();
        }

    }
}
