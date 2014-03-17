<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="RoomDelete.aspx.cs" Inherits="BookingEngine.Pages.RoomDelete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div>
    <h1>Delete Room</h1>
    <asp:ValidationSummary runat="server" CssClass="validation-summary-errors" />
    <p>
        Are you sure you want to delete this room from booking
        <asp:Literal runat="server" Text="<%$ RouteValue:bookingId%>" />?
    </p>
    </div>
    <div>
        <p>
        <asp:LinkButton runat="server" ID="DeleteLinkButton" Text="Yes, delete the room" OnClick="DeleteLinkButton_Click" CssClass="button-link" />
        </p>
        <p>
        <asp:HyperLink runat="server" ID="CancelHyperLink" Text="Cancel" CssClass="button-link" />
        </p>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server">
</asp:Content>
