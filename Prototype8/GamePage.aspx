<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GamePage.aspx.cs" Inherits="Prototype8.GamePage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body style="width: 95%; height: 100%; background-color: rgb(40, 40, 40);">
    <form id="GameForm" runat="server">

        <asp:ScriptManager ID="ScriptManager" runat="server" EnableCdn="true"></asp:ScriptManager>

        <div style = "vertical-align:central; text-align:center">

            <asp:Panel ID = "pnlForm" runat="server" style="z-index: 1; height: 850px; width: 960px; background-color: rgb(30, 30, 30); margin: 2% auto; position: relative; border-radius: 5px 5px">

                <asp:Label ID="lblUsername" runat="server" Text = "User currently logged in: Zobear" style = "position:absolute; left: 38px; top:20px;" Font-Bold="True" Font-Names="Segoe UI" Font-Size="14pt" ForeColor="White"></asp:Label>

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

                <asp:UpdatePanel ID="updatePanelTimers" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false" EnableViewState="true"> 
                    
                    <ContentTemplate>
                        <asp:Timer ID="timerUpdateTime" runat="server" Enabled="false" OnTick="timerUpdateTime_Tick" Interval="10"></asp:Timer>
                        <!-- White/Black UI -->
                        <asp:Panel ID = "pnlWhiteUI" runat="server" style="height: 60px; width: 600px; background-color: rgb(70, 70, 70); position: absolute; left: 38px; top: 743px; border-radius: 5px 5px">

                            <asp:Panel ID = "pnlWhiteTime" runat="server" style="height: 53px; width: 165px; background-color: rgb(20, 20, 20); position: absolute; left: 3px; top: 4px; border-radius: 5px 5px">
                                <asp:Image ID="picWhiteTime" runat="server" style="position:absolute; left:3px; top:3px; width:47px; height: 47px;" ImageUrl="~/Resources/Timer.png"/>
                                <asp:Label ID="lblWhiteTime" runat="server" style = "position:absolute; left: 59px; top: 17px;" Font-Names="Segoe UI" Font-Size="12pt" Font-Bold="true" ForeColor="White"></asp:Label>
                            </asp:Panel>

                            <asp:Label ID="lblBlackTaken" runat="server" style = "position:absolute; left: 172px; top: 12px;" Font-Names="Arial" Font-Size="20pt" Font-Bold="true" ForeColor="White"></asp:Label>

                        </asp:Panel>

                        <asp:Panel ID = "pnlBlackUI" runat="server" style="height: 60px; width: 600px; background-color: rgb(70, 70, 70); position: absolute; left: 38px; top: 56px; border-top-left-radius: 5px; border-top-right-radius: 5px">

                            <asp:Panel ID = "pnlBlackTime" runat="server" style="height: 53px; width: 165px; background-color: rgb(20, 20, 20); position: absolute; left: 3px; top: 4px; border-radius: 5px 5px">
                                <asp:Image ID="picBlackTime" runat="server" style="position:absolute; left:3px; top:3px; width:47px; height: 47px;" ImageUrl="~/Resources/Timer.png"/>
                                <asp:Label ID="lblBlackTime" runat="server" style = "position:absolute; left: 59px; top: 17px;" Font-Names="Segoe UI" Font-Size="12pt" Font-Bold="true" ForeColor="White"></asp:Label>
                            </asp:Panel>

                            <asp:Label ID="lblWhiteTaken" runat="server" style = "position:absolute; left: 172px; top: 12px;" Font-Names="Arial" Font-Size="20pt" Font-Bold="true" ForeColor="White"></asp:Label>

                        </asp:Panel>
                        <!-- White/Black UI -->
                    </ContentTemplate>

                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="timerUpdateTime" EventName="Tick" />
                    </Triggers>

                </asp:UpdatePanel>

                <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional" OnPreRender="UpdatePanel" ChildrenAsTriggers="true" EnableViewState="true"> 
                    <ContentTemplate>

                    <!-- CHESSBOARD -->
                    <asp:Panel ID = "pnlBoard" runat="server" style="height: 600px; width: 600px; background-color: rgb(115, 115, 115); position: absolute; left: 38px; top: 118px">

                    </asp:Panel>
                    <!-- CHESSBOARD -->

                    <!-- Pre-Game Settings -->
                    <asp:Panel ID = "pnlPreGame" runat="server" style="height: 747px; width: 300px; background-color: rgb(40, 40, 40); position: absolute; left: 641px; top: 56px; border-radius: 5px 5px">

                        <asp:Panel ID = "pnlPlayerSettings" runat="server" style="height: 205px; width: 294px; background-color: rgb(70, 70, 70); position: absolute; left: 3px; top: 3px; border-top-left-radius: 5px; border-top-right-radius: 5px">

                            <asp:Label ID="lblPlayAgainst" runat="server" Text = "Play Against:" style = "position:absolute; left: 4px; top: 4px;" Font-Names="Segoe UI Semibold" Font-Size="11pt" ForeColor="White"></asp:Label>

                            <asp:RadioButton ID="radAgainstHuman" runat="server" Text="Human" Checked="true" style="position:absolute; left:9px; top:28px; text-align:center; color: rgb(215, 215, 215);" Font-Names="Segoe UI Semibold" Font-Size="9.75pt" ForeColor="White" GroupName="AISettings" OnCheckedChanged="radAgainstAI_CheckedChanged" AutoPostBack="true"/>
                            <asp:RadioButton ID="radAgainstAI" runat="server" Text="AI" Checked="false" style="position:absolute; left:9px; top:55px; text-align:center; color: rgb(215, 215, 215)" Font-Names="Segoe UI Semibold" Font-Size="9.75pt" ForeColor="White" GroupName="AISettings" OnCheckedChanged="radAgainstAI_CheckedChanged" AutoPostBack="true"/>
                        
                            <asp:Panel ID = "pnlAISettings" runat="server" style="height: 120px; width: 288px; background-color: rgb(40, 40, 40); position: absolute; left: 3px; top: 82px; border-radius: 5px 5px;">

                                <asp:Label ID="lblDepth" runat="server" Text = "Ply Depth:" style = "position:absolute; left: 6px; top: 14px; color: rgb(215, 215, 215)" Font-Bold = "True" Font-Names="Segoe UI" Font-Size="9.75pt" ForeColor="White"></asp:Label>
                                <ajaxToolkit:ComboBox runat="server" ID="cmbPlyDepth" style="position:absolute; width: 136px; height: 25px; left:78px; top:6px; text-align:center; color: rgb(215, 215, 215);" Font-Names="Segoe UI" Font-Size="10pt" ForeColor="Black" DropDownStyle="Simple" AutoPostBack="true"
                                    ToolTip="Dictates how many moves ahead the AI calculates.">
                                    <asp:ListItem Text="1 (Very Easy)"></asp:ListItem>
                                    <asp:ListItem Text="2 (Easy)"></asp:ListItem>
                                    <asp:ListItem Text="3 (Competent)"></asp:ListItem>
                                    <asp:ListItem Text="4 (Normal)" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="5 (Good)"></asp:ListItem>
                                    <asp:ListItem Text="6 (Very Good)"></asp:ListItem>
                                    <asp:ListItem Text="7 (Hard)"></asp:ListItem>
                                    <asp:ListItem Text="8 (Very Hard)"></asp:ListItem>
                                </ajaxToolkit:ComboBox>

                                <asp:Label ID="lblQDepth" runat="server" Text = "Q Depth:" style = "position:absolute; left: 6px; top: 54px; color: rgb(215, 215, 215)" Font-Bold = "True" Font-Names="Segoe UI" Font-Size="9.75pt" ForeColor="White"></asp:Label>
                                <ajaxToolkit:ComboBox runat="server" ID="cmbQDepth" style="position:absolute; width: 136px; height: 25px; left:78px; top:46px; text-align:center; color: rgb(215, 215, 215);" Font-Names="Segoe UI" Font-Size="10pt" ForeColor="Black" DropDownStyle="Simple" AutoPostBack="true"
                                    ToolTip="Dictates how many moves ahead the AI can calculate after ply. Use to simulate higher ply if high ply runs slowly.">
                                    <asp:ListItem Text="0"></asp:ListItem>
                                    <asp:ListItem Text="1"></asp:ListItem>
                                    <asp:ListItem Text="2" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="3"></asp:ListItem>
                                    <asp:ListItem Text="4"></asp:ListItem>
                                    <asp:ListItem Text="5"></asp:ListItem>
                                    <asp:ListItem Text="6"></asp:ListItem>
                                    <asp:ListItem Text="7"></asp:ListItem>
                                    <asp:ListItem Text="8"></asp:ListItem>
                                </ajaxToolkit:ComboBox>

                                <asp:CheckBox ID="checkUseTT" style="position:absolute; left:9px; top:89px;" Text ="Use Transposition Table" Font-Names="Segoe UI Semibold" Font-Size="9.75pt" ForeColor="White" GroupName="TimeSettings" runat="server" ToolTip="Improves performance but increases memory usage. Recommended for ply above 4"/>
                            </asp:Panel>

                        </asp:Panel>

                        <asp:Panel ID = "pnlTimeControl" runat="server" style="height: 223px; width: 294px; background-color: rgb(70, 70, 70); position: absolute; left: 3px; top: 214px;">
                            <asp:Label ID="lblTimeControl" runat="server" Text = "Time:" style = "position:absolute; left: 4px; top: 4px;" Font-Names="Segoe UI Semibold" Font-Size="11pt" ForeColor="White"></asp:Label>


                            <asp:RadioButton ID="radNoTimers" runat="server" Text="Unlimited" Checked="true" style="position:absolute; left:7px; top:33px; text-align:center; color: rgb(215, 215, 215);" Font-Names="Segoe UI Semibold" Font-Size="9.75pt" ForeColor="White" GroupName="TimeSettings" OnCheckedChanged="radAgainstAI_CheckedChanged" AutoPostBack="true"/>
                            <asp:RadioButton ID="radPresetTime" runat="server" Text="Preset" Checked="false" style="position:absolute; left:7px; top:70px; text-align:center; color: rgb(215, 215, 215);" Font-Names="Segoe UI Semibold" Font-Size="9.75pt" ForeColor="White" GroupName="TimeSettings" OnCheckedChanged="radAgainstAI_CheckedChanged" AutoPostBack="true"/>
                            <asp:RadioButton ID="radCustomTime" runat="server" Text="Custom" Checked="false" style="position:absolute; left:7px; top:140px; text-align:center; color: rgb(215, 215, 215);" Font-Names="Segoe UI Semibold" Font-Size="9.75pt" ForeColor="White" GroupName="TimeSettings" OnCheckedChanged="radAgainstAI_CheckedChanged" AutoPostBack="true"/>

                            <ajaxToolkit:ComboBox runat="server" ID="cmbTimeSettings" style="position:absolute; width: 136px; height: 25px; left:7px; top:97px; text-align:center; color: rgb(215, 215, 215);" Font-Names="Segoe UI" Font-Size="10pt" ForeColor="Black" DropDownStyle="Simple" AutoPostBack="true">
                                <asp:ListItem Text="1 min"></asp:ListItem>
                                <asp:ListItem Text="10 min" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="20 min"></asp:ListItem>
                                <asp:ListItem Text="60 min"></asp:ListItem>
                                <asp:ListItem Text="15 | 10"></asp:ListItem>
                                <asp:ListItem Text="10 | 5"></asp:ListItem>
                                <asp:ListItem Text="3 | 2"></asp:ListItem>
                                <asp:ListItem Text="1 | 1"></asp:ListItem>
                            </ajaxToolkit:ComboBox>
                        

                            <asp:Panel ID = "pnlCustomTime" runat="server" style="height: 33px; width: 286px; background-color: rgb(70, 70, 70); position: absolute; left: 3px; top: 167px;">

                                <asp:TextBox ID="textMinutes" runat="server" style="left:16px; top:4px; width:80px; height:25px; position:absolute; background-color: rgb(50,50,50); text-align:center" Font-Names="Segoe UI Semibold" Font-Size="9.75pt" ForeColor="White" Text="minutes" OnTextChanged="customTimeTextBox_TextChanged" AutoPostBack="true" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                <asp:TextBox ID="textSeconds" runat="server" style="left:102px; top:4px; width:80px; height:25px; position:absolute; background-color: rgb(50,50,50); text-align:center" Font-Names="Segoe UI Semibold" Font-Size="9.75pt" ForeColor="White" Text="seconds" OnTextChanged="customTimeTextBox_TextChanged" AutoPostBack="true" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                <asp:TextBox ID="textIncrement" runat="server" style="left:188px; top:4px; width:80px; height:25px; position:absolute; background-color: rgb(50,50,50); text-align:center" Font-Names="Segoe UI Semibold" Font-Size="9.75pt" ForeColor="White" Text="increment" OnTextChanged="customTimeTextBox_TextChanged" AutoPostBack="true" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>

                            </asp:Panel>

                        </asp:Panel>

                        <asp:Panel ID = "pnlVariants" runat="server" style="height: 82px; width: 294px; background-color: rgb(70, 70, 70); position: absolute; left: 3px; top: 443px;">
                            <asp:Label ID="lblVariant" runat="server" Text = "Variant:" style = "position:absolute; left: 4px; top: 4px;" Font-Names="Segoe UI Semibold" Font-Size="11pt" ForeColor="White"></asp:Label>

                            <ajaxToolkit:ComboBox runat="server" ID="cmbVariant" style="position:absolute; width: 136px; height: 25px; left:7px; top:34px; text-align:center; color: rgb(215, 215, 215);" Font-Names="Segoe UI" Font-Size="10pt" ForeColor="Black" DropDownStyle="Simple" AutoPostBack="true" OnSelectedIndexChanged="cmbVariant_SelectedIndexChanged">
                                <asp:ListItem Text="Standard" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Chess960"></asp:ListItem>
                                <asp:ListItem Text="Antichess"></asp:ListItem>
                                <asp:ListItem Text="Three-Check"></asp:ListItem>
                            </ajaxToolkit:ComboBox>
                        </asp:Panel>

                        <asp:Panel ID = "pnlPosition" runat="server" style="height: 125px; width: 294px; background-color: rgb(70, 70, 70); position: absolute; left: 3px; top: 531px; border-bottom-left-radius: 5px; border-bottom-right-radius: 5px">
                            <asp:Label ID="lblPosition" runat="server" Text = "Position:" style = "position:absolute; left: 4px; top: 4px;" Font-Names="Segoe UI Semibold" Font-Size="11pt" ForeColor="White"></asp:Label>

                            <asp:RadioButton ID="radDefaultPosition" runat="server" Text="Default" Checked="true" style="position:absolute; left:6px; top:29px; text-align:center; color: rgb(215, 215, 215);" Font-Names="Segoe UI Semibold" Font-Size="9.75pt" ForeColor="White" GroupName="PosSettings" OnCheckedChanged="radAgainstAI_CheckedChanged" AutoPostBack="true"/>
                            <asp:RadioButton ID="radCustomPosition" runat="server" Text="Custom" Checked="false" style="position:absolute; left:6px; top:54px; text-align:center; color: rgb(215, 215, 215)" Font-Names="Segoe UI Semibold" Font-Size="9.75pt" ForeColor="White" GroupName="PosSettings" OnCheckedChanged="radAgainstAI_CheckedChanged" AutoPostBack="true"/>
                        
                            <asp:TextBox ID="textFEN" runat="server" style="position:absolute; left:6px; top:88px; background-color: rgb(50, 50, 50); width:270px; height:16px" Font-Names="Segoe UI Semibold" Font-Size="9.75pt" ForeColor="White"></asp:TextBox>

                        </asp:Panel>

                        <asp:Button ID="btnStartGame" runat="server" style = "position:absolute; left: 3px; top: 662px; width: 294px; height: 84px; text-align:center, center; background-color: forestgreen; border-radius: 5px 5px"
                            Font-Bold="True" Font-Size="20pt" Font-Names="Bahnschrift" Text="START GAME" ForeColor ="White" FlatStyle="Flat" BorderColor="White" BorderWidth="1px" OnClick="btnStartGame_Click"/>

                    </asp:Panel>
                    <!-- Pre-Game Settings -->


                    <!-- During-Game Settings -->
                    <asp:Panel ID = "pnlDuringGame" runat="server" style="height: 747px; width: 300px; background-color: rgb(40, 40, 40); position: absolute; left: 641px; top: 56px; border-radius: 5px 5px">
                        <asp:Panel ID = "pnlPGN" runat="server" style="height: 640px; width: 293px; background-color: rgb(50, 50, 50); position: absolute; left: 3px; top: 3px; border-top-left-radius:5px; border-top-right-radius:5px;">
                            <asp:TextBox ID="txtWhiteMoves" runat="server" style="position:absolute; left:3px; top:3px; width:100px; height:634px; background-color: rgb(50, 50, 50);" ReadOnly="true" Font-Names="Segoe UI Semibold" Font-Size="9.75pt" ForeColor="White" BorderStyle="None" Rows = "30" TextMode="MultiLine" AutoPostBack="true"></asp:TextBox>
                            <asp:TextBox ID="txtBlackMoves" runat="server" style="position:absolute; left:109px; top:3px; width:100px; height:634px; background-color: rgb(50, 50, 50);" ReadOnly="true" Font-Names="Segoe UI Semibold" Font-Size="9.75pt" ForeColor="White" BorderStyle="None" Rows = "30" TextMode="MultiLine" AutoPostBack="true"></asp:TextBox>
                    
                            <asp:Label ID="lblAnalysisMove" runat="server" style = "position:absolute; left: 9px; top: 656px;" Font-Names="Segoe UI Semibold" Font-Size="9.75pt" ForeColor="White"></asp:Label>
                        </asp:Panel>

                        <asp:ImageButton ID="btnUndo" runat="server" style="position:absolute; left:3px; top:688px; width:94px; height: 56px; background-color:rgb(70, 70, 70); border-bottom-left-radius:5px;" ImageUrl="~/Resources/Undo.png"/>
                        <asp:ImageButton ID="btnResign" runat="server" style="position:absolute; left:102px; top:688px; width:95px; height: 56px; background-color:rgb(70, 70, 70);" ImageUrl="~/Resources/Flag.png"/>
                        <asp:Button ID="btnDraw" runat="server" style="position:absolute; left:202px; top:688px; width:94px; height: 56px; background-color:rgb(70, 70, 70); border-bottom-right-radius:5px;" BorderWidth="0px" Text="½ ½" Font-Names="Segoe UI" Font-Size="14pt" Font-Bold="true" ForeColor="White"/>

                    </asp:Panel>
                    <!-- During-Game Settings -->

                </ContentTemplate>

            </asp:UpdatePanel>

            </asp:Panel>

        </div>

    </form>
</body>
</html>
