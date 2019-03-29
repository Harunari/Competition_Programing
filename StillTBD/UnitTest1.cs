using System;
using Xunit;
using _2019024AtCoder;

namespace StillTBD
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal("Heisei", Program.EvalEra("2015/05/15"));
            Assert.Equal("Heisei", Program.EvalEra("2019/03/15"));
            Assert.Equal("Heisei", Program.EvalEra("2019/04/30"));
            Assert.Equal("TBD", Program.EvalEra("2019/11/01"));
            Assert.Equal("TBD", Program.EvalEra("2019/05/01"));
            Assert.Equal("TBD", Program.EvalEra("2020/03/15"));
            Assert.Equal("TBD", Program.EvalEra("2120/03/15"));
        }
    }
}
