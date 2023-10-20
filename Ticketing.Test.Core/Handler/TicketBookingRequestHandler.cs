using Ticketing.Core.DataService;
using Ticketing.Core.Domain;
using Ticketing.Core.Model;

namespace Ticketing.Core.Handler
{
    public class TicketBookingRequestHandler
    {
        private readonly ITicketBookingService _ticketBookingService;

        public TicketBookingRequestHandler(ITicketBookingService ticketBookingService)
        {
            _ticketBookingService = ticketBookingService;
        }

        public ServiceBookingResult BookService(TicketBookingRequest bookingRequest)
        {
            if (bookingRequest is null)
            {
                throw new ArgumentNullException(nameof(bookingRequest));
            }

            _ticketBookingService.Save(new TicketBooking()
            {
                Email = bookingRequest.Email,
                Family = bookingRequest.Family,
                Name = bookingRequest.Name,
            });

            return new ServiceBookingResult
            {
                Name = bookingRequest.Name,
                Family = bookingRequest.Family,
                Email = bookingRequest.Email
            };
        }
    }
}