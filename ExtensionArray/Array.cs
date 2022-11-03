using System;
using System.Data;
using System.Linq;
using System.Windows.Controls;

namespace LibArray
{
    public class Array<T>
    {
        // поле 
        private T[] _items; // обобщение
        private int _capacity;

        private readonly int _defaultcapacity = 8;

        // конструктор
        public Array(int capacity)
        {
            _items = new T[capacity];
            Capacity = capacity;
        }

        // свойства
        public int Length { get; private set; }

        public T this[int index] // индексаторы c обобщением 
                                 // добавляем новый функционал 
        {
            get { return _items[index]; } 
            set { _items[index] = value; }
        }

        // свойства
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
                Array.Resize(ref _items, _capacity); // Изменяет количество элементов в одномерном массиве до указанной величины.

            }
        }

        private int EnsureCapacity(int itemsLenght = 0) // расширение длины массива на 2 
        {
            int tempCapacity = Capacity;
            while (itemsLenght + Length >= tempCapacity)
            {
                tempCapacity *= 2;
            }

            return tempCapacity;
        }

        public DataTable ToDataTable() // вывод в таблицу 
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

        public void AddRange(T[] items) // добавление числе в конец существующего массива 
        {
            Capacity = EnsureCapacity(items.Length);
            Array.Copy(items, 0, _items, Length, items.Length); // массив из которого копируем, с какого элемента, куда копируем, элементы добавляения 
            Length += items.Length;
        }

        public bool Remove(T item) 
        {
            int x = Array.IndexOf(_items, item); //удаляет элемент

            if (x >= 0)
            {
                Array.Copy(_items, x + 1, _items, x, Capacity - (x + 1));
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

        public void Clear() // очищает класс внутри 
        {
            Capacity = _defaultcapacity;
            Length = 0;
            _items = new T[Capacity];
            
        }
    }
}
