<%@ Page Title="Student Repository" Language="C#" AutoEventWireup="true" CodeBehind="StudentRepository.aspx.cs" Inherits="Comp229_Assign03.Pages.StudentRepository" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="StudentPrinter">
        <asp:GridView ID="studentGridView" AutoGenerateColumns="false" runat="server">
        </asp:GridView>

        <asp:TextBox runat="server" ID="firstMidName"></asp:TextBox>
        <asp:TextBox runat="server" ID="lastName"></asp:TextBox>
        <asp:Button runat="server" ID="addStudentButton" Text="Add Student" OnClick="Add_Student"></asp:button>
    </div>

</asp:Content>
