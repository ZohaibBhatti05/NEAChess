<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="Prototype8.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="width: 800px; height: 500px; background-color: rgb(40, 40, 40); max-width: 500px; margin:10% auto;">
    <form id="RegisterForm" runat="server">

        <asp:Panel ID="pnlRegister" runat="server" style="z-index: 1; height: 535px; width: 400px; background-color: rgb(70, 70, 70); margin:50px, auto; position:relative; border-radius: 5px 5px">

            <asp:Label ID="lblRegister" runat="server" style = "position:absolute; left: 33px; top: 30px;" Font-Bold="False" Font-Names="Segoe UI Semibold" Font-Size="19pt" ForeColor="White"
                >Register</asp:Label>

            <asp:Label ID="lblUsername" runat="server" style = "position:absolute; left: 72px; top: 98px;" Font-Bold="True" Font-Names="Segoe UI" Font-Size="12pt" ForeColor="White"
                >Username</asp:Label>

            <asp:Label ID="lblUNError" runat="server" style = "position:absolute; left: 72px; top: 180px;" Font-Bold="True" Font-Names="Segoe UI" Font-Size="9pt" ForeColor="IndianRed"
                ></asp:Label>

            <asp:Label ID="lblPWError" runat="server" style = "position:absolute; left: 72px; top: 283px;" Font-Bold="True" Font-Names="Segoe UI" Font-Size="9pt" ForeColor="IndianRed"
                ></asp:Label>

            <asp:Label ID="lblPassword" runat="server" style = "position:absolute; left: 72px; top: 200px;" Font-Bold="True" Font-Names="Segoe UI" Font-Size="12pt" ForeColor="White"
                >Password</asp:Label>

            <asp:Label ID="lblConfirmPassword" runat="server" style = "position:absolute; left: 72px; top: 302px;" Font-Bold="True" Font-Names="Segoe UI" Font-Size="12pt" ForeColor="White"
                >Confirm Password</asp:Label>

            <asp:Panel ID="pnlUN" runat="server" style = "position:absolute; left: 75px; top: 130px; background-color: rgb(64, 66, 51); width: 250px; height: 45px; border-radius: 5px 5px">
                <asp:TextBox ID="txtUsername" runat="server" style = "position:absolute; left: 10px; top: 12px; width:227px; background-color: rgb(64, 66, 51);"
                    Font-Bold="False" Font-Names="Segoe UI" Font-Size="12pt" ForeColor="White" BorderStyle ="None" ViewStateMode="Inherit">
                </asp:TextBox>
            </asp:Panel>

            <asp:Panel ID="pnlPW" runat="server" style = "position:absolute; left: 75px; top: 232px; background-color: rgb(64, 66, 51); width: 250px; height: 45px; border-radius: 5px 5px">
                <asp:TextBox ID="txtPassword" runat="server" style = "position:absolute; left: 10px; top: 12px; width: 227px; background-color: rgb(64, 66, 51);"
                    Font-Bold="False" Font-Names="Segoe UI" Font-Size="12pt" ForeColor="White" BorderStyle ="None" TextMode="Password">
                </asp:TextBox>
            </asp:Panel>

            <asp:Panel ID="pnlCPW" runat="server" style = "position:absolute; left: 75px; top: 334px; background-color: rgb(64, 66, 51); width: 250px; height: 45px; border-radius: 5px 5px">
                <asp:TextBox ID="txtPasswordConfirm" runat="server" style = "position:absolute; left: 10px; top: 12px; width: 227px; background-color: rgb(64, 66, 51);"
                    Font-Bold="False" Font-Names="Segoe UI" Font-Size="12pt" ForeColor="White" BorderStyle ="None" TextMode="Password">
                </asp:TextBox>
            </asp:Panel>

            <asp:Button ID="btnRegister" runat="server" style = "position:absolute; left: 75px; top: 399px; width: 250px; height: 45px; text-align:center, center; background-color: rgb(80, 150, 230); border-radius: 5px 5px"
                Font-Bold="True" Font-Size="13pt" Font-Names="Bahnschrift" Text="REGISTER" ForeColor ="White" FlatStyle="Flat" BorderColor="White" BorderWidth="1px" OnClick="btnRegister_Click"/>


            <asp:Button ID="btnLogin" runat="server" style = "position:absolute; left: 138px; top: 457px; width: 120px; height: 30px; text-align:center, center; background-color: rgb(70, 70, 70);
                color:rgb(80, 150, 230);" 
                Font-Bold="True" Font-Size="10pt" Font-Names="Segoe UI" Text="Back to Sign In" FlatStyle="Flat" BorderStyle="None" OnClick="btnLogin_Click"/>

        </asp:Panel>

    </form>
</body>
</html>
