<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookingDelete.aspx.cs" Inherits="BookingEngine.Pages.BookingDelete" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Delete Booking</h1>
        <asp:ValidationSummary runat="server" CssClass="validation-summary-errors" />
        <p>
            Are you sure you want to delete Booking <asp:Literal runat="server" Text="<%$ RouteValue:id%>" />?
        </p>
    </div>
    <div>
        <asp:LinkButton runat="server" ID="DeleteLinkButton" Text="Yes, delete the booking"
            OnCommand="DeleteLinkButton_Command" CommandArgument='<%$ RouteValue:id %>' />
        <br />
        <asp:HyperLink runat="server" ID="CancelHyperLink" Text="Cancel" NavigateUrl="<%$ RouteUrl:RouteName=Default %>" />
    </div>
    </form>
</body>
</html>
