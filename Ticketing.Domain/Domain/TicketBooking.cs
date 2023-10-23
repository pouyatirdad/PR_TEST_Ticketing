using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Base;

namespace Ticketing.Domain.Domain
{
    public class TicketBooking : ServiceBookingBase
    {
        public static int Id { get; set; }
        public int TicketId { get; set; }
    }
}
