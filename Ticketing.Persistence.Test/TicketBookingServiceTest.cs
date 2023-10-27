using Microsoft.EntityFrameworkCore;
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
                .UseInMemoryDatabase("AvailableTicketTest",x=>x.EnableNullChecks(false))
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

            var availableServices =ticketBookingService.GetAvailableTickets(date);

            //assert

            Assert.NotNull(availableServices);
            Assert.Equal(2, availableServices.Count());
            Assert.Contains(availableServices,x=>x.Id == 2);
            Assert.Contains(availableServices,x=>x.Id == 3);
            Assert.DoesNotContain(availableServices,x=>x.Id == 1);

        }

        [Fact]
        public void Should_Save_Ticket_Booking()
        {
            //arrange

            var dbOptions = new DbContextOptionsBuilder<MyDbContext>()
                .UseInMemoryDatabase("ShouldSaveTicketTest", x => x.EnableNullChecks(false))
                .Options;

            var ticketBooking = new TicketBooking { TicketId=1,Date=new DateTime(2022,06,01) };

            //act

            using var context = new MyDbContext(dbOptions);
            var ticketBookingService =new TicketBookingService(context);
            ticketBookingService.Save(ticketBooking);

            //assert

            var bookings =context.TicketBookings.ToList();

            Assert.NotNull(bookings);

            var booking = Assert.Single(bookings); 

            Assert.Equal(ticketBooking.Date,booking.Date);
            Assert.Equal(ticketBooking.TicketId,booking.TicketId);

        }
    }
}
