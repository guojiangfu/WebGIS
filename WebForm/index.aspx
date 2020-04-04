<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebForm.WebGIS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>WebGIS实验</title>
    <style>
        div {
            font-size: 18px;
            text-align: center;
        }

        .t {
            border: 1px black solid;
            border-spacing: 0px;
            margin: 0 auto;
        }

        .t td {
            border: 1px black solid;
            padding: 5px;
        }

        .t th {
            border: 1px black solid;
            padding: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>WebGIS实验三</h1>
        <table class="t" id ="tab1" runat="server">
            <thead>
                <tr>
                    <td>姓名</td>
                    <td>学号</td>
                    <td>ID</td>
                    <td>成绩</td>
                    <td>科目</td>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>
                            <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="tbNumber" runat="server"></asp:TextBox>
                    </td>
                    <td>
                       <asp:TextBox ID="tbID" runat="server"></asp:TextBox>
                    </td>
                    <td>
                      <asp:TextBox ID="tbScore" runat="server"></asp:TextBox>
                    </td>
                    <td>
                       <asp:TextBox ID="tbCourse" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </tbody>
        </table> 
       <asp:Button runat="server" ID="BtnLoad" text="加载" Width="80px" Height="30px" OnClick="BtnLoad_Click"/>
        <asp:Button runat="server" ID="BtnAdd" text="添加" Width="80px" Height="30px" OnClick="BtnAdd_Click"/>
        <asp:Button ID="BtnDel" runat="server" OnClick="BtnDel_Click" Text="删除" Width="80px" Height="30px"/>
        <asp:Button ID="BtnUpdate" runat="server" OnClick="BtnUpdate_Click" Text="修改" Width="80px" Height="30px" />
        <asp:Button ID="BtnSelect" runat="server" OnClick="BtnSelect_Click" Text="查询" Width="80px" Height="30px" />
        <asp:Button ID="BtnClose" runat="server" Text="断开数据库"  Width="80px" Height="30px" OnClick="BtnClose_Click"/>
    </div>
  </form>
</body>
</html>
