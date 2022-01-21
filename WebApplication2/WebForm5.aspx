<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm5.aspx.cs" Inherits="WebApplication2.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style2 {
        width: 400px;
    }
    .auto-style3 {
        text-align: center;
    }
        .auto-style6 {
            text-align: center;
            height: 52px;
        }
        .auto-style7 {
            width: 1024px;
            height: 140px;
        }
        .auto-style8 {
            height: 278px;
        }
        .auto-style9 {
            text-align: center;
            height: 167px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style7">
    <tr>
        <td class="auto-style6"><strong>URL</strong></td>
    </tr>
    <tr>
        <td class="auto-style9" >
            <asp:TextBox ID="url5" runat="server" Width="670px" Height="157px" textmode = "Multiline"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style3">
            <asp:Button ID="Button5" runat="server" Text="Start" OnClick="Button5_Click" />
        </td>
    </tr>
        <tr>
                    <td style="vertical-align: top; text-align: center;" class="auto-style8" >
                        <asp:Label ID="lbl5" runat="server" Text="Text" Height="1000px" Width="1013px" autosize="true"></asp:Label>
                    </td></tr>
</table>
</asp:Content>
