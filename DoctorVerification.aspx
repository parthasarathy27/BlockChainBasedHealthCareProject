<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DoctorVerification.aspx.cs" Inherits="DoctorVerification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table align="center" border="0" width="70%"  cellpadding ="10px">
<tr>
<th colspan ="2"><h3>Doctor Verification Process</h3><hr /></th>
</tr>
<tr>
<td colspan ="2">
<center>
    <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="393px" 
        AutoGenerateRows ="False" EmptyDataText ="Record Not Found!!!" 
        BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
        CellPadding="4" CellSpacing="2" ForeColor="Black">
        <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
    <Fields>
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
    </Fields>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle HorizontalAlign="Left" BackColor="White" />
    </asp:DetailsView>
    </center>
</td>
</tr>
<tr>
<td style ="text-align :right ;">Status</td>
<td>
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatLayout="Flow">
        <asp:ListItem>Accept</asp:ListItem>
        <asp:ListItem>Reject</asp:ListItem>
    </asp:RadioButtonList>
</td>
</tr>
<tr>
<td  style ="text-align :center ;" colspan="2">

    <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" 
        onclick="LinkButton1_Click">Update</asp:LinkButton>
</td>
</tr>
<tr>
<td  style ="text-align :center ;" colspan="2">

    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</td>
</tr>
</table>
</asp:Content>

