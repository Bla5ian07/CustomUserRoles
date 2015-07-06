<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Login"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    Please login to access.....
    <br />
    <br />
    <table border="1" style="border-collapse: collapse;">
        <tr>
            <td>
                Username:
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Password:
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" TextMode="Password" Width="147px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
</asp:Content>
