<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="Prototype8.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="MenuStyles.css"/>
</head>
<body style="height: 500px; background: linear-gradient(90deg, rgba(50, 50, 50, 1) 0%, rgba(30, 30, 30, 1) 100%);">
    <form id="RegisterForm" runat="server">

        <asp:Panel ID="pnlRegister" runat="server" style="height: 535px;" CssClass="Panel">

            <asp:Label ID="lblRegister" runat="server" CssClass="BigLabel">Register</asp:Label>

            <asp:Label ID="lblUsername" runat="server" style = "top: 98px;" CssClass="Heading">Username</asp:Label>

            <asp:Label ID="lblUNError" runat="server" style = "top: 180px;" CssClass="Error"></asp:Label>

            <asp:Label ID="lblPWError" runat="server" style = "top: 283px;" CssClass="Error"></asp:Label>

            <asp:Label ID="lblPassword" runat="server" style = "top: 200px;" CssClass="Heading">Password</asp:Label>

            <asp:Label ID="lblConfirmPassword" runat="server" style = "top: 302px;" CssClass="Heading">Confirm Password</asp:Label>

            <asp:Panel ID="pnlUN" runat="server" style = "top: 130px;" CssClass="TextPanel">
                <asp:TextBox ID="txtUsername" runat="server" CssClass="TextBox"></asp:TextBox>
            </asp:Panel>

            <asp:Panel ID="pnlPW" runat="server" style = "top: 232px;" CssClass="TextPanel">
                <asp:TextBox ID="txtPassword" runat="server" CssClass="TextBox" TextMode="Password"></asp:TextBox>
            </asp:Panel>

            <asp:Panel ID="pnlCPW" runat="server" style = "top: 334px;" CssClass="TextPanel">
                <asp:TextBox ID="txtPasswordConfirm" runat="server" CssClass="TextBox" TextMode="Password"></asp:TextBox>
            </asp:Panel>

            <asp:Button ID="btnRegister" runat="server" style = "top: 399px;" CssClass="BigButton" Text="REGISTER" FlatStyle="Flat" OnClick="btnRegister_Click"/>

            <asp:Button ID="btnLogin" runat="server" style = "left: 138px; top: 457px; width: 120px;" CssClass="SmallButton" Text="Back to Sign In" FlatStyle="Flat" OnClick="btnLogin_Click"/>

        </asp:Panel>

    </form>
</body>
</html>
