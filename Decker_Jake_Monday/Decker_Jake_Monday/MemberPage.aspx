<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MemberPage.aspx.cs" Inherits="Decker_Jake_Monday.MemberPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
     <%-- Title --%>
    <asp:Label ID="lblTitle" runat="server" Text="Title" Width ="150"></asp:Label>
        <asp:DropDownList ID="dropDownTitle" runat="server" Width="200">
                <asp:ListItem Text="Select Preffered Title" Value="1"></asp:ListItem>
                <asp:ListItem Text="Mr." Value="Mr."></asp:ListItem>
                <asp:ListItem Text="Mrs." Value="Mrs."></asp:ListItem>
                <asp:ListItem Text="Miss" Value="Miss"></asp:ListItem>
                <asp:ListItem Text="Dr." Value="Dr."></asp:ListItem>
            </asp:DropDownList>
    
    <%-- Member Name --%>
    <br />
    <asp:Label ID="MemberName" runat="server" Text="Member Name:" Width="150"></asp:Label>
    <asp:TextBox ID="txtMemberName" runat="server" Width="150"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate ="txtMemberName" Text ="Member Name Cannot be Empty"></asp:RequiredFieldValidator>
    <br />
    <%-- Email Address --%>
    <asp:Label ID="MemberEmailAddress" runat="server" Text="Email Address:" Width ="150"></asp:Label>
    <asp:TextBox ID="txtEmailAddress" runat="server" Width="150"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate ="txtEmailAddress" Text ="Member Email Cannot be Empty"></asp:RequiredFieldValidator>
    <br />
      <%-- Phone Number --%>
    <asp:Label ID="PhoneNumber" runat="server" Text="Phone Number:" Width ="150"></asp:Label>
    <asp:TextBox ID="txtPhoneNumber" runat="server" Width="150"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhone" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate ="txtPhoneNumber" Text ="Phone Number Cannot be Empty"></asp:RequiredFieldValidator>
    <br />
     <%-- Member Grad Year --%>
    <asp:Label ID="memberGradYear" runat="server" Text="Graduation Year:" Width ="150"></asp:Label>
    <asp:TextBox ID="txtMemberGradYear" runat="server" TextMode="Date" Width="150"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorYear" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate ="txtMemberGradYear" Text ="Graduation Year Cannot be Empty"></asp:RequiredFieldValidator>
    <br />
    <br />
     <%-- Buttons --%>
   <asp:Button ID="btnPopulate" runat="server" Text="Populate Member" Width="200" OnClick="btnPopulate_Click" CausesValidation ="false" />
    <asp:Button ID="btnClear" runat="server" Text="Clear Member" Width="200" OnClick="btnClear_Click" CausesValidation="false" />
    <br />
    <asp:Button ID="btnAddMember" runat="server" Text="Commit Memeber" OnClick="btnAddMember_Click" Width="200" CausesValidation="true" />
    
    <%-- Button Status Label --%>
    <asp:Label ID="buttonStatus" runat="server" Text=""></asp:Label>

</asp:Content>
