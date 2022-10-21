<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnalysisPage.aspx.cs" Inherits="Prototype8.AnalysisPage" EnableEventValidation="false"%>
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

                <asp:ScriptManager ID="ScriptManager" runat="server" EnableCdn="true"></asp:ScriptManager>


                <asp:UpdatePanel ID="updatePanelTimers" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false" EnableViewState="true"> 
                    
                    <ContentTemplate>
                
                        <asp:GridView ID="dataGridGames" runat="server" AutoGenerateColumns="false" DataKeyNames="GameID"
                        EmptyDataText="No games have been played by this user" style="position:absolute; left:12px; top:50px;
                        height:22px; font-size:9pt" Font-Names="Segoe UI" Font-Bold="true" ForeColor="White"
                         HeaderStyle-BackColor="#5a5a5a" RowStyle-Height="22px" AllowSorting="true" HeaderStyle-Height="22px" SelectedRowStyle-BackColor="#828282"
                          RowStyle-BackColor="#323232" OnRowDataBound="dataGridGame_OnRowBound" OnSelectedIndexChanged="dataGridGames_SelectedIndexChanged" 
                            OnRowEditing="dataGridGames_OnRowEdit" AllowPaging="false"> 
                        <Columns>
                            <asp:TemplateField HeaderText="DatePlayed" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate" runat="server" Text='<%# Eval("DatePlayed") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDate" runat="server" Text='<%# Eval("DatePlayed") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Variant" ItemStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label ID="lblVariant" runat="server" Text='<%# Eval("Variant") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtVariant" runat="server" Text='<%# Eval("Variant") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="WinState" ItemStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label ID="lblWinState" runat="server" Text='<%# Eval("WinState") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtWinState" runat="server" Text='<%# Eval("WinState") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="FEN" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblFEN" runat="server" Text='<%# Eval("FEN") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="lblFEN" runat="server" Text='<%# Eval("FEN") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="PGN" ItemStyle-Width="250">
                                <ItemTemplate>
                                    <asp:Label ID="lblPGN" runat="server" Text='<%# Eval("PGN") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="lblPGN" runat="server" Text='<%# Eval("PGN") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        </asp:GridView>

                    </ContentTemplate>

                    <Triggers>
                        <asp:PostBackTrigger ControlID="dataGridGames" />
                    </Triggers>

                </asp:UpdatePanel>

            </asp:Panel>
        </div>
    </form>
</body>
</html>
