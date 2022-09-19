﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GamePage.aspx.cs" Inherits="Prototype8.GamePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body style="width: 95%; height: 100%; background-color: rgb(40, 40, 40);">
    <form id="GameForm" runat="server">

        <div style = "vertical-align:central; text-align:center">

            <asp:Panel ID = "pnlForm" runat="server" style="z-index: 1; height: 850px; width: 960px; background-color: rgb(30, 30, 30); margin: 2% auto; position: relative; border-radius: 5px 5px">

                <!-- File/Rank Labels -->
                <asp:Label ID="lblFile1" runat="server" Text = "a" style = "position:absolute; left: 38px; top: 718px; width:75px; height:22px; text-align:center" Font-Bold="True" Font-Names="Segoe UI" Font-Size="12pt" ForeColor="White"></asp:Label>
                <asp:Label ID="lblFile2" runat="server" Text = "b" style = "position:absolute; left: 113px; top: 718px; width:75px; height:22px; text-align:center" Font-Bold="True" Font-Names="Segoe UI" Font-Size="12pt" ForeColor="White"></asp:Label>
                <asp:Label ID="lblFile3" runat="server" Text = "c" style = "position:absolute; left: 188px; top: 718px; width:75px; height:22px; text-align:center" Font-Bold="True" Font-Names="Segoe UI" Font-Size="12pt" ForeColor="White"></asp:Label>
                <asp:Label ID="lblFile4" runat="server" Text = "d" style = "position:absolute; left: 263px; top: 718px; width:75px; height:22px; text-align:center" Font-Bold="True" Font-Names="Segoe UI" Font-Size="12pt" ForeColor="White"></asp:Label>
                <asp:Label ID="lblFile5" runat="server" Text = "e" style = "position:absolute; left: 338px; top: 718px; width:75px; height:22px; text-align:center" Font-Bold="True" Font-Names="Segoe UI" Font-Size="12pt" ForeColor="White"></asp:Label>
                <asp:Label ID="lblFile6" runat="server" Text = "f" style = "position:absolute; left: 413px; top: 718px; width:75px; height:22px; text-align:center" Font-Bold="True" Font-Names="Segoe UI" Font-Size="12pt" ForeColor="White"></asp:Label>
                <asp:Label ID="lblFile7" runat="server" Text = "g" style = "position:absolute; left: 488px; top: 718px; width:75px; height:22px; text-align:center" Font-Bold="True" Font-Names="Segoe UI" Font-Size="12pt" ForeColor="White"></asp:Label>
                <asp:Label ID="lblFile8" runat="server" Text = "h" style = "position:absolute; left: 563px; top: 718px; width:75px; height:22px; text-align:center" Font-Bold="True" Font-Names="Segoe UI" Font-Size="12pt" ForeColor="White"></asp:Label>

                <asp:Label ID="lblRank1" runat="server" Text = "1" style = "line-height:75px; position:absolute; left: 13px; top: 643px; width:22px; height:75px; text-align:center" Font-Bold="True" Font-Names="Segoe UI" Font-Size="12pt" ForeColor="White"></asp:Label>
                <asp:Label ID="lblRank2" runat="server" Text = "2" style = "line-height:75px; position:absolute; left: 13px; top: 568px; width:22px; height:75px; text-align:center" Font-Bold="True" Font-Names="Segoe UI" Font-Size="12pt" ForeColor="White"></asp:Label>
                <asp:Label ID="lblRank3" runat="server" Text = "3" style = "line-height:75px; position:absolute; left: 13px; top: 493px; width:22px; height:75px; text-align:center" Font-Bold="True" Font-Names="Segoe UI" Font-Size="12pt" ForeColor="White"></asp:Label>
                <asp:Label ID="lblRank4" runat="server" Text = "4" style = "line-height:75px; position:absolute; left: 13px; top: 418px; width:22px; height:75px; text-align:center" Font-Bold="True" Font-Names="Segoe UI" Font-Size="12pt" ForeColor="White"></asp:Label>
                <asp:Label ID="lblRank5" runat="server" Text = "5" style = "line-height:75px; position:absolute; left: 13px; top: 343px; width:22px; height:75px; text-align:center" Font-Bold="True" Font-Names="Segoe UI" Font-Size="12pt" ForeColor="White"></asp:Label>
                <asp:Label ID="lblRank6" runat="server" Text = "6" style = "line-height:75px; position:absolute; left: 13px; top: 268px; width:22px; height:75px; text-align:center" Font-Bold="True" Font-Names="Segoe UI" Font-Size="12pt" ForeColor="White"></asp:Label>
                <asp:Label ID="lblRank7" runat="server" Text = "7" style = "line-height:75px; position:absolute; left: 13px; top: 193px; width:22px; height:75px; text-align:center" Font-Bold="True" Font-Names="Segoe UI" Font-Size="12pt" ForeColor="White"></asp:Label>
                <asp:Label ID="lblRank8" runat="server" Text = "8" style = "line-height:75px; position:absolute; left: 13px; top: 118px; width:22px; height:75px; text-align:center" Font-Bold="True" Font-Names="Segoe UI" Font-Size="12pt" ForeColor="White"></asp:Label>
                <!-- File/Rank Labels -->

                <asp:Panel ID = "pnlBoard" runat="server" style="height: 600px; width: 600px; background-color: rgb(115, 115, 115); position: absolute; left: 38px; top: 118px">

                </asp:Panel>

                <!-- White/Black UI -->
                <asp:Panel ID = "pnlWhiteUI" runat="server" style="height: 60px; width: 600px; background-color: rgb(70, 70, 70); position: absolute; left: 38px; top: 743px; border-radius: 5px 5px">

                    <asp:Panel ID = "pnlWhiteTime" runat="server" style="height: 53px; width: 165px; background-color: rgb(20, 20, 20); position: absolute; left: 3px; top: 4px; border-radius: 5px 5px">

                    </asp:Panel>

                </asp:Panel>

                <asp:Panel ID = "pnlBlackUI" runat="server" style="height: 60px; width: 600px; background-color: rgb(70, 70, 70); position: absolute; left: 38px; top: 56px; border-top-left-radius: 5px; border-top-right-radius: 5px">

                    <asp:Panel ID = "pnlBlackTime" runat="server" style="height: 53px; width: 165px; background-color: rgb(20, 20, 20); position: absolute; left: 3px; top: 4px; border-radius: 5px 5px">

                    </asp:Panel>

                </asp:Panel>
                <!-- White/Black UI -->


                <!-- Pre-Game Settings -->
                <asp:Panel ID = "pnlPreGame" runat="server" style="height: 747px; width: 300px; background-color: rgb(40, 40, 40); position: absolute; left: 641px; top: 56px; border-radius: 5px 5px">

                    <asp:Panel ID = "pnlPlayerSettings" runat="server" style="height: 205px; width: 294px; background-color: rgb(70, 70, 70); position: absolute; left: 3px; top: 3px; border-top-left-radius: 5px; border-top-right-radius: 5px">

                        <asp:Label ID="lblPlayAgainst" runat="server" Text = "Play Against:" style = "position:absolute; left: 4px; top: 4px;" Font-Names="Segoe UI Semibold" Font-Size="11pt" ForeColor="White"></asp:Label>

                        <asp:RadioButton ID="radAgainstHuman" runat="server" Text="Human" Checked="true" style="position:absolute; left:9px; top:28px; text-align:center; color: rgb(215, 215, 215);" Font-Names="Segoe UI Semibold" Font-Size="9.75pt" ForeColor="White" GroupName="AISettings" OnCheckedChanged="radAgainstAI_CheckedChanged" AutoPostBack="true"/>
                        <asp:RadioButton ID="radAgainstAI" runat="server" Text="AI" Checked="false" style="position:absolute; left:9px; top:55px; text-align:center; color: rgb(215, 215, 215)" Font-Names="Segoe UI Semibold" Font-Size="9.75pt" ForeColor="White" GroupName="AISettings" OnCheckedChanged="radAgainstAI_CheckedChanged" AutoPostBack="true"/>
                        
                        <asp:Panel ID = "pnlAISettings" runat="server" style="height: 120px; width: 288px; background-color: rgb(40, 40, 40); position: absolute; left: 3px; top: 82px; border-radius: 5px 5px;">

                            <asp:Label ID="lblDepth" runat="server" Text = "Ply Depth:" style = "position:absolute; left: 6px; top: 14px; color: rgb(215, 215, 215)" Font-Bold = "True" Font-Names="Segoe UI" Font-Size="9.75pt" ForeColor="White"></asp:Label>
                            <asp:Label ID="lblPlyDepth" runat="server" Text = "4" style = "position:absolute; left: 78px; top: 14px; color: rgb(215, 215, 215)" Font-Bold = "True" Font-Names="Segoe UI" Font-Size="9.75pt" ForeColor="White"></asp:Label>


                        </asp:Panel>

                    </asp:Panel>

                    <asp:Panel ID = "pnlTimeControl" runat="server" style="height: 223px; width: 294px; background-color: rgb(70, 70, 70); position: absolute; left: 3px; top: 214px;">


                    </asp:Panel>

                    <asp:Panel ID = "pnlVariants" runat="server" style="height: 82px; width: 294px; background-color: rgb(70, 70, 70); position: absolute; left: 3px; top: 443px;">


                    </asp:Panel>

                    <asp:Panel ID = "pnlPosition" runat="server" style="height: 125px; width: 294px; background-color: rgb(70, 70, 70); position: absolute; left: 3px; top: 531px; border-bottom-left-radius: 5px; border-bottom-right-radius: 5px">


                    </asp:Panel>

                    <asp:Button ID="btnStartGame" runat="server" style = "position:absolute; left: 3px; top: 662px; width: 294px; height: 84px; text-align:center, center; background-color: forestgreen; border-radius: 5px 5px"
                        Font-Bold="True" Font-Size="20pt" Font-Names="Bahnschrift" Text="START GAME" ForeColor ="White" FlatStyle="Flat" BorderColor="White" BorderWidth="1px" OnClick="btnStartGame_Click"/>

                </asp:Panel>
                <!-- Pre-Game Settings -->


                <!-- During-Game Settings -->

                <!-- During-Game Settings -->
            </asp:Panel>

        </div>

    </form>
</body>
</html>
