using System.Web.Routing;

namespace BookingEngine
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("BookingDelete", "booking/{id}/delete", "~/Pages/BookingDelete.aspx");
            routes.MapPageRoute("Bookings", "bookings", "~/Bookingslist.aspx");
            routes.MapPageRoute("BookingCreate", "booking/arrival", "~/Pages/BookingCreate1.aspx");
            routes.MapPageRoute("BookingCreate2", "booking/rooms", "~/Pages/BookingCreate2.aspx");
            routes.MapPageRoute("BookingCreate3", "booking/details", "~/Pages/BookingCreate3.aspx");
            routes.MapPageRoute("BookingChange", "booking/{id}", "~/Pages/BookingChange.aspx");
            routes.MapPageRoute("BookedRoomDelete", "room/{bookingId}/{roomId}/delete", "~/Pages/RoomDelete.aspx");

            routes.MapPageRoute("Error", "servererror", "~/Pages/Error.aspx");

            routes.MapPageRoute("Default", "", "~/Bookingslist.aspx");
        }
    }
}