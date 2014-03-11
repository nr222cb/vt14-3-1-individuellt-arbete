<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="BookingCreate2.aspx.cs" Inherits="BookingEngine.Pages.BookingCreate2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server">
    Choose rooms
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <dl>
    <asp:ListView ID="AvailRoomsListView" runat="server" 
        ItemType="BookingEngine.Model.Room" 
        DataKeyNames="RoomID" 
        SelectMethod="AvailRoomsListView_GetData">
        <LayoutTemplate>
            <dt>
                Room name
            </dt>
            <dd>
                Room details - tick the box to book the room
            </dd>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
        </LayoutTemplate>
        <ItemTemplate>
            <dt>
                <%#: Item.RoomName %>
            </dt>
            <dd>
                Room Type: <%#: Item.RoomType %>
            </dd>
            <dd>
                Room Price: <%#: Item.PricePerNight %>
            </dd>
            <dd>
                <asp:CheckBox ID="RoomCheckBox" runat="server" />
            </dd>
        </ItemTemplate>
        <EmptyDataTemplate>
            <p>
                No rooms were found for this period.
            </p>
        </EmptyDataTemplate>

    </asp:ListView>
    <asp:Button ID="SubmitButton" runat="server" Text="Book now" OnClick="SubmitButton_Click" Visible="False" />
    </dl>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server">
</asp:Content>
