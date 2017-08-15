<%@ Page Title="" Language="C#" MasterPageFile="~/UI/PioneerTechMasterPage.Master" AutoEventWireup="true" CodeBehind="ProjectDetails.aspx.cs" Inherits="PioneerTech.WebApp.UI.ProjectDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="ProjectDetails" class="style1">
        <tr>
           <th>ProjectDetails</th>
        </tr>
        <tr id="EmployeeIDRow">
            <td>
                <asp:Label ID="EmployeeIDLabel" runat="server" Text="EmployeeID"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="EmployeeIDTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr id="Project_NameRow">
            <td>
                <asp:Label ID="Project_NameLabel" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="Project_NameTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr id="Client_NameRow">
            <td>
                <asp:Label ID="Client_NameLabel" runat="server" Text="Client_Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="Client_NameTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr id="LocationRow">
            <td>
                <asp:Label ID="LocationLabel" runat="server" Text="Location"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="LocationTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr id="RolesRow">
            <td>
                <asp:Label ID="RolesLabel" runat="server" Text="Roles"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="RolesTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="ProjectDetailsSave" runat="server" Text="Save" OnClick="ProjectDetailsSave_Click" />
            </td>
            <td>
                <asp:Button ID="ProjectDetailsEdit" runat="server" Text="Edit" />
            </td>
            <td>
                <asp:Button ID="ProjectDetailsClear" runat="server" Text="Clear" />
            </td>
        </tr>
    </table>
</asp:Content>
