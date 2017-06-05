<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="orm4.UserList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<asp:ListView ID="ListView1" runat="server" ItemType="orm4.UserInfo"
             SelectMethod="GetUsers" UpdateMethod="EditUser" DeleteMethod="DeleteUser"
             InsertMethod="InsertUser" DataKeyNames="UserId">
            <LayoutTemplate>
                <table>
                    <tr>
                        <th>ID</th>
                        <th>Имя</th>
                        <th>Дата регистрации</th>
                        <th>Дата рождения</th>
                    </tr>
                    <tr id="itemPlaceholder" runat="server"></tr>
                </table>
            </LayoutTemplate>

            <ItemTemplate>
                <tr>
                    <td><%# Item.UserID %></td>
                    <td><%# Item.UserName %></td>
                    <td><%# Item.UserRegDate != null ? Item.UserRegDate.ToShortDateString() : String.Empty %></td>
                    
                    <td><%# Item.BirthDate?.ToShortDateString() ?? string.Empty %></td>
                    <td>
                        <asp:Button CommandName="Edit" runat="server" Text="Изменить" />
                        <asp:Button CommandName="Delete" runat="server" Text="Удалить" />
                    </td>
                </tr>
            </ItemTemplate>

            <EditItemTemplate>
                <tr>
                    <td><%# Item.UserID %></td>
                    <td><input id="userName" runat="server" value="<%# BindItem.UserName %>" /></td>
                    <td><%# Item.UserRegDate != null ? Item.UserRegDate.ToShortDateString() : String.Empty %></td>
                    <td><input id="birthDate" runat="server" value="<%# BindItem.BirthDate %>" /></td>
                    <td>
                        <asp:Button CommandName="Update" runat="server" Text="Сохранить" />
                        <asp:Button CommandName="Cancel" runat="server" Text="Отмена" />
                    </td>
                </tr>
            </EditItemTemplate>

            <InsertItemTemplate>
                <tr>
                    <td></td>
                    <td><input id="userName" runat="server" value="<%# BindItem.UserName %>" /></td>
                    <td><input id="userRegDate" runat="server" value="<%# DateTime.UtcNow.ToShortDateString() %>" /></td>
                    <td><input id="birthDate" runat="server" value="<%# BindItem.BirthDate %>" /></td>
                    <td>
                        <asp:Button ID="Button1" CommandName="Insert" runat="server" Text="Вставить" />
                    </td>
                </tr>
            </InsertItemTemplate>
        </asp:ListView>
    </asp:Content>