<%@ Page Title="" Language="C#" MasterPageFile="~/Defualt.Master" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="myjobprotal.LoginForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table>


    <tr>
        <td>User Type:</td>
        <td><asp:DropDownList ID="ddluserType" runat="server">
            <asp:ListItem Text="---select---" Value="0"></asp:ListItem>
            <asp:ListItem Text="Admin" Value="1"></asp:ListItem>
            <asp:ListItem Text="Jobseeker" Value="2"></asp:ListItem>
            <asp:ListItem Text="Jobrecrutier" Value="3"></asp:ListItem>
            
            </asp:DropDownList></td>
    

    </tr>

  


    <tr>
        <td>Email:</td>
        <td><asp:TextBox ID="txtemail" runat="server"></asp:TextBox></td>
    </tr>

    <tr>
        <td>Password:</td>
        <td><asp:TextBox ID="txtpassword" runat="server"></asp:TextBox></td>
    </tr>
    
  

    <tr>
        <td></td>
        <td><asp:Button ID="btnlogin" runat="server" Text="Login" OnClick="btnlogin_Click" /></td>
    </tr>
    <tr>
        <td></td>
        <td><asp:Label ID="lblmsg" runat="server" ForeColor="OrangeRed" Font-Bold="true"></asp:Label></td>
    </tr>

</table>
</asp:Content>
