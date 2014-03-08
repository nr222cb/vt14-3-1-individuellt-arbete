using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookingEngine.Model.DAL
{
    public class RoomDAL : DALBase
    {
        public List<Room> GetRoomByRoomId(int roomId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("dbo.usp_GetRoomByRoomId", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RoomId", roomId);

                    List<Room> room = new List<Room>(10);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var roomIdIndex = reader.GetOrdinal("RoomID");
                        var roomNameIndex = reader.GetOrdinal("RoomName");
                        var roomTypeIndex = reader.GetOrdinal("RoomType");
                        var pricePerNightIndex = reader.GetOrdinal("PricePerNight");

                        while (reader.Read())
                        {
                            room.Add(new Room
                            {
                                RoomID = reader.GetInt32(roomIdIndex),
                                RoomName = reader.GetString(roomNameIndex),
                                RoomType = reader.GetString(roomTypeIndex),
                                PricePerNight = reader.GetDecimal(pricePerNightIndex)
                            });
                        }

                        room.TrimExcess();

                        return room;

                    }
                }
                catch
                {
                    throw new ApplicationException("An error occured while getting rooms from the database.");
                }
            }
        }
    }
}