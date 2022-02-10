namespace TestManagement.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TestCenterController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TestCenterController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Route("create")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Guid>> CreateTestCenter([FromBody] CreateTestCenterCommand command) 
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TestCenterVM>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TestCenterVM>>> GetTestCentersAync() 
        {
            var getTestCentersQuery = new GetAllTestCenterListQuery();
            var testCenters = await _mediator.Send(getTestCentersQuery);
            return Ok(testCenters);
        }
        [Route("getavailable")]
        [HttpGet]
        [ProducesResponseType(typeof (IEnumerable<TestCenterVM>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TestCenterVM>>> GetTestCenterByAvailability(bool isAvalable) 
        {
            var query = new GetAvailableTestCenterQuery(isAvalable);
            var availableTestCenters = await _mediator.Send(query);
            return Ok(availableTestCenters);
        }

    }
}
