<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnalysisPage.aspx.cs" Inherits="Prototype8.AnalysisPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="width: 95%; height: 100%; background-color: rgb(40, 40, 40);">
    <form id="AnalysisForm" runat="server">
        <div>
            <asp:Panel ID = "pnlForm" runat="server" style="z-index: 1; height: 850px; width: 960px; background-color: rgb(30, 30, 30); margin: 2% auto; position: relative; border-radius: 5px 5px">
                <asp:Button id="btnPrintToFile" runat="server" style="position:absolute; left:12px; top:12px; width: 137px; height: 32px; background-color:rgb(100,100,100)" Font-Bold="True" Font-Names="Segoe UI" Font-Size="9.75pt" ForeColor="White" Text="Print Data to File" BorderStyle="None"/>

                <asp:ListView ID="dataGridGames" runat="server" ConvertEmptyStringToNull="True">

                </asp:ListView>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
