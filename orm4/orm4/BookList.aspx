<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookList.aspx.cs" Inherits="orm4.BookList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="ListView1" runat="server" ItemType="orm4.BookViewModel"
            SelectMethod="GetBooks"
            InsertMethod="InsertBook" DataKeyNames="BookId">
        <LayoutTemplate>
            <table>
                <tr>
                    <th>ID</th>
                    <th>Название</th>
                    <th>Автор</th>
                    <th>Год публикации</th>
                    <th>Размещение</th>
                </tr>
                <tr id="itemPlaceholder" runat="server"></tr>
            </table>
        </LayoutTemplate>

        <ItemTemplate>
            <tr>
                <td><%# Item.BookID %></td>
                <td><%# Item.BookName %></td>
                <td><%# Item.AuthorName %></td>
                <td><%# Item.PublishYear %></td>
                <td><%# Item.BookLocation %></td>
            </tr>
        </ItemTemplate>
    </asp:ListView>

</asp:Content>
