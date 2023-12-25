namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new();
            board.Initialize();

            Console.CursorVisible = false;

            int lastTick = 0;
            const int FRAME = 1000 / 30;
            const char CIRCLE = '●';

            while (true)
            {
                # region 프레임 관리
                int currentTick = Environment.TickCount & Int32.MaxValue;

                if (currentTick - lastTick < FRAME)
                {
                    continue;
                }

                lastTick = currentTick;
                # endregion

                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < 25; i++)
                {
                    for (int j = 0; j < 25; j++)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(CIRCLE);
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
