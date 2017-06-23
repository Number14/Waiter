
using System;
using System.Diagnostics;
using System.Threading;
using Shouldly;
using Xunit;

namespace Waiter.Tests
{
    public class TimeouterWithDebuggerOptionsTests
    {
        private readonly Timeouter sut;

        public TimeouterWithDebuggerOptionsTests()
        {
            sut = new Timeouter(TimeSpan.FromSeconds(1), new Waiter.DebuggerOptions(TimeoutMode.Indefinite));
        }
        [Fact]
        public void ShouldOverrideGivenTimeoutWithGivenOptionsWhenDebuggerIsAttached()
        {
            Debugger.Launch();

            var cancellationTokenSource = new CancellationTokenSource();
            
            sut.Wait(cancellationTokenSource.Token);

            cancellationTokenSource.CancelAfter(1100);

            sut.HasTriggered.ShouldBe(true);
        }
    }
}