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
        private T[] array { get; set; } // the array storing the queue
        private int head { get; set; } // the int keeping track of the next element to remove
        private int count { get; set; } // the int keeping track of the number of elements stored in 'array', or the index of the tail + 1
        public Deque (int size = DEFAULT_SIZE)
        {
            // if the size is less than one, make it the default size instead
            size = size < 1 ? DEFAULT_SIZE : size;
            // make the array member equal to the size parameter, or the default if the parameter was omitted or < 1
            array = new T[size];
        }
        public bool isEmpty()
        {
            return count == 0 ? true : false;
        }
        public void throwIfEmpty()
        {
            if (isEmpty())
                throw out_of_range;
        }
        public bool isFull()
        {
            return count + 1 > array.Length ? true : false;
        }
        public void resize()
        {
            T[] tempArray = new T[count * 2];
            for (int k = 0; k < count; k++)
                tempArray[k] = array[(head + k) % array.Length];
            array = tempArray;
            head = 0;
        }
        public void resizeIfFull()
        {
            if (isFull())
                resize();
        }
        public void addTail(T value)
        {
            resizeIfFull();
            array[(head + count) % array.Length] = value;
            count++;
        }
        public T removeTail(int index = -1)
        {
            // This function actually has the ability to remove a value at any index position,
            // but it's default behavior is to remove at the tail.
            index = index == -1 ? count - 1 : index;
            T value = array[(head + index) % array.Length];
            if (index < count / 2)
            {
                // shift array[0],..,[i-1] right one position
                for (int k = index; k > 0; k--)
                    array[(head + k) % array.Length] = array[(head + k - 1) % array.Length];
                head = (head + 1) % array.Length;
            }
            else
            {
                // shift a[i+1],..,a[count-1] left one position
                for (int k = index; k < count - 1; k++)
                    array[(head + k) % array.Length] = array[(head + k + 1) % array.Length];
            }
            count--;
            if (3 * count < array.Length)
                resize();
            return value;
        }
        public void addHead(T value, int index = 0)
        {
            // This function actually has the ability to add a value at any index position,
            // but it's default behavior is to add at the head.
            resizeIfFull();
            if (index < count / 2)
            {
                // shift array[0],..,array[index-1] left one position
                head = (head == 0) ? array.Length - 1 : head - 1; //(head-1)mod array.length
                for (int k = 0; k <= index - 1; k++)
                    array[(head + k) % array.Length] = array[(head + k + 1) % array.Length];
            }
            else
            {
                // shift array[index],..,array[count-1] right one position
                for (int k = count; k > index; k--)
                    array[(head + k) % array.Length] = array[(head + k - 1) % array.Length];
            }
            array[(head + index) % array.Length] = value;
            count++;

        }
        public T removeHead()
        {
            throwIfEmpty();
            T value = array[head];
            head = (head + 1) % array.Length;
            count--;
            if (array.Length >= 3 * count)
                resize();
            return value;
        }
        public string dumpArray()
        {
            string dump = "";
            foreach (var item in array)
                dump += item + " ";
            return dump;
        }
        public string listQueue()
        {
            string list = "";
            for (int i = 0; i < count; i++)
                list += array[i] + " ";
            return list;
        }
    }
}
