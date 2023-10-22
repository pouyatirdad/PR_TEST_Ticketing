using Ticketing.Core.Enums;

namespace Ticketing.Core.Model
{
    public class ServiceBookingResult : ServiceBookingBase
    {
        public BookingSuccessFlag Flag { get; set; }
    }
}