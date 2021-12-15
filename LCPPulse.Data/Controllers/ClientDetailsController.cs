using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using LCPPulse.Data.Models;
using LCPPulse.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LCPPulse.Data.Controllers
{
    public class ClientDetailsController : Controller
    {
        private readonly ILogger<ClientDetailsController> _logger;
        private readonly IClientDetailsService _clientDetailsService;

        public ClientDetailsController(ILogger<ClientDetailsController> logger,
            IClientDetailsService clientDetailsService)
        {
            _logger = logger;
            _clientDetailsService = clientDetailsService;
        }

        [HttpPost]
        [Route("client/create")]
        [ProducesResponseType(typeof(ClientDetails), StatusCodes.Status201Created)]
        [ProducesResponseType( StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateClient([FromBody] ClientDetails clientDetails)
        {
            try
            {
                var result = await _clientDetailsService.CreateClient(clientDetails);
                return new ObjectResult(result) {StatusCode = StatusCodes.Status201Created};
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new StatusCodeResult(500);
            }
        }

        //could also be a patch
        [HttpPost]
        [Route("client/update")]
        [ProducesResponseType(typeof(ClientDetails), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateClient([FromBody] ClientDetails clientDetails)
        {
            try
            {
                var result = await _clientDetailsService.UpdateClientDetails(clientDetails);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpDelete]
        [Route("client/delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteClient([FromBody] Guid clientId)
        {
            try
            {
                var result = await _clientDetailsService.DeleteClient(clientId);

                if (result)
                {
                    return NoContent();
                }

                return BadRequest("Could not delete client");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpGet]
        [Route("client/list")]
        [ProducesResponseType(typeof(List<ClientDetails>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ListClients([FromQuery] Guid employeeId)
        {
            try
            {
                var result = await _clientDetailsService.ListClients(employeeId);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpGet]
        [Route("client/get")]
        [ProducesResponseType(typeof(ClientDetails), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetClientDetails([FromQuery] Guid clientId)
        {
            try
            {
                var result = await _clientDetailsService.GetClientDetails(clientId);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new StatusCodeResult(500);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
