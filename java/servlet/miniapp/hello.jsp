<html>

<head>
    <title>Hello World - JSP</title>
</head>

<body>
    <%-- JSP Comment --%>
    <h2>Hello World!</h2>
    <p>
    <%
        out.println("Your IP address is ");
    %>
    <span style="color:red">
        <%= request.getRemoteAddr() %>
    </span>
    </p>
</body>

</html>