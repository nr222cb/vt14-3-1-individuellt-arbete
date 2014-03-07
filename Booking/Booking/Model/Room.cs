using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingEngine.Model
{
    public class Room
    {
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public string RoomType { get; set; }
        public decimal PricePerNight { get; set; }
    }
}