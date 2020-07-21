using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CitizenApp.Helper
{
    public class ThreadSafeBool
    {
        private long _backing;

        public ThreadSafeBool(bool initValue) => _backing = initValue ? 1L : 0L;

        public bool Get() => Interlocked.Read(ref _backing) == 1L;

        public void Set(bool value)
        {
            if (value) Interlocked.CompareExchange(ref _backing, 1L, 0L);
            else Interlocked.CompareExchange(ref _backing, 0L, 1L);
        }
    }
}
