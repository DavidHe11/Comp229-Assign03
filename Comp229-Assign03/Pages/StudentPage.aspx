<%@ MasterPageFile="~/Site.Master" Page Title="Student" Language="C#" AutoEventWireup="true" CodeBehind="StudentPage.aspx.cs" Inherits="Comp229_Assign03.Pages.StudentPage" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="StudentPage">
        <asp:label runat="server" ID="StudentIDLbl" Text='<%# Eval("studentId") %>'></asp:label>
        <asp:label runat="server" ID="FirstMidNameLbl" Text='<%# Eval("firstmidName") %>'></asp:label>
        <asp:label runat="server" ID="LastNameLbl" Text='<%# Eval("lastName") %>'></asp:label>
        <asp:Button runat="server" ID="updateStudentButton" Text="Update" OnClick="UpdateButton_Click"></asp:button>
        <asp:Button runat="server" ID="deleteStudentButton" Text="Delete" OnClick="DeleteButton_Click"></asp:button>
    </div>

</asp:Content>
