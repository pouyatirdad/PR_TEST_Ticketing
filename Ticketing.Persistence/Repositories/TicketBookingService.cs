using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Core.DataService;
using Ticketing.Domain.Domain;

namespace Ticketing.Persistence.Repositories
{
    public class TicketBookingService : ITicketBookingService
    {
        public MyDbContext _context { get; }
        public TicketBookingService(MyDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Ticket> GetAvailableTickets(DateTime date)
        {
            var unAvaiableTickets =_context.TicketBookings
                .Where(x=>x.Date == date)
                .Select(x => x.TicketId)
                .ToList();

            var avaiableTickets = _context.Tickets
                .Where(x => unAvaiableTickets.Contains(x.Id) == false)
                .ToList();

            return avaiableTickets;
        }

        public void Save(TicketBooking ticketBooking)
        {
            throw new NotImplementedException();
        }
    }
}
