<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Custom.aspx.cs" Inherits="orm4.Custom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <asp:ListView ID="ListView1" runat="server" ItemType="orm4.Custom">
    </asp:ListView>
    <br />
    <br />
    <label>Первое задание:</label>
    <div class ="task">ФИО всех пользователей, которые брали книги авторов родившихся до 1900 года.</div>
        <asp:Button ID="Button1" runat="server" Text="Найти"  OnClick="Button1_Click"/>
        <asp:Label ID="Label1" runat="server" Text="Нажми на кнопку, получишь результат"></asp:Label>
    <br />
    <br />
        <label>Второе задание:</label>
    <div class ="task">Название всех книг, купленных в марте 2003 года, и их стоимость.</div>
        <asp:Button ID="Button2" runat="server" Text="Найти"  OnClick="Button2_Click"/>
        <asp:Label ID="Label2" runat="server" Text="Нажми на кнопку, получишь результат"></asp:Label>
    <br />
    <br />
        <label>Третье задание:</label>
    <div class ="task">Книги, которые у пользователей на руках и у которых больше двух авторов.</div>
        <asp:Button ID="Button3" runat="server" Text="Найти" OnClick="Button3_Click" />
        <asp:Label ID="Label3" runat="server" Text="Нажми на кнопку, получишь результат"></asp:Label>
</asp:Content>
