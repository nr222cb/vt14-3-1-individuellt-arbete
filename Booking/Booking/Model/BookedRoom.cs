using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingEngine.Model
{
    public class BookedRoom
    {
        public int BookingID { get; set; }
        public int RoomID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int AmountNights { get; set; }
    }
}