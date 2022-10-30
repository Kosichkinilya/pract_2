using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;




namespace LibArray
{
    public class Array<T>
    {
        private T[] _items;
        private int _capacity;

        private readonly int _defaultcapacity = 8;

        public Array(int capacity)
        {
            _items = new T[capacity];
            Capacity = capacity;
        }

        public int Length { get; private set; }

        public T this[int index]
        {
            get { return _items[index]; }
            set { _items[index] = value; }
        }

        public int Capacity
        {
            get => _capacity;
            private set
            {
                if (value == _capacity)
                {
                    return;
                }

                _capacity = value;
                Array.Resize(ref _items, _capacity);
            }
        }

        private int EnsureCapacity(int itemsLenght = 0)
        {
            int tempCapacity = Capacity;
            while (itemsLenght + Length >= tempCapacity)
            {
                tempCapacity *= 2;
            }

            return tempCapacity;
        }

        public DataTable ToDataTable()
        {
            var res = new DataTable();

            for (int i = 0; i < Length; i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }

            var row = res.NewRow();

            for (int i = 0; i < Length; i++)
            {
                row[i] = _items[i];
            }

            res.Rows.Add(row);
            return res;
        }

        public void AddRange(T[] items)
        {
            Capacity = EnsureCapacity(items.Length);
            Array.Copy(items, 0, _items, Length, items.Length);
            Length += items.Length;
        }

        // 1 2 3 4 5 array
        // 0 1 2 3 4 index
        public bool Remove(T item)
        {
            int x = Array.IndexOf(_items, item);

            if (x >= 0)
            {
                Array.Copy(_items, x + 1, _items, x, Capacity - (x + 1));
                Capacity--;
                Length--;
                return true;
            }
            return false;
        }

        public void Add(T item)
        {
            Capacity = EnsureCapacity();
            _items[Length++] = item;
        }

        public void Clear()
        {
            Capacity = _defaultcapacity;
            Length = 0;
            _items = new T[Capacity];
        }

        public T[] ToArray()
        {
            return _items.Take(Length).ToArray();
        }

    }
}
