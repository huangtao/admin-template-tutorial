<%
    // 获取登录表达数据
    String username = request.getParameter("username");
    String password = request.getParameter("password");
    // 判断登录是否成功
    if (username.equals("admin") && password.equals("admin")) {
        // 跳转到登录成功页面
        System.out.println("登录成功!");
        session.setAttribute("username", username);
        response.sendRedirect("home.jsp?username=" + username);
    } else {
        // 跳转到登录失败页面
        response.sendRedirect("error.jsp?username=" + username);
    }
%>