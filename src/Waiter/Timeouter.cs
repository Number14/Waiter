using System;
using System.Threading;

namespace Waiter
{
    public class Timeouter
    {
        private TimeSpan timeout;

        public Timeouter(TimeSpan timeout)
        {
            this.timeout = timeout;
        }

        public bool Wait()
        {
            var waiter = new ManualResetEventSlim();
            return waiter.Wait(timeout);
        }
    }
}
