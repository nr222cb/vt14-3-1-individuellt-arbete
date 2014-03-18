<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="BookingCreate2.aspx.cs" Inherits="BookingEngine.Pages.BookingCreate2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server">
    Choose rooms
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>Choose rooms</h1>
    <dl>
    <asp:ListView ID="AvailRoomsListView" runat="server" 
        ItemType="BookingEngine.Model.Room" 
        DataKeyNames="RoomID" 
        SelectMethod="AvailRoomsListView_GetData">
        <LayoutTemplate>
            <div class="ddgroup">
            <dt>
                Room name
            </dt>
            <dd>
                Room details - tick the box to book the room
            </dd>
            </div>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
        </LayoutTemplate>
        <ItemTemplate>
            <div class="ddgroup">
            <dt>
                <%#: Item.RoomName %>
            </dt>
            <dd class="ddgroup">
                Room Type: <%#: Item.RoomType %>
            </dd>
            <dd class="ddgroup">
                Room Price: <%#: Item.PricePerNight %>
            </dd>
            <dd>
                <asp:CheckBox ID="RoomCheckBox" runat="server" />
            </dd>
            </div>
        </ItemTemplate>
        <EmptyDataTemplate>
            <p>
                No rooms were found for this period.
            </p>
        </EmptyDataTemplate>

    </asp:ListView>
    <asp:Button ID="SubmitButton" runat="server" Text="Book now" OnClick="SubmitButton_Click" Visible="False" CssClass="button-link" />
    </dl>
    <p><asp:LinkButton ID="CancelButton" runat="server" Text="Cancel" CssClass="button-link" OnClick="CancelButton_Click" CausesValidation="false"></asp:LinkButton></p>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server">
</asp:Content>
