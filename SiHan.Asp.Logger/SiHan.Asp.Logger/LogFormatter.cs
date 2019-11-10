using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiHan.Asp.Logger
{
    internal class LogFormatter
    {
        private static readonly string BLANK = "  ";
        public static string Handle<TState>(string name, LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            StringBuilder sb = new StringBuilder();
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            sb.Append($"[{time}]{BLANK}");
            sb.Append($"[{logLevel.ToString()}]{BLANK}");
            sb.Append($"[{name}]{BLANK}");
            string t = formatter(state, exception).Replace(System.Environment.NewLine, " ");
            sb.Append(t);
            return sb.ToString();
        }
    }
}
