using System;
using System.Collections.Generic;
using System.Linq;
using Counting_Sort;
using Xunit;

namespace Counting_Sort_Test
{
    public class CountingSortTest
    {
        [Fact]
        public void Should_fail_when_being_sorted_list_contains_minus_values()
        {
            var ar = new ArrangedLists();

            Action act1 = () => Program.CountingSort(ar.ContainMinusValuesList);

            Assert.Throws<ArgumentException>(act1);
        }

        [Fact]
        public void Should_sorted_after_run()
        {
            var ar = new ArrangedLists();

            var result = Program.CountingSort(ar.NotSortedList);

            Assert.Equal(ar.AnswerList, result);

        }



    }

    public class ArrangedLists
    {
        public List<int> NotSortedList { get; set; }
        public List<int> AnswerList { get; set; }
        public List<int> InputtedList { get; set; }
        public List<int> CacheList { get; set; }
        public List<int> ExtraList { get; set; }
        public List<int> ContainMinusValuesList { get; set; }

        public ArrangedLists()
        {
            NotSortedList = new List<int> { 5, 21, 10, 3, 9, 2, 15 };
            AnswerList = new List<int> { 2, 3, 5, 9, 10, 15, 21 };
            InputtedList = new List<int> { 5, 3, 6, 8, 2 };
            CacheList = new List<int>();
            ExtraList = new List<int>() { 1, 2, 3, 4, 5, 7, 9, 10, 11,12 };
            ContainMinusValuesList = new List<int> { -3, -1, -4, 1, 2, -9 };
        }
    }

}
