using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookingEngine.Pages
{
    public partial class BookingCreate11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                DateTime arrivalDate = DateTime.Parse(DateTextBox.Text);
                Page.SetTempData("arrivalDate", arrivalDate);
                int amountNights = int.Parse(NumberTextBox.Text);
                Page.SetTempData("amountNights", amountNights);
                int amountPersons = int.Parse(AmountPersonsDropDown.Text);
                Page.SetTempData("amountPersons", amountPersons);

                Response.RedirectToRoute("BookingCreate2", null);
                Context.ApplicationInstance.CompleteRequest();
            }
        }
    }
}