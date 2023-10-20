using Xunit;
using Shouldly;
using Ticketing.Core.Model;
using Ticketing.Core.Handler;
using Ticketing.Core.DataService;
using Moq;
using Ticketing.Core.Domain;

namespace Ticketing.Test
{
    public class Ticket_Booking_Request_Handler_Test
    {
        private readonly TicketBookingRequestHandler _handler;
        private readonly TicketBookingRequest _request;
        private readonly Mock<ITicketBookingService> _ticketBookingServiceMock;

        public Ticket_Booking_Request_Handler_Test()
        {
            //arrange - collect data

            _request = new TicketBookingRequest
            {
                Name = "Test Name",
                Family = "Test Family",
                Email = "Test Email",
            };

            _ticketBookingServiceMock = new Mock<ITicketBookingService>();

            _handler = new TicketBookingRequestHandler(_ticketBookingServiceMock.Object);
        }

        [Fact]
        public void Should_Return_Ticket_Booking_Response_With_Request_Values()
        {
            //act - pass data to method

            ServiceBookingResult Result =_handler.BookService(_request);

            //assert - pass tests

            Assert.NotNull(Result);
            Assert.Equal(_request.Name, Result.Name);
            Assert.Equal(_request.Family, Result.Family);
            Assert.Equal(_request.Email, Result.Email);

               //use shouldbe

            Result.ShouldNotBeNull();
            Result.Name.ShouldBe(_request.Name);
            Result.Family.ShouldBe(_request.Family);
            Result.Email.ShouldBe(_request.Email);
        }

        [Fact]
        public void Should_Throw_Exception_For_Null_Request()
        {
            var exception = Should.Throw<ArgumentNullException>(()=> _handler.BookService(null));
            exception.ParamName.ShouldBe("bookingRequest");

        }

        [Fact]
        public void Should_Save_Ticket_Booking_Request()
        {
            TicketBooking savedBooking = null;
            _ticketBookingServiceMock.Setup(x => x.Save(It.IsAny<TicketBooking>()))
                .Callback<TicketBooking>(result =>
                {
                    savedBooking = result;
                });

            _handler.BookService(_request);

            _ticketBookingServiceMock.Verify(x=>x.Save(It.IsAny<TicketBooking>()),Times.Once);

            //assert

            savedBooking.ShouldNotBeNull();
            savedBooking.Name.ShouldBe(_request.Name);
            savedBooking.Family.ShouldBe(_request.Family);
            savedBooking.Email.ShouldBe(_request.Email);

        }
    }
}
