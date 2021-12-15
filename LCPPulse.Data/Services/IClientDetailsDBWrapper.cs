using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LCPPulse.Data.Models;

namespace LCPPulse.Data.Services
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
