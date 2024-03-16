package com.example;

import java.io.*;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.*;
import jakarta.servlet.http.*;

// 最新Servlet版本只需要通过注解就可以完成映射
@WebServlet(urlPatterns = "/test")
public class TestServlet extends HttpServlet {

    public void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        doPost(request, response);
    }

    public void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        // 设置响应类型
        response.setContentType("text/html");
        // 获取输出流
        PrintWriter out = response.getWriter();
        // 写入响应
        out.println("<html>");
        out.println("<head>");
        out.println("<title>Hello World!</title>");
        out.println("</head>");
        out.println("<body>");
        out.println("<h1>Test</h1>");
        out.println("</body>");
        out.println("</html>");
    }
}