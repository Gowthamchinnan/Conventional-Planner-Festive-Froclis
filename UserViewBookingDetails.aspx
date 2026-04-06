<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserViewBookingDetails.aspx.cs" Inherits="UserViewBookingDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellspacing ="20" align="center" width ="70%">
    <tr>
        <th colspan ="2">
            <h1>
                View Hall Booking</h1>
        </th>
    </tr>
    <tr>
        <td style ="text-align :right ;">
            User Name</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align :center ;" colspan="2">
            <center>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" 
           EmptyDataText ="Record Not Found!!!" DataKeyNames="bid" 
           onrowcommand="GridView1_RowCommand" BackColor="#CCCCCC" BorderColor="#999999" 
                    BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
                    ForeColor="Black">
                    <Columns >
                        <asp:BoundField DataField ="bid" HeaderText ="Booking ID" />
                        <asp:BoundField DataField ="bdate" HeaderText ="Booking Date" HtmlEncode ="false" DataFormatString ="{0:dd-MMM-yyyy}" />
                        <asp:BoundField DataField ="uname" HeaderText ="User Name" />
                        <asp:BoundField DataField ="hid" HeaderText ="Hall ID" />
                        <asp:BoundField DataField ="hname" HeaderText ="Hall Name" />
                        <asp:BoundField DataField ="coption" HeaderText ="Catering" />
                        <asp:BoundField DataField ="doption" HeaderText ="Decoration" />
                          <asp:BoundField DataField ="soption" HeaderText ="Studio" />
                              <asp:BoundField DataField ="moption" HeaderText ="Moisoft" />
                        <asp:BoundField DataField ="pstatus" HeaderText ="Payment Status" />
                        <asp:ButtonField Text ="Catering"  HeaderText ="View Catering" CommandName ="vc"  ControlStyle-ForeColor ="Green"  ControlStyle-Font-Bold ="true" />
                        <asp:ButtonField Text ="Decoration" HeaderText ="View Decoration" CommandName ="vd" ControlStyle-ForeColor ="Green"  ControlStyle-Font-Bold ="true"  />
                          <asp:ButtonField Text ="Studio" HeaderText ="View Studio" CommandName ="vs" ControlStyle-Font-Bold ="true" ControlStyle-ForeColor ="Green" />
                               <asp:ButtonField Text ="Moisoft" HeaderText ="View Moisoft" CommandName ="vm" ControlStyle-Font-Bold ="true" ControlStyle-ForeColor ="Green" />
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
        <td style="text-align :center; margin-left: 40px;" colspan="2">
            <asp:Label ID="Label2" runat="server" Text="View Catering" Visible="False"></asp:Label>
            <br />
            <center>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns ="False" 
                    EmptyDataText ="Record Not Found!!!" BackColor="#CCCCCC" BorderColor="#999999" 
                    BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
                    ForeColor="Black">
                    <Columns >
                        <asp:BoundField DataField ="csname" HeaderText ="Catering Service Name" />
                        <asp:BoundField DataField ="ftype" HeaderText ="Food Type" />
                        <asp:BoundField DataField ="fcategory" HeaderText ="Food Category" />
                        <asp:BoundField DataField ="fitems" HeaderText ="Food Items" />
                        <asp:BoundField DataField ="cost" HeaderText ="Cost" />
                        <asp:BoundField DataField ="noperson" HeaderText ="No of Person" />
                        <asp:BoundField DataField ="totalamount" HeaderText ="Total Amount" />
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
        <td style="text-align :center; margin-left: 40px;" colspan="2">
            <asp:Label ID="Label3" runat="server" Text="View Decoration" Visible="False"></asp:Label>
            <br />
            <center>
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns ="False" 
                    EmptyDataText ="Record Not Found!!!" BackColor="#CCCCCC" BorderColor="#999999" 
                    BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
                    ForeColor="Black">
                    <Columns >
                        <asp:BoundField DataField ="dsname" HeaderText ="Service Name" />
                        <asp:BoundField DataField ="dtype" HeaderText ="Type" />
                        <asp:ImageField DataImageUrlField ="dimage" DataImageUrlFormatString ="DImage\{0}" HeaderText ="Image">
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
            <td style="text-align :center; margin-left: 40px;" colspan="2">
                <asp:Label ID="Label5" runat="server" Text="View Studio" Visible="False"></asp:Label>
                <br />
                <center>
                    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns ="False" 
                        EmptyDataText ="Record Not Found!!!" BackColor="#CCCCCC" BorderColor="#999999" 
                        BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
                        ForeColor="Black">
                        <Columns >
                        <asp:BoundField DataField ="studioname" HeaderText ="Studio Name" />
                                          <asp:BoundField DataField ="packname" HeaderText ="Package Name" />
                                                            <asp:BoundField DataField ="packdesc" HeaderText ="Package Description" />
                                                                              <asp:BoundField DataField ="amount" HeaderText ="Amount" />
         
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
            <td style="text-align :center; margin-left: 40px;" colspan="2">
                <asp:Label ID="Label6" runat="server" Text="View Moisoft" Visible="False"></asp:Label>
                <br />
                <center>
                    <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns ="False" 
                        EmptyDataText ="Record Not Found!!!" BackColor="#CCCCCC" BorderColor="#999999" 
                        BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
                        ForeColor="Black">
                        <Columns >
                            <asp:BoundField DataField ="mid" HeaderText ="ID" />
                            <asp:BoundField DataField ="icount" HeaderText ="Invitation Count" />
                              <asp:BoundField DataField ="scost" HeaderText ="Service Cost" />
                                <asp:BoundField DataField ="scount" HeaderText ="System Count" />
                           
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
        <td style="text-align :center; margin-left: 40px;" colspan="2">
            <asp:Label ID="Label4" runat="server" Text="Total Amount" Visible="False"></asp:Label>
            <br />
            <br />
           <center><asp:DetailsView ID="DetailsView1" runat="server" Height="50px" 
                   Width="293px" AutoGenerateRows ="False" 
                   EmptyDataText ="Record Not Found!!!" BackColor="#CCCCCC" BorderColor="#999999" 
                   BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
                   ForeColor="Black">
               <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <Fields >
                     <asp:BoundField DataField ="hrent" HeaderText ="Hall Rent" />
                       <asp:BoundField DataField ="camount" HeaderText ="Catering Amount" />
                       <asp:BoundField DataField ="damount" HeaderText ="Decoration Amount" />
                           <asp:BoundField DataField ="samount" HeaderText ="Studio Amount" />
                         <asp:BoundField DataField ="mamount" HeaderText ="Moisoft Amount" />
            </Fields>
               <FooterStyle BackColor="#CCCCCC" />
               <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
               <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
               <RowStyle HorizontalAlign="Left" BackColor="White" />
            </asp:DetailsView></center> 
        </td>
    </tr>
    <tr>
        <td style="text-align :center; margin-left: 40px;" colspan="2">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>

