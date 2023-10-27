<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfosForm.aspx.cs" Inherits="WebFormProject3.UserInfosForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <thead>
                    <tr>
                        <th>이름</th>
                        <th>나이</th>
                        <th>연락처</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="UserInfos" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("Name") %></td>
                                <td><%# Eval("Age") %></td>
                                <td><%# Eval("Phone") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
