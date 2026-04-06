<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MoisoftBooking.aspx.cs" Inherits="MoidosftBooking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellspacing ="20" align="center" width ="70%">
        <tr>
            <th colspan ="2">
                <h1>
                    Moisoft Booking</h1>
            </th>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Booking ID</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                User Name</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                ID</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center ;" colspan="2">
                <center>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
           EmptyDataText="Record Not Found!!!" onrowcommand="GridView1_RowCommand" 
           DataKeyNames="msid" BackColor="#CCCCCC" BorderColor="#999999" 
           BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
           ForeColor="Black">
                        <Columns >
                            <asp:BoundField DataField ="icount" HeaderText ="Invitation Count" />
                            <asp:BoundField DataField ="scost" HeaderText ="Service Cost" />
                            <asp:BoundField DataField ="scount" HeaderText ="System Count" />
                            <asp:ButtonField Text ="Select" HeaderText ="Select" CommandName ="ss" ControlStyle-Font-Bold ="true" ControlStyle-ForeColor ="Green"  />
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
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                </center>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Invitation Count</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Service Cost</td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                System Count</td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center ;" colspan="2">
                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Add</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">Amount Payment</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center; margin-left: 40px;" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

