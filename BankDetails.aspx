<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BankDetails.aspx.cs" Inherits="BankDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="0" cellspacing ="20" align="center" width ="70%">
<tr>
<th colspan ="2"><h1>Bank Account</h1></th>
</tr>
<tr>
<td style ="text-align :right ;">User Name</td>
<td>
    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">Bank Name</td>
<td>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">Bank Address</td>
<td>
    <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">Account Number</td>
<td>
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">IFSC Code</td>
<td>
    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">Amount</td>
<td>
    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Create</asp:LinkButton>
&nbsp; </td>
</tr>
<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </td>
</tr>
</table>
</asp:Content>

