<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>登录</title>
</head>
<body>
    <h3>登录</h3>
    <form action="doLogin.jsp" methon="post">
        <table>
            <tr>
                <td>用户名:</td>
                <td><input type="text" name="username" /></td>
            </tr>
            <tr>
                <td>密码:</td>
                <td><input type="password" name="password" /></td>
            </tr>
            <tr>
                <td colspan="2"><input type="submit" value="登录" /></td>
            </tr>
        </table>
    </form>
</body>

</html>