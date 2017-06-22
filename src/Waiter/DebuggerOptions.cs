namespace Waiter
{
    public class DebuggerOptions
    {
        public TimeoutMode TimeoutMode { get; }

        public DebuggerOptions(TimeoutMode timeoutMode)
        {
            TimeoutMode = timeoutMode;
        }
    }
}