using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Domain;

namespace Ticketing.Core.DataService
{
    public interface ITicketBookingService
    {
        void Save(TicketBooking ticketBooking);

        IEnumerable<Ticket> GetAvailableTickets(DateTime date);
    }
}
