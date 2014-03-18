<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="BookingDelete.aspx.cs" Inherits="BookingEngine.Pages.BookingDelete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div>
        <h1>Delete Booking</h1>
        <asp:ValidationSummary runat="server" CssClass="validation-summary-errors" />
        <p>
            Are you sure you want to delete Booking
            <asp:Literal runat="server" Text="<%$ RouteValue:id%>" />?
        </p>
    </div>
    <div>
        <p>
        <asp:LinkButton runat="server" ID="DeleteLinkButton" Text="Yes, delete the booking"
            OnCommand="DeleteLinkButton_Command" CommandArgument='<%$ RouteValue:id %>' CssClass="button-link" />
        </p>
        <p>
        <asp:HyperLink runat="server" ID="CancelHyperLink" Text="Cancel" NavigateUrl="<%$ RouteUrl:RouteName=Default %>" CssClass="button-link" />
        </p>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server">
</asp:Content>
