<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ManageCities.aspx.cs" Inherits="myjobprotal.AdminModule.ManageCities" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
            <table>
    <tr>
        <td>States Name:</td>  
        <td><asp:DropDownList ID="ddlstate" runat="server"></asp:DropDownList></td>
    </tr>

    <tr>
        <td>Countries Name:</td>  
        <td><asp:DropDownList ID="ddlcountry" runat="server" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
    </tr>
    <tr>

        <td>City Name:</td>  
        <td><asp:TextBox ID="txtcityname" runat="server"></asp:TextBox></td>
    </tr>
    

        <tr>
        <td></td>
        <td><asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" /></td>
    </tr>
    <tr>
        <td></td>
        <td><asp:GridView ID="gvcities" runat="server" AutoGenerateColumns="False" OnRowCommand="gvcities_RowCommand"  CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="City Id">
                    <ItemTemplate>
                        <%#Eval("cityid") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="CityName"  >
                    <ItemTemplate>
                        <%#Eval("cityname") %>
                    </ItemTemplate>
                </asp:TemplateField>
                

                
                <asp:TemplateField HeaderText="States Name">
                    <ItemTemplate>
                        <%#Eval("sid") %>
                    </ItemTemplate>
                </asp:TemplateField>



                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btndelete" runat="server" Text="Delete" CommandName="A" CommandArgument='<%#Eval("cityid") %>' />
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnedit" runat="server" Text="Edit" CommandName="B" CommandArgument='<%#Eval("cityid") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>

        </td>
    </tr>

</table>

</asp:Content>
