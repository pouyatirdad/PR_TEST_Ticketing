﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Core.Model;

namespace Ticketing.Core.Domain
{
    public class TicketBooking : ServiceBookingBase
    {
        public int Id { get; set; }
    }
}
