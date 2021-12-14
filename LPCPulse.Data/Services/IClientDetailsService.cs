using LPCPulse.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LPCPulse.Data.Services
{
    public interface IClientDetailsService
    {
        Task<ClientDetails> GetClientDetails(Guid clientId);
        Task<ClientDetails> CreateClient(ClientDetails clientDetails);
        Task<ClientDetails> UpdateClientDetails(ClientDetails clientDetails);
        Task<bool> DeleteClient(Guid clientId);
        Task<List<ClientDetails>> ListClients(Guid clientId);
    }
}
