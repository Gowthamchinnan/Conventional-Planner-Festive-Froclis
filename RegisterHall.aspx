<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RegisterHall.aspx.cs" Inherits="RegisterHall" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style1
    {}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellspacing ="20" align="center" width ="70%">
<tr>
<th colspan ="2"><h1>New Hall Registration</h1></th>
</tr>
<tr>
<td style ="text-align :right ;" class="style1">User Name</td>
<td>
    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
</tr>

<tr>
<td style ="text-align :right ;" class="style1">Hall ID</td>
<td>
    <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
</tr>

<tr>
<td style ="text-align :right ;" class="style1">Hall Name</td>
<td>
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    </td>
</tr>

<tr>
<td style ="text-align :right ;" class="style1">Hall Type</td>
<td>
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>Select</asp:ListItem>
        <asp:ListItem>AC</asp:ListItem>
        <asp:ListItem>Non AC</asp:ListItem>
    </asp:DropDownList>
    </td>
</tr>

<tr>
<td style ="text-align :right ;" class="style1">Hall Capacity</td>
<td>
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
    </td>
</tr>

<tr>
<td style ="text-align :right ;" class="style1">Address</td>
<td>
    <asp:TextBox ID="TextBox5" runat="server" TextMode="MultiLine"></asp:TextBox>
    </td>
</tr>

<tr>
<td style ="text-align :right ;" class="style1">City</td>
<td>
    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
    </td>
</tr>

<tr>
<td style ="text-align :right ;" class="style1">Rent</td>
<td>
    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
    </td>
</tr>

<tr>
<td style ="text-align :right ;" class="style1">Advance Amount</td>
<td>
    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
    </td>
</tr>

<tr>
<td style ="text-align :right ;" class="style1">Image</td>
<td>
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <br />
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">View</asp:LinkButton>
    <br />
    <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" />
    </td>
</tr>

<tr>
<td style ="text-align :center ;" class="style1" colspan="2">
    <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">Insert</asp:LinkButton>
&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click">Clear</asp:LinkButton>
    </td>
</tr>

<tr>
<td style ="text-align :center ;" class="style1" colspan="2">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </td>
</tr>

</table>
</asp:Content>

