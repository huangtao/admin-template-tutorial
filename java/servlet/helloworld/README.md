# tomcat servlet hello world

1. 安装开发环境：JDK、Apache Tomcat。
2. Tomcat的webapps目录一般结构：
|-- webapp                         # 站点根目录
    |-- META-INF                   # META-INF 目录
    |   `-- MANIFEST.MF            # 配置清单文件
    |-- WEB-INF                    # WEB-INF 目录
    |   |-- classes                # class文件目录
    |   |   |-- *.class            # 程序需要的 class 文件
    |   |   `-- *.xml              # 程序需要的 xml 文件
    |   |-- lib                    # 库文件夹
    |   |   `-- *.jar              # 程序需要的 jar 包
    |   `-- web.xml                # Web应用程序的部署描述文件
    |-- <userdir>                  # 自定义的目录
    |-- <userfiles>                # 自定义的资源文件
- webapp：工程发布文件夹。其实每个 war 包都可以视为 webapp 的压缩包。
- META-INF：META-INF 目录用于存放工程自身相关的一些信息，元文件信息，通常由开发工具，环境自动生成。
- WEB-INF：Java web应用的安全目录。所谓安全就是客户端无法访问，只有服务端可以访问的目录。
- /WEB-INF/classes：存放程序所需要的所有 Java class 文件。
- /WEB-INF/lib：存放程序所需要的所有 jar 文件。
- /WEB-INF/web.xml：web 应用的部署配置文件。它是工程中最重要的配置文件，它描述了 servlet 和组成应用的其它组件，以及应用初始化参数、安全管理约束等。

3. 编写代码中我们一般从HttpServlet继承(编写doGet,doPost)，如果从GenericServlet继承则重写service()方法。
4. 在classes目录下编译代码：javac -classpath %TOMCAT_DIR%/lib/servlet-api.jar -encoding UTF-8 -d . HelloWorld.java
5. 编译成功后将helloworld拷贝到Tomcat的webapps目录下
6. 启动tomcat访问:http://localhost:8080/{appdir}/{url}。因为我们的目录是helloworld，web.xml给servlet配置的url是/hello。所以正确的路径是：
http://localhost:8080/helloworld/hello