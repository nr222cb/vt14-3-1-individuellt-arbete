﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookingsList.aspx.cs" Inherits="BookingEngine.BookingsList" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My bookings</title>
    <link rel="stylesheet" href="Content/StyleSheet.css" />
</head>
<body>
    <h1>My Bookings</h1>
    <form id="form1" runat="server">
    <div>

        <asp:ListView ID="BookingsListView" runat="server"
        ItemType="BookingEngine.Model.Booking"
        SelectMethod="BookingsListView_GetData"
        DataKeyNames="BookingID">
        <LayoutTemplate>
            <%-- Platshållare för bokningar --%>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
        </LayoutTemplate>
        <ItemTemplate>
            <dl>
                <dt>
                    Booking <%#: Item.BookingID %>, booked on <%#: Item.BookingDate.ToShortDateString() %> for <%#: Item.AmountPersons %> Persons
                </dt>
                <asp:FormView ID="BookedRoomFormView" runat="server"
                    ItemType="BookingEngine.Model.BookedRoom"
                    DataKeyNames="BookingID"
                    SelectMethod="BookedRoomFormView_GetItem">
                    <ItemTemplate>
                        <dd>
                            Room No <%#: Item.RoomID %>
                        </dd>
                        <dd>
                            Arriving on <%#: Item.StartDate.ToShortDateString() %>
                        </dd>
                        <dd>
                            Leaving on <%#: Item.EndDate.ToShortDateString() %>
                        </dd>
                        <dd>
                            Staying <%#: Item.AmountNights %> Nights
                        </dd>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <p>No booked rooms found</p>
                    </EmptyDataTemplate>
                </asp:FormView>
            </dl>
        </ItemTemplate>
        <EmptyDataTemplate>
            <%-- Detta visas då bokningar saknas i databasen. --%>
            <p>
                No bookings found.
            </p>
        </EmptyDataTemplate>
    </asp:ListView>
    
    </div>
    </form>
</body>
</html>