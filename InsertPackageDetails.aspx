<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InsertPackageDetails.aspx.cs" Inherits="InsertPackageDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellspacing ="20" align="center" width ="70%">
        <tr>
            <th colspan ="2">
                <h1>
                    Package Details</h1>
            </th>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Studio Name</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                    AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center ;" colspan="2">
                Previous Package Details<br />
                <center>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" 
            EmptyDataText ="Record Not Found!!!" Width="351px" BackColor="#CCCCCC" 
            BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
            CellSpacing="2" ForeColor="Black">
                        <Columns>
                         <asp:BoundField DataField ="packname" HeaderText ="Package Name" />
                          <asp:BoundField DataField ="packdesc" HeaderText ="Package Description" />
                           <asp:BoundField DataField ="amount" HeaderText ="Amount" />
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
            <td style ="text-align :right ;">
                Package Name</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Package Description</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Amount</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center ;" colspan="2">
                <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">Insert</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center ;" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

