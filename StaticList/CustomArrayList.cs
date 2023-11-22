using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticList
{
    internal class CustomArrayList<T>
    {
        private T[] arr;
        private int count;
        private const int INITIAL_CAPACITY = 5;

        public int Count
        {
            get { return this.count; }
        }

        // Initializes the array-based list – allocate memory
        public CustomArrayList(int capacity = INITIAL_CAPACITY)
        {
            this.arr = new T[capacity];
            this.count = 0;
        }

        //Adds element to the list
        public void Add(T item)
        {
            GrowIfArrIsFull();
            this.arr[this.count] = item;
            this.count++;
        }

        /// Inserts the specified element at given position in this list
        public void Insert(int index, T item)
        {
            if(index > this.count || index < 0)
            {
                throw new IndexOutOfRangeException("Invalid index: " + index);
            }
            GrowIfArrIsFull();
            Array.Copy(this.arr, index, this.arr, index + 1, this.Count - index);
            this.arr[index] = item;
            this.count++;
        }

        // Doubles the size of this.arr (grow) if it is full
       private void GrowIfArrIsFull()
        {
            if(this.count + 1 > this.arr.Length)
            {
                T[] extendedArr = new T[this.arr.Length * 2];
                Array.Copy(this.arr, extendedArr, this.count);
                this.arr = extendedArr;
            }
        }

        //Clears the list (remove everything)
        public void Clear()
        {
            this.arr = new T[INITIAL_CAPACITY];
            this.count = 0;
        }

        // Returns the index of the first occurrence of the specified element in the list
        // If element not found returns negative 1
        public int IndexOf(T item) 
        { 
            for(int i = 0; i < this.count; i++)
            {
                if (object.Equals(this.arr[i], item)) return i;
            }
            return -1;
        }

        //Checks if an element exists
        public bool Contains(T item)
        {
            int index = IndexOf(item);
            bool found = (index != -1);
            return found;
        }

        //Indexer: access to element at given index
        public T this[int index]
        {
            get
            {
                if(index >= this.count || index < 0)
                {
                    throw new IndexOutOfRangeException("Invalid index:" + index);
                }
                return this.arr[index];

            }
            set
            {
                if (index >= this.count || index < 0)
                {
                    throw new ArgumentOutOfRangeException(
                    "Invalid index: " + index);
                }

                this.arr[index] = value;
            }
        }
        public T RemoveAt(int index)
        {
            if (index >= this.count || index < 0)
            {
                throw new ArgumentOutOfRangeException(
                "Invalid index: " + index);
            }

            T item = this.arr[index];
            Array.Copy(this.arr, index + 1, this.arr, index, this.count - index - 1);
            this.arr[this.count - 1] = default(T);
            this.count--;
            return item;
        }

        //Removes the specified item
        //Returns the element's index or -1
        public int Remove(T item)
        {
            int index = IndexOf(item);
            if(index != -1)
            {
                this.RemoveAt(index);
            }
            return index;
        }
    }
}
