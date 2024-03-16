package com.example;

import java.io.*;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.*;
import jakarta.servlet.http.*;
import java.util.HashMap;
import java.util.Map;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

// 最新Servlet版本只需要通过注解就可以完成映射
@WebServlet(urlPatterns = "/login.do")
public class LoginServlet extends BaseServlet {

    /**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	public String login(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        Map<String,Object> data = new HashMap<>();

        // 获取登录表达数据
        String username = request.getParameter("username");
        String password = request.getParameter("password");
        // 判断登录是否成功
        if (username.equals("admin") && password.equals("admin")) {
            // 跳转到登录成功页面
            System.out.println("登录成功!");
            HttpSession session = request.getSession();
            session.setMaxInactiveInterval(12 * 60 * 60); // 12小时
            session.setAttribute("isLogin", true);
            session.setAttribute("username", username);

            data.put("ret", 1);
        } else {
            // 失败
            data.put("ret", 0);
        }

        Gson gson = new Gson();
        String jsonStr = gson.toJson(data);
        return jsonStr;
    }
}