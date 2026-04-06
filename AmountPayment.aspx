<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AmountPayment.aspx.cs" Inherits="AmountPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="0" cellspacing ="20" align="center" width ="70%">
<tr>
<th colspan ="2"><h1>Amount Payment</h1></th>
</tr>
<tr>
<td style ="text-align :right ;">User Name</td>
<td>
    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">Booking ID</td>
<td>
    <asp:TextBox ID="TextBox2" runat="server" AutoPostBack="True" 
        ontextchanged="TextBox2_TextChanged" style="height: 22px"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">Payment Date</td>
<td>
    <asp:TextBox ID="TextBox3" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">Hall Amount</td>
<td>
    <asp:TextBox ID="TextBox4" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">Catering Amount</td>
<td>
    <asp:TextBox ID="TextBox5" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">Decoration Amount</td>
<td>
    <asp:TextBox ID="TextBox6" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">Studio Amount</td>
<td>
    <asp:TextBox ID="TextBox10" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">Moisoft Amount</td>
<td>
    <asp:TextBox ID="TextBox11" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">Total Amount</td>
<td>
    <asp:TextBox ID="TextBox7" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">Account Number</td>
<td>
    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">IFSC Code</td>
<td>
    <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Payment</asp:LinkButton>
    </td>
</tr>
<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </td>
</tr>
</table>
</asp:Content>

