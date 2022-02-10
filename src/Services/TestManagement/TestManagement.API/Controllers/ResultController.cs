
using TestManagement.Application.Queries.Result;

namespace TestManagement.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly IMediator _mediator;   
        public ResultController(IMediator mediator)
        {
            _mediator = mediator;   
        }
        [Route("create")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Guid>> CreateSpecimenInformation([FromBody] CreateResultCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [Route("update")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateResult([FromBody] UpdateResultCommand command)
        {
            var result = await _mediator.Send(command);
            return NoContent();
        }
        [Route("getall")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ResultVM>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ResultVM>>> GetAllResult() 
        {
            var query = new GetAllResultQuery();
            var data = await _mediator.Send(query);
            return Ok(data);

        }

    }
}
