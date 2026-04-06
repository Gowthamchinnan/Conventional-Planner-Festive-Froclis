<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewAccountDetails.aspx.cs" Inherits="ViewAccountDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="0" cellspacing ="20" align="center" width ="70%">
<tr>
<th><h1>View Account</h1></th>
</tr>
<tr>
<td style="text-align :center ;">
    <center>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
        EmptyDataText="Record Not Found!!!" Height="50px" Width="353px" 
            BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
            CellPadding="4" CellSpacing="2" ForeColor="Black">
            <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <Fields >
        <asp:BoundField DataField ="uname" HeaderText ="User Name" />
        <asp:BoundField DataField ="bname" HeaderText ="Bank Name" />
        <asp:BoundField DataField ="baddress" HeaderText ="Bank Address" />
        <asp:BoundField DataField ="accno" HeaderText ="Account Number" />
        <asp:BoundField DataField ="ifsccode" HeaderText ="IFSC Code" />
        <asp:BoundField DataField ="amount" HeaderText ="Amount" />
        </Fields>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle HorizontalAlign="Left" BackColor="White" />
    </asp:DetailsView>
    </center>
    </td>
</tr>
<tr>
<td style="text-align :center ;">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </td>
</tr>
</table>
</asp:Content>

