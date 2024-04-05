<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PatientViewMedicalSchemeApplyDetails.aspx.cs" Inherits="PatientViewMedicalSchemeApplyDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" border="0" width="70%"  cellpadding ="10px">
        <tr>
            <th colspan ="2">
                <h3 >
                    View
                    Applied Medical Insurance Scheme</h3><hr />
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
                    <asp:DetailsView ID="DetailsView1" runat="server"   
                        EmptyDataText ="Record Not Found!!!" AutoGenerateRows ="False" 
                        AllowPaging="True" onpageindexchanging="DetailsView1_PageIndexChanging" 
                        BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
                        CellPadding="4" CellSpacing="2" ForeColor="Black" >
                        <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <Fields>
                    <asp:BoundField DataField ="policyno"  HeaderText ="Policy Number" />
                    <asp:BoundField DataField ="padate" HeaderText ="Policy Apply Date" HtmlEncode ="false" DataFormatString ="{0:dd-MMM-yyyy}" />
                    <asp:BoundField DataField ="iid" HeaderText ="Insurer ID" />
                                   <asp:BoundField DataField ="cname" HeaderText ="Insurance Company Name" />
                            <asp:BoundField DataField ="mischeme" HeaderText ="Medical Insurance Scheme" />
                            <asp:BoundField DataField ="ipamount" HeaderText ="Insurance Policy Amount" />
                            <asp:BoundField DataField ="vperiod" HeaderText ="Valid Period in Year" />
                            <asp:BoundField DataField ="idisease" HeaderText ="Disease to be Insured" />
                            <asp:BoundField DataField ="mcamount" HeaderText ="Maximum Claim Amount" />                     
                    
                    
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
            <td style ="text-align :center ;" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
</asp:Content>

