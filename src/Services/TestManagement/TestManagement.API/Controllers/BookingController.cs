
namespace TestManagement.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Route("create")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Guid>> CreateBooking([FromBody] CreateBookingCommand command) 
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [Route("cancel")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CancelBooking([FromBody] CancelBookingCommand command) 
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [Route("complete")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CompleteBooking([FromBody] CompleteBookingCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BookingVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<BookingVM>>> GetAllBookings() 
        {
            var getAllQuery = new GetAllBookingListQuery();
            var bookings = await _mediator.Send(getAllQuery);
            return Ok(bookings);
        }


    }
}
