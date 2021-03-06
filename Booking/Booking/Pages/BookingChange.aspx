﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="BookingChange.aspx.cs" Inherits="BookingEngine.Pages.BookingChange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>Change booking
        <asp:Literal runat="server" Text="<%$ RouteValue:id%>" />
    </h1>
    <p>* You can delete a booked room only if the booking contains several rooms!</p>
    <p>* To cancel the booking go to My bookings!</p>
    <asp:Panel runat="server" ID="SuccessMessagePanel" Visible="false" CssClass="icon-ok">
        <asp:Literal runat="server" ID="SuccessMessageLiteral" />
    </asp:Panel>
    <asp:ListView ID="BookingChangeListView" runat="server"
        ItemType="BookingEngine.Model.BookedRoom"
        DataKeyNames="BookingID"
        SelectMethod="BookingChangeListView_GetData">
        <LayoutTemplate>
            <asp:Button ID="AddRoomsButton" runat="server" Text="Add more rooms" CssClass="button-link" OnClick="AddRoomsButton_Click" />
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
        </LayoutTemplate>
        <ItemTemplate>
            <dl>
            <asp:Repeater ID="RoomRepeater" runat="server"
                ItemType="BookingEngine.Model.Room"
                DataSource='<%# GetReferences(Item.RoomID) %>' 
                OnItemDataBound="RoomRepeater_ItemDataBound">
                <ItemTemplate>
                        <dt>
                            <%# Item.RoomName %> (<%# Item.RoomType %>)
                            <asp:HyperLink ID="delLink" runat="server" Text="Delete room" NavigateUrl='<%# GetRouteUrl("BookedRoomDelete", new { bookingId = RouteData.Values["id"], roomId = Item.RoomID }) %>' CssClass="button-link" Visible="false"></asp:HyperLink>
                        </dt>
                        <div class="paper">
                        <dd>Price per Night: EUR <%# Item.PricePerNight %>
                        </dd>
                </ItemTemplate>
            </asp:Repeater>
            <dd>Arriving on <%#: Item.StartDate.ToShortDateString() %>
            </dd>
            <dd>Leaving on <%#: Item.EndDate.ToShortDateString() %>
            </dd>
            <dd>Staying <%#: Item.AmountNights %> Night(s)
            </dd>
            </div>
            </dl>
        </ItemTemplate>
    </asp:ListView>
    <asp:LinkButton ID="CancelButton" runat="server" Text="Return to My Bookings" CssClass="button-link" OnClick="CancelButton_Click"></asp:LinkButton>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server">
</asp:Content>
