using System;
using System.Threading;

namespace Waiter
{
    public class Timeouter
    {
        private TimeSpan timeout;
        private readonly ManualResetEventSlim waiter;

        public Timeouter(TimeSpan timeout)
        {
            this.timeout = timeout;
            waiter = new ManualResetEventSlim();            
        }

        public bool Wait()
        {
            return waiter.Wait(timeout);
        }

        public void Trigger()
        {
            waiter.Set();
        }
    }
}
