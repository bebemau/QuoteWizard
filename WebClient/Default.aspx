<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebClient.Default"  Async="true"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblError" runat="server"></asp:Label>

        </div>
        <hr />
        <div>
            <h2>This listview has a slight modification in the code behind to accommodate the pager control</h2>
            <asp:ListView ID="lv" runat="server" OnPagePropertiesChanging="ListView1_PagePropertiesChanging" GroupItemCount="3">
                <EmptyDataTemplate>
                    <table runat="server" style="">
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td runat="server" />
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr runat="server" id="itemPlaceholderContainer">
                        <td runat="server" id="itemPlaceholder"></td>
                    </tr>
                </GroupTemplate>

                <ItemTemplate>
                    <td runat="server" style="">
                        <asp:Label Text='<%# Eval("QuoteID") %>' runat="server" ID="lblQuoteID" /><br />
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table runat="server" id="groupPlaceholderContainer" style="" border="0">
                                    <tr runat="server" id="groupPlaceholder"></tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="">
                                <asp:DataPager runat="server" PageSize="5" ID="DataPager1">
                                    <Fields>
                                        <asp:NumericPagerField></asp:NumericPagerField>
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>

            </asp:ListView>
        </div>
    </form>
</body>
</html>
