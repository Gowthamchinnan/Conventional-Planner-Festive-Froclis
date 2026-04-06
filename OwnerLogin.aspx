<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OwnerLogin.aspx.cs" Inherits="OwnerLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellspacing ="20" align="center" width ="70%">
<tr>
<th colspan ="2"><h1>Client Login</h1></th>
</tr>
<tr>
<td style ="text-align :right ;">User Name</td>
<td>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </td>
</tr>

<tr>
<td style ="text-align :right ;">Password</td>
<td>
    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
    </td>
</tr>

<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Login</asp:LinkButton>
&nbsp;&nbsp;&nbsp;
    <span style ="float :right ;"><asp:HyperLink ID="HyperLink1" runat="server" 
        NavigateUrl="~/OwnerRegistration.aspx">New Client</asp:HyperLink></span>
    </td>
</tr>

<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </td>
</tr>

</table>
</asp:Content>

