<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HallBooking.aspx.cs" Inherits="HallBooking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="0" cellspacing ="20" align="center" width ="70%">
<tr><th colspan ="2"><h1>Hall Booking</h1></th></tr>
<tr>
<td style ="text-align :right ;">Booking ID</td>
<td>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">Booking Date</td>
<td>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">User Name</td>
<td>
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">Hall ID</td>
<td>
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">Hall Name</td>
<td>
    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">Catering Option</td>
<td>
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
        RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem>Yes</asp:ListItem>
        <asp:ListItem>No</asp:ListItem>
    </asp:RadioButtonList>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">Decoration Option</td>
<td>
    <asp:RadioButtonList ID="RadioButtonList2" runat="server" 
        RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem>Yes</asp:ListItem>
        <asp:ListItem>No</asp:ListItem>
    </asp:RadioButtonList>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">Studio Option</td>
<td>
    <asp:RadioButtonList ID="RadioButtonList3" runat="server" 
        RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem>Yes</asp:ListItem>
        <asp:ListItem>No</asp:ListItem>
    </asp:RadioButtonList>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">Moisoft Option</td>
<td>
    <asp:RadioButtonList ID="RadioButtonList4" runat="server" 
        RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem>Yes</asp:ListItem>
        <asp:ListItem>No</asp:ListItem>
    </asp:RadioButtonList>
    </td>
</tr>
<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Booking</asp:LinkButton>
    </td>
</tr>
<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </td>
</tr>
</table>
</asp:Content>

