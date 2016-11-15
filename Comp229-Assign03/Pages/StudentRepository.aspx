<%@ Page Title="Student Repository" Language="C#" AutoEventWireup="true" CodeBehind="StudentRepository.aspx.cs" Inherits="Comp229_Assign03.Pages.StudentRepository" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="StudentPrinter">
        <asp:Repeater runat="server">
            <ItemTemplate>
                <asp:Label runat="server"> <%# Eval("FirstName") %></asp:Label>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
