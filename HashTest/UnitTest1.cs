using Hash;
using System;
using System.Linq;
using Xunit;

namespace HashTest
{
    public class HashArgorismUnitTest
    {


        [Fact]
        public void Should_take_the_value_from_0_to_listSizesMinus1()
        {
            var kl = ArrangeTest();

            Assert.InRange(Program.H1(kl.Key, kl.ListSize), 0, kl.ListSize - 1);
            Assert.InRange(Program.H2(kl.Key, kl.ListSize), 0, kl.ListSize - 1);
            int count = 1;
            while (count == 20)
            {
                Assert.InRange(Program.H(kl.Key, kl.ListSize, count++), 0, kl.ListSize - 1);
            }
        }

        [Fact]
        public void Should_throw_exception_when_invalid_number_inputted()
        {
            Action act = () => Program.H1(-1, 33);
            Assert.Throws<ArgumentException>(act);
            act = () => Program.H1(23, -5);
            Assert.Throws<ArgumentException>(act);

            act = () => Program.H2(-1, 33);
            Assert.Throws<ArgumentException>(act);
            act = () => Program.H2(23, -5);
            Assert.Throws<ArgumentException>(act);

            act = () => Program.H(-3, -5, -1);
            Assert.Throws<ArgumentException>(act);
            act = () => Program.H(3, -5, -1);
            Assert.Throws<ArgumentException>(act);
            act = () => Program.H(-3, 5, -1);
            Assert.Throws<ArgumentException>(act);
            act = () => Program.H(3, 5, -1);
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void Should_success_insert_even_if_inputKey_already_exist()
        {
            var array = ArrangeTestArray(ArrangeType.IsInputted);

            Assert.True(Program.Insert(array, 1));
            Assert.True(Program.Insert(array, 2));
            Assert.True(Program.Insert(array, 4));
        }

        [Fact]
        public void Should_failed_insert_if_input_minus_value()
        {
            var array = ArrangeTestArray(ArrangeType.NIL);

            Action act = () => Program.Insert(array, -3);
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void Should_success_search_if_inputNum_is_in_array()
        {
            var array = ArrangeTestArray(ArrangeType.IsInputted);

            Assert.True(Program.Search(array, 1));
            Assert.True(Program.Search(array, 2));
            Assert.True(Program.Search(array, 4));
            Assert.True(Program.Search(array, 5));
        }

        [Fact]
        public void Should_failed_search_if_inputNum_is_none_in_array()
        {
            var array = ArrangeTestArray(ArrangeType.IsInputted);

            Assert.False(Program.Search(array, 3));
            Assert.False(Program.Search(array, 6));
            Assert.False(Program.Search(array, 9));
        }


        public static KeyListSize ArrangeTest()
        {
            var random = new Random();
            var kl = new KeyListSize
            {
                Key = random.Next(),
                ListSize = random.Next()
            };
            return kl;
        }

        public enum ArrangeType { NIL, IsInputted };
        public static int[] ArrangeTestArray(ArrangeType type)
        {

            const int NIL = -1;
            var array = Enumerable.Repeat(NIL, 100).ToArray();
            
            if (type == ArrangeType.IsInputted)
            {
                Program.Insert(array, 1);
                Program.Insert(array, 2);
                Program.Insert(array, 4);
                Program.Insert(array, 7);
                Program.Insert(array, 5);
            }

            return array;
        }

        public class KeyListSize
        {
            public int Key { get; set; }
            public int ListSize { get; set; }
        }
    }
}
