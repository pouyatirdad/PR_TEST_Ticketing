using Ticketing.Core.Model;

namespace Ticketing.Core.Handler
{
    public interface ITicketBookingRequestHandler
    {
        ServiceBookingResult BookService(TicketBookingRequest bookingRequest);
    }
}