<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="DoctorRegistration.aspx.cs" Inherits="DoctorRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" border="0" width="70%"  cellpadding ="10px">
        <tr>
            <th colspan ="2">
                <h3 >Doctor Registration</h3><hr /></th>
</tr>
<tr>
<td style ="text-align :right ;">Doctor ID</td>
<td>
    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
    </td>

</tr>

<tr>
<td style ="text-align :right ;">Doctor Name</td>
<td>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </td>

</tr>

<tr>
<td style ="text-align :right ;">Gender</td>
<td>
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
        RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem>Male</asp:ListItem>
        <asp:ListItem>Female</asp:ListItem>
    </asp:RadioButtonList>
    </td>

</tr>

<tr>
<td style ="text-align :right ;">Age</td>
<td>
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    </td>

</tr>

<tr>
<td style ="text-align :right ;">Address</td>
<td>
    <asp:TextBox ID="TextBox4" runat="server" TextMode="MultiLine"></asp:TextBox>
    </td>

</tr>

<tr>
<td style ="text-align :right ;">Mobile Number</td>
<td>
    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
    </td>

</tr>

<tr>
<td style ="text-align :right ;">Email ID</td>
<td>
    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
    </td>

</tr>

<tr>
<td style ="text-align :right ;">Qualification</td>
<td>
    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
    </td>

</tr>

<tr>
<td style ="text-align :right ;">Certificate Number</td>
<td>
    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
    </td>

</tr>

<tr>
<td style ="text-align :right ;">Experience</td>
<td>
    <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
    </td>

</tr>

<tr>
<td style ="text-align :right ;">Specialist</td>
<td>
    <asp:TextBox ID="TextBox10" runat="server" TextMode="MultiLine"></asp:TextBox>
    </td>

</tr>

<tr>
<td style ="text-align :right ;">User Name</td>
<td>
    <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
    </td>

</tr>

<tr>
<td style ="text-align :right ;">Password</td>
<td>
    <asp:TextBox ID="TextBox12" runat="server" TextMode="Password"></asp:TextBox>
    </td>

</tr>

<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click"  Font-Bold="True" >Register</asp:LinkButton>
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



