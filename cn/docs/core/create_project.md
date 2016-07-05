在创建项目前，请准备好以下的东西

- Visual Studio 2015 update 3
- 如果你需要运行在Asp.Net Core上，请安装
	- DotNetCore 1.0.0 Runtime
	- DotNetCore 1.0.0 VS2015 Tooling Preview 2
- 下载ZKWeb和ZKWeb.Plugins项目
	- https://github.com/zkweb-framework/ZKWeb
	- https://github.com/zkweb-framework/ZKWeb.Plugins

准备好以后，打开`ZKWeb\Tools\ProjectCreator.Gui.exe`，创建一个新的项目。<br/>
如果使用的是SQLite以外的数据库，请先创建好一个空的数据库，并点击`Test`测试数据库连接。<br/>
![项目创建器](../img/project_creator.jpg)

创建好项目以后，使用Visual Studio打开并运行。<br/>
第一次打开需要编译所有插件，可能会耗时几分钟，请耐心等待。<br/>
![首次运行](../img/first_running.jpg)

### FAQ

<h4>我不想使用默认的插件集，怎么办？</h4>
默认的插件集中包含了比较多的功能，但不一定适合所有人的需要。<br/>
如果不想使用默认的插件集，可以在创建项目时把`Use Default Plugins`留空。<br/>
不使用默认的程序集需要自己编写静态文件处理器和表单处理等功能，可以参考`Common.Base`插件进行编写。

<h4>我需要重新初始化数据库，怎么办？</h4>
重新创建数据库后，删除`App_Data\DatabaseScript.txt`并刷新网站即可。

<h4>怎么进入默认的后台？</h4>
后台地址是`/admin`，首次运行网站时应该先注册一个用户并用这个用户登录到后台。<br/>
网站创建后第一个登陆到后台的用户会成为超级管理员。