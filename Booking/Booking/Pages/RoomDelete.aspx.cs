using BookingEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookingEngine.Pages
{
    public partial class RoomDelete : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            // Ett Service-objekt skapas först då det behövs för första 
            // gången (lazy initialization, http://en.wikipedia.org/wiki/Lazy_initialization).
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Sätta cancel-hyperlänken tillbaka till aktuell bokning
            int bookingId = Convert.ToInt32(Page.RouteData.Values["bookingId"]);
            RouteValueDictionary parameters = new RouteValueDictionary  
            { 
                {"id", bookingId }
            };
            VirtualPathData vpd = RouteTable.Routes.GetVirtualPath(null, "BookingChange", parameters);
            CancelHyperLink.NavigateUrl = vpd.VirtualPath;
        }

        protected void DeleteLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Hämta bookingId samt roomId från RouteDate och ta bort rummet
                int bookingId = Convert.ToInt32(Page.RouteData.Values["bookingId"]);
                int roomId = Convert.ToInt32(Page.RouteData.Values["roomId"]);

                Service.DeleteBookedRoom(bookingId, roomId);

                Page.SetTempData("SuccessMessage", "The room was deleted.");
                Response.RedirectToRoute("BookingChange", new { id = bookingId});
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Error occured while deleting a room");
            }
        }
    }
}