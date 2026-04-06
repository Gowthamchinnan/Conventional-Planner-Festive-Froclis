<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminViewFoodItems.aspx.cs" Inherits="AdminViewFoodItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellspacing ="20" align="center" width ="70%">
<tr>
<th colspan ="2"><h1>Food Items</h1></th>
</tr>
<tr>
<td style ="text-align :right ;">Catering Service Name</td>
<td>
    <asp:DropDownList ID="DropDownList1" runat="server">
    </asp:DropDownList>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">Type</td>
<td>
    <asp:DropDownList ID="DropDownList2" runat="server">
        <asp:ListItem>Select</asp:ListItem>
        <asp:ListItem>Veg</asp:ListItem>
        <asp:ListItem>Non Veg</asp:ListItem>
    </asp:DropDownList>
    </td>
</tr>
<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">View</asp:LinkButton>
    </td>
</tr>
<tr>
<td style ="text-align :center ;" colspan="2">
   <center> 
   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" 
           EmptyDataText ="Record Not Found!!!" Width="450px" BackColor="#CCCCCC" 
           BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
           CellSpacing="2" ForeColor="Black">
   <Columns >
   <asp:BoundField DataField ="fcategory" HeaderText ="Food Category" />
   <asp:BoundField DataField ="fitems" HeaderText ="Food Items" />
   <asp:BoundField DataField ="cost" HeaderText ="Cost" />
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

