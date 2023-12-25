namespace Algorithm
{
    class Board
    {
        public int[] _data = new int[25 * 25]; // 배열
        public MyList<int> data2 = new(); // 동적 배열(=리스트)
        public LinkedList<int> data3 = new(); // 연결 리스트

        public void Initialize()
        {
            data2.Add(1);
            data2.Add(2);

            int a = data2[0];

            data2.RemoveAt(0);
        }
    }
}
