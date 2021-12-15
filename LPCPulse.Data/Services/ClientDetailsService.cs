using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LCPPulse.Data.Models;

namespace LCPPulse.Data.Services
{
    public class ClientDetailsService : IClientDetailsService
    {
        private readonly IClientDetailsDBWrapper _dbWrapper;

        public ClientDetailsService(IClientDetailsDBWrapper dbWrapper)
        {
            _dbWrapper = dbWrapper;
        }

        public async Task<ClientDetails> GetClientDetails(Guid clientId)
        {
            try
            {
                return await _dbWrapper.GetClientDetails(clientId);
            }
            catch
            {
                //would return a response object with a succeeded bool value and the returned object rather than this. So that error handling can be handled on the front end via the controller i.e. Failed to get client details.
                return null;
            }
            
        }

        public async Task<ClientDetails> CreateClient(ClientDetails clientDetails)
        {
            try
            { 
                await _dbWrapper.CreateClient(clientDetails);
                return clientDetails;
            }
            catch
            {
                //would return a response object with a succeeded bool value and the created object rather than this. So that error handling can be handled on the front end via the controller i.e. Failed to create client.
                return null;
            }
        }

        public async Task<ClientDetails> UpdateClientDetails(ClientDetails clientDetails)
        {
            try
            {
                await _dbWrapper.UpdateClientDetails(clientDetails);
                return clientDetails;
            }
            catch
            {
                //would return a response object with a succeeded bool value and the created object rather than this. So that error handling can be handled on the front endvia the controller  i.e. Failed to update client details.
                return null;
            }
        }

        public async Task<bool> DeleteClient(Guid clientId)
        {
            try
            {
                await _dbWrapper.DeleteClient(clientId);
                return true;
            }
            catch
            {
                //would return a response object with a succeeded bool value and the created object rather than this. So that error handling can be handled on the front end i.e. Failed to update client details.
                return false;
            }
        }

        public async Task<List<ClientDetails>> ListClients(Guid employeeId)
        {
            try
            {
                return await _dbWrapper.ListClients(employeeId);
            }
            catch
            {
                //would return a response object with a succeeded bool value  rather than this. So that error handling can be handled on the front end i.e. Failed to list clients.
                return new List<ClientDetails>();
            }
        }
    }
}
