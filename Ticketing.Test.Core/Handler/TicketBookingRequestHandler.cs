using Ticketing.Core.DataService;
using Ticketing.Core.Model;
using Ticketing.Domain.Base;
using Ticketing.Domain.Domain;

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

            var availableTickets = _ticketBookingService.GetAvailableTickets(bookingRequest.Date);
            var result = CreateTicketBookingObject<ServiceBookingResult>(bookingRequest);

            if (availableTickets.Any())
            {
                var Ticket =availableTickets.First();
                var TicketBooking = CreateTicketBookingObject<TicketBooking>(bookingRequest);
                TicketBooking.TicketId = Ticket.Id;
                _ticketBookingService.Save(TicketBooking);
                result.TicketBookingId = TicketBooking.TicketId;
                result.Flag = Enums.BookingResultFlag.Success;
            }
            else { 
            result.Flag = Enums.BookingResultFlag.Failure;
            }

            return result;
        }
        public static T CreateTicketBookingObject<T>(TicketBookingRequest bookingRequest)
        where T : ServiceBookingBase,new()
        {
            return new T
            {
                Name= bookingRequest.Name,
                Family = bookingRequest.Family,
                Email = bookingRequest.Email,
            };
        }
    }
}