<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserViewDecoration.aspx.cs" Inherits="UserViewDecoration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellspacing ="20" align="center" width ="70%">
        <tr>
            <th colspan ="2">
                <h1>
                Decoration Style Details</h1>
            </th>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Decoration Type</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>Wedding</asp:ListItem>
                    <asp:ListItem>Reception</asp:ListItem>
                    <asp:ListItem>Engagement</asp:ListItem>
                    <asp:ListItem>Name Ceremony</asp:ListItem>
                    <asp:ListItem>Birthday</asp:ListItem>
                    <asp:ListItem>Conference</asp:ListItem>
                    <asp:ListItem>Baby Shower</asp:ListItem>
                    <asp:ListItem>Laporate Event</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center ;" colspan="2">
                <asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click">View</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center ;" colspan="2">
                <center>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" 
            EmptyDataText ="Record Not Found!!!" Width="351px" BackColor="#CCCCCC" 
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
                        CellSpacing="2" ForeColor="Black">
                        <Columns>
                        <asp:BoundField DataField ="dsname" HeaderText ="Service Name" />
                            <asp:ImageField DataImageUrlField ="dimage" DataImageUrlFormatString ="DImage/{0}" HeaderText ="Image">
                                <ControlStyle Width ="100" Height ="100" />
                            </asp:ImageField>
                            <asp:BoundField DataField ="dcost" HeaderText ="Cost" />
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                </center>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center ;" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

