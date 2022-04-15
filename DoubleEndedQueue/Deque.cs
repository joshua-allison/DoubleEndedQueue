using System;
using System.Linq;

namespace Deque
{
    public class Deque
    {
        /* The method names, method parameters, and expected output of this Deque.cs are necessitated by the test methods written in Driver.cs,
         * and "cs 260: double ended queue (lab 2)", both by jim bailey.
         *  This implementation of a deque class is by josh allison
        */

        private const int DEFAULT_SIZE = 20;
        private int[] Queue { get; set; } // the array storing the queue
        private int Head { get; set; } // the int keeping track of the index of the oldest element in the queue
        private int Tail { get; set; }  // the int keeping track of the index of the newest element in the queue
        private int NumQueued { get; set; } // the int keeping track of how many elements there are in the queue
        public int Length { get; set; }
        public Deque (int size = DEFAULT_SIZE)
        {
            // if the size parameter is less than one, make it the default size instead
            size = size < 1 ? DEFAULT_SIZE : size;
            // initialize the head and tail to the first index
            Tail = -1;
            Head = 0;
            // make the queue array member's length equal to the size parameter, or the default if the parameter was omitted or < 1
            Queue = new int[size];
            Length = Queue.Length;
        }
        public bool isEmpty()
        {
            //The array is empty if the head and tail are in their starting positions...
            return NumQueued == 0;
        }
        public bool IsFull()
        {
            return NumQueued == Length;
        }
        private bool IsWrapped()
        {
            return (Tail < Head);
        }
        public void resize()
        {
            //Double the size of the array.
            int[] tempArray = new int[Length * 2];
            //Don't bother with copying values if the array is empty
            if (!isEmpty())
            {
                if (IsWrapped())
                {
                    // Get both halves of the wrap
                    int[] ZeroToTail = Queue[0..(Tail+1)];
                    int[] HeadToEnd = Queue[Head..Length];
                    // Copy over the wrap pieces to the temp array
                    HeadToEnd.CopyTo(tempArray, 0);
                    ZeroToTail.CopyTo(tempArray, HeadToEnd.Length);
                }
                else
                // If the array is not wrapped...
                {
                    for (int k = 0; k < NumQueued; k++)
                    {
                        tempArray[k] = Queue[k+Head];
                    }
                }
            }
            //Update the head and tail,
            Head = 0;
            Tail = Queue.Length - 1;
            //And set the Queue array equal to the constructed temp array
            Queue = tempArray;
            //Finally, update the Length member to reflect the new queue size.
            Length = Queue.Length;
        }
        public string dumpArray()
        {
            string dump = "";
            foreach (var item in Queue)
                dump += item + " ";
            return dump;
        }
        public string listQueue()
        {
            string list = "";
            if (IsWrapped())
            {
                //...If it is, copy over the pieces of the wraps to arrays 
                int[] HeadToEnd = Queue[Head..Length];
                int[] ZeroToTail = Queue[0..(Tail + 1)];
                // then concat the elements of those arrays to the list
                foreach (int num in HeadToEnd)
                    list += (num + " ");
                foreach (int num in ZeroToTail)
                    list += (num + " ");
            }
            else
            {
                //... otherwise, just add the elements to list from head to tail.
                int[] HeadToTail = Queue[Head..(Tail + 1)];
                foreach (int num in HeadToTail)
                    list += (num + " ");
            }
            return list;
        }
        public void addTail(int value)
        {
            // The standard Queue Enque (FIFO) 

            if (IsFull()) resize();

            //If the tail is at the last element (and we know that the array is not full)
            if (Tail == Length - 1)
                //Then wrap the queue
                Tail = -1;

            // Incremenet the tail and the number of queued elements,
            Tail++;
            NumQueued++;
            //and at the index of the tail, set the value equal to the passed in parameter
            Queue[Tail] = value;
        }
        public int removeHead()
        {
            // The standard Queue Deque (FIFO) 
            if (isEmpty()) throw new IndexOutOfRangeException();
            int value = Queue[Head];
            if (Head == Length - 1)
                Head = -1;
            Head++;
            NumQueued--;
            return value;
        }
        public void addHead(int value)
        {
            // Enables Enqueing at the head (LIFO)

            if (IsFull()) resize();

            if (Head == 0)
            {
                Head = Queue.Length;
                if (isEmpty())
                    Tail = Head -1;
            }

            Head--;
            NumQueued++;

            Queue[Head] = value;
        }
        public int removeTail()
        {
            // Enables Dequeing at the tail (LIFO)

            if (isEmpty()) throw new IndexOutOfRangeException();
            int value = Queue[Tail];

            if (IsWrapped())
            {
                if (Tail == 0)
                    Tail = Length - 1;
                else
                    Tail--;
            }
            else
                Tail--;
            NumQueued--;
            return value;
        }
    }
}
