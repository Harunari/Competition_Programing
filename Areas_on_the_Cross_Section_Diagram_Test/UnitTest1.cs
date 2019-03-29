using System;
using Areas_on_the_Cross_Section_Diagram;
using System.Collections;
using Xunit;

namespace Areas_on_the_Cross_Section_Diagram_Test
{
    public class CalcTest
    {
        [Fact]
        public void Stack_Should_Single_When_last_one_element_is_merged_new_area()
        {
            var s2 = new Stack();

            s2.PushCalcedInfo(1, 2);

            Assert.Single(s2);
            

            s2.PushCalcedInfo(3, 4);
            s2.PushCalcedInfo(2, 5);

            Assert.Equal(2, s2.Count);
        }

        [Fact]
        public void Should_return_tuple_which_have_correct_area_and_coordinate()
        {
            var s2 = new Stack();

            s2.PushCalcedInfo(1, 2);

            Assert.Equal((1, 1), s2.Pop());


            s2.PushCalcedInfo(3, 4);
            s2.PushCalcedInfo(2, 5);

            Assert.Equal((4, 2), s2.Pop());
        }
    }
}
