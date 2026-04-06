<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CateringBooking.aspx.cs" Inherits="CateringBooking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="0" cellspacing ="20" align="center" width ="70%">
<tr>
<th colspan ="2"><h1>Catering Booking Details</h1></th>
</tr>
<tr>
<td style ="text-align :right;">Booking ID</td>
<td>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right;">User Name</td>
<td>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right;">Type</td>
<td>
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
        RepeatDirection="Horizontal" RepeatLayout="Flow">
     <asp:ListItem>Veg</asp:ListItem>
        <asp:ListItem>Non Veg</asp:ListItem>
    </asp:RadioButtonList>
    </td>
</tr>
<tr>
<td style ="text-align :right;">Category</td>
<td>

    <asp:DropDownList ID="DropDownList1" runat="server">
    <asp:ListItem >Select</asp:ListItem>
    <asp:ListItem>Morning Tiffen</asp:ListItem>
        <asp:ListItem>Afternoon Lunch</asp:ListItem>
        <asp:ListItem>Evening Snacks</asp:ListItem>
        <asp:ListItem>Night Dinner</asp:ListItem>
    </asp:DropDownList>
    </td>
</tr>
<tr>
<td style ="text-align :center;" colspan="2">
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">View</asp:LinkButton>
    </td>
</tr>
<tr>
<td style ="text-align :center;" colspan="2">
    <center>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        EmptyDataText="Record Not Found!!!" onrowcommand="GridView1_RowCommand" 
            BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
            CellPadding="4" CellSpacing="2" ForeColor="Black">
        <Columns >
        <asp:BoundField DataField ="csname" HeaderText ="Catering Service Name" />

        <asp:BoundField DataField ="fitems" HeaderText ="Food Items" />
        <asp:BoundField DataField ="cost" HeaderText ="Cost" />
        <asp:ButtonField Text ="Select" CommandName ="ss" HeaderText ="Select" ControlStyle-Font-Bold ="true" ControlStyle-ForeColor ="Green"  />
        </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <sortedascendingcellstyle backcolor="#F1F1F1" />
            <sortedascendingheaderstyle backcolor="#808080" />
            <sorteddescendingcellstyle backcolor="#CAC9C9" />
            <sorteddescendingheaderstyle backcolor="#383838" />
    </asp:GridView>
    </center>
    </td>
</tr>
<tr>
<td style ="text-align :right;">Catering Service Name</td>
<td>
    <asp:TextBox ID="TextBox3" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right;">Food Items</td>
<td>
    <asp:TextBox ID="TextBox4" runat="server" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right;">Single Person Cost</td>
<td>
    <asp:TextBox ID="TextBox5" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right;">Total Number of Person</td>
<td>
    <asp:TextBox ID="TextBox6" runat="server" AutoPostBack="True" 
        ontextchanged="TextBox6_TextChanged"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right;">Total Cost</td>
<td>
    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :center;" colspan="2">
    <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">Add</asp:LinkButton>
    </td>
</tr>
<tr>
<td style ="text-align :center;" colspan="2">
    <center>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns ="False" 
            EmptyDataText ="Record Not Found!!!" BackColor="#CCCCCC" BorderColor="#999999" 
            BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
            ForeColor="Black">
    <Columns >
    <asp:BoundField DataField ="csname" HeaderText ="Catering Service Name" />
    <asp:BoundField DataField ="ftype" HeaderText ="Food Type" />
    <asp:BoundField DataField ="fcategory" HeaderText ="Food Category" />
    <asp:BoundField DataField ="fitems" HeaderText ="Food Items" />
    <asp:BoundField DataField ="cost" HeaderText ="Cost" />
    <asp:BoundField DataField ="noperson" HeaderText ="Total Person" />
    <asp:BoundField DataField ="totalamount" HeaderText ="Total Amount" />
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
<td style ="text-align :center;" colspan="2">
    <asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click">Booking</asp:LinkButton>
    </td>
</tr>
<tr>
<td style ="text-align :center;" colspan="2">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </td>
</tr>
</table>
</asp:Content>

