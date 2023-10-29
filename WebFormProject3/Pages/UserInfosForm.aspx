<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfosForm.aspx.cs" Inherits="WebFormProject3.UserInfosForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
                        <th>성별</th>
                        <th>연락처</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="UserInfos" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("Name") %></td>
                                <td><%# Eval("Age") %></td>
                                <td><%# Eval("Gender") %></td>
                                <td><%# Eval("Phone") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <div>
            <table>
                <thead>
                    <tr>
                        <th>이름</th>
                        <th>생년월일</th>
                        <th>성별</th>
                        <th>연락처</th>
                    </tr>
                </thead>
                <tbody id="inputRows">
                    <tr class="userItem">
                        <td>
                            <input class="inputName" type="text" /></td>
                        <td>
                            <input class="inputBirthday" type="text" /></td>
                        <td>
                            <input class="inputGender" type="text" /></td>
                        <td>
                            <input class="inputPhone" type="text" /></td>
                    </tr>
                </tbody>
            </table>
            <div>
                <asp:Button ID="btnAddRow" runat="server" Text="행 추가" OnClientClick="addUserRow();" />
                <asp:Button ID="btnInsert" runat="server" Text="삽입하기" OnClick="btnInsert_Click" OnClientClick="return insertUser();" />
            </div>
        </div>
    </form>
    <script>
        function addUserRow() {
            event.preventDefault();

            const newTr = document.createElement("tr");
            newTr.classList.add("userItem");
            newTr.innerHTML = `<td><input class="inputName" type="text"/></td>
<td><input class="inputBirthday" type="text"/></td>
<td><input class="inputGender" type="text"/></td>
<td><input class="inputPhone" type="text"/></td>`;

            const tbody = document.getElementById("inputRows");
            tbody.appendChild(newTr);

            return true;
        }

        function insertUser() {
            return true;
        }
    </script>
</body>
</html>
