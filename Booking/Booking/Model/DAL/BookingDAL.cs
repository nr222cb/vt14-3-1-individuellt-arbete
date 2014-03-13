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

        public void DeleteBooking(int bookingId)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att 
                    // exekveras specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("dbo.usp_DelBooking", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till den paramter den lagrade proceduren kräver. Använder här det effektiva sätttet att
                    // göra det på - något "svårare" men ASP.NET behöver inte "jobba" så mycket.
                    cmd.Parameters.Add("@Bookingid", SqlDbType.Int, 4).Value = bookingId;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Den lagrade proceduren innehåller en DELETE-sats och returnerar inga poster varför metoden 
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

        // Metoden använder ett usp som gör insert i två tabeller. Svårt att validera data i BLL.
        // Säkerställer konsistent db om ngt skulle gå fel eftersom transaktionen lätt kan rullas tillbaka.
        public void MakeBooking(int amountPersons, int roomID, DateTime startDate, DateTime endDate)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att 
                    // exekveras specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("dbo.usp_NewBooking", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de paramterar den lagrade proceduren kräver. Använder här det effektiva sätttet att
                    // göra det på - något "svårare" men ASP.NET behöver inte "jobba" så mycket.
                    cmd.Parameters.Add("@AmountPersons", SqlDbType.Int, 4).Value = amountPersons;
                    cmd.Parameters.Add("@RoomID", SqlDbType.Int, 4).Value = roomID;
                    cmd.Parameters.Add("@Startdate", SqlDbType.Date).Value = startDate;
                    cmd.Parameters.Add("@Enddate", SqlDbType.Date).Value = endDate;

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