using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticketing.Core.Handler;
using Ticketing.Core.Model;

namespace Ticketing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private ITicketBookingRequestHandler _ticketBookingRequestHandler;

        public BookingController(ITicketBookingRequestHandler ticketBookingRequestHandler)
        {
            _ticketBookingRequestHandler= ticketBookingRequestHandler;
        }

        public async Task<IActionResult> Book(TicketBookingRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = _ticketBookingRequestHandler.BookService(request);
                if (result.Flag == Core.Enums.BookingResultFlag.Success)
                {
                    return Ok(result);
                }

                ModelState.AddModelError(nameof(TicketBookingRequest.Date), "No Ticket Available For Given Date");
            }

            return BadRequest(ModelState);
        }
    }
}
