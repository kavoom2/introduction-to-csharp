namespace Algorithm
{
    class MyLinkedListNode<T>
    {
        public MyLinkedListNode<T>? Next = null;
        public MyLinkedListNode<T>? Prev = null;
        public T Data;

        public MyLinkedListNode(T data)
        {
            Data = data;
        }
    }

    class MyLinkedList<T>
    {
        public MyLinkedListNode<T>? Head = null;
        public MyLinkedListNode<T>? Tail = null;
        public int Count = 0;

        public MyLinkedListNode<T> AddLast(T data)
        {
            MyLinkedListNode<T> newNode = new(data);

            if (Head == null)
            {
                Head = newNode;
            }

            if (Tail != null)
            {
                Tail.Next = newNode;
                newNode.Prev = Tail;
            }

            Tail = newNode;
            Count++;

            return newNode;
        }

        public void Remove(MyLinkedListNode<T> node)
        {
            if (Head == node)
            {
                Head = Head.Next;
            }

            if (Tail == node)
            {
                Tail = Tail.Prev;
            }

            if (node.Prev != null)
            {
                node.Prev.Next = node.Next;
            }

            if (node.Next != null)
            {
                node.Next.Prev = node.Prev;
            }

            Count--;
        }
    }
}
