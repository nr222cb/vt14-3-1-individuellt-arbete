using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookingEngine.Model.DAL
{
    public class BookedRoomDAL : DALBase
    {
        public List<BookedRoom> GetBookedRoomByBookingId(int bookingId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("dbo.usp_GetBookedRoomByBookingId", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BookingId", bookingId);

                    List<BookedRoom> bookedRooms = new List<BookedRoom>(10);

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var bookingIdIndex = reader.GetOrdinal("BookingID");
                        var roomIdIndex = reader.GetOrdinal("RoomID");
                        var startDateIndex = reader.GetOrdinal("StartDate");
                        var endDateIndex = reader.GetOrdinal("EndDate");
                        var amountNightsIndex = reader.GetOrdinal("AmountNights");

                        while (reader.Read())
                        {
                            bookedRooms.Add(new BookedRoom
                            {
                                BookingID = reader.GetInt32(bookingIdIndex),
                                RoomID = reader.GetInt32(roomIdIndex),
                                StartDate = reader.GetDateTime(startDateIndex),
                                EndDate = reader.GetDateTime(endDateIndex),
                                AmountNights = reader.GetInt32(amountNightsIndex)
                            });
                        }

                        bookedRooms.TrimExcess();

                        return bookedRooms;
                    }
                }
                catch
                {
                    throw new ApplicationException("An error occured while getting booked rooms from the database.");
                }
            }
        }
    }
}