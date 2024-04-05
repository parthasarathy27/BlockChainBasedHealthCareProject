<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="PatientLogin.aspx.cs" Inherits="PatientLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <table align="center" border="0" width="70%"  cellpadding ="10px">
        <tr>
            <th colspan ="2">
                <h3 >
                    Patient Login</h3><hr />
            </th>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Patient ID</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Password</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center ;" colspan="2">
                <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" 
                    onclick="LinkButton1_Click">Login</asp:LinkButton>

                      <span style ="float :right; width: 105px;">
            <asp:HyperLink ID="HyperLink1" runat="server" 
                    NavigateUrl="~/PatientRegistration.aspx" Font-Bold="True">New Registration</asp:HyperLink>
                    </span>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center ;" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
</asp:Content>

