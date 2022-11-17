<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Prototype8.LoginPage"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style ="vertical-align:middle">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="MenuStyles.css"/>
</head>

<body style="height: 575px; background: linear-gradient(90deg, rgba(40, 40, 40, 1) 0%, rgba(30, 30, 30, 1) 100%);">
    <form id="LoginForm" runat="server">

        <asp:Panel ID="pnlLogin" runat="server" style="height: 505px;" CssClass="Panel">

            <asp:Label ID="lblLogin" runat="server" CssClass="BigLabel">Sign In</asp:Label>

            <asp:Label ID="lblUsername" runat="server" style = "top: 102px;" CssClass="Heading">Username</asp:Label>

            <asp:Label ID="lblError" runat="server" style = "top: 188px;" CssClass="Error"></asp:Label>

            <asp:Label ID="lblPassword" runat="server" style = "top: 213px;" CssClass="Heading">Password</asp:Label>

            <asp:Label ID="lblNoAccount" runat="server" style = "position:absolute; left: 75px; top: 386px;" Font-Bold="False" Font-Names="Segoe UI" Font-Size="12pt" ForeColor="White"
                >Don't have an account?</asp:Label>

            <asp:Panel ID="pnlUN" runat="server" style = "top: 136px;" CssClass="TextPanel">
                <asp:TextBox ID="txtLoginUsername" runat="server" Text="Zohaib1" CssClass="TextBox"></asp:TextBox>
            </asp:Panel>

            <asp:Panel ID="pnlPW" runat="server" style = "top: 247px;" CssClass="TextPanel">
                <asp:TextBox ID="txtLoginPassword" runat="server" Text="Password1" CssClass="TextBox"></asp:TextBox>
            </asp:Panel>

            <asp:Button ID="btnLogin" runat="server" style = "top: 323px;" CssClass="BigButton" Text="SIGN IN" FlatStyle="Flat" OnClick="btnLogin_Click"/>

            <asp:Button ID="btnRegister" runat="server" style = "left: 253px; top: 384px; width: 72px; height: 26px;" CssClass="SmallButton" Text="Register" FlatStyle="Flat" OnClick="btnRegister_Click"/>

            <asp:Button ID="btnGuest" runat="server" style = "left: 132px; top: 422px; width: 135px; height: 24px;" CssClass="SmallButton" Text="Continue as Guest" FlatStyle="Flat" OnClick="btnGuest_Click"/>

        </asp:Panel>

    </form>
</body>
</html>
