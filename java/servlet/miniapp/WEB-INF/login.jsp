<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>登录</title>
</head>
<body>
    <a href="/home">返回</a>
    <form action="/login" methon="post">
        <input type="text" name="user"/>
        <input type="password" name="password"/>
        <input type="submit" value="登录">
    </form>
</body>
</html>