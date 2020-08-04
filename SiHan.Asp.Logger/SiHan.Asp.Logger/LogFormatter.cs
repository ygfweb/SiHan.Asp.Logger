using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiHan.Asp.Logger
{
    internal class LogFormatter
    {
        public static string Handle<TState>(string name, LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            StringBuilder sb = new StringBuilder();
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            sb.Append($"[{time}]\t");
            sb.Append($"[{logLevel.ToString()}]\t");
            sb.Append($"[{name}]\t");
            if (exception != null)
            {
                sb.Append($"{exception.ToString()}\t");
            }
            string t = formatter(state, exception).Replace(System.Environment.NewLine, " ");
            sb.Append(t);
            return sb.ToString();
        }
    }
}
