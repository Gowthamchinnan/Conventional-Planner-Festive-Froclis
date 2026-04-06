<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OwnerViewEditHallDetails.aspx.cs" Inherits="OwnerViewEditHallDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="0" cellspacing ="20" align="center" width ="70%">
<tr>
<th colspan ="2"><h1>View Hall Details</h1></th>
</tr>
<tr>
<td style ="text-align : right ;">User Name
</td>
<td>
    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
</tr>


<tr>
<td style ="text-align :center ;" colspan="2">
    <center><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            EmptyDataText ="Record Not Found!!!" AutoGenerateEditButton="True" 
            DataKeyNames="hid" onrowediting="GridView1_RowEditing" 
            onrowupdating="GridView1_RowUpdating" BackColor="#CCCCCC" 
            BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
            CellSpacing="2" ForeColor="Black" 
            onrowcancelingedit="GridView1_RowCancelingEdit">
    <Columns >
                <asp:BoundField DataField ="hname" HeaderText ="Hall Name" />
            <asp:BoundField DataField ="htype" HeaderText ="Hall Type" />
            <asp:BoundField DataField ="hcapacity" HeaderText ="Hall Capacity" />
            <asp:BoundField DataField ="haddress" HeaderText ="Address" />
            <asp:BoundField DataField ="hcity" HeaderText ="City" />
            <asp:BoundField DataField ="rent" HeaderText ="Rent" />
            <asp:BoundField DataField ="aamount" HeaderText ="Advance Amount" />
            <asp:ImageField DataImageUrlField ="himage" DataImageUrlFormatString ="HImage/{0}" HeaderText ="Hall Image" ReadOnly ="true" >
            <ControlStyle Width ="100" Height ="100" />
            </asp:ImageField>
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
<td style ="text-align :center ;" colspan="2">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </td>
</tr>

</table>
</asp:Content>

