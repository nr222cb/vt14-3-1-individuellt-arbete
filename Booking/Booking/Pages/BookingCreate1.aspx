<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="BookingCreate1.aspx.cs" Inherits="BookingEngine.Pages.BookingCreate11" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server">
    Choose arrival date
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>Choose arrival date</h1>
    <fieldset>
        <legend>Choose the dates for your stay!</legend>
        <div>
            <div>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            </div>
            <div>
                <label for="DateTextBox">Choose your arrival date:</label>
            </div>
            <div>
                <asp:TextBox ID="DateTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You must choose arrival date." ControlToValidate="DateTextBox" Display="Dynamic" SetFocusOnError="True" Text="*"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Enter a date." ControlToValidate="DateTextBox" Operator="DataTypeCheck" Type="Date" Text="*" SetFocusOnError="True" Display="Dynamic"></asp:CompareValidator>
                <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="Select a date from today" ControlToValidate="DateTextBox" Display="Dynamic" Operator="GreaterThanEqual" SetFocusOnError="True" Text="*" Type="Date"></asp:CompareValidator>
            </div>
            <div>
                <label for="NumberTextBox">How many nights?</label>
            </div>
            <div>
                <asp:TextBox ID="NumberTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="You must choose how many nights you are staying." ControlToValidate="NumberTextBox" Display="Dynamic" SetFocusOnError="True" Text="*"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Enter a number." ControlToValidate="NumberTextBox" Display="Dynamic" Operator="DataTypeCheck" SetFocusOnError="True" Text="*" Type="Integer"></asp:CompareValidator>
            </div>
            <div>
                <label for="AmountPersonsDropDown">How many are you?</label>
            </div>
            <div>
                <asp:DropDownList ID="AmountPersonsDropDown" runat="server">
                    <asp:ListItem Value="1"> 1 Person </asp:ListItem>
                    <asp:ListItem Value="2"> 2 Persons </asp:ListItem>
                </asp:DropDownList>
            </div>
            <p>
                <asp:Button ID="SearchButton" runat="server" Text="Search for rooms" CssClass="button-link" OnClick="SearchButton_Click" />
            </p>
        </div>
    </fieldset>
    <p><asp:LinkButton ID="CancelButton" runat="server" Text="Cancel and return to My Bookings" CssClass="button-link" OnClick="CancelButton_Click" CausesValidation="false"></asp:LinkButton></p>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server">
    <script src="//code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
</asp:Content>
