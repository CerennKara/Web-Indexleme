<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="WebApplication2.WebForm4" %>
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style7">
    <tr>
        <td class="auto-style6"><strong>URL</strong></td>
    </tr>
    <tr>
        <td class="auto-style3" >
            <asp:TextBox ID="url41" runat="server" Width="670px"></asp:TextBox>
        </td>
    </tr>
          <tr>
        <td class="auto-style3" >
            <asp:TextBox ID="url42" runat="server" Width="670px" Height="187px" textmode = "Multiline"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style3">
            <asp:Button ID="Button4" runat="server" Text="Start" OnClick="Button4_Click" />
        </td>
    </tr>
        <tr><td style="vertical-align: top;" class="auto-style8" >
                        <asp:Label ID="lbl4" runat="server" Text="Text" Height="1000px" Width="1013px" autosize="true"></asp:Label>
                    </td></tr>
</table>
</asp:Content>