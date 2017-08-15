<%@ Page Title="" Language="C#" MasterPageFile="~/UI/PioneerTechMasterPage.Master" AutoEventWireup="true" CodeBehind="EducationDetails.aspx.cs" Inherits="PioneerTech.WebApp.UI.EducationalDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="EducationDetails" class="style1">
        <tr>
           <th>EducationDetails</th>
        </tr>
        <tr id="CourseTypeRow">
            <td>
                <asp:Label ID="CourseTypeLabel" runat="server" Text="CourseType"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="CourseTypeTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr id="CourseSpecialisationRow">
            <td>
                <asp:Label ID="CourseSpecialisationLabel" runat="server" Text="Coursespecialisation"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="CoursespecialisationTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr id="YearOfPassRow">
            <td>
                <asp:Label ID="YearOfPassLabel" runat="server" Text="YearOfPass"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="YearOfPassTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="EducationalDetailsSave" runat="server" Text="Save" OnClick="EducationalDetailsSave_Click" />
            </td>
            <td>
                <asp:Button ID="EducationalDetailsEdit" runat="server" Text="Edit" />
            </td>
            <td>
                <asp:Button ID="EducationalDetailsClear" runat="server" Text="Clear" />
            </td>
        </tr>
    </table>
</asp:Content>
