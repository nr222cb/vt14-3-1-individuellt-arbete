using BookingEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookingEngine.Pages
{
    public partial class BookingCreate2 : System.Web.UI.Page
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
        
        // Hämta ut tillgängliga rum mha sparade sessionsvariabler
        public List<BookingEngine.Model.Room> AvailRoomsListView_GetData()
        {
            try
            {
                DateTime startDate = DateTime.Parse(Page.GetAndKeepTempData("arrivalDate").ToString());
                //int? amountNights = Page.GetTempData("amountNights") as int?;
                int amountNights = int.Parse(Page.GetAndKeepTempData("amountNights").ToString());
                DateTime endDate = startDate.AddDays(amountNights);
                SubmitButton.Visible = true;

                return Service.GetAvailRooms(startDate, endDate);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Error while fetching the available rooms.");
                return null;
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            List<int> selectedRooms = new List<int>();

            // Hitta alla checkboxar och kolla status på dem och lägga till valda rum i en lista
            foreach (ListViewItem item in AvailRoomsListView.Items)
            {
                CheckBox cb = (CheckBox)item.FindControl("RoomCheckbox");

                if (cb.Checked)
                {
                    int id = Convert.ToInt32(AvailRoomsListView.DataKeys[item.DisplayIndex].Value);
                    selectedRooms.Add(id);
                }
            }
            // Lägger till valda rum i en sessionsvariabel
            Page.SetTempData("selectedRooms", selectedRooms);

            Response.RedirectToRoute("BookingCreate3", null);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}