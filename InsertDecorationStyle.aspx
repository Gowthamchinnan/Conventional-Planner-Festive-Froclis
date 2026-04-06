<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InsertDecorationStyle.aspx.cs" Inherits="InsertDecorationStyle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellspacing ="20" align="center" width ="70%">
<tr>
<th colspan ="2">
<h1>Decoration Style Details</h1>
</th>
</tr>
<tr>
<td style ="text-align :right ;">Service Name</td>
<td>
    <asp:DropDownList ID="DropDownList1" runat="server">
    </asp:DropDownList>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">Type</td>
<td>
    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DropDownList2_SelectedIndexChanged">
        <asp:ListItem>Select</asp:ListItem>
        <asp:ListItem>Wedding</asp:ListItem>
        <asp:ListItem>Reception</asp:ListItem>
        <asp:ListItem>Engagement</asp:ListItem>
                <asp:ListItem>Name Ceremony</asp:ListItem>
                  <asp:ListItem>Birthday</asp:ListItem>
                    <asp:ListItem>Conference</asp:ListItem>
                      <asp:ListItem>Baby Shower</asp:ListItem>
                        <asp:ListItem>Laporate Event</asp:ListItem>
    </asp:DropDownList>
    </td>
</tr>
<tr>
<td style ="text-align :center ;" colspan="2">Previous Decoration Details<br />
    <center><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" 
            EmptyDataText ="Record Not Found!!!" Width="351px" BackColor="#CCCCCC" 
            BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
            CellSpacing="2" ForeColor="Black">
    <Columns>
    <asp:ImageField DataImageUrlField ="dimage" DataImageUrlFormatString ="DImage/{0}" HeaderText ="Image">
    <ControlStyle Width ="100" Height ="100" />
    </asp:ImageField>
    <asp:BoundField DataField ="dcost" HeaderText ="Cost" />

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
<td style ="text-align :right ;">Image</td>
<td>
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <br />
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">View</asp:LinkButton>
    <br />
    <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" />
    </td>
</tr>
<tr>
<td style ="text-align :right ;">Cost</td>
<td>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">Insert</asp:LinkButton>
    </td>
</tr>
<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </td>
</tr>
</table>
</asp:Content>

