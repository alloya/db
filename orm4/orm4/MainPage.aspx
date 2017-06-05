<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="orm4.ASPX.MainPage" %>


<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            Вы не авторизованы
        </AnonymousTemplate>
    </asp:LoginView>
</asp:Content>



