<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Library.aspx.cs" Inherits="Biblioteka.Library" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 847px;
            height: 374px;
        }
        .auto-style3 {
            height: 23px;
            width: 163px;
        }
        .auto-style5 {
            width: 297px;
        }
        .auto-style6 {
            height: 23px;
            width: 297px;
            text-align: center;
        }
        .auto-style7 {
            height: 178px;
            width: 297px;
        }
        .auto-style8 {
            width: 287px;
            height: 178px;
            text-align: center;
        }
        .auto-style9 {
            height: 178px;
            width: 163px;
        }
        .auto-style14 {
            width: 287px;
            text-align: center;
        }
        .auto-style15 {
            text-align: center;
            width: 163px;
        }
        .auto-style16 {
            width: 297px;
            text-align: center;
            height: 36px;
        }
        .auto-style18 {
            text-align: center;
            width: 163px;
            height: 36px;
        }
        .auto-style19 {
            width: 297px;
            text-align: center;
            height: 45px;
        }
        .auto-style21 {
            text-align: center;
            width: 163px;
            height: 45px;
        }
        .auto-style22 {
            width: 287px;
            text-align: center;
            height: 36px;
        }
        .auto-style23 {
            height: 23px;
            width: 287px;
            text-align: center;
        }
        .auto-style24 {
            width: 287px;
            text-align: center;
            height: 45px;
        }
        .auto-style26 {
            margin-left: 0px;
        }
        .auto-style27 {
            width: 297px;
            height: 50px;
        }
        .auto-style28 {
            width: 287px;
            text-align: center;
            height: 50px;
        }
        .auto-style29 {
            text-align: center;
            width: 163px;
            height: 50px;
        }
        .auto-style30 {
            height: 23px;
            width: 163px;
            text-align: center;
        }
    </style>
</head>
<body style="height: 492px; width: 896px;">
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="lInfo" runat="server" Text="..." ForeColor="Blue"></asp:Label>
                    </td>
                    <td class="auto-style14">
                        <asp:Button ID="Button1" runat="server" Text="START" OnClick="Button1_Click" Height="41px" Width="191px" />
                    </td>
                    <td class="auto-style15">
                        <asp:Button ID="btnReset" runat="server" Height="39px" OnClick="btnReset_Click" Text="RESET" Width="111px" />
                    </td>
                    <td class="auto-style15">
                        <asp:Label ID="lSwitch" runat="server" ForeColor="Red" Text="OFF"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style16">
                        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" Width="91px" />
                    </td>
                    <td class="auto-style22">
                        &nbsp;</td>
                    <td class="auto-style18">
                        &nbsp;</td>
                    <td class="auto-style18">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        <asp:Label ID="Label1" runat="server" Text="Authors"></asp:Label>
                    </td>
                    <td class="auto-style23">
                        <asp:Label ID="Label2" runat="server" Text="Title"></asp:Label>
                    </td>
                    <td class="auto-style30">
                        <asp:Label ID="Label3" runat="server" Text="ID"></asp:Label>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style19">
                        <asp:TextBox ID="txtAuthor" runat="server" Width="292px"></asp:TextBox>
                    </td>
                    <td class="auto-style24">
                        <asp:TextBox ID="txtTitle" runat="server" Width="286px"></asp:TextBox>
                    </td>
                    <td class="auto-style21">
                        <asp:Label ID="lId" runat="server" ForeColor="White" Text="NULL"></asp:Label>
                    </td>
                    <td class="auto-style21">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" Width="92px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:ListBox ID="lbBooks" runat="server" AutoPostBack="True" Height="169px" Width="302px"></asp:ListBox>
                    </td>
                    <td class="auto-style8">
                        <asp:Button ID="btnSelect" runat="server" OnClick="btnSelect_Click" Text="Select" Width="206px" />
                    </td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style27"></td>
                    <td class="auto-style28">
                        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" CssClass="auto-style26" Width="82px" />
                    </td>
                    <td class="auto-style29">
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" Width="86px" />
                    </td>
                    <td class="auto-style29">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
