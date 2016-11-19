<%@ Page Title="Courses" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="CoursesPage.aspx.cs" Inherits="Comp229_Assign03.Pages.CoursesPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="CoursesLayout">
        <asp:GridView ID="coursesGridView" AutoGenerateColumns="false" runat="server">
        </asp:GridView>
    </div>

</asp:Content>
