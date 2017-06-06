<%@ Page Language="C#"  MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="orm4.ASPX.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <h1><strong><span class="auto-style1">Welcome to LibNet Service!</span></strong></h1>
        <br />
        <br />
            <asp:LoginView ID="LoginView1" runat="server">
                <AnonymousTemplate>
                    You are not logged in. Click the Login link to sign in <br />
                </AnonymousTemplate>
                <LoggedInTemplate>
                        You are logged in. Welcome,
                    <asp:LoginName ID="LoginName1" runat="server" />
                    <br />
                    <br />
                </LoggedInTemplate>
            </asp:LoginView>
        <br />
            <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutPageUrl="~/LoginPage.aspx" />
        <br />

</asp:Content>