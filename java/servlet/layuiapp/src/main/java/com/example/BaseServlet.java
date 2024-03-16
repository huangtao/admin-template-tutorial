package com.example;

import java.io.*;
import java.lang.reflect.Method;

import jakarta.servlet.*;
import jakarta.servlet.http.*;

public class BaseServlet extends HttpServlet {

    /**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	public void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        doPost(request, response);
    }

    public void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        try {
            String name = request.getParameter("method");
            // 利用反射机制，取得类中的方法
            Method method = this.getClass().getMethod(name, HttpServletRequest.class, HttpServletResponse.class);
            // 执行方法
            Object result = method.invoke(this, request, response);
            // 返回响应值
            if (result != null) {
                String str = (String)result;
                response.setContentType("application/json");
                response.getWriter().println(str);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}