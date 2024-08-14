using APIMeuAmigoNOTAM.Domain.Commands.v1.CreateNotam;
using APIMeuAmigoNOTAM.Domain.Commands.v1.DeleteNotamByID;
using APIMeuAmigoNOTAM.Domain.Commands.v1.UpdateNotam;
using APIMeuAmigoNOTAM.Domain.Queries.v1.GetAllNotam;
using APIMeuAmigoNOTAM.Domain.Queries.v1.GetNotamById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace APIMeuAmigoNOTAM.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotamController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotamController(IMediator mediator)
        {
            _mediator = mediator;
        }

       /*[HttpPost]
       public async Task<IActionResult> CreateNotam([FromBody] CreateNotam command)
       {
;
       }*/

       /*[HttpDelete("{id}")]
       public async Task<IActionResult> DeleteNotamById(string id)
       {

       }*/

        /*[HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotam(string id, [FromBody] UpdateNotam command )
        {

        }*/

        [HttpGet]
        public async Task<IActionResult> GetAllNotam()
        {
            var query = new GetAllNotamQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        /*[HttpGet("{id}")]
        public async Task<IActionResult> GetNotam(string id)
        {
          
        }*/
    }
}
