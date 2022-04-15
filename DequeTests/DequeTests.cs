using System;
using Xunit;

namespace Deque
{
    public class DequeTests
    {
        [Fact]
        public void AddHead_NoWrap()
        {
            //arrange
            Deque dq = new Deque(3);
            string correctQueue = "9 8 7 4 5 6 ";
            //act
            dq.addTail(1);
            dq.addTail(2);
            dq.addTail(3);
            dq.addTail(4);
            dq.addTail(5);
            dq.addTail(6);
            dq.removeHead();
            dq.removeHead();
            dq.removeHead();
            dq.addHead(7);
            dq.addHead(8);
            dq.addHead(9);
            string dqStr = dq.listQueue();
            //assert
            Assert.Equal(correctQueue, dqStr);
        }
       
        [Fact]
        public void AddHead_Wrap()
        {
            //arrange
            Deque dq = new Deque(3);
            string correctQueue = "1 2 3 4 6 5 ";
            //act
            dq.addTail(1);
            dq.addTail(2);
            dq.addTail(3);
            dq.addTail(4);
            dq.addHead(5);
            dq.addHead(6);
            string dqStr = dq.listQueue();
            //assert
            Assert.Equal(correctQueue, dqStr);
        }
      
        [Fact]
        public void Constructor_Default()
        {
            //arrange
            Deque dq = new Deque();
            //act
            //assert
            Assert.True(dq.Length == 20);

        }
       
        [Fact]
        public void Constructor_NegativeSizeParameter()
        {
            //arrange
            Deque dq = new Deque(-1);
            //act
            //assert
            Assert.True(dq.Length == 20);

        }
       
        [Fact]
        public void Constructor_SizeParameter()
        {
            //arrange
            Deque dq = new Deque(5);
            //act
            //assert
            Assert.True(dq.Length == 5);
        }
        
        [Fact]
        public void DumpArray_NoWrap()
        {
            //arrange
            Deque dq = new Deque(3);
            string correctQueue = "1 2 3 4 5 6 ";
            //act
            dq.addTail(1);
            dq.addTail(2);
            dq.addTail(3);
            dq.addTail(4);
            dq.addTail(5);
            dq.addTail(6);
            dq.removeHead();
            dq.removeHead();
            string dqStr = dq.dumpArray();
            //assert
            Assert.Equal(correctQueue, dqStr);
        }
        
        [Fact]
        public void DumpArray_Wrap()
        {
            //arrange
            Deque dq = new Deque(3);
            string correctQueue = "7 8 3 4 5 6 ";
            //act
            dq.addTail(1);
            dq.addTail(2);
            dq.addTail(3);
            dq.addTail(4);
            dq.addTail(5);
            dq.addTail(6);
            dq.removeHead();
            dq.removeHead();
            dq.addTail(7);
            dq.addTail(8);
            string dqStr = dq.dumpArray();
            //assert
            Assert.Equal(correctQueue, dqStr);
        }
        
        [Fact]
        public void IsEmpty()
        {
            //arrange
            Deque dq = new Deque();
            //act
            dq.addTail(1);
            dq.removeHead();
            //assert
            Assert.True(dq.isEmpty());
        }
        
        [Fact]
        public void IsFull_NoWrap()
        {
            //arrange
            Deque dq = new Deque(1);
            //act
            dq.addTail(1);
            //assert
            Assert.True(dq.IsFull());
        }
        
        [Fact]
        public void IsFull_WithWrap()
        {
            //arrange
            Deque dq = new Deque(3);
            //act
            dq.addTail(1);
            dq.addTail(2);
            dq.addTail(3);
            dq.removeHead();
            dq.addTail(4);
            //assert
            Assert.True(dq.IsFull());
        }
        
        [Fact]
        public void ListElements_NoWrap()
        {
            //arrange
            Deque dq = new Deque(3);
            string correctQueue = "4 5 6 ";
            //act
            dq.addTail(1);
            dq.addTail(2);
            dq.addTail(3);
            dq.addTail(4);
            dq.removeHead();
            dq.addTail(5);
            dq.addTail(6);
            dq.removeHead();
            dq.removeHead();
            string dqStr = dq.listQueue();
            //assert
            Assert.Equal(correctQueue, dqStr);
        }
        
        [Fact]
        public void MixedTest()
        {
            //arrange
            Deque dq = new Deque(3);
            string correctArr = "8 3 4 5 6 7 ";
            //act
            dq.addTail(1);
            dq.addTail(2);
            dq.addTail(3);
            dq.removeHead();
            dq.addTail(4);
            dq.addTail(5);
            dq.addTail(6);
            dq.removeHead();
            dq.addTail(7);
            dq.addTail(8);
            string dqStr = dq.dumpArray();
            //assert
            Assert.Equal(correctArr, dqStr);
        }

        [Fact]
        public void RemoveTail_NoWrap()
        {
            //arrange
            Deque dq = new Deque(3);
            string correctQueue = "1 2 3 4 ";
            //act
            dq.addTail(1);
            dq.addTail(2);
            dq.addTail(3);
            dq.addTail(4);
            dq.addTail(5);
            dq.addTail(6);
            dq.removeTail();
            dq.removeTail();
            string dqStr = dq.listQueue();
            //assert
            Assert.Equal(correctQueue, dqStr);
        }

        [Fact]
        public void RemoveTail_Wrap()
        {
            //arrange
            Deque dq = new Deque(3);
            string correctQueue = "2 3 4 5 ";
            //act
            dq.addTail(1);
            dq.addTail(2);
            dq.addTail(3);
            dq.addTail(4);
            dq.addTail(5);
            dq.addTail(6);
            dq.removeHead();
            dq.addTail(7);
            dq.removeTail();
            dq.removeTail();
            string dqStr = dq.listQueue();
            //assert
            Assert.Equal(correctQueue, dqStr);
        }

        [Fact]
        public void Resize_NoWrap_CorrectArray()
        {
            //arrange
            Deque dq = new Deque(5);
            int[] testArr1 = { 1, 2, 3, 4, 5, 6 };
            int[] testArr2 = new int[6];
            //act
            dq.addTail(1);
            dq.addTail(2);
            dq.addTail(3);
            dq.addTail(4);
            dq.addTail(5);
            dq.addTail(6);

            for (int i = 0; i < 6; i++)
            {
                testArr2[i] = dq.removeHead();
                //assert
                Assert.True(testArr1[i] == testArr2[i]);
            }
        }
        
        [Fact]
        public void Resize_NoWrap_CorrectLength()
        {
            //arrange
            Deque dq = new Deque(5);
            //act
            dq.resize();
            //assert
            Assert.True(dq.Length == 10);
        }
       
        [Fact]
        public void Resize_Wrap_CorrectArray()
        {
            //arrange
            Deque dq = new Deque(3);
            string correctArr = "3 4 5 6 7 8 ";
            int[] testArr = new int[6];
            //act
            dq.addTail(1);
            dq.addTail(2);
            dq.addTail(3);
            dq.removeHead();
            dq.removeHead();
            dq.addTail(4);
            dq.addTail(5);
            dq.addTail(6);
            dq.addTail(7);
            dq.addTail(8);
            string dqStr = dq.dumpArray();
            //assert
            Assert.Equal(correctArr, dqStr);

        }
        
        [Fact]
        public void Resize_Wrap_CorrectLength()
        {
            //arrange
            Deque dq = new Deque(3);
            //act
            dq.addTail(1);
            dq.addTail(2);
            dq.addTail(3);
            dq.removeHead();
            dq.addTail(4);
            dq.addTail(5);
            //assert
            Assert.True(dq.Length == 6);
        }
    }
}
