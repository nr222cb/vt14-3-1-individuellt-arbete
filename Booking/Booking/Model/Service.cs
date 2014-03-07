using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookingEngine.Model.DAL;

namespace BookingEngine.Model
{
    public class Service
    {
        private BookingDAL _bookingDAL;
        private BookedRoomDAL _bookedRoomDal;

        private BookingDAL BookingDAL
        {
            get { return _bookingDAL ?? (_bookingDAL = new BookingDAL()); }
        }

        private BookedRoomDAL BookedRoomDAL
        {
            get { return _bookedRoomDal ?? (_bookedRoomDal = new BookedRoomDAL()); }
        }

        // Hämta ut alla bokningar fr tabellen Booking
        public IEnumerable<Booking> GetBookings()
        {
            return BookingDAL.GetBookings();
        }

        // Hämta ut BookedRoom mha BookingID
        public BookedRoom GetBookedRoom(int bookingId)
        {
            return BookedRoomDAL.GetBookedRoomByBookingId(bookingId);
        }
    }
}