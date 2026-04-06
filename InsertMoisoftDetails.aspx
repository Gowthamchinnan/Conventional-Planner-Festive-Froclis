<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InsertMoisoftDetails.aspx.cs" Inherits="InsertMoisoftDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellspacing ="20" align="center" width="70%">
        <tr>
            <th colspan ="2">
                <h1>
                    Moisoft Details</h1>
            </th>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Name</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Description</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Address</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Mobile Number</td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center ;" colspan="2">
                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Insert</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">Clear</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center ;" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

