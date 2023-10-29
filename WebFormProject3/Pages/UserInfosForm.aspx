<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfosForm.aspx.cs" Inherits="WebFormProject3.UserInfosForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="userInfoForm" runat="server">
        <div>
            <div>
                <asp:Label Text="이름: " runat="server" />
                <asp:TextBox runat="server" ID="tBoxName" Placeholder="홍길동" Required="true" />
            </div>
            <div>
                <asp:Label Text="생년월일: " runat="server" />
                <asp:TextBox runat="server" ID="tBoxBirthday" Placeholder="1996-04-01" Required="true" />
            </div>
            <div>
                <asp:Label Text="성별" runat="server" />
                <asp:RadioButton Text="남성" runat="server" ID="radioMan" GroupName="RadioGenders" Checked="true" />
                <asp:RadioButton Text="여성" runat="server" ID="radioWoman" GroupName="RadioGenders" />
            </div>
            <div>
                <asp:Label Text="휴대폰 번호" runat="server" />
                <asp:TextBox runat="server" ID="tBoxPhone" Placeholder="010-1234-5678" Required="true" />
            </div>
            <div>
                <asp:Button ID="btnInsert" runat="server" Text="삽입하기" type="submit" OnClick="btnInsert_Click" OnClientClick="return validateUserInfo();"/>
            </div>
        </div>
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
    </form>
    <script>
        function validateUserInfo() {
            const tBoxBirthday = document.querySelector("#<%= tBoxBirthday.ClientID%>");
            const birthday = tBoxBirthday.value;
            if (!/^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|31)$/.test(birthday)) {
                alert("생년월일의 양식을 만족하지 않습니다.");
                return false;
            }

            const date = new Date(birthday);
            if (Date.now() < date) {
                alert("생년월일은 현재 이후일 수 없습니다.");
                return false;
            }

            const tBoxPhone = document.querySelector("#tBoxPhone");
            const phone = tBoxPhone.value;
            if (!/^\d{3,4}-\d{4}-\d{4}$/.test(phone)) {
                alert("휴대폰 번호의 양식을 만족하지 않습니다.");
                return false;
            }
            console.log("검사 통과!");
            return true;
        }
    </script>
</body>
</html>
