using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingEngine.Model
{
    public class Booking
    {
        public int BookingID { get; set; }
        public DateTime BookingDate { get; set; }
        public int CustomerID { get; set; }
        public int AmountPersons { get; set; }
    }
}