<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PatientApplyMedicalInsuranceScheme.aspx.cs" Inherits="PatientApplyMedicalInsuranceScheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <table align="center" border="0" width="70%"  cellpadding ="10px">
        <tr>
            <th colspan ="2">
                <h3 >
                    Apply
                    Medical Insurance Scheme</h3><hr />
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
            <td style ="text-align :right ;">
                Policy Number</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Registration Date</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td >
            <h5 style ="text-align :center ;">Patient Information</h5>
            <center>
                <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="345px" 
                    AutoGenerateRows ="False" EmptyDataText ="Record Not Found!!!" 
                    BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
                    CellPadding="4" CellSpacing="2" ForeColor="Black" >
                    <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <Fields>
                 
    <asp:BoundField DataField ="pname" HeaderText ="Patient Name" />
    <asp:BoundField DataField ="gender" HeaderText ="Gender" />
    <asp:BoundField DataField ="age" HeaderText ="Age" />
    <asp:BoundField DataField ="address" HeaderText ="Address" />
    <asp:BoundField DataField ="city" HeaderText ="City" />
    <asp:BoundField DataField ="mno" HeaderText ="Mobile Number" />
    <asp:BoundField DataField ="emailid" HeaderText ="Email ID" />
                </Fields>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle HorizontalAlign="Left" BackColor="White" />
                </asp:DetailsView></center>
            </td>
            <td>
             <h5 style ="text-align :center ;">Policy Information</h5>
             <center>
                <asp:DetailsView ID="DetailsView2" runat="server" Height="50px" Width="381px" 
                     AutoGenerateRows ="False" EmptyDataText ="Record Not Found!!!" 
                     BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
                     CellPadding="4" CellSpacing="2" ForeColor="Black" >
                    <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <Fields>
                     <asp:BoundField DataField ="iid" HeaderText ="Insurer ID" />
                  <asp:BoundField DataField ="cname" HeaderText ="Insurance Company Name" />
                            <asp:BoundField DataField ="mischeme" HeaderText ="Medical Insurance Scheme" />
                            <asp:BoundField DataField ="ipamount" HeaderText ="Insurance Policy Amount" />
                            <asp:BoundField DataField ="vperiod" HeaderText ="Valid Period in Year" />
                            <asp:BoundField DataField ="idisease" HeaderText ="Disease to be Insured" />
                            <asp:BoundField DataField ="mcamount" HeaderText ="Maximum Claim Amount" />
                            <asp:BoundField DataField ="cdate" HeaderText ="Created Date" HtmlEncode ="false" DataFormatString ="{0:dd-MMM-yyyy}" />
                </Fields>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle HorizontalAlign="Left" BackColor="White" />
                </asp:DetailsView></center>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center ;" colspan="2">
                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click"  Font-Bold="True">Apply</asp:LinkButton>
            &nbsp;&nbsp;
                </td>
        </tr>
        <tr>
            <td style ="text-align :center ;" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    &nbsp;
            </td>
        </tr>
    </table>

</asp:Content>

