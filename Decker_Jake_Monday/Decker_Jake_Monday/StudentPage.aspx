<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="StudentPage.aspx.cs" Inherits="Decker_Jake_Monday.StudentPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%-- List Box of Students Currently in Database --%>
    <asp:Label ID="lblStudentList" runat="server" Text="Student List: " Width="150"></asp:Label>
    <asp:ListBox ID="lstStudents" runat="server" DataSourceID="sqlsrcStudentTable"
                DataTextField="StudentName" DataValueField="StudentID" AutoPostBack="true"></asp:ListBox>
    <br />
    <br />
      
    <%-- Student Name --%>
    <asp:Label ID="FirstName" runat="server" Text="First Name:" Width="150"></asp:Label>
    <asp:TextBox ID="txtFirstName" runat="server" Width="150"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorFName" runat="server" ErrorMessage="First Name Required" ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
    <br />
      <asp:Label ID="LastName" runat="server" Text="Last Name:" Width="150"></asp:Label>
    <asp:TextBox ID="txtLastName" runat="server" Width="150"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorLName" runat="server" ErrorMessage="Last Name Required" ControlToValidate="txtLastName"></asp:RequiredFieldValidator>
    <br />
    <%-- Email Address --%>
    <asp:Label ID="StudentEmailAddress" runat="server" Text="Email Address:" Width ="150"></asp:Label>
    <asp:TextBox ID="txtEmail" runat="server" Width="150"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ErrorMessage="Email Required" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
    <br />

      <%-- Phone Number --%>
    <asp:Label ID="PhoneNumber" runat="server" Text="Phone Number:" Width ="150"></asp:Label>
    <asp:TextBox ID="txtPhoneNumber" runat="server" Width="150"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPNumber" runat="server" ErrorMessage="Phone Number Required" ControlToValidate="txtPhoneNumber"></asp:RequiredFieldValidator>
    <br />

      <%-- Major --%>
    <asp:Label ID="Major" runat="server" Text="Major:" Width ="150"></asp:Label>
    <asp:TextBox ID="txtMajor" runat="server" Width="150"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorMajor" runat="server" ErrorMessage="Major Required" ControlToValidate="txtMajor"></asp:RequiredFieldValidator>
    <br />
    
    <%-- Graduation Date --%>
   <asp:Label ID="lblGradDate" runat="server" Text="Graduation Date:" Width="150"></asp:Label>
   <asp:TextBox ID="txtGraduationDate" runat="server" TextMode="Date" Width="150"></asp:TextBox>
   <asp:RequiredFieldValidator ID="RequiredFieldValidatorGradYear" runat="server" ErrorMessage="Graduation Date Required" ControlToValidate="txtGraduationDate"></asp:RequiredFieldValidator>
   <br />
 
    <%-- Grade Level --%>
            <asp:Label ID="lblGradeLevel" runat="server" Text="Grade Level:"  Width="150"></asp:Label>
            <asp:DropDownList ID="dropDownGradeLevel" runat="server" Width="200">
                <asp:ListItem Text="Select Grade Level" Value="1"></asp:ListItem>
                <asp:ListItem Text="Freshman" Value="Freshman"></asp:ListItem>
                <asp:ListItem Text="Sophomore" Value="Sophomore"></asp:ListItem>
                <asp:ListItem Text="Junior" Value="Junior"></asp:ListItem>
                <asp:ListItem Text="Senior" Value="Senior"></asp:ListItem>
            </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorGradeLevel" runat="server" ErrorMessage="Grade Level Required" ControlToValidate="dropDownGradeLevel"></asp:RequiredFieldValidator>
            <br />
           
    <%-- Employment Status --%>
             <asp:Label ID="lblEmploymentStatus" runat="server" Text="Employment Status:"  Width="150"></asp:Label>
            <asp:DropDownList ID="dropDownEmploymentStatus" runat="server" Width="200">
                <asp:ListItem Text="Select Employment Status" Value="1"></asp:ListItem>
                <asp:ListItem Text="Not working" Value="Not working"></asp:ListItem>
                <asp:ListItem Text="Internship" Value="Internship"></asp:ListItem>
                <asp:ListItem Text="Part-Time" Value="Part-Time"></asp:ListItem>
                <asp:ListItem Text="Full-Time" Value="Full-Time"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
      <%-- Buttons --%>
             <asp:Button ID="btnPopulate" runat="server" Text="Populate Student" Width="150" OnClick="btnPopulate_Click" CausesValidation="false" />
            <asp:Button ID="btnClear" runat="server" Text="Clear Information" Width="150" OnClick="btnClear_Click" CausesValidation="false" />   
            <br />
            <asp:Button ID="btnAdd" runat="server" Text="Commit Student" Width="150" OnClick ="btnAdd_Click" CausesValidation="true" />
            <asp:Button ID="btnSave" runat="server" Text="Save Student" Width="150" OnClick="btnSave_Click2" CausesValidation="true" />
            <asp:Label ID="buttonStatus" runat="server" Text=""></asp:Label>
            <br />
      <%-- Data Source --%>
    <asp:SqlDataSource ID="sqlsrcStudentTable"
        runat="server"
        ConnectionString="<%$ ConnectionStrings:Lab1Database %>"
        SelectCommand="SELECT (FirstName + ' ' + LastName) AS StudentName, StudentID From Student"></asp:SqlDataSource>
</asp:Content>
