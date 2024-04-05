<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewDoctorDetails.aspx.cs" Inherits="ViewDoctorDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <table align="center" border="0" width="70%"  cellpadding ="10px">
<tr>
<th><h3>View Doctor Details</h3><hr /></th>
</tr>
<tr>
<td>
   <center><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" 
           EmptyDataText ="Record Not Found!!!" DataKeyNames ="did" BackColor="#CCCCCC" 
           BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
           CellSpacing="2" ForeColor="Black">
    <Columns>
    <asp:BoundField DataField ="did" HeaderText ="Doctor ID" />
    <asp:BoundField DataField ="uname" HeaderText ="User ID" />
    <asp:BoundField DataField ="dname" HeaderText ="Doctor Name" />
    <asp:BoundField DataField ="mno" HeaderText ="Mobile Number" />
    <asp:BoundField DataField ="emailid" HeaderText ="Email ID" />
    <asp:HyperLinkField Text ="View" HeaderText ="Verification" DataNavigateUrlFields ="did" DataNavigateUrlFormatString ="DoctorVerification.aspx?DID={0}" ControlStyle-Font-Bold ="true" ControlStyle-ForeColor ="Red"  />
    
    
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
<td  style ="text-align :center ;">

    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</td>
</tr>
</table>
</asp:Content>

