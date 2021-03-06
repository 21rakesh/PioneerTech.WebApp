﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UI/PioneerTechMasterPage.Master" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="PioneerTech.WebApp.UI.EmployeeDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <table ID="EmployeeTable" >
      <tr>
          <th>EmployeeDetails</th>
          </tr>
       <tr id="EmployeeIDRow">
            <td>
                <asp:Label ID="EmployeeIDLabel" runat="server" Text="EmployeeID"></asp:Label>   
            </td>
            <td style="width: 255px">
                 <asp:DropDownList ID="EmployeeIDDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="EmployeeIDDropDownList_SelectedIndexChanged">
                     <asp:ListItem Text="Select One to edit" Value="0"></asp:ListItem>
                 </asp:DropDownList>
            </td>
        </tr>
      <tr id="First_NameRow">
        <td>
            <asp:Label ID="First_NameLabel" runat="server" Text="First_Name"></asp:Label>
        </td>
        <td style="width: 255px">
            <asp:TextBox ID="First_NameTextBox" runat="server" ></asp:TextBox>
            </td>
          <td>
            <asp:RequiredFieldValidator ID="First_NameRequiredFieldValidator" runat="server" ErrorMessage="Please enter first name" ControlToValidate="First_NameTextBox" ForeColor="#CC0000"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr id="Last_NameRow">
        <td>
            <asp:Label ID="Last_NameLabel" runat="server" Text="Last_Name"></asp:Label>
        </td>
        <td style="width: 255px">
            <asp:TextBox ID="Last_NameTextBox" runat="server" ></asp:TextBox>
            </td>
        <td>
            <asp:RequiredFieldValidator ID="Last_NameRequiredFieldValidator" runat="server" ErrorMessage="Please enter last name" ControlToValidate="Last_NameTextBox" ForeColor="#CC0000"></asp:RequiredFieldValidator>
        </td>
    </tr>
        <tr id="EmailRow">
            <td>
                <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
            </td>
            <td style="width: 255px">
                <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
                </td>
            <td>
                <asp:RegularExpressionValidator ID="EmailRegularExpressionValidator" runat="server" ErrorMessage="Please enter valid email id" ControlToValidate="EmailTextBox"
                    SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="#CC0000"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr id="Mobile_NumberRow">
            <td>
                <asp:Label ID="Mobile_NumberLabel" runat="server" Text="Mobile_Number"></asp:Label>
            </td>
            <td style="width: 255px">
                <asp:TextBox ID="Mobile_NumberTextBox" runat="server"></asp:TextBox>
                </td>
            <td>
                <asp:RegularExpressionValidator ID="Mobile_NumberRegularExpressionValidator" runat="server" ErrorMessage="Please enter a valid mobile number" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" ForeColor="#CC0000" ControlToValidate="Mobile_NumberTextBox"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr id="AlternateMobileNumberRow">
            <td>
                <asp:Label ID="AlternateMobileNumberLabel" runat="server" Text="AlternateMobileNumber"></asp:Label>
            </td>
            <td style="width: 255px">
                <asp:TextBox ID="AlternateMobileNumberTextBox" runat="server"></asp:TextBox>
                </td>
            <td>
                <asp:RegularExpressionValidator ID="AlternateMobileNumberRegularExpressionValidator" runat="server" ErrorMessage="Please enter a valid mobile number" ForeColor="#CC0000" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" ControlToValidate="AlternateMobileNumberTextBox"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr id="Address1Row">
            <td>
                <asp:Label ID="Address1Label" runat="server" Text="Address1"></asp:Label>
            </td>
            <td style="width: 255px">
                <asp:TextBox ID="Address1TextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr id="Addrees2Row">
            <td>
                <asp:Label ID="Address2Label" runat="server" Text="Address2"></asp:Label>
            </td>
            <td style="width: 255px">
                <asp:TextBox ID="Address2TextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr id="Current_CountryRow">
            <td>
                <asp:Label ID="Current_CountryLabel" runat="server" Text="Current_Country"></asp:Label>
            </td>
            <td style="width: 255px">
                <asp:TextBox ID="Current_CountryTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr id="Home_CountryRow">
            <td>
                <asp:Label ID="Home_CountryLabel" runat="server" Text="Home_Country"></asp:Label>
            </td>
            <td style="width: 255px">
                <asp:TextBox ID="Home_CountryTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr id="ZipCodeRow">
            <td>
                <asp:Label ID="ZipCodeLabel" runat="server" Text="ZipCode"></asp:Label>
            </td>
            <td style="width: 255px">
                <asp:TextBox ID="ZipCodeTextBox" runat="server"></asp:TextBox>
                </td>
            <td>
                <%--<asp:RegularExpressionValidator ID="ZipCodeRegularExpressionValidator" runat="server" ErrorMessage="Please enter valid ZipCode" ControlToValidate="ZipCodeTextBox" ForeColor="#CC0000" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>--%>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="SaveButton" runat="server" Text="Save" OnClick="SaveButton_Click" Width="104px" />
            </td>
            <td style="width: 255px">
                <asp:Button ID="EditButton" runat="server" Text="Edit" Width="107px" OnClick="EditButton_Click" />
            </td>
            <td>
                <asp:Button ID="ClearButton" runat="server" Text="Clear" Width="93px" Height="25px" OnClick="ClearButton_Click" />
            </td>

        </tr>
        </table>     
</asp:Content>
