using Ticketing.Core.Enums;

namespace Ticketing.Core.Model
{
    public class ServiceBookingResult : ServiceBookingBase
    {
        public BookingResultFlag Flag { get; set; }

        public int? TicketBookingId { get; set; }
    }
}