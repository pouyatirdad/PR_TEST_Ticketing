﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Domain;
using Ticketing.Persistence.Repositories;
using Xunit;

namespace Ticketing.Persistence.Test
{
    public class TicketBookingServiceTest
    {
        [Fact]
        public void Should_Return_Available_Services()
        {
            //arange
            var date = new DateTime(2023, 10, 23);

            var dbOptions =new DbContextOptionsBuilder<MyDbContext>()
                .UseInMemoryDatabase("AvailableTicketTest")
                .Options;

            using var context = new MyDbContext(dbOptions);
            context.Add(new Ticket { Id = 1, Name="first"});
            context.Add(new Ticket { Id = 2, Name="second"});
            context.Add(new Ticket { Id = 3, Name= "third" });

            context.Add(new TicketBooking { TicketId = 1, Date = date });
            context.Add(new TicketBooking { TicketId = 2, Date = date.AddDays(-1) });

            context.SaveChanges();

            var ticketBookingService = new TicketBookingService(context);

            //act



            //assert
        }
    }
}
