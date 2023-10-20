using Xunit;
using Shouldly;
using Ticketing.Core.Model;
using Ticketing.Core.Handler;

namespace Ticketing.Test
{
    public class Ticket_Booking_Request_Handler_Test
    {
        private readonly TicketBookingRequestHandler _handler;

        public Ticket_Booking_Request_Handler_Test()
        {
            _handler = new TicketBookingRequestHandler();
        }

        [Fact]
        public void Should_Return_Ticket_Booking_Response_With_Request_Values()
        {
            //arrange - collect data

            var BookingRequest = new TicketBookingRequest
            {
                Name= "Test Name",
                Family= "Test Family",
                Email= "Test Email",
            };

            //act - pass data to method

            ServiceBookingResult Result =_handler.BookService(BookingRequest);

            //assert - pass tests

            Assert.NotNull(Result);
            Assert.Equal(BookingRequest.Name, Result.Name);
            Assert.Equal(BookingRequest.Family, Result.Family);
            Assert.Equal(BookingRequest.Email, Result.Email);

               //use shouldbe

            Result.ShouldNotBeNull();
            Result.Name.ShouldBe(BookingRequest.Name);
            Result.Family.ShouldBe(BookingRequest.Family);
            Result.Email.ShouldBe(BookingRequest.Email);
        }

        [Fact]
        public void Should_Throw_Exception_For_Null_Request()
        {
            var exception = Should.Throw<ArgumentNullException>(()=> _handler.BookService(null));
            exception.ParamName.ShouldBe("bookingRequest");

        }
    }
}
