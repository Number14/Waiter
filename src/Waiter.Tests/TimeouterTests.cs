
using System;
using System.Threading;
using Shouldly;
using Xunit;

namespace Waiter.Tests
{
    public class TimeouterTests
    {
        [Fact]
        public void ShouldTimeoutIfNotTriggered()
        {
            var sut = new Timeouter(TimeSpan.FromSeconds(1));

            Thread.Sleep(1100);

            sut.Wait().ShouldBe(false);
        }
    }
}