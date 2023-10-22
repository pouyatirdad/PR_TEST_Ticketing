﻿using Ticketing.Core.DataService;
using Ticketing.Core.Domain;
using Ticketing.Core.Model;

namespace Ticketing.Core.Handler
{
    public class TicketBookingRequestHandler
    {
        private readonly ITicketBookingService _ticketBookingService;

        public TicketBookingRequestHandler(ITicketBookingService ticketBookingService)
        {
            _ticketBookingService = ticketBookingService;
        }

        public ServiceBookingResult BookService(TicketBookingRequest bookingRequest)
        {
            if (bookingRequest is null)
            {
                throw new ArgumentNullException(nameof(bookingRequest));
            }

            var availableTickets = _ticketBookingService.GetAvailableTickets(bookingRequest.Date);

            if (availableTickets.Any())
            {
                var Ticket =availableTickets.First();
                var TicketBooking = CreateTicketBookingObject<TicketBooking>(bookingRequest);
                TicketBooking.Id = Ticket.Id;
                _ticketBookingService.Save(TicketBooking);
            }


            return CreateTicketBookingObject<ServiceBookingResult>(bookingRequest);
        }
        public static T CreateTicketBookingObject<T>(TicketBookingRequest bookingRequest)
        where T : ServiceBookingBase,new()
        {
            return new T
            {
                Name= bookingRequest.Name,
                Family = bookingRequest.Family,
                Email = bookingRequest.Email,
            };
        }
    }
}