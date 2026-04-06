<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AmountUpdate.aspx.cs" Inherits="AmountUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table  border="0" cellspacing ="20" align="center" width ="70%">
<tr>
<th colspan ="2"><h1>Update Amount</h1></th>
</tr>
<tr>
<td style ="text-align :right ;">User Name</td>
<td>
    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">Account Number</td>
<td>
    <asp:TextBox ID="TextBox2" runat="server" AutoPostBack="True" Height="22px" 
        ontextchanged="TextBox2_TextChanged"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">Previous Balance</td>
<td>
    <asp:TextBox ID="TextBox3" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">Amount</td>
<td>
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Update</asp:LinkButton>
    </td>
</tr>
<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </td>
</tr>
</table>
</asp:Content>

