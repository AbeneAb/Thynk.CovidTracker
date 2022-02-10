namespace TestManagement.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SpecimenInformationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SpecimenInformationController(IMediator mediator)
        {
            _mediator = mediator;   
        }
        [Route("create")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Guid>> CreateSpecimenInformation([FromBody] CreateSpecimenCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
