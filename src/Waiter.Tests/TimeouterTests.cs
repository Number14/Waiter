
using System;
using System.Threading;
using Shouldly;
using Xunit;

namespace Waiter.Tests
{
    public class TimeouterTests
    {
        private readonly Timeouter sut;

        public TimeouterTests()
        {
            sut = new Timeouter(TimeSpan.FromSeconds(1));
        }

        [Fact]
        public void ShouldTimeoutIfNotTriggered()
        {
            Thread.Sleep(1100);

            sut.Wait().ShouldBe(false);
        }

        [Fact]
        public void ShouldReturnTrueWhenTriggeredBeforeTimeout()
        {
            sut.Trigger();

            sut.Wait().ShouldBe(true);
        }
    }
}