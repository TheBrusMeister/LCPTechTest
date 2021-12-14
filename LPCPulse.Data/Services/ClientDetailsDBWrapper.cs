using LPCPulse.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace LPCPulse.Data.Services
{
    public class ClientDetailsDBWrapper : IClientDetailsDBWrapper
    {
        private readonly ILogger _logger;

        public ClientDetailsDBWrapper(ILogger<IClientDetailsDBWrapper> logger)
        {
            _logger = logger;
        }

        public async Task<ClientDetails> GetClientDetails(Guid clientId)
        {
            try
            {
                //would inject from configuration and get using DI and IOptions
                var connectionString = "connection string";

                await using SqlConnection connection = new SqlConnection(connectionString);
                await using var cmd = connection.CreateCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spGetClientDetailsByClientId";

                cmd.Parameters.AddWithValue("@ClientId", clientId);

                await connection.OpenAsync();

                var result = await cmd.ExecuteScalarAsync() as ClientDetails;

                return result;
            }
            catch (Exception e)
            {
               _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task CreateClient(ClientDetails clientDetails)
        {
            try
            {
                //would inject from configuration and get using DI and IOptions
                var connectionString = "connection string";

                await using SqlConnection connection = new SqlConnection(connectionString);
                await using var cmd = connection.CreateCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spCreateClientByClientDetails ";

                cmd.Parameters.AddWithValue("@ClientId", clientDetails.ClientId);
                cmd.Parameters.AddWithValue("@FirstName", clientDetails.FirstName);
                cmd.Parameters.AddWithValue("@Surname", clientDetails.Surname);
                cmd.Parameters.AddWithValue("@Address", clientDetails.Address);
                cmd.Parameters.AddWithValue("@Phone", clientDetails.Address);
                cmd.Parameters.AddWithValue("@Company", clientDetails.Company);

                await connection.OpenAsync();

                await cmd.ExecuteScalarAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task UpdateClientDetails(ClientDetails clientDetails)
        {
            try
            {
                //would inject from configuration and get using DI and IOptions
                var connectionString = "connection string";

                await using SqlConnection connection = new SqlConnection(connectionString);
                await using var cmd = connection.CreateCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spCreateClientByClientDetails";

                cmd.Parameters.AddWithValue("@ClientId", clientDetails.ClientId);
                cmd.Parameters.AddWithValue("@FirstName", clientDetails.FirstName);
                cmd.Parameters.AddWithValue("@Surname", clientDetails.Surname);
                cmd.Parameters.AddWithValue("@Address", clientDetails.Address);
                cmd.Parameters.AddWithValue("@Phone", clientDetails.Address);
                cmd.Parameters.AddWithValue("@Company", clientDetails.Company);

                await connection.OpenAsync();

                await cmd.ExecuteScalarAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task DeleteClient(Guid clientId)
        {
            try
            {
                //would inject from configuration and get using DI and IOptions
                var connectionString = "connection string";

                await using SqlConnection connection = new SqlConnection(connectionString);
                await using var cmd = connection.CreateCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spDeleteClient";

                cmd.Parameters.AddWithValue("@ClientId", clientId);

                await connection.OpenAsync();

                await cmd.ExecuteScalarAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }

        public async Task<List<ClientDetails>> ListClients(Guid employeeId)
        {
            try
            {
                //would inject from configuration and get using DI and IOptions
                var connectionString = "connection string";

                await using SqlConnection connection = new SqlConnection(connectionString);
                await using var cmd = connection.CreateCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spListClients";

                await connection.OpenAsync();

                return await cmd.ExecuteScalarAsync() as List<ClientDetails>;
            }
            catch (Exception e)
            {
                //would normally use ILogger set up from the start up and log to somewhere like cloudwatch in AWS
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
