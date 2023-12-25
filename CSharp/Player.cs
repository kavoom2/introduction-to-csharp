namespace Algorithm
{
    class Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    class Player
    {
        public int PosX { get; private set; }
        public int PosY { get; private set; }

        Board _board;

        enum Direction
        {
            Up,
            Left,
            Down,
            Right,
        }

        int _direction = (int)Direction.Up;
        List<Position> _history = new();

        public void Initialize(int posX, int posY, Board board)
        {
            PosX = posX;
            PosY = posY;

            _board = board;

            int[] frontX = { 0, -1, 0, 1 };
            int[] frontY = { -1, 0, 1, 0 };

            int[] rightX = { 1, 0, -1, 0 };
            int[] rightY = { 0, -1, 0, 1 };

            _history.Add(new Position(PosX, PosY));

            while (PosX != _board.DestX || PosY != _board.DestY)
            {
                // 현 방향에서 오른쪽으로 회전 후 전진할 수 있는 경우
                if (
                    _board.GetTileType(PosX + rightX[_direction], PosY + rightY[_direction])
                    == Board.TileType.Empty
                )
                {
                    _direction = (_direction - 1 + 4) % 4;

                    PosX = PosX + frontX[_direction];
                    PosY = PosY + frontY[_direction];
                    _history.Add(new Position(PosX, PosY));
                }
                // 현 방향으로 전진할 수 있는 경우
                else if (
                    _board.GetTileType(PosX + frontX[_direction], PosY + frontY[_direction])
                    == Board.TileType.Empty
                )
                {
                    PosX = PosX + frontX[_direction];
                    PosY = PosY + frontY[_direction];
                    _history.Add(new Position(PosX, PosY));
                }
                // 좌측으로 회전
                else
                {
                    _direction = (_direction + 1) % 4;
                }
            }
        }

        const int MOVE_TICK = 50;
        int _sumTick = 0;
        int _lastIndex = 0;

        public void Update(int deltaTick)
        {
            if (_lastIndex >= _history.Count)
            {
                return;
            }

            _sumTick += deltaTick;

            if (_sumTick >= MOVE_TICK)
            {
                _sumTick = 0;

                PosX = _history[_lastIndex].X;
                PosY = _history[_lastIndex].Y;
                _lastIndex++;
            }
        }
    }
}
