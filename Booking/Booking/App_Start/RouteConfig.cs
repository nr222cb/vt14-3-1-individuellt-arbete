﻿using System.Web.Routing;

namespace BookingEngine
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("BookingDelete", "booking/{id}/delete", "~/Pages/BookingDelete.aspx");
            routes.MapPageRoute("Bookings", "bookings", "~/Bookingslist.aspx");
            routes.MapPageRoute("BookingCreate", "booking/new", "~/Pages/BookingCreate1.aspx");
            routes.MapPageRoute("BookingCreate2", "booking/new/rooms", "~/Pages/BookingCreate2.aspx");
            routes.MapPageRoute("BookingCreate3", "booking/new/details", "~/Pages/BookingCreate3.aspx");
            routes.MapPageRoute("BookingChange", "booking/{id}", "~/Pages/BookingChange.aspx");
            routes.MapPageRoute("CustomerEdit", "kunder/{id}/edit", "~/Pages/CustomerPages/Edit.aspx");
            routes.MapPageRoute("BookedRoomDelete", "room/{bookingId}/{roomId}/delete", "~/Pages/RoomDelete.aspx");

            routes.MapPageRoute("Error", "serverfel", "~/Pages/Shared/Error.aspx");

            routes.MapPageRoute("Default", "", "~/Bookingslist.aspx");
        }
    }
}