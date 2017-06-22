using System;
using System.Diagnostics;
using System.Threading;

namespace Waiter
{
    public class Timeouter
    {
        private TimeSpan timeout;
        private readonly ManualResetEventSlim waiter;
        private DebuggerOptions debuggerOptions;
        public bool HasTriggered => waiter.IsSet;

        public Timeouter(TimeSpan timeout) : this(timeout, new DebuggerOptions(TimeoutMode.Default))
        {
        }

        public Timeouter(TimeSpan timeout, DebuggerOptions debuggerOptions)
        {
            this.timeout = timeout;
            waiter = new ManualResetEventSlim();
            this.debuggerOptions = debuggerOptions;
        }

        public bool Wait(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (Debugger.IsAttached && debuggerOptions.TimeoutMode == TimeoutMode.Indefinite)
            {
                waiter.Wait(cancellationToken);
                return true;
            }
            return waiter.Wait(timeout, cancellationToken);
        }

        public void Trigger()
        {
            waiter.Set();
        }
    }
}
