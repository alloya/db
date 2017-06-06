<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="orm4.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Login ID="Login1" 
        runat="server" 
        OnAuthenticate="ValidateUser"
         InstructionText="Enter your user name and password to log in." DestinationPageUrl="~/Default.aspx">
        <InstructionTextStyle Font-Bold="True" ForeColor="#E0E0E0" BackColor="Gray"></InstructionTextStyle>
    </asp:Login>
</asp:Content>
