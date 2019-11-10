using System;
using System.Collections.Generic;
using System.Text;

namespace SiHan.Asp.Logger
{
    internal class NoopDisposable : IDisposable
    {
        public void Dispose()
        {
        }
    }
}
