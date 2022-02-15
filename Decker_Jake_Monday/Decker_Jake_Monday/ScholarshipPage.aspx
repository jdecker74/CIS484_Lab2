<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ScholarshipPage.aspx.cs" Inherits="Decker_Jake_Monday.ScholarshipPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    
    <%-- Current Scholarships --%>
    <br />
    <asp:Label ID="lblCurrentScholarships" runat="server" Text="Current Scholarships:  " Width="200"></asp:Label>
    <asp:DropDownList ID="scholarshipDropDown" DataSourceID="srcScholarship" DataTextField="ScholarshipName" runat ="server" AutoPostBack="true" Width="200"></asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCurrentScholarships" runat="server" ErrorMessage=" Scholarship Name Required" ControlToValidate="scholarshipDropDown"></asp:RequiredFieldValidator>
   <br />
    <br />
    <%-- Scholarship Name --%>
    <asp:Label ID="ScholarshipName" runat="server" Text="Scholarship Name:" Width="200"></asp:Label>
    <asp:TextBox ID="txtName" runat="server" Width="150"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ErrorMessage=" Scholarship Name Required" ControlToValidate="txtName"></asp:RequiredFieldValidator>
    <br />
    
    <%-- Scholarship Year --%>
      <asp:Label ID="ScholarshipYear" runat="server" Text="Year Awarded: " Width="200"></asp:Label>
    <asp:TextBox ID="txtYear" runat="server" Width="150"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorYear" runat="server" ErrorMessage=" Scholarship Year Required" ControlToValidate="txtYear"></asp:RequiredFieldValidator>
    <br />

    <%-- Scholarship Amount --%>
    <asp:Label ID="ScholarshipAmount" runat="server" Text="Scholarship Amount" Width ="200"></asp:Label>
    <asp:TextBox ID="txtScholarshipAmount" runat="server" Width="150"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorAmount" runat="server" ErrorMessage=" Scholarship Amount Required" ControlToValidate="txtScholarshipAmount"></asp:RequiredFieldValidator>
    <br />
     <%-- Approving Member (Shows --%>
    <asp:Label ID="ApprovingMember" runat="server" Text="Select Member for Approval" Width ="200"></asp:Label>
    <asp:DropDownList ID="dropdownListMember" DataSourceID="srcMember" DataTextField="MemberName"  runat ="server" AutoPostBack="true"></asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorApprovingMember" runat="server" ErrorMessage=" Approving Member Required" ControlToValidate="dropdownListMember"></asp:RequiredFieldValidator>
    <br />
    <br />
    
    <%-- Commit and Save Buttons --%>
    <asp:Button ID="populateScholarship" runat="server" Text="Populate Scholarship" Width="200" OnClick ="populateScholarship_Click" CausesValidation="false"/>
    <asp:Button ID="clearScholarship" runat="server" Text="Clear Scholarship" Width="200" OnClick="clearScholarship_Click" CausesValidation="false"/>
    <br />
    <asp:Button ID="commitScholarship" runat="server" Text="Commit Scholarship" Width="200" OnClick="commitScholarship_Click" CausesValidation="true"/>
    <asp:Button ID="saveScholarship" runat="server" Text="Save Scholarship" Width="200" OnClick="saveScholarship_Click" CausesValidation="true"/>
    <asp:Label ID="buttonStatus" runat="server" Text=""></asp:Label>

   

     <asp:SqlDataSource ID="srcScholarship"
        runat="server"
        ConnectionString="<%$ ConnectionStrings:Lab1Database %>"
        SelectCommand="SELECT ScholarshipName, ScholarshipAmount From Scholarship"></asp:SqlDataSource>

    <asp:SqlDataSource ID="srcMember"
        runat="server"
        ConnectionString="<%$ ConnectionStrings:Lab1Database %>"
        SelectCommand="SELECT MemberName From Member"></asp:SqlDataSource>
</asp:Content>
