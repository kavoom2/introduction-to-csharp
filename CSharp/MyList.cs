namespace Algorithm
{
    class MyList<T>
    {
        const int DEFAULT_CAPACITY = 1;
        T[] _data = new T[DEFAULT_CAPACITY];
        public int Count = 0; // 실제로 사용하는 데이터의 개수
        public int Capacity
        {
            get { return _data.Length; }
        } // 예약된 데이터의 개수

        private bool IsOverCapacity()
        {
            return Count >= Capacity;
        }

        private void Allocate()
        {
            int newCapacity = Capacity * 2;
            T[] newData = new T[newCapacity];

            for (int i = 0; i < Count; i++)
            {
                newData[i] = _data[i];
            }

            _data = newData;
        }

        public void Add(T item)
        {
            if (IsOverCapacity())
            {
                Allocate();
            }

            _data[Count] = item;
            Count++;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                _data[i] = _data[i + 1];
            }

            _data[Count - 1] = default(T);
            Count--;
        }

        // 인덱서
        public T this[int index]
        {
            get { return _data[index]; }
            set { _data[index] = value; }
        }
    }
}
