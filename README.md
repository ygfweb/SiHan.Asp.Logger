# SiHan.Asp.Logger
## 介绍

ASP.NET Core 简单日志库，为ASP.NET Core 3.1添加颜色控制台、滚动文件日志。

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

        public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
			.ConfigureLogging(logging =>
			{
				logging.ClearProviders();
				logging.AddConsole();
				logging.AddFile();
			})
			.ConfigureWebHostDefaults(webBuilder =>
			{
				webBuilder.UseStartup<Startup>();
			});

    }
```

