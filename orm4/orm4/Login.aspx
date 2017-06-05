<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="orm4.ASPX.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Login ID="Login1" runat="server" OnLoggingIn="Login1_LoggingIn"></asp:Login>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Login1" HeaderText="Заполните необходимые поля."/>

</asp:Content>
