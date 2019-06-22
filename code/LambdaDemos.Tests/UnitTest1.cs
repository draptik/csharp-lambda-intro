using FluentAssertions;
using Xunit;

namespace LambdaDemos.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            true.Should().BeTrue();
        }
    }
}
