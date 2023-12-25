namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new();
            Player player = new();
            board.Initialize(25, player);
            player.Initialize(1, 1, board);

            Console.CursorVisible = false;

            int lastTick = 0;
            const int FRAME = 1000 / 30;

            while (true)
            {
                # region 프레임 관리
                int currentTick = Environment.TickCount & int.MaxValue;

                if (currentTick - lastTick < FRAME)
                {
                    continue;
                }

                int deltaTick = currentTick - lastTick;
                lastTick = currentTick;
                # endregion

                # region 로직 처리
                player.Update(deltaTick);
                # endregion

                # region 렌더링
                Console.SetCursorPosition(0, 0);
                board.Render();
                # endregion
            }
        }
    }
}
