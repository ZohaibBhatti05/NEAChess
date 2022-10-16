<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Prototype8.LoginPage"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style ="vertical-align:middle">
<head runat="server">
    <title></title>
</head>

<body style="width: 800px; height: 575px; background-color: rgb(40, 40, 40); max-width: 500px; margin:10% auto;">
    <form id="LoginForm" runat="server">

        <asp:Panel ID="pnlLogin" runat="server" style="z-index: 1; height: 505px; width: 400px; background-color: rgb(70, 70, 70); max-width: 500px; max-height: 500px; margin:50px, auto; position:relative; border-radius: 5px 5px">

            <asp:Label ID="lblLogin" runat="server" style = "position:absolute; left: 33px; top: 30px;" Font-Bold="False" Font-Names="Segoe UI Semibold" Font-Size="19pt" ForeColor="White"
                >Sign In</asp:Label>

            <asp:Label ID="lblUsername" runat="server" style = "position:absolute; left: 72px; top: 102px;" Font-Bold="True" Font-Names="Segoe UI" Font-Size="12pt" ForeColor="White"
                >Username</asp:Label>

            <asp:Label ID="lblError" runat="server" style = "position:absolute; left: 72px; top: 188px;" Font-Bold="True" Font-Names="Segoe UI" Font-Size="9pt" ForeColor="IndianRed"
                ></asp:Label>

            <asp:Label ID="lblPassword" runat="server" style = "position:absolute; left: 72px; top: 213px;" Font-Bold="True" Font-Names="Segoe UI" Font-Size="12pt" ForeColor="White"
                >Password</asp:Label>

            <asp:Label ID="lblNoAccount" runat="server" style = "position:absolute; left: 75px; top: 386px;" Font-Bold="False" Font-Names="Segoe UI" Font-Size="12pt" ForeColor="White"
                >Don't have an account?</asp:Label>

            <asp:Panel ID="pnlUN" runat="server" style = "position:absolute; left: 75px; top: 136px; background-color: rgb(64, 66, 51); width: 250px; height: 45px; border-radius: 5px 5px">
                <asp:TextBox ID="txtLoginUsername" runat="server" style = "position:absolute; left: 10px; top: 12px; width:227px; background-color: rgb(64, 66, 51);"
                    Font-Bold="False" Font-Names="Segoe UI" Font-Size="12pt" ForeColor="White" BorderStyle ="None" ViewStateMode="Inherit" Text="Zohaib1">
                </asp:TextBox>
            </asp:Panel>
            <asp:Panel ID="pnlPW" runat="server" style = "position:absolute; left: 75px; top: 247px; background-color: rgb(64, 66, 51); width: 250px; height: 45px; border-radius: 5px 5px">
                <asp:TextBox ID="txtLoginPassword" runat="server" style = "position:absolute; left: 10px; top: 12px; width: 227px; background-color: rgb(64, 66, 51);"
                    Font-Bold="False" Font-Names="Segoe UI" Font-Size="12pt" ForeColor="White" BorderStyle ="None" Text="Password1">
                </asp:TextBox>
            </asp:Panel>

            <asp:Button ID="btnLogin" runat="server" style = "position:absolute; left: 75px; top: 323px; width: 250px; height: 45px; text-align:center, center; background-color: rgb(80, 150, 230); border-radius: 5px 5px"
                Font-Bold="True" Font-Size="13pt" Font-Names="Bahnschrift" Text="SIGN IN" ForeColor ="White" FlatStyle="Flat" BorderColor="White" BorderWidth="1px" OnClick="btnLogin_Click"/>

            <asp:Button ID="btnRegister" runat="server" style = "position:absolute; left: 253px; top: 384px; width: 72px; height: 26px; text-align:center, center; background-color: rgb(70, 70, 70);
                color:rgb(80, 150, 230)"
                Font-Bold="True" Font-Size="10pt" Font-Names="Segoe UI" Text="Register" FlatStyle="Flat" BorderStyle="None" OnClick="btnRegister_Click"/>

            <asp:Button ID="btnGuest" runat="server" style = "position:absolute; left: 132px; top: 422px; width: 135px; height: 24px; text-align:center, center; background-color: rgb(70, 70, 70);
                color:rgb(80, 150, 230);" 
                Font-Bold="True" Font-Size="10pt" Font-Names="Segoe UI" Text="Continue as Guest" FlatStyle="Flat" BorderStyle="None" OnClick="btnGuest_Click"/>

        </asp:Panel>

    </form>
</body>
</html>
