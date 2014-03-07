using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookingEngine.Model;

namespace BookingEngine
{
    public partial class BookingsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Booking> BookingsListView_GetData()
        {
            try
            {
                Service service = new Service();
                return service.GetBookings();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Error while fetching the bookings.");
                return null;
            }
        }

        public BookedRoom BookedRoomFormView_GetItem()
        {
            // Hämta ut ListView kontrollen
            ListView lv = Page.FindControl("BookingsListView") as ListView;
            // Hämta ut värdet för aktuellt datakey så att det kan användas i metoden GetBookedRoom som inparameter
            int test = 1;
            foreach (DataKey key in lv.DataKeys)
            {
                test = Convert.ToInt32(key.Value.ToString());
            }

            Service service = new Service();
            return service.GetBookedRoom(test);
        }
    }
}