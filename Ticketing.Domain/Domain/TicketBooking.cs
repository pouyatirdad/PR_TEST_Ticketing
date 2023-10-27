using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Base;

namespace Ticketing.Domain.Domain
{
    public class TicketBooking : ServiceBookingBase
    {
        [Key]
        public int Id { get; set; }

        public Ticket Ticket { get; set; }
        public int TicketId { get; set; }
    }
}
