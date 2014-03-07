using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookingEngine.Model.DAL
{
    public class BookingDAL : DALBase
    {
        // Hämta ut alla bokningar fr tabellen Booking
        public IEnumerable<Booking> GetBookings()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var bookings = new List<Booking>(100);

                    var cmd = new SqlCommand("dbo.usp_GetBookings", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var bookingIdIndex = reader.GetOrdinal("BookingID");
                        var bookingDateIndex = reader.GetOrdinal("BookingDate");
                        var amountPersonsIndex = reader.GetOrdinal("AmountPersons");

                        while (reader.Read())
                        {
                            bookings.Add(new Booking
                            {
                                BookingID = reader.GetInt32(bookingIdIndex),
                                BookingDate = reader.GetDateTime(bookingDateIndex),
                                AmountPersons = reader.GetByte(amountPersonsIndex)
                            });
                        }

                    }

                    bookings.TrimExcess();

                    return bookings;

                }
                catch (Exception)
                {

                    throw new ApplicationException("An error occured while getting bookings from the database.");
                }
            }
        }
    }
}