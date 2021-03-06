﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="BookingCreate3.aspx.cs" Inherits="BookingEngine.Pages.BookingCreate3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server">
    Review details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>Review booking details</h1>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <dl>
        <asp:ListView ID="BookingDetailsListView" runat="server"
            ItemType="BookingEngine.Model.Room"
            DataKeyNames="RoomID"
            SelectMethod="BookingDetailsListView_GetData">
            <LayoutTemplate>
                <div class="ddgroup">
                <dt>You have selected the following:
                </dt>
                <dd>See room details below
                </dd>
                </div>
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </LayoutTemplate>
            <ItemTemplate>
                <div class="ddgroup">
                <dt>
                    <%#: Item.RoomName %>
                </dt>
                <dd>Room Type: <%#: Item.RoomType %>
                </dd>
                <dd>Room Price: <%#: Item.PricePerNight %>
                </dd>
                </div>
            </ItemTemplate>
            <EmptyDataTemplate>
                <p>
                    No selected rooms were found.
                </p>
            </EmptyDataTemplate>

        </asp:ListView>
        <asp:Button ID="SubmitButton" runat="server" Text="Confirm booking" OnClick="SubmitButton_Click" CssClass="button-link" Visible="false" />
    </dl>
    <p><asp:LinkButton ID="CancelButton" runat="server" Text="Cancel and return to My Bookings" CssClass="button-link" OnClick="CancelButton_Click" CausesValidation="false"></asp:LinkButton></p>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server">
</asp:Content>
