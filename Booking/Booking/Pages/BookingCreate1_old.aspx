<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookingCreate1_old.aspx.cs" Inherits="BookingEngine.Pages.BookingCreate1" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css" />
    <link rel="stylesheet" href="/Content/StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
        <fieldset>
        <legend>Choose the dates for your stay!</legend>
        <div>
            <div>
                <label for="DateTextBox">Choose your arrival date:</label>
            </div>
            <div>
                <asp:TextBox ID="DateTextBox" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="NumberTextBox">How many nights?</label>
            </div>
            <div>
                <asp:TextBox ID="NumberTextBox" runat="server"></asp:TextBox>
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
                <asp:Button ID="SearchButton" runat="server" Text="Search for rooms" CssClass=".button-link" OnClick="SearchButton_Click" />
            </p>
        </div>
        </fieldset>
    </form>
    <script src="/Scripts/jquery-2.1.0.js" type="text/javascript"></script>
    <script src="//code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
    <script src="/Scripts/app.js" type="text/javascript"></script>
</body>
</html>
