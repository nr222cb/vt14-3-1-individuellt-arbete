using System.Web.Routing;

namespace BookingEngine
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("BookingDelete", "booking/{id}/delete", "~/Pages/BookingDelete.aspx");
            routes.MapPageRoute("Customers", "kunder", "~/Pages/CustomerPages/Listing.aspx");
            routes.MapPageRoute("BookingCreate", "booking/new", "~/Pages/BookingCreate1.aspx");
            routes.MapPageRoute("BookingCreate2", "booking/new/rooms", "~/Pages/BookingCreate2.aspx");
            routes.MapPageRoute("CustomerDetails", "kunder/{id}", "~/Pages/CustomerPages/Details.aspx");
            routes.MapPageRoute("CustomerEdit", "kunder/{id}/edit", "~/Pages/CustomerPages/Edit.aspx");
            routes.MapPageRoute("ContactDelete", "kontakter/{id}/tabort", "~/Pages/ContactPages/Delete.aspx");

            routes.MapPageRoute("Error", "serverfel", "~/Pages/Shared/Error.aspx");

            routes.MapPageRoute("Default", "", "~/Bookingslist.aspx");
        }
    }
}