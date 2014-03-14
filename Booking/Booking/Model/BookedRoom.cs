using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookingEngine.Model
{
    public class BookedRoom
    {
        [Required(ErrorMessage = "BookingID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "BookingID must be an integer")]
        public int BookingID { get; set; }

        [Required(ErrorMessage = "RoomID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "RoomID must be an integer")]
        public int RoomID { get; set; }

        [Required(ErrorMessage = "StartDate is required")]
        [DataType(DataType.DateTime, ErrorMessage = "Must be of type DateTime")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "EndDate is required")]
        [DataType(DataType.DateTime, ErrorMessage = "Must be of type DateTime")]
        public DateTime EndDate { get; set; }

        public int AmountNights { get; set; }
    }
}