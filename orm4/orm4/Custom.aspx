<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Custom.aspx.cs" Inherits="orm4.Custom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <asp:ListView ID="ListView1" runat="server" ItemType="orm4.Custom">
        <LayoutTemplate>
            <table>
                <tr>

                </tr>
                <tr id="itemPlaceholder" runat="server"></tr>
            </table>
        </LayoutTemplate>

        <ItemTemplate>
            <tr>

            </tr>
        </ItemTemplate>
    </asp:ListView>
    <label>Первое задание:</label>
        <asp:Button ID="Button1" runat="server" Text="Button"  OnClick="Button1_Click"/>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
        <label>Второе задание:</label>
        <asp:Button ID="Button2" runat="server" Text="Button"  OnClick="Button2_Click"/>
    <br />
        <label>Третье задание:</label>
        <asp:Button ID="Button3" runat="server" Text="Button" OnClick="Button3_Click" />
        <label id="query3"></label>
</asp:Content>
