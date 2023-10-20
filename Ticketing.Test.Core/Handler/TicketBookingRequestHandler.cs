using Ticketing.Core.Model;

namespace Ticketing.Core.Handler
{
    public class TicketBookingRequestHandler
    {
        public TicketBookingRequestHandler()
        {
        }

        public ServiceBookingResult BookService(TicketBookingRequest bookingRequest)
        {
            return new ServiceBookingResult
            {
                Name = bookingRequest.Name,
                Family = bookingRequest.Family,
                Email = bookingRequest.Email
            };
        }
    }
}