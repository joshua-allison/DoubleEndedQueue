using System;

namespace DoubleEndedQueue
{
    class Deque
    {
        private readonly IndexOutOfRangeException out_of_range = new IndexOutOfRangeException();
        private const int DEFAULT_SIZE = 20;
        private int[] a { get; set; } // the array storing the queue
        private int j { get; set; } // the int keeping track of the next element to remove
        private int n { get; set; } // the int keeping track of the number of elements stored in 'a'
        public Deque(int size = DEFAULT_SIZE)
        {
            // if the size is less than one, make it the default size instead
            size = size < 1 ? DEFAULT_SIZE : size;
            // make the array member equal to the size parameter, or the default if the parameter was omitted or < 1
            a = new int[size];
        }
        public void addTail(int value)
        {
            resizeIfFull();
            a[(j + n) % a.Length] = value;
            n++;
        }
        public int removeHead()
        {
            if (isEmpty()) throw out_of_range;
            int x = a[j];
            j = (j + 1) % a.Length;
            n--;
            if (a.Length >= 3 * n)
                resize();
            return x;
        }
        public string dumpArray()
        {
            string dump = "";
            foreach (var item in a)
                dump += item + " ";
            return dump;
        }
        public void resize()
        {
            int[] b = new int[n * 2];
            for (int k = 0; k < n; k++)
                b[k] = a[(j + k) % a.Length];
            a = b;
            j = 0;
        }
        public string listQueue()
        {
            string list = "";
            for (int i = 0; i < n; i++)
            {
                list += a[i] + " ";
            }
            return list;
        }
        public bool isEmpty()
        {
            return n == 0 ? true : false;
        }
        public bool isFull()
        {
            return n + 1 > a.Length ? true : false;
        }
        public void resizeIfFull()
        {
            if (isFull())
                resize();
        }
        public void addHead(int value, int index = 0)
        {
            // This function actually has the ability to add a value at any index position,
            // but it's default behavior is to add at the head.
            resizeIfFull();
            if (index < n / 2)
            { // shift a[0],..,a[i-1] left one position
                j = (j == 0) ? a.Length - 1 : j - 1; //(j-1)mod a.length
                for (int k = 0; k <= index - 1; k++)
                    a[(j + k) % a.Length] = a[(j + k + 1) % a.Length];
            }
            else
            { // shift a[i],..,a[n-1] right one position
                for (int k = n; k > index; k--)
                    a[(j + k) % a.Length] = a[(j + k - 1) % a.Length];
            }
            a[(j + index) % a.Length] = value;
            n++;

        }
        public int removeTail(int index = -1)
        {
            index = index == -1 ? n-1 : index;
            int value = a[(j + index) % a.Length];
            if (index < n / 2)
            { // shift a[0],..,[i-1] right one position
                for (int k = index; k > 0; k--)
                    a[(j + k) % a.Length] = a[(j + k - 1) % a.Length];
                j = (j + 1) % a.Length;
            }
            else
            { // shift a[i+1],..,a[n-1] left one position
                for (int k = index; k < n - 1; k++)
                    a[(j + k) % a.Length] = a[(j + k + 1) % a.Length];
            }
            n--;
            if (3 * n < a.Length) resize();
            return value;
        }
    }
}
