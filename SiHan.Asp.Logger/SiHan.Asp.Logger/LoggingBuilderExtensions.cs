using Microsoft.Extensions.Logging;
using SiHan.Asp.Logger.ColoredConsole;
using SiHan.Asp.Logger.LogFiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiHan.Asp.Logger
{
    public static class LoggingBuilderExtensions
    {
        public static ILoggingBuilder AddColorConsole(this ILoggingBuilder builder)
        {
            builder.AddProvider(new ColoredConsoleLoggerProvider(new ColoredConsoleLoggerConfiguration()
            {
                LogLevel = LogLevel.Trace,
                Color = ConsoleColor.White
            }));
            builder.AddProvider(new ColoredConsoleLoggerProvider(new ColoredConsoleLoggerConfiguration()
            {
                LogLevel = LogLevel.Debug,
                Color = ConsoleColor.White
            }));
            builder.AddProvider(new ColoredConsoleLoggerProvider(new ColoredConsoleLoggerConfiguration()
            {
                LogLevel = LogLevel.Information,
                Color = ConsoleColor.White
            }));
            builder.AddProvider(new ColoredConsoleLoggerProvider(new ColoredConsoleLoggerConfiguration
            {
                LogLevel = LogLevel.Warning,
                Color = ConsoleColor.Yellow
            }));
            builder.AddProvider(new ColoredConsoleLoggerProvider(new ColoredConsoleLoggerConfiguration
            {
                LogLevel = LogLevel.Error,
                Color = ConsoleColor.Red
            }));
            builder.AddProvider(new ColoredConsoleLoggerProvider(new ColoredConsoleLoggerConfiguration
            {
                LogLevel = LogLevel.Critical,
                Color = ConsoleColor.Red
            }));
            return builder;
        }
        public static ILoggingBuilder AddFile(this ILoggingBuilder builder)
        {
            builder.AddProvider(new FileLoggerProvider());
            return builder;
        }
    }
}




