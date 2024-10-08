﻿using APIMeuAmigoNOTAM.Domain.Commands.v1.CreateNotam;
using APIMeuAmigoNOTAM.Domain.Commands.v1.DeleteNotamByID;
using APIMeuAmigoNOTAM.Domain.Commands.v1.UpdateExpired;
using APIMeuAmigoNOTAM.Domain.Commands.v1.UpdateNotam;
using APIMeuAmigoNOTAM.Domain.Queries.v1.GetAllNotam;
using APIMeuAmigoNOTAM.Domain.Queries.v1.GetIdsIfExperid;
using APIMeuAmigoNOTAM.Domain.Queries.v1.GetNotamById;
using APIMeuAmigoNOTAM.Domain.Queries.v1.GetNotamByIsExperid;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace APIMeuAmigoNOTAM.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotamController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<NotamController> _logger;
        
        public NotamController(IMediator mediator, ILogger<NotamController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotam([FromBody] CreateNotamCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotamById(string id)
        {
            var command = new DeleteNotamByIdCommand { Id = id };
            var result = await _mediator.Send(command);
            return result.Success ? Ok() : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotam(string id, [FromBody] UpdateNotamCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateExperid(string id)
        {
            var command = new UpdateExpiredCommand { Id = id };
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotam()
        {
            var query = new GetAllNotamQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotamById(string id)
        {
            var query = new GetNotamByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet("Experid/{isExperid}")]
        public async Task<IActionResult> GetIsExperid(bool isExperid)
        {
            var query = new GetNotamByIsExperidQuery { isExperid = isExperid };
            var result = await _mediator.Send(query);

            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet("IdsExperid")]
        public async Task<IActionResult> GetIdsIfExperid()
        {
            _logger.LogInformation("Starting GetIdsIfExperid method.");

            var query = new GetIdIfExperidQuery();
            var result = await _mediator.Send(query);

            if (result != null && result.Ids.Any())
            {
                _logger.LogInformation($"Received {result.Ids.Count} expired IDs.");
            }
            else
            {
                _logger.LogInformation("No expired IDs found.");
            }

            _logger.LogInformation("Finished GetIdsIfExperid method.");

            return Ok(result);
        }

        [HttpGet("health")]
        public IActionResult Health()
        {
            return Ok(true);
        }
    }
}