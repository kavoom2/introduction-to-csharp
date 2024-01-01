namespace Algorithm
{
    class PriorityQueue<T>
        where T : IComparable<T>
    {
        readonly List<T> _heap = new();

        void Swap(int index1, int index2)
        {
            T temp = _heap[index1];
            _heap[index1] = _heap[index2];
            _heap[index2] = temp;
        }

        int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        int GetLeftChildIndex(int index)
        {
            return index * 2 + 1;
        }

        int GetRightChildIndex(int index)
        {
            return index * 2 + 2;
        }

        bool HasParent(int index)
        {
            if (index == 0)
            {
                return false;
            }

            return GetParentIndex(index) >= 0;
        }

        bool HasLeftChild(int index)
        {
            return GetLeftChildIndex(index) < _heap.Count;
        }

        bool HasRightChild(int index)
        {
            return GetRightChildIndex(index) < _heap.Count;
        }

        public void Enqueue(T item)
        {
            _heap.Add(item);

            int nodeIndex = _heap.Count - 1;
            while (HasParent(nodeIndex))
            {
                int parentIndex = GetParentIndex(nodeIndex);

                if (_heap[parentIndex].CompareTo(_heap[nodeIndex]) < 0)
                {
                    break;
                }

                Swap(parentIndex, nodeIndex);
                nodeIndex = parentIndex;
            }
        }

        public T Dequeue()
        {
            T min = _heap[0];
            int lastIndex = _heap.Count - 1;
            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);

            int nodeIndex = 0;
            while (HasLeftChild(nodeIndex))
            {
                int leftChildIndex = GetLeftChildIndex(nodeIndex);
                int rightChildIndex = GetRightChildIndex(nodeIndex);
                int smallerChildIndex = nodeIndex;

                if (
                    HasLeftChild(nodeIndex)
                    && _heap[leftChildIndex].CompareTo(_heap[smallerChildIndex]) < 0
                )
                {
                    smallerChildIndex = leftChildIndex;
                }

                if (
                    HasRightChild(nodeIndex)
                    && _heap[rightChildIndex].CompareTo(_heap[smallerChildIndex]) < 0
                )
                {
                    smallerChildIndex = rightChildIndex;
                }

                if (smallerChildIndex == nodeIndex)
                {
                    break;
                }

                Swap(nodeIndex, smallerChildIndex);
                nodeIndex = smallerChildIndex;
            }

            return min;
        }

        public int Count
        {
            get { return _heap.Count; }
        }
    }
}
