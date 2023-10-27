﻿using System;
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
            return _context.Tickets
                .Where(x => !x.TicketBookings.Any(c=>c.Date == date))
                .ToList();
        }

        public void Save(TicketBooking ticketBooking)
        {
            _context.Add(ticketBooking);
            _context.SaveChanges();
        }
    }
}
