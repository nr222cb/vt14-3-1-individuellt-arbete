using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookingEngine.Model;

namespace BookingEngine
{
    public partial class BookingsList : System.Web.UI.Page
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

        }

        public IEnumerable<Booking> BookingsListView_GetData()
        {
            try
            {
                return Service.GetBookings();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Error while fetching the bookings.");
                return null;
            }
        }

        public IEnumerable<BookedRoom> BookedRoomListView_GetItem()
        {
            try
            {
                // Hämta ut ListView kontrollen
                ListView lv = Page.FindControl("BookingsListView") as ListView;

                // Hämta ut värdet för aktuellt datakey så att det kan användas i metoden GetBookedRoom som inparameter
                int test = 1;
                foreach (DataKey key in lv.DataKeys)
                {
                    test = Convert.ToInt32(key.Value.ToString());
                }

                return Service.GetBookedRoom(test);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Error while fetching the booked rooms.");
                return null;
            }
        }

        //RoomFormView_GetItem([Control("BookedRoomListView")]int? roomID)
        //Det nya sättet med value providers funkar ej

        public IEnumerable<Room> GetReferences(int id)
        {
            return Service.GetRoom(id);
        }

    }
}