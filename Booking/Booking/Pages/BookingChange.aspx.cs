using BookingEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;

namespace BookingEngine.Pages
{
    public partial class BookingChange : System.Web.UI.Page
    {
        private Service _service;
        private Service Service
        {
            // Ett Service-objekt skapas först då det behövs för första 
            // gången (lazy initialization, http://en.wikipedia.org/wiki/Lazy_initialization).
            get { return _service ?? (_service = new Service()); }
        }

        private int itemCount;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Hämta och visa (rätt)meddelande, om det finns något meddelande. (Meddelandet hämtas 
            // från en "temporär" sessionsvariabel som kapslas in av en "extension method" 
            // i App_Infrastructure/PageExtensions.)
            // Del av designmönstret Post-Redirect-Get (PRG, http://en.wikipedia.org/wiki/Post/Redirect/Get).
            SuccessMessageLiteral.Text = Page.GetTempData("SuccessMessage") as string;
            SuccessMessagePanel.Visible = !String.IsNullOrWhiteSpace(SuccessMessageLiteral.Text);
        }

        public IEnumerable<BookedRoom> BookingChangeListView_GetData([RouteData]int id)
        {
            try
            {
                // ett alternativ till DouteData som inparameter i BookingChangeListView_GetData
                //int id = Convert.ToInt32(Page.RouteData.Values["id"]);
                IEnumerable<BookedRoom> result = Service.GetBookedRoom(id);

                // lagra antalet rader i resultatet
                itemCount = result.Count();
                return result;
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Error while fetching the booked rooms.");
                return null;
            }
        }

        public IEnumerable<Room> GetReferences(int id)
        {
            try
            {
                return Service.GetRoom(id);
            }
            catch (Exception)
            {

                ModelState.AddModelError(String.Empty, "Error while fetching the rooms.");
                return null;
            }
        }

        protected void RoomRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HyperLink delLink = (HyperLink)e.Item.FindControl("delLink");
            // Om det finns fler rum än 1 i bokningen visa Delete-länken
            if (itemCount > 1)
            {
                delLink.Visible = true;
            }
        }

        // sätter sessionsvariabel för bookingId om man kommer från Change booking
        protected void AddRoomsButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Page.RouteData.Values["id"]);
            Page.SetTempData("bookingId", id);

            Response.RedirectToRoute("BookingCreate", null);
            Context.ApplicationInstance.CompleteRequest();
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.RedirectToRoute("Default", null);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}