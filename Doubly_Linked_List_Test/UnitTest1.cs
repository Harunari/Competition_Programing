using Doubly_linked_List;
using System;
using System.Collections.Generic;
using Xunit;

namespace Doubly_Linked_List_Test
{
    public class DoublyLinkedListTest
    {
        const int NIL = -1;
        Nodes NodesList { get; set; }

        public DoublyLinkedListTest()
        {
            NodesList = new Nodes();
            NodesList = NodesList.Init();
        }

        internal void Add4and33()
        {
            NodesList = NodesList.Insert(4)
                .Insert(33);
        }

        internal void AddMoreToList()
        {
            NodesList = NodesList.Insert(5)
                .Insert(10).Insert(32).Insert(23).Insert(25).Insert(46);
        }


        [Fact]
        public void Should_have_correct_node_when_exec_init()
        {
            
            Assert.Single(NodesList);
            Assert.Equal(NIL, NodesList[0].Prev);
            Assert.Equal(NIL, NodesList[0].Key);
            Assert.Equal(NIL, NodesList[0].Next);
        }

        [Fact]
        public void Should_increase_node_when_Insert_to_nodes()
        {
            NodesList = NodesList.Insert(4);

            Assert.Equal(2, NodesList.Count);
        }

        [Fact]
        public void Should_have_correct_routing_added_node()
        {
            Add4and33();

            Assert.Equal(33, NodesList[2].Key);
            Assert.Equal(1, NodesList[2].Next);
            Assert.Equal(0, NodesList[2].Prev);
        }

        [Fact]
        public void Should_have_correct_routing_sentinel_node()
        {
            Add4and33();

            Assert.Equal(2, NodesList[0].Next);
            Assert.Equal(NIL, NodesList[0].Prev);
            Assert.Equal(NIL, NodesList[0].Key);
        }

        [Fact]
        public void Should_have_correct_routing_already_exist_node()
        {
            Add4and33();

            Assert.Equal(4, NodesList[1].Key);
            Assert.Equal(2, NodesList[1].Prev);
            Assert.Equal(NIL, NodesList[1].Next);

            AddMoreToList();
            Assert.Equal(6, NodesList[7].Next);
        }

        [Fact]
        public void Should_return_correct_index()
        {
            Add4and33();
            AddMoreToList();

            Assert.Equal(5, NodesList.Search(32));
            Assert.Equal(6, NodesList.Search(23));
            Assert.Equal(7, NodesList.Search(25));
            Assert.Equal(8, NodesList.Search(46));
            Assert.Equal(1, NodesList.Search(4));
            Assert.Equal(NIL, NodesList.Search(100));
        }

        [Fact]
        public void Should_return_false_when_index_isNot_found()
        {
            Add4and33();
            AddMoreToList();

            Assert.False(NodesList.DeleteNode(100));
            Assert.False(NodesList.DeleteNode(11));
        }

        [Fact]
        public void Should_return_true_when_index_is_found()
        {
            Add4and33();
            AddMoreToList();

            Assert.True(NodesList.DeleteNode(10));
            Assert.True(NodesList.DeleteNode(23));
            Assert.True(NodesList.DeleteNode(25));
            Assert.True(NodesList.DeleteNode(46));
        }

        [Fact]
        public void Should_return_false_when_sentinelIndex_is_indicated()
        {
            Add4and33();
            AddMoreToList();

            Assert.False(NodesList.DeleteNode(0));
        }
    }
}
