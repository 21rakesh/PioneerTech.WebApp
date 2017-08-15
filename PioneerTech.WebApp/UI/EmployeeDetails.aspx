<%@ Page Title="" Language="C#" MasterPageFile="~/UI/PioneerTechMasterPage.Master" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="PioneerTech.WebApp.UI.EmployeeDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <table ID="EmployeeTable" class="style1">
      <tr>
          <th>EmployeeDetails</th>
          </tr>
            <tr id="FirstNameRow">
        <td>
            <asp:Label ID="FirstNameLabel" runat="server" Text="FirstName"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="FirstNameTextBox" runat="server" Width="160px"></asp:TextBox>
        </td>
    </tr>
    <tr id="LastNameRow">
        <td>
            <asp:Label ID="LastNameLabel" runat="server" Text="LastName"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="LastNameTextBox" runat="server" Width="158px"></asp:TextBox>
        </td>
    </tr>
        <tr id="EmailRow">
            <td>
                <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr id="MobileNumberRow">
            <td>
                <asp:Label ID="MobileNumberLabel" runat="server" Text="MobileNumber"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="MobileNumberTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr id="AlternateMobileNumberRow">
            <td>
                <asp:Label ID="AlternateMobileNumberLabel" runat="server" Text="AlternateMobileNumber"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="AlternateMobileNumberTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr id="Address1Row">
            <td>
                <asp:Label ID="Address1Label" runat="server" Text="Address1"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="Address1TextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr id="Addrees2Row">
            <td>
                <asp:Label ID="Address2Label" runat="server" Text="Address2"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="Address2TextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr id="CurrentCountryRow">
            <td>
                <asp:Label ID="CurrentCountryLabel" runat="server" Text="CurrentCountry"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="CurrentCountryTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr id="HomeCountryRow">
            <td>
                <asp:Label ID="HomeCountryLabel" runat="server" Text="HomeCountry"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="HomeCountryTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr id="ZipCodeRow">
            <td>
                <asp:Label ID="ZipCodeLabel" runat="server" Text="ZipCode"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="ZipCodeTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="SaveButton" runat="server" Text="Save" OnClick="SaveButton_Click" Width="104px" />
            </td>
            <td>
                <asp:Button ID="EditButton" runat="server" Text="Edit" Width="107px" />
            </td>
            <td>
                <asp:Button ID="ClearButton" runat="server" Text="Clear" Width="93px" Height="25px" />
            </td>

        </tr>
        </table>     
</asp:Content>
