using LPCPulse.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LPCPulse.Data.Services
{
    public interface IClientDetailsDBWrapper
    {
        Task<ClientDetails> GetClientDetails(Guid clientId);
        Task CreateClient(ClientDetails clientDetails);
        Task UpdateClientDetails(ClientDetails clientDetails);
        Task DeleteClient(Guid clientId);
        Task<List<ClientDetails>> ListClients(Guid employeeId);
    }
}
