using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using LCPPulse.Data.Models;
using Microsoft.Extensions.Logging;

namespace LCPPulse.Data.Services
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

                var result = await cmd.ExecuteReaderAsync();

                while (await result.ReadAsync())
                {
                    Guid? candidateId = result.GetGuid("ClientId");
                    string firstName = result.GetString("FirstName");
                    string surname = result.GetString("Surname");
                    string phone = result.GetString("Phone");
                    string company = result.GetString("Company");
                    string address = result.GetString("Address");

                    return new ClientDetails()
                    {
                        ClientId = candidateId,
                        FirstName = firstName,
                        Address = address,
                        Company = company,
                        Phone = phone,
                        Surname = surname
                    };
                }

                return null;
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

                var result = await cmd.ExecuteReaderAsync();

                var clientDetailsList = new List<ClientDetails>();

                while (await result.ReadAsync())
                {
                    Guid? candidateId = result.GetGuid("ClientId");
                    string firstName = result.GetString("FirstName");
                    string surname = result.GetString("Surname");
                    string phone = result.GetString("Phone");
                    string company = result.GetString("Company");
                    string address = result.GetString("Address");

                    var clientDetails = new ClientDetails()
                    {
                        ClientId = candidateId,
                        FirstName = firstName,
                        Address = address,
                        Company = company,
                        Phone = phone,
                        Surname = surname
                    };

                    clientDetailsList.Add(clientDetails);
                }

                return clientDetailsList;
            }
            catch (Exception e)
            {
               _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
