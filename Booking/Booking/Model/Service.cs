using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        // Ta bort BookedRoom
        public void DeleteBookedRoom(int bookingId, int roomId)
        {
            BookedRoomDAL.DeleteBookedRoom(bookingId, roomId);
        }

        public void SaveBooking(Booking booking)
        {
            // Uppfyller inte objektet affärsreglerna...
            ICollection<ValidationResult> validationResults;
            if (!booking.Validate(out validationResults)) // Använder "extension method" för valideringen!
            {                                              // Klassen finns under App_Infrastructure.
                // ...kastas ett undantag med ett allmänt felmeddelande samt en referens 
                // till samlingen med resultat av valideringen.
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }

            // Booking-objektet sparas antingen genom att en ny post 
            // skapas eller genom att en befintlig post uppdateras.
            if (booking.BookingID == 0) // Ny post om CustomerId är 0!
            {
                BookingDAL.InsertBooking(booking);
            }
            else
            {
                BookingDAL.UpdateBooking(booking);
            }
        }

        public void SaveBookedRoom(BookedRoom bookedRoom)
        {
            // Uppfyller inte objektet affärsreglerna...
            ICollection<ValidationResult> validationResults;
            if (!bookedRoom.Validate(out validationResults)) // Använder "extension method" för valideringen!
            {                                              // Klassen finns under App_Infrastructure.
                // ...kastas ett undantag med ett allmänt felmeddelande samt en referens 
                // till samlingen med resultat av valideringen.
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }

            // BookedRoom-objektet sparas genom att en ny post 
            // skapas
            BookedRoomDAL.InsertBookedRoom(bookedRoom);
        }

    }
}