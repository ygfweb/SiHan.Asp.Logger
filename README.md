# SiHan.Asp.Logger
## 介绍

ASP.NET Core 简单日志库，为ASP.NET Core 2.1添加颜色控制台、滚动文件日志。

## 安装

```
PM> Install-Package SiHan.Asp.Logger
```

## 使用

```c#
public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddColorConsole(); // 添加颜色控制台
                    logging.AddFile(); // 添加滚动文件
                });
    }
```

