using Ticketing.Core.Model;

namespace Ticketing.Core.Handler
{
    public class TicketBookingRequestHandler
    {
        public TicketBookingRequestHandler(DataService.ITicketBookingService @object)
        {
        }

        public ServiceBookingResult BookService(TicketBookingRequest bookingRequest)
        {
            if (bookingRequest is null)
            {
                throw new ArgumentNullException(nameof(bookingRequest));
            }

            return new ServiceBookingResult
            {
                Name = bookingRequest.Name,
                Family = bookingRequest.Family,
                Email = bookingRequest.Email
            };
        }
    }
}