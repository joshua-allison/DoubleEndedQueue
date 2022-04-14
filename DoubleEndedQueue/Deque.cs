using System;
using System.Linq;

namespace Deque
{
    public class Deque
    {
        /* The method names, method parameters, and expected output of this Deque.cs are necessitated by the test methods written in Driver.cs,
         * and "cs 260: double ended queue (lab 2)", both by jim bailey.
         * the adaptation of those methods are almost completely based on the instructions of chapter 2 of "open data structures" by pat morin.
         *      Open Data Structures: https://www.aupress.ca/app/uploads/120226_99z_morin_2013-open_data_structures.pdf
         *  The algorithms taught in chapter 2 of "open data structures" were adapted and included in this dequeue.cs to -
         *  address and test against the methods written in driver.cs.
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
        public void resize()
        {
            //Double the size of the array.
            int[] tempArray = new int[Length * 2];
            // If the array is wrapped...
            if (!isEmpty())
            {
                if (Tail < Head)
                {
                    int[] ZeroToTail = Queue[0..Tail];
                    int[] HeadToEnd = Queue[Head..(Length - 1)];
                    for (int i = 0; i < HeadToEnd.Length - 1; i++)
                    {
                        tempArray[i] = HeadToEnd[i];
                    }
                    for (int j = 0; j < ZeroToTail.Length; j++)
                    {
                        tempArray[j + (HeadToEnd.Length - 1)] = ZeroToTail[j];
                    }
                }
                else
                // If the array is not wrapped...
                {
                    int[] HeadToTail = Queue[Head..Tail];
                    for (int k = 0; k < HeadToTail.Length - 1; k++)
                    {
                        tempArray[k] = HeadToTail[k];
                    }
                }
            }
            //Update the head and tail,
            Head = 0;
            Tail = Queue.Length - 1;
            //And set the Queue array equal to the constructed temp array.
            Queue = tempArray;
            Length *= 2;
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
            for (int i = 0; i < Queue.Length-1; i++)
                list += Queue[i] + " ";
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

            //Finally, Incremenet the tail and the number of queued elements,
            Tail++;
            NumQueued++;
            //and at the index of the tail, set the value equal to the passed in parameter
            Queue[Tail] = value;
        }
        public int removeHead()
        {
            // The standard Queue Deque (FIFO) 

            int value = Queue[Head];
            Head++;
            NumQueued--;
            return value;
        }
        public void addHead(int value)
        {
            // Enables Enqueing at the head (LIFO)
            throw new NotImplementedException();
        }
        public int removeTail()
        {
            // Enables Dequeing at the tail (LIFO)
            throw new NotImplementedException();
        }
    }
}
