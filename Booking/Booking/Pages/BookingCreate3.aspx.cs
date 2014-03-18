using BookingEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookingEngine.Pages
{
    public partial class BookingCreate3 : System.Web.UI.Page
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

        public List<BookingEngine.Model.Room> BookingDetailsListView_GetData()
        {
            try
            {
                // skapa en tom lista för resultatet
                List<Room> resultRooms = new List<Room>();
                // hämta valda rum från sessionsvariabel
                List<int> selRooms = Page.GetAndKeepTempData("selectedRooms") as List<int>;
                // visa confirm-knappen om det finns rum att boka
                if (selRooms.Count() != 0)
                {
                    SubmitButton.Visible = true;
                }
                // för varje valt rum hämta information från db
                foreach (int id in selRooms)
                {
                    resultRooms.AddRange(Service.GetRoom(id));
                }

                return resultRooms;
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Error while fetching the selected rooms.");
                return null;
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                int amountPersons = int.Parse(Page.GetTempData("amountPersons").ToString());
                DateTime startDate = DateTime.Parse(Page.GetTempData("arrivalDate").ToString());
                int amountNights = int.Parse(Page.GetTempData("amountNights").ToString());
                DateTime endDate = startDate.AddDays(amountNights);

                // hämta valda rum från sessionsvariabel
                List<int> selRooms = Page.GetTempData("selectedRooms") as List<int>;

                // skapa nytt booking objekt och skicka det till SaveBooking
                Booking booking = new Booking();

                // om sessionsvariabel finns
                if (Session["bookingId"] != null)
                {
                    // hämta boookingId från sessionsvariabel och tilldela objektet egenskapen bookingId
                    int bookingId = int.Parse(Page.GetAndKeepTempData("bookingId").ToString());
                    booking.BookingID = bookingId;
                }

                booking.AmountPersons = amountPersons;
                Service.SaveBooking(booking);

                // skapa nytt BookedRoom objekt och skicka det till SaveBookedRoom
                BookedRoom bookedRoom = new BookedRoom();
                bookedRoom.BookingID = booking.BookingID;
                bookedRoom.StartDate = startDate;
                bookedRoom.EndDate = endDate;
                
                foreach (int id in selRooms)
                {
                    bookedRoom.RoomID = id;
                    Service.SaveBookedRoom(bookedRoom);
                }
                
                // om det finns bookingId i session skicka tillbaka till Change booking
                if (Session["bookingId"] != null)
                {
                    Page.SetTempData("SuccessMessage", "The room was added successfully.");
                    int bookingId = int.Parse(Page.GetTempData("bookingId").ToString());
                    Response.RedirectToRoute("BookingChange", new { id = bookingId });
                    Context.ApplicationInstance.CompleteRequest();
                }

                // annars till bokningslistan
                else
                {
                    Page.SetTempData("SuccessMessage", "The Booking was made successfully.");
                    Response.RedirectToRoute("Default", null);
                    Context.ApplicationInstance.CompleteRequest();
                }

            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Error while making a booking");
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.RedirectToRoute("Default", null);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}