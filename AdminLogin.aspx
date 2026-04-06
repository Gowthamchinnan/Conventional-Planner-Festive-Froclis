<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="AdminLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" align="center" width ="70%" cellspacing ="20" >
        <tr>
            <th colspan ="2">
                <h1>
                    Admin Login</h1>
            </th>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                User Name</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Password</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center ;" colspan="2">
                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
                    Font-Bold="True">Login</asp:LinkButton>
&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td style ="text-align :center ;" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

