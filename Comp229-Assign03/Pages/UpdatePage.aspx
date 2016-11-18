<%@ Page Title="Update Student" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="UpdatePage.aspx.cs" Inherits="Comp229_Assign03.Pages.UpdatePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="UpdateStudent">
        <asp:label runat="server" ID="StudentIDLbl" Text='<%# Eval("studentId") %>'></asp:label>
        <asp:TextBox runat="server" ID="FirstMidNameTextBox" Text='<%# Eval("firstmidName") %>'></asp:TextBox>
        <asp:TextBox runat="server" ID="LastNameTextBox" Text='<%# Eval("lastName") %>'></asp:TextBox>
        <asp:Button runat="server" ID="updateStudentButton" Text="Update" OnClick="UpdateButton_Click"></asp:button>
    </div>

</asp:Content>