using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LCPPulse.Data.Models;
using LCPPulse.Data.Services;
using Moq;
using Xunit;

namespace LPCPulse.UnitTests
{
    public class ClientDetailsServiceTests
    {
        [Fact]
        public async Task ShouldGetClientsDetailsByClientId()
        {
            var expectedClientId = Guid.NewGuid();

            var expectedClientDetails = new ClientDetails()
            {
                Address = "somewhere",
                ClientId = expectedClientId,
                Company = "a company",
                FirstName = "Aiden",
                Surname = "Brusby",
                Phone = "07954528477"
            };
            var detailsDbWrapperMock = new Mock<IClientDetailsDBWrapper>();
            detailsDbWrapperMock.Setup(x => x.GetClientDetails(expectedClientId)).ReturnsAsync(expectedClientDetails);

            var subject = CreateSubject(detailsDbWrapperMock);

            var result = await subject.GetClientDetails(expectedClientId);

            Assert.Equal(expectedClientDetails.ClientId, result.ClientId);
            Assert.Equal(expectedClientDetails.Address, result.Address);
            Assert.Equal(expectedClientDetails.Company, result.Company);
            Assert.Equal(expectedClientDetails.FirstName, result.FirstName);
            Assert.Equal(expectedClientDetails.Surname, result.Surname);
            Assert.Equal(expectedClientDetails.Phone, result.Phone);
        }

        [Fact]
        public async Task ShouldCreateClientsDetailsByClientId()
        {
            var expectedClientDetails = new ClientDetails()
            {
                Address = "somewhere",
                ClientId = Guid.NewGuid(),
                Company = "the company",
                FirstName = "Aiden",
                Surname = "Brusby",
                Phone = "07954528477"
            };

            var detailsDbWrapperMock = new Mock<IClientDetailsDBWrapper>();
            detailsDbWrapperMock.Setup(x => x.CreateClient(expectedClientDetails)).Returns(Task.CompletedTask);

            var subject = CreateSubject(detailsDbWrapperMock);

            var result = await subject.CreateClient(expectedClientDetails);

           
            Assert.Equal(expectedClientDetails.ClientId, result.ClientId);
            Assert.Equal(expectedClientDetails.Address, result.Address);
            Assert.Equal(expectedClientDetails.Company, result.Company);
            Assert.Equal(expectedClientDetails.FirstName, result.FirstName);
            Assert.Equal(expectedClientDetails.Surname, result.Surname);
            Assert.Equal(expectedClientDetails.Phone, result.Phone);
        }

        [Fact]
        public async Task ShouldUpdateClientDetailsUsingClientDetails()
        {
            var expectedClientDetails = new ClientDetails()
            {
                Address = "somewhere new",
                ClientId = Guid.NewGuid(),
                Company = "the company",
                FirstName = "Aiden",
                Surname = "Brusby",
                Phone = "07954528477"
            };

            var detailsDbWrapperMock = new Mock<IClientDetailsDBWrapper>();
            detailsDbWrapperMock.Setup(x => x.UpdateClientDetails(expectedClientDetails)).Returns(Task.CompletedTask);

            var subject = CreateSubject(detailsDbWrapperMock);

            var result = await subject.UpdateClientDetails(expectedClientDetails);

            Assert.Equal(expectedClientDetails.ClientId, result.ClientId);
            Assert.Equal(expectedClientDetails.Address, result.Address);
            Assert.Equal(expectedClientDetails.Company, result.Company);
            Assert.Equal(expectedClientDetails.FirstName, result.FirstName);
            Assert.Equal(expectedClientDetails.Surname, result.Surname);
            Assert.Equal(expectedClientDetails.Phone, result.Phone);
        }

        [Fact]
        public async Task ShouldDeleteClientByClientId()
        {

            var expectedClientId = Guid.NewGuid();

            var detailsDbWrapperMock = new Mock<IClientDetailsDBWrapper>();
            detailsDbWrapperMock.Setup(x => x.DeleteClient(expectedClientId)).Returns(Task.CompletedTask);
            var subject = CreateSubject(detailsDbWrapperMock);

            var result = await subject.DeleteClient(expectedClientId);

            Assert.True(result);
        }

        [Fact]
        public async Task ShouldListClients()
        {

            var employeeId = Guid.NewGuid();
            var expectedClientId = Guid.NewGuid();

            var expectedClients = new List<ClientDetails>()
            {
                new ClientDetails()
                {
                    FirstName = "Dave",
                    Surname = "Davidson",
                    Address = "new lane",
                    ClientId = expectedClientId,
                    Company = "a company",
                    Phone = "07954563266"
                }
            };

            var detailsDbWrapperMock = new Mock<IClientDetailsDBWrapper>();
            detailsDbWrapperMock.Setup(x => x.ListClients(employeeId)).ReturnsAsync(expectedClients);

            var subject = CreateSubject(detailsDbWrapperMock);

            var result = await subject.ListClients(employeeId);

            Assert.NotEmpty(result);
            Assert.Equal(result.First().ClientId, expectedClientId);
        }

        internal IClientDetailsService CreateSubject(Mock<IClientDetailsDBWrapper> mockDbWrapper = null)
        {
            mockDbWrapper ??= new Mock<IClientDetailsDBWrapper>();

            return new ClientDetailsService(mockDbWrapper.Object);
        }
    }
}
