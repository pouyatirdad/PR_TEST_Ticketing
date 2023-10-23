using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Domain;

namespace Ticketing.Persistence
{
    public class MyDbContext:DbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> options):
            base(options)
        {
               
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketBooking> TicketBookings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ticket>().HasData(
                new Ticket { Id = 1, Name = "first Name"},
                new Ticket { Id = 2, Name = "second Name"},
                new Ticket { Id = 3, Name = "third Name" }
                );
        }

    }
}
