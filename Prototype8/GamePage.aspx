<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GamePage.aspx.cs" Inherits="Prototype8.GamePage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Styles.css"/>
</head>

<body style="width: 95%; height: 100%; background-color: rgb(40, 40, 40);">
    <form id="GameForm" runat="server">
        
        <asp:Button runat="server" ID="temp" OnClick="temp_Click" style="position:absolute; left: 3px; top:3px"/>

        <asp:ScriptManager ID="ScriptManager" runat="server" EnableCdn="true"></asp:ScriptManager>

        <div style = "vertical-align:central; text-align:center">

            <asp:Panel ID = "pnlForm" runat="server" style="position:absolute; left: -100px; height: 850px; width: 960px; background-color: rgb(30, 30, 30); margin: 2% auto; position: relative; border-radius: 5px 5px">

                <asp:Label ID="lblUsername" runat="server" Text = "User currently logged in:" style = "left: 38px; top:20px;" CssClass="HeadingLabels"></asp:Label>

                <!-- File/Rank Labels -->
                <asp:Label ID="lblFile1" runat="server" Text = "a" style = "left: 38px;" CssClass="FileLabels"></asp:Label>
                <asp:Label ID="lblFile2" runat="server" Text = "b" style = "left: 113px;" CssClass="FileLabels"></asp:Label>
                <asp:Label ID="lblFile3" runat="server" Text = "c" style = "left: 188px;" CssClass="FileLabels"></asp:Label>
                <asp:Label ID="lblFile4" runat="server" Text = "d" style = "left: 263px;" CssClass="FileLabels"></asp:Label>
                <asp:Label ID="lblFile5" runat="server" Text = "e" style = "left: 338px;" CssClass="FileLabels"></asp:Label>
                <asp:Label ID="lblFile6" runat="server" Text = "f" style = "left: 413px;" CssClass="FileLabels"></asp:Label>
                <asp:Label ID="lblFile7" runat="server" Text = "g" style = "left: 488px;" CssClass="FileLabels"></asp:Label>
                <asp:Label ID="lblFile8" runat="server" Text = "h" style = "left: 563px;" CssClass="FileLabels"></asp:Label>

                <asp:Label ID="lblRank1" runat="server" Text = "1" style = "top: 643px;" CssClass="RankLabels"></asp:Label>
                <asp:Label ID="lblRank2" runat="server" Text = "2" style = "top: 568px;" CssClass="RankLabels"></asp:Label>
                <asp:Label ID="lblRank3" runat="server" Text = "3" style = "top: 493px;" CssClass="RankLabels"></asp:Label>
                <asp:Label ID="lblRank4" runat="server" Text = "4" style = "top: 418px;" CssClass="RankLabels"></asp:Label>
                <asp:Label ID="lblRank5" runat="server" Text = "5" style = "top: 343px;" CssClass="RankLabels"></asp:Label>
                <asp:Label ID="lblRank6" runat="server" Text = "6" style = "top: 268px;" CssClass="RankLabels"></asp:Label>
                <asp:Label ID="lblRank7" runat="server" Text = "7" style = "top: 193px;" CssClass="RankLabels"></asp:Label>
                <asp:Label ID="lblRank8" runat="server" Text = "8" style = "top: 118px;" CssClass="RankLabels"></asp:Label>
                <!-- File/Rank Labels -->

                <asp:UpdatePanel ID="updatePanelTimers" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true" EnableViewState="true"> 
                    
                    <ContentTemplate>

                        <asp:Timer ID="timerUpdateTime" runat="server" Enabled="false" OnTick="timerUpdateTime_Tick" Interval="10"></asp:Timer>
                        <!-- White/Black UI -->
                        <asp:Panel ID = "pnlWhiteUI" runat="server" CssClass="PlayerUIPanels" style="top: 743px;">

                            <asp:Panel ID = "pnlWhiteTime" runat="server" CssClass="TimePanels">
                                <asp:Image ID="picWhiteTime" runat="server" style = "position:absolute; left:3px; top:3px; width:47px; height: 47px;" ImageUrl="~/Resources/Timer.png"/>
                                <asp:Label ID="lblWhiteTime" runat="server" style = "position:absolute; left: 59px; top: 17px;" Font-Names="Segoe UI" Font-Size="12pt" Font-Bold="true" ForeColor="White"></asp:Label>
                            </asp:Panel>

                        </asp:Panel>

                        <asp:Panel ID = "pnlBlackUI" runat="server" CssClass="PlayerUIPanels" style="top: 56px">

                            <asp:Panel ID = "pnlBlackTime" runat="server" CssClass="TimePanels">
                                <asp:Image ID="picBlackTime" runat="server" style = "position:absolute; left:3px; top:3px; width:47px; height: 47px;" ImageUrl="~/Resources/Timer.png"/>
                                <asp:Label ID="lblBlackTime" runat="server" style = "position:absolute; left: 59px; top: 17px;" Font-Names="Segoe UI" Font-Size="12pt" Font-Bold="true" ForeColor="White"></asp:Label>
                            </asp:Panel>
                            
                        </asp:Panel>
                        <!-- White/Black UI -->
                    </ContentTemplate>

                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="timerUpdateTime" EventName="Tick" />
                    </Triggers>

                </asp:UpdatePanel>

                <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional" OnPreRender="UpdatePanel" ChildrenAsTriggers="true" EnableViewState="true"> 
                    <ContentTemplate>

                    <!-- Settings -->
                    <asp:Panel ID="pnlSettings" runat="server" style="background-color: rgb(30, 30, 30); border-radius: 5px 5px; position:absolute; left: 965px; top:0px; width:300px; height: 700px" Visible="true">

                        <!-- Visual Settings -->
                        <asp:Panel ID="pnlVisuals" runat="server" style="background-color: rgb(50, 50, 50); border-radius: 5px 5px; position:absolute; left: 5px; top:5px; width:290px; height: 390px" Visible="true">

                            <asp:Label runat="server" ID="lblSettings" Text = "Settings" style="left: 10px; top: 15px" CssClass="HeadingLabels"></asp:Label>

                            <asp:Label runat="server" ID="lblLightColour" Text="Light Cell Colour:" style="top: 65px;" CssClass="ColourLabels"></asp:Label>
                            <asp:TextBox ID="txtLightCellColour" runat="server" AutoPostBack="true" style="position:absolute; left: 150px; top: 65px; width: 120px" CssClass="ColourPickers"></asp:TextBox>
                            <ajaxToolkit:ColorPickerExtender runat="server" TargetControlID="txtLightCellColour" Enabled="true"/>

                            <asp:Label runat="server" ID="lblDarkColour" Text="Dark Cell Colour:" style="top: 105px;" CssClass="ColourLabels"></asp:Label>
                            <asp:TextBox ID="txtDarkCellColour" runat="server" AutoPostBack="true" style="top: 105px;" CssClass="ColourPickers"></asp:TextBox>
                            <ajaxToolkit:ColorPickerExtender runat="server" TargetControlID="txtDarkCellColour" Enabled="true" />

                            <asp:Label runat="server" ID="lblSelectColour" Text="Selected Colour:" style="top: 145px;" CssClass="ColourLabels"></asp:Label>
                            <asp:TextBox ID="txtSelectCellColour" runat="server" AutoPostBack="true" style="top: 145px;" CssClass="ColourPickers"></asp:TextBox>
                            <ajaxToolkit:ColorPickerExtender runat="server" TargetControlID="txtSelectCellColour" Enabled="true" />

                            <asp:Label runat="server" ID="lblCheckColour" Text="Check Colour:" style="top: 185px;" CssClass="ColourLabels"></asp:Label>
                            <asp:TextBox ID="txtCheckCellColour" runat="server" AutoPostBack="true" style="top: 185px;" CssClass="ColourPickers"></asp:TextBox>
                            <ajaxToolkit:ColorPickerExtender runat="server" TargetControlID="txtCheckCellColour" Enabled="true" />

                            <asp:Label runat="server" ID="lblMoveColour" Text="Move Colour:" style="top: 225px;" CssClass="ColourLabels"></asp:Label>
                            <asp:TextBox ID="txtMoveCellColour" runat="server" AutoPostBack="true" style="top: 225px;" CssClass="ColourPickers"></asp:TextBox>
                            <ajaxToolkit:ColorPickerExtender runat="server" TargetControlID="txtMoveCellColour" Enabled="true" />

                            <asp:Label runat="server" ID="lblPieceSet" Text="Pieces:" style="top: 265px;" CssClass="ColourLabels"></asp:Label>
                            <ajaxToolkit:ComboBox runat="server" ID="cmbPieceSet" style="position:absolute; width: 0px; height: 25px; left:70px; top:257px; text-align:center; background-color: rgb(215, 215, 215);" Font-Bold="true" Font-Names="Segoe UI" Font-Size="10pt" ForeColor="Black" DropDownStyle="Simple" AutoPostBack="true" OnSelectedIndexChanged="cmbPieceSet_SelectedIndexChanged">
                                <asp:ListItem Text="Standard"></asp:ListItem>
                                <asp:ListItem Text="Kosal"></asp:ListItem>
                            </ajaxToolkit:ComboBox>

                            <asp:Button ID="btnChangeColours" runat="server" OnClick="ManageColours" style="position:absolute; left: 10px; top: 310px; width: 130px; height: 70px; border-radius:5px 5px; background-color:rgb(90, 90, 90)"
                                BorderStyle="None" Text="Apply Changes" Font-Names="Segoe UI" Font-Size="10pt" Font-Bold="true" ForeColor="White"/>

                            <asp:Button ID="btnDefaultVisuals" runat="server" OnClick="btnDefaultVisuals_Click" style="position:absolute; left: 150px; top: 310px; width: 130px; height: 70px; border-radius:5px 5px; background-color:rgb(90, 90, 90)"
                                BorderStyle="None" Text="Reset to Defaults" Font-Names="Segoe UI" Font-Size="10pt" Font-Bold="true" ForeColor="White"/>

                        </asp:Panel>

                        <!-- User Settings -->
                        <asp:Panel runat="server" ID="pnlUserSettings" style="background-color: rgb(50, 50, 50); border-radius: 5px 5px; position:absolute; left: 5px; top:400px; width:290px; height: 295px" Visible="true">

                            <asp:Label runat="server" ID="lblUserSettings" Text = "User Settings:" style="left: 10px; top: 15px" CssClass="HeadingLabels"></asp:Label>
                            <asp:Button runat="server" ID="btnLogOut" Text="Log Out" style="position:absolute; top: 300px; left: 5px; width: 200px; height: 80px"/>


                        </asp:Panel>
                    </asp:Panel>

                    <!-- CHESSBOARD -->
                    <asp:Panel ID = "pnlBoard" runat="server" style="height: 600px; width: 600px; background-color: rgb(115, 115, 115); position: absolute; left: 38px; top: 118px">

                    </asp:Panel>
                    <!-- CHESSBOARD -->

                    <!-- Pre-Game Settings -->
                    <asp:Panel ID = "pnlPreGame" runat="server" style="height: 747px; width: 300px; background-color: rgb(40, 40, 40); position: absolute; left: 641px; top: 56px; border-radius: 5px 5px">

                        <asp:Panel ID = "pnlPlayerSettings" runat="server" style="height: 205px; width: 294px; background-color: rgb(70, 70, 70); position: absolute; left: 3px; top: 3px; border-top-left-radius: 5px; border-top-right-radius: 5px">

                            <asp:Label ID="lblPlayAgainst" runat="server" Text = "Play Against:" CssClass="SubHeadingLabels"></asp:Label>

                            <asp:RadioButton ID="radAgainstHuman" runat="server" Text="Human" Checked="true" style="top:28px;" GroupName="AISettings" OnCheckedChanged="radAgainstAI_CheckedChanged" AutoPostBack="true" CssClass="RadioButton"/>
                            <asp:RadioButton ID="radAgainstAI" runat="server" Text="AI" Checked="false" style="top:55px;" GroupName="AISettings" OnCheckedChanged="radAgainstAI_CheckedChanged" AutoPostBack="true" CssClass="RadioButton"/>
                        
                            <asp:Panel ID = "pnlAISettings" runat="server" style="height: 120px; width: 288px; background-color: rgb(40, 40, 40); position: absolute; left: 3px; top: 82px; border-radius: 5px 5px;">

                                <asp:Label ID="lblDepth" runat="server" Text = "Ply Depth:" style = "top: 14px;" CssClass="AILabels"></asp:Label>
                                <ajaxToolkit:ComboBox runat="server" ID="cmbPlyDepth" style="position:absolute; width: 0px; height: 25px; left:78px; top:6px; text-align:center; color: rgb(215, 215, 215);" Font-Bold="true" Font-Names="Segoe UI" Font-Size="10pt" ForeColor="Black" DropDownStyle="Simple" AutoPostBack="true"
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

                                <asp:Label ID="lblQDepth" runat="server" Text = "Q Depth:" style = "top: 54px;" CssClass="AILabels"></asp:Label>
                                <ajaxToolkit:ComboBox runat="server" ID="cmbQDepth" style="position:absolute; width: 0px; height: 25px; left:78px; top:46px; text-align:center; color: rgb(215, 215, 215);" Font-Bold="true" Font-Names="Segoe UI" Font-Size="10pt" ForeColor="Black" DropDownStyle="Simple" AutoPostBack="true"
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

                                <asp:CheckBox ID="checkUseTT" style="position:absolute; left:9px; top:89px;" Text ="Use Transposition Table" Font-Names="Segoe UI Semibold" Font-Size="9.75pt" ForeColor="White"
                                    GroupName="TimeSettings" runat="server" ToolTip="Improves performance but increases memory usage. Recommended for ply above 4"/>
                            </asp:Panel>

                        </asp:Panel>

                        <asp:Panel ID = "pnlTimeControl" runat="server" style="height: 223px; width: 294px; background-color: rgb(70, 70, 70); position: absolute; left: 3px; top: 214px;">
                            <asp:Label ID="lblTimeControl" runat="server" Text = "Time:" CssClass="SubHeadingLabels"></asp:Label>

                            <asp:RadioButton ID="radNoTimers" runat="server" Text="Unlimited" Checked="true" style="top:33px;" GroupName="TimeSettings" OnCheckedChanged="radAgainstAI_CheckedChanged" AutoPostBack="true" CssClass="RadioButton"/>
                            <asp:RadioButton ID="radPresetTime" runat="server" Text="Preset" Checked="false" style="top:70px;" GroupName="TimeSettings" OnCheckedChanged="radAgainstAI_CheckedChanged" AutoPostBack="true" CssClass="RadioButton"/>
                            <asp:RadioButton ID="radCustomTime" runat="server" Text="Custom" Checked="false" style="top:140px;" GroupName="TimeSettings" OnCheckedChanged="radAgainstAI_CheckedChanged" AutoPostBack="true" CssClass="RadioButton"/>

                            <ajaxToolkit:ComboBox runat="server" ID="cmbTimeSettings" style="position:absolute; width: 136px; height: 25px; left:7px; top:97px; text-align:center; color: rgb(215, 215, 215);" Font-Bold="true" Font-Names="Segoe UI" Font-Size="10pt" ForeColor="Black" DropDownStyle="Simple" AutoPostBack="true">
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

                                <asp:TextBox ID="textMinutes" runat="server" style="left:16px;" Text="minutes" OnTextChanged="customTimeTextBox_TextChanged" AutoPostBack="true" CssClass="TimeTextBox"></asp:TextBox>
                                <asp:TextBox ID="textSeconds" runat="server" style="left:102px;" Text="seconds" OnTextChanged="customTimeTextBox_TextChanged" AutoPostBack="true" CssClass="TimeTextBox"></asp:TextBox>
                                <asp:TextBox ID="textIncrement" runat="server" style="left:188px;" Text="increment" OnTextChanged="customTimeTextBox_TextChanged" AutoPostBack="true" CssClass="TimeTextBox"></asp:TextBox>

                            </asp:Panel>

                        </asp:Panel>

                        <asp:Panel ID = "pnlVariants" runat="server" style="height: 82px; width: 294px; background-color: rgb(70, 70, 70); position: absolute; left: 3px; top: 443px;">
                            <asp:Label ID="lblVariant" runat="server" Text = "Variant:" CssClass="SubHeadingLabels"></asp:Label>

                            <ajaxToolkit:ComboBox runat="server" ID="cmbVariant" style="position:absolute; width: 136px; height: 25px; left:7px; top:34px; text-align:center; color: rgb(215, 215, 215);" Font-Bold="true" Font-Names="Segoe UI" Font-Size="10pt" ForeColor="Black" DropDownStyle="Simple" AutoPostBack="true" OnSelectedIndexChanged="cmbVariant_SelectedIndexChanged">
                                <asp:ListItem Text="Standard" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Chess960"></asp:ListItem>
                                <asp:ListItem Text="Antichess"></asp:ListItem>
                                <asp:ListItem Text="Three-Check"></asp:ListItem>
                            </ajaxToolkit:ComboBox>
                        </asp:Panel>

                        <asp:Panel ID = "pnlPosition" runat="server" style="height: 125px; width: 294px; background-color: rgb(70, 70, 70); position: absolute; left: 3px; top: 531px; border-bottom-left-radius: 5px; border-bottom-right-radius: 5px">
                            <asp:Label ID="lblPosition" runat="server" Text = "Position:" CssClass="SubHeadingLabels"></asp:Label>

                            <asp:RadioButton ID="radDefaultPosition" runat="server" Text="Default" Checked="true" style="top:29px;" GroupName="PosSettings" OnCheckedChanged="radAgainstAI_CheckedChanged" AutoPostBack="true" CssClass="RadioButton"/>
                            <asp:RadioButton ID="radCustomPosition" runat="server" Text="Custom" Checked="false" style="top:54px;" GroupName="PosSettings" OnCheckedChanged="radAgainstAI_CheckedChanged" AutoPostBack="true" CssClass="RadioButton"/>
                        
                            <asp:TextBox ID="textFEN" runat="server" style="position:absolute; left:6px; top:88px; background-color: rgb(50, 50, 50); width:270px; height:16px" Font-Names="Segoe UI Semibold" Font-Size="9.75pt" ForeColor="White" Text="rnbqkbnr/ppPp1ppp/8/8/8/8/PP1PpPPP/RNBQKBNR w KQkq - 0 1"></asp:TextBox>

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
                    
                            <asp:Label ID="lblAnalysisMove" runat="server" style = "position:absolute; left: 9px; top: 636px;" Font-Names="Segoe UI Semibold" Font-Size="9.75pt" ForeColor="White"></asp:Label>

                            <asp:Label ID="lblWhiteTaken" runat="server" style = "position:absolute; left: -430px; top: 11px;" Font-Names="Arial" Font-Size="20pt" ForeColor="White"></asp:Label>
                            <asp:label ID="lblBlackTaken" runat="server" style = "position:absolute; left: -430px; top: 696px;" Font-Names="Arial" Font-Size="20pt" ForeColor="White"></asp:label>

                        </asp:Panel>

                        <asp:ImageButton ID="btnUndo" runat="server" style="position:absolute; left:3px; top:688px; width:94px; height: 56px; background-color:rgb(70, 70, 70); border-bottom-left-radius:5px;" ImageUrl="~/Resources/Undo.png" OnClick="btnUndoMove_Click"/>
                        <asp:ImageButton ID="btnResign" runat="server" style="position:absolute; left:102px; top:688px; width:95px; height: 56px; background-color:rgb(70, 70, 70);" ImageUrl="~/Resources/Flag.png" OnClick="btnResign_Click"/>
                        <asp:Button ID="btnDraw" runat="server" style="position:absolute; left:202px; top:688px; width:94px; height: 56px; background-color:rgb(70, 70, 70); border-bottom-right-radius:5px;" BorderWidth="0px" Text="½ ½" Font-Names="Segoe UI" Font-Size="14pt" Font-Bold="true" ForeColor="White"/>

                        <asp:Label ID="lblPromote" runat="server" Text = "Promote To:" style = "position:absolute; left: 6px; top: 658px; color: rgb(215, 215, 215)" Font-Bold = "True" Font-Names="Segoe UI" Font-Size="9.75pt" ForeColor="White"></asp:Label>
                        <ajaxToolkit:ComboBox runat="server" ID="cmbPromote" style="position:absolute; width: 0px; height: 25px; left:85px; top:648px; text-align:center; color: rgb(215, 215, 215);" Font-Bold="true" Font-Names="Segoe UI" Font-Size="10pt" ForeColor="Black" DropDownStyle="Simple" AutoPostBack="true"
                            ToolTip="Determines what a pawn becomes when reaching the opposite end of the board.">
                            <asp:ListItem Text="Bishop ♗"></asp:ListItem>
                            <asp:ListItem Text="Knight ♘"></asp:ListItem>
                            <asp:ListItem Text="Rook ♖"></asp:ListItem>
                            <asp:ListItem Text="Queen ♕" Selected="True"></asp:ListItem>
                        </ajaxToolkit:ComboBox>
                    </asp:Panel>
                    <!-- During-Game Settings -->

                </ContentTemplate>

            </asp:UpdatePanel>

            </asp:Panel>

        </div>

    </form>
</body>
</html>
