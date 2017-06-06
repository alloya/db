<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Authors.aspx.cs" Inherits="orm4.Authors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ListView ID="ListView1" runat="server" ItemType="orm4.Author"
             SelectMethod="GetAuthors" UpdateMethod="EditAuthor" DeleteMethod="DeleteAuthor"
             InsertMethod="InsertAuthor" DataKeyNames="AuthorId">
            <LayoutTemplate>
                <table>
                    <tr>
                        <th>ID</th>
                        <th>Имя</th>
                        <th>Дата рождения</th>
                        <th>Дата сметри</th>
                    </tr>
                    <tr id="itemPlaceholder" runat="server"></tr>
                </table>
            </LayoutTemplate>

            <ItemTemplate>
                <tr>
                    <td><%# Item.AuthorID %></td>
                    <td><%# Item.AuthorName %></td>
                    <td><%# Item.BirthDate != null ? Item.BirthDate.ToShortDateString() : String.Empty %></td>
                    <td><%# Item.DeathDate?.ToShortDateString() ?? string.Empty %></td>
                    <td>
                        <asp:Button CommandName="Edit" runat="server" Text="Изменить" />
                        <asp:Button CommandName="Delete" runat="server" Text="Удалить" />
                    </td>
                </tr>
            </ItemTemplate>

            <EditItemTemplate>
                <tr>
                    <td><%# Item.AuthorID %></td>
                    <td><input id="userName" runat="server" value="<%# BindItem.AuthorName %>" /></td>
                    <td><input id="BirthDate" runat="server" value="<%# BindItem.BirthDate %>" /></td>
                    <td><input id="DeathDate" runat="server" value="<%# BindItem.DeathDate %>" /></td>
                    <td>
                        <asp:Button CommandName="Update" runat="server" Text="Сохранить" />
                        <asp:Button CommandName="Cancel" runat="server" Text="Отмена" />
                    </td>
                </tr>
            </EditItemTemplate>

            <InsertItemTemplate>
                <tr>
                    <td></td>
                    <td><input id="userName" runat="server" value="<%# BindItem.AuthorName %>" /></td>
                    <td><input id="BirthDate" runat="server" value="<%# BindItem.BirthDate %>" /></td>
                    <td><input id="DeathDate" runat="server" value="<%# BindItem.DeathDate %>" /></td>
                    <td>
                        <asp:Button ID="Button1" CommandName="Insert" runat="server" Text="Вставить" />
                    </td>
                </tr>
            </InsertItemTemplate>
        </asp:ListView>
</asp:Content>
