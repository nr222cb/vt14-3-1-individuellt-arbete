using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookingEngine.Model
{
    public class Booking
    {
        public int BookingID { get; set; }
        public DateTime BookingDate { get; set; }
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Number of persons is required.")]
        [Range(1, 10, ErrorMessage = "Number of persons in the booking cannot exceed 10")]
        public int AmountPersons { get; set; }
    }
}