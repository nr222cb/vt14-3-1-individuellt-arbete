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
        private RoomDAL _roomDal;

        private BookingDAL BookingDAL
        {
            get { return _bookingDAL ?? (_bookingDAL = new BookingDAL()); }
        }

        private BookedRoomDAL BookedRoomDAL
        {
            get { return _bookedRoomDal ?? (_bookedRoomDal = new BookedRoomDAL()); }
        }

        private RoomDAL RoomDAL
        {
            get { return _roomDal ?? (_roomDal = new RoomDAL()); }
        }

        // Hämta ut alla bokningar fr tabellen Booking
        public IEnumerable<Booking> GetBookings()
        {
            return BookingDAL.GetBookings();
        }

        // Hämta ut BookedRoom mha BookingID
        public List<BookedRoom> GetBookedRoom(int bookingId)
        {
            return BookedRoomDAL.GetBookedRoomByBookingId(bookingId);
        }

        // Hämta ut Room mha RoomID
        public List<Room> GetRoom(int roomId)
        {
            return RoomDAL.GetRoomByRoomId(roomId);
        }

        // Hämta ut tillgängliga rum
        public List<Room> GetAvailRooms(DateTime startDate, DateTime endDate)
        {
            return RoomDAL.GetAvailRooms(startDate, endDate);
        }

        // Ta bort Booking
        public void DeleteBooking(int bookingId)
        {
            BookingDAL.DeleteBooking(bookingId);
        }

        // Skapa en bokning
        public void MakeBooking(int amountPersons, int roomID, DateTime startDate, DateTime endDate)
        {
            BookingDAL.MakeBooking(amountPersons, roomID, startDate, endDate);
        }

    }
}