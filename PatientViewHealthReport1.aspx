<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PatientViewHealthReport1.aspx.cs" Inherits="PatientViewHealthReport1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" border="0" width="70%"  cellpadding ="10px">
        <tr>
            <th colspan ="2">
                <h3 >
                    Patient View Health Report</h3><hr />
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
                Secret Key</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
            &nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" 
                    onclick="LinkButton2_Click">Get Key</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center ;" colspan="2">
                <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" 
                    onclick="LinkButton1_Click">Verify</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center ;" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
</asp:Content>

