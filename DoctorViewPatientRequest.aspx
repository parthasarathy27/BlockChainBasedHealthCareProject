<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DoctorViewPatientRequest.aspx.cs" Inherits="DoctorViewPatientRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table align="center" border="0" width="70%"  cellpadding ="10px">
        <tr>
            <th colspan ="2">
                <h3 >
                    View Patient Request 
                    &amp; Report</h3><hr />
            </th>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Doctor ID</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center ;" colspan="2">
                <center>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" 
                        EmptyDataText ="Record Not Found!!!" DataKeyNames ="reqid" 
                        onrowcommand="GridView1_RowCommand" BackColor="#CCCCCC" 
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
                        CellSpacing="2" ForeColor="Black">
                        <Columns>
                        <asp:BoundField DataField ="reqid" HeaderText ="Request ID" />
                         <asp:BoundField DataField ="reqdate" HeaderText ="Request Date" HtmlEncode ="false" DataFormatString ="{0:dd-MMM-yyyy}" />
                          <asp:BoundField DataField ="pid" HeaderText ="Patient ID" />
                           <asp:BoundField DataField ="pname" HeaderText ="Patient Name" />
                            <asp:BoundField DataField ="gender" HeaderText ="Gender" />
                             <asp:BoundField DataField ="age" HeaderText ="Age" />
                              <asp:BoundField DataField ="mno" HeaderText ="Mobile Number" />
                               <asp:BoundField DataField ="emailid" HeaderText ="Email ID" />
                                <asp:BoundField DataField ="pkey" HeaderText ="Private Key" />


                                <asp:ButtonField Text ="View" HeaderText ="View Health Info" CommandName ="vh" ControlStyle-Font-Bold ="true" ControlStyle-ForeColor ="Red"  />
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
            <td style ="text-align :center ;" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>

</asp:Content>

