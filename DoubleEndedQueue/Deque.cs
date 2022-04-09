using System;

namespace DoubleEndedQueue
{
    class Deque <T>
    {
        // This method names, parameters, and expected output are necessitated by the driver and "CS 260 - Lab 2: Double Ended Queue" by Jim Bailey.
        // The implementations of those methods are based almost completely on Chapter 2 of "Open Data Structures" by Pat Morin.
        //              https://www.aupress.ca/app/uploads/120226_99Z_Morin_2013-Open_Data_Structures.pdf
        // The adapation of the above and programming of this class was performed by Josh Allison

        private readonly IndexOutOfRangeException out_of_range = new IndexOutOfRangeException();
        private const int DEFAULT_SIZE = 20;
        private T[] queue { get; set; } // the array storing the queue
        private int head { get; set; } // the int keeping track of the index of what will be dequed next, accounting for wrapping
        private int tail { get; set; } // the int keeping track of the number of elements stored in 'queue', or the index of the tail
        public Deque (int size = DEFAULT_SIZE)
        {
            // if the size is less than one, make it the default size instead
            size = size < 1 ? DEFAULT_SIZE : size;
            // make the queue member equal to the size parameter, or the default if the parameter was omitted or < 1
            queue = new T[size];
        }
        public bool isEmpty()
        {
            return tail == 0 ? true : false;
        }
        public void throwIfEmpty()
        {
            if (isEmpty())
                throw out_of_range;
        }
        public bool isFull()
        {
            return tail + 1 > queue.Length ? true : false;
        }
        public void resize()
        {
            T[] tempArray = new T[tail * 2];
            for (int k = 0; k < tail; k++)
                tempArray[k] = queue[(head + k) % queue.Length];
            queue = tempArray;
            head = 0;
        }
        public void resizeIfFull()
        {
            if (isFull())
                resize();
        }
        public string dumpArray()
        {
            string dump = "";
            foreach (var item in queue)
                dump += item + " ";
            return dump;
        }
        public string listQueue()
        {
            string list = "";
            for (int i = 0; i < tail; i++)
                list += queue[i] + " ";
            return list;
        }
        public void addTail(T value)
        {
            resizeIfFull();
            queue[(head + tail) % queue.Length] = value;
            tail++;
        }
        public T removeTail(int index = -1)
        {
            throwIfEmpty();
            // This function actually has the ability to remove a value at any index position,
            // but it's default behavior is to remove at the tail.
            index = index == -1 ? tail - 1 : index;
            T value = queue[(head + index) % queue.Length];
            if (index < tail / 2)
            {
                // shift queue[0],..,[i-1] right one position
                for (int k = index; k > 0; k--)
                    queue[(head + k) % queue.Length] = queue[(head + k - 1) % queue.Length];
                head = (head + 1) % queue.Length;
            }
            else
            {
                // shift a[i+1],..,a[tail-1] left one position
                for (int k = index; k < tail - 1; k++)
                    queue[(head + k) % queue.Length] = queue[(head + k + 1) % queue.Length];
            }
            tail--;
            if (3 * tail < queue.Length)
                resize();
            return value;
        }
        public void addHead(T value, int index = 0)
        {
            // This function actually has the ability to add a value at any index position,
            // but it's default behavior is to add at the head.
            resizeIfFull();
            if (index < tail / 2)
            {
                // shift queue[0],..,queue[index-1] left one position
                head = (head == 0) ? queue.Length - 1 : head - 1; //(head-1)mod queue.length
                for (int k = 0; k <= index - 1; k++)
                    queue[(head + k) % queue.Length] = queue[(head + k + 1) % queue.Length];
            }
            else
            {
                // shift queue[index],..,queue[tail-1] right one position
                for (int k = tail; k > index; k--)
                    queue[(head + k) % queue.Length] = queue[(head + k - 1) % queue.Length];
            }
            queue[(head + index) % queue.Length] = value;
            tail++;

        }
        public T removeHead()
        {
            throwIfEmpty();
            T value = queue[head];
            head = (head + 1) % queue.Length;
            tail--;
            if (queue.Length >= 3 * tail)
                resize();
            return value;
        }
    }
}
