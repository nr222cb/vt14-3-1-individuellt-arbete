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
        
        public void InsertBookedRoom(BookedRoom bookedRoom)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att 
                    // exekveras specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("usp_NewBookingPart2", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de paramterar den lagrade proceduren kräver. Använder här det effektiva sätttet att
                    // göra det på - något "svårare" men ASP.NET behöver inte "jobba" så mycket.
                    cmd.Parameters.Add("@BookingID", SqlDbType.Int, 4).Value = bookedRoom.BookingID;
                    cmd.Parameters.Add("@RoomID", SqlDbType.Int, 4).Value = bookedRoom.RoomID;
                    cmd.Parameters.Add("@Startdate", SqlDbType.Date).Value = bookedRoom.StartDate;
                    cmd.Parameters.Add("@Enddate", SqlDbType.Date).Value = bookedRoom.EndDate;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Den lagrade proceduren innehåller en INSERT-sats och returnerar inga poster varför metoden 
                    // ExecuteNonQuery används för att exekvera den lagrade proceduren.
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
    
    }
}