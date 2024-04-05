<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddMedicalInsuranceScheme.aspx.cs" Inherits="AddMedicalInsuranceScheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" border="0" width="70%"  cellpadding ="10px">
        <tr>
            <th colspan ="2">
              <h3>
                    Medical Insurance Scheme</h3><hr />
            </th>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Insurer ID</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Insurance Company Name</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Medical Insurance Scheme</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Insurance Policy Amount</td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Valid Period(In Years)</td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Disease to be Insured</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>Neuro Surgery</asp:ListItem>
                    <asp:ListItem>Heart Surgery</asp:ListItem>
                    <asp:ListItem>Skin Surgery</asp:ListItem>
                    <asp:ListItem>Eye Surgery</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Maximum Claim Amount</td>
            <td>
                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Created Date</td>
            <td>
                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center ;" colspan="2">
                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click"   ForeColor="#3333FF">Insert</asp:LinkButton>
            &nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" 
                    onclick="LinkButton2_Click">Clear</asp:LinkButton>
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

