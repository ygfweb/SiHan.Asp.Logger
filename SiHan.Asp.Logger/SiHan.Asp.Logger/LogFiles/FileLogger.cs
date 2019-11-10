using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace SiHan.Asp.Logger.LogFiles
{
    internal class FileLogger : ILogger
    {
        private string CategoryName { get; set; }
        private static string CurrentCategory = Directory.GetCurrentDirectory();
        private static ReaderWriterLockSlim fileLock = new ReaderWriterLockSlim();

        public FileLogger(string categoryName)
        {
            CategoryName = categoryName;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return new NoopDisposable();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            string log = LogFormatter.Handle<TState>(this.CategoryName, logLevel, eventId, state, exception, formatter);
            DateTime now = DateTime.Now;
            string fileName = now.ToString("yyyy-MM-dd") + ".log";
            DirectoryInfo directory = new DirectoryInfo(Path.Combine(CurrentCategory, "logs"));
            fileLock.EnterWriteLock();
            try
            {
                if (!directory.Exists)
                {
                    directory.Create();
                }
                this.ApplyRetainPolicy(directory);
                using (var writer = File.AppendText(Path.Combine(directory.FullName, fileName)))
                {
                    writer.WriteLine(log);
                }
            }
            finally
            {
                fileLock.ExitWriteLock();
            }
        }

        private void ApplyRetainPolicy(DirectoryInfo directory)
        {
            FileInfo FI;
            try
            {
                List<FileInfo> FileList = directory.GetFiles("*.log", SearchOption.TopDirectoryOnly).OrderBy(fi => fi.CreationTime).ToList();
                while (FileList.Count >= 30)
                {
                    FI = FileList.First();
                    FI.Delete();
                    FileList.Remove(FI);
                }
            }
            catch
            {
            }
        }
    }
}
