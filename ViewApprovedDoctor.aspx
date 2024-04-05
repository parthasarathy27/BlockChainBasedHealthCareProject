<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewApprovedDoctor.aspx.cs" Inherits="ViewApprovedDoctor" %>

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
            EmptyDataText ="Record Not Found!!!" BackColor="#CCCCCC" BorderColor="#999999" 
            BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
            ForeColor="Black" >
    <Columns>
   <asp:BoundField DataField ="did" HeaderText ="Doctor ID" />
    <asp:BoundField DataField ="uname" HeaderText ="User ID" />
    <asp:BoundField DataField ="dname" HeaderText ="Doctor Name" />
    <asp:BoundField DataField ="gender" HeaderText ="Gender" />
    <asp:BoundField DataField ="age" HeaderText ="Age" />
    <asp:BoundField DataField ="address" HeaderText ="Address" />
    <asp:BoundField DataField ="mno" HeaderText ="Mobile Number" />
    <asp:BoundField DataField ="emailid" HeaderText ="Email ID" />
    <asp:BoundField DataField ="qualification" HeaderText ="Qualification" />
    <asp:BoundField DataField ="certificateno" HeaderText ="Certificate Number" />
    <asp:BoundField DataField ="experience" HeaderText ="Experience" />
    <asp:BoundField DataField ="specialist" HeaderText ="Specialist" />
    <asp:BoundField DataField ="status" HeaderText ="Status" />
  
    
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

