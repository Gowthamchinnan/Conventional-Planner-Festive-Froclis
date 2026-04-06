<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserViewStudioandPackageDetails.aspx.cs" Inherits="UserViewStudioandPackageDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellspacing ="20" align="center" width ="70%">
    <tr>
        <th>
            <h1>
                    View Studio and Package Details</h1>
        </th>
    </tr>
    <tr>
        <td style ="text-align :center ;">
            <center>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False"  DataKeyNames ="studioid"
           EmptyDataText ="Record Not Found!!!" BackColor="#CCCCCC" BorderColor="#999999" 
           BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
           ForeColor="Black" onrowcommand="GridView1_RowCommand">
                    <Columns >
                        <asp:BoundField DataField ="studioname" HeaderText ="Studio Name" />
                        <asp:BoundField DataField ="address" HeaderText ="Address" />
                        <asp:BoundField DataField ="emailid" HeaderText ="Email ID" />
                        <asp:BoundField DataField ="mno" HeaderText ="Mobile Number" />
                        <asp:ButtonField Text ="View" HeaderText ="Package" CommandName ="vp" />
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
        <td style ="text-align :center ;">
            <center><asp:GridView ID="GridView2" runat="server" AutoGenerateColumns ="False"  DataKeyNames ="packid"
           EmptyDataText ="Record Not Found!!!" BackColor="#CCCCCC" BorderColor="#999999" 
           BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
           ForeColor="Black">
                <Columns >
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
            </asp:GridView></center>
        </td>
    </tr>
    <tr>
        <td style ="text-align :center ;">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>

