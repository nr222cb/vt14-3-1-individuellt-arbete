<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookingsList.aspx.cs" Inherits="BookingEngine.BookingsList" ViewStateMode="Disabled" %>

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
            <div>
                <asp:Panel runat="server" ID="SuccessMessagePanel" Visible="false" CssClass="icon-ok">
                    <asp:Literal runat="server" ID="SuccessMessageLiteral" />
                </asp:Panel>
            </div>
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
                            <dt>Booking <%#: Item.BookingID %>, booked on <%#: Item.BookingDate.ToShortDateString() %> for <%#: Item.AmountPersons %> Person(s)
                                <br />
                                <asp:HyperLink runat="server" Text="Cancel booking" NavigateUrl='<%# GetRouteUrl("BookingDelete", new { id = Item.BookingID }) %>' />
                            </dt>
                            <asp:ListView ID="BookedRoomListView" runat="server"
                                ItemType="BookingEngine.Model.BookedRoom"
                                DataKeyNames="BookingID"
                                SelectMethod="BookedRoomListView_GetItem">
                                <ItemTemplate>
                                    <asp:Repeater ID="RoomListView" runat="server"
                                        ItemType="BookingEngine.Model.Room"
                                        DataSource='<%# GetReferences(Item.RoomID) %>'>
                                        <ItemTemplate>
                                            <dd>
                                                <%# Item.RoomName %> (<%# Item.RoomType %>)
                                            </dd>
                                            <dd>Price per Night: EUR <%# Item.PricePerNight %>
                                            </dd>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <dd>Arriving on <%#: Item.StartDate.ToShortDateString() %>
                                    </dd>
                                    <dd>Leaving on <%#: Item.EndDate.ToShortDateString() %>
                                    </dd>
                                    <dd>Staying <%#: Item.AmountNights %> Nights
                                    </dd>
                                    <hr />
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    <p>No booked rooms found</p>
                                </EmptyDataTemplate>
                            </asp:ListView>
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
        </div>
    </form>
    <script src="Scripts/jquery-2.1.0.js" type="text/javascript"></script>
    <script src="Scripts/app.js" type="text/javascript"></script>
</body>
</html>
