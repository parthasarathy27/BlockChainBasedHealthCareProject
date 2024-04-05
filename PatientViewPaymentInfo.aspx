<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PatientViewPaymentInfo.aspx.cs" Inherits="PatientViewPaymentInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <table align="center" border="0" width="70%"  cellpadding ="10px">
        <tr>
            <th colspan ="2">
                <h3 >
&nbsp;View Payment Information</h3><hr />
            </th>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Patient ID</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center ;" colspan="2">
            <center>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" 
                    EmptyDataText ="Record Not Found!!!" BackColor="#CCCCCC" BorderColor="#999999" 
                    BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
                    ForeColor="Black">
                    <Columns>
                    <asp:BoundField DataField ="did" HeaderText ="Doctor ID" />
 <asp:BoundField DataField ="dname" HeaderText ="Doctor Name" />
 <asp:BoundField DataField ="ttype" HeaderText ="Treatment Type" />
 <asp:BoundField DataField ="tamount" HeaderText ="Treatment Amount" />
 <asp:BoundField DataField ="tdate" HeaderText ="Treatment Date" HtmlEncode ="false" DataFormatString ="{0:dd-MMM-yyy}" />
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
                </asp:GridView></center>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center ;" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
</asp:Content>

