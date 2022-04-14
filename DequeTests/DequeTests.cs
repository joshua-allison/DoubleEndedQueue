using System;
using Xunit;

namespace Deque
{
    public class DequeTests
    {
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

            for (int i = 0; i < dq.Length; i++)
                testArr2[i] = dq.removeHead();
            //assert
            Assert.True(testArr1 == testArr2);
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
            //act
            dq.addTail(1);
            dq.addTail(2);
            dq.addTail(3);
            dq.removeHead();
            dq.addTail(4);
            dq.addTail(5);
            //assert
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
