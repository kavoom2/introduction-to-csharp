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

            // RightHand();
            // BFS();
            AStar();
        }

        struct PQNode : IComparable<PQNode>
        {
            public int F;
            public int G;
            public int Y;
            public int X;

            public int CompareTo(PQNode other)
            {
                if (F == other.F)
                {
                    return 0;
                }

                return F < other.F ? 1 : -1;
            }
        }

        void AStar()
        {
            // Scoring
            // F = G + H;
            // F: 최종 점수 (작을 수록 좋습니다.)
            // G: 시작점에서 해당 지점까지 이동하는데 필요한 비용 (작을 수록 좋습니다.)
            // H: 해당 지점에서 목적지까지 거리 (작을 수록 좋습니다.)

            bool[,] visited = new bool[_board.Size, _board.Size];
            int[,] priority = new int[_board.Size, _board.Size];
            for (int y = 0; y < _board.Size; y++)
            {
                for (int x = 0; x < _board.Size; x++)
                {
                    priority[y, x] = int.MaxValue;
                }
            }
            Position[,] parent = new Position[_board.Size, _board.Size];
            PriorityQueue<PQNode> pq = new();

            int[] deltaY = { -1, 0, 1, 0, -1, 1, 1, -1 };
            int[] deltaX = { 0, -1, 0, 1, -1, -1, 1, 1 };
            int[] cost = { 10, 10, 10, 10, 14, 14, 14, 14 };

            priority[PosY, PosX] =
                10 * (Math.Abs(_board.DestY - PosY) + Math.Abs(_board.DestX - PosX));
            pq.Enqueue(
                new PQNode
                {
                    F = priority[PosY, PosX],
                    G = 0,
                    Y = PosY,
                    X = PosX
                }
            );
            parent[PosY, PosX] = new Position(PosX, PosY);

            while (pq.Count > 0)
            {
                PQNode node = pq.Dequeue();

                if (visited[node.Y, node.X])
                {
                    continue;
                }

                visited[node.Y, node.X] = true;
                if (node.Y == _board.DestY && node.X == _board.DestX)
                {
                    break;
                }

                for (int i = 0; i < deltaX.Length; i++)
                {
                    int nextX = node.X + deltaX[i];
                    int nextY = node.Y + deltaY[i];

                    if (_board.GetTileType(nextX, nextY) != Board.TileType.Empty)
                    {
                        continue;
                    }

                    if (visited[nextY, nextX])
                    {
                        continue;
                    }

                    int nextG = node.G + cost[i];
                    int nextH =
                        10 * (Math.Abs(_board.DestY - nextY) + Math.Abs(_board.DestX - nextX));
                    int nextF = nextG + nextH;

                    if (priority[nextY, nextX] < nextF)
                    {
                        continue;
                    }

                    priority[nextY, nextX] = nextF;
                    pq.Enqueue(
                        new PQNode()
                        {
                            F = nextF,
                            G = nextG,
                            Y = nextY,
                            X = nextX
                        }
                    );
                    parent[nextY, nextX] = new Position(node.X, node.Y);
                }
            }

            int currX = _board.DestX;
            int currY = _board.DestY;

            while (parent[currY, currX].X != currX || parent[currY, currX].Y != currY)
            {
                _history.Add(new Position(currX, currY));

                Position pos = parent[currY, currX];
                currX = pos.X;
                currY = pos.Y;
            }

            _history.Add(new Position(currX, currY));
            _history.Reverse();
        }

        void BFS()
        {
            int[] deltaY = { -1, 0, 1, 0 };
            int[] deltaX = { 0, -1, 0, 1 };
            bool[,] visited = new bool[_board.Size, _board.Size];
            Position[,] parent = new Position[_board.Size, _board.Size];
            Queue<Position> queue = new();

            visited[PosY, PosX] = true;
            parent[PosY, PosX] = new Position(PosX, PosY);
            queue.Enqueue(new Position(PosX, PosY));

            while (queue.Count > 0)
            {
                Position position = queue.Dequeue();

                for (int i = 0; i < 4; i++)
                {
                    int nextX = position.X + deltaX[i];
                    int nextY = position.Y + deltaY[i];

                    if (_board.GetTileType(nextX, nextY) != Board.TileType.Empty)
                    {
                        continue;
                    }

                    if (visited[nextY, nextX])
                    {
                        continue;
                    }

                    visited[nextY, nextX] = true;
                    parent[nextY, nextX] = position;
                    queue.Enqueue(new Position(nextX, nextY));
                }
            }

            int x = _board.DestX;
            int y = _board.DestY;

            while (parent[y, x].X != x || parent[y, x].Y != y)
            {
                _history.Add(new Position(x, y));

                Position pos = parent[y, x];
                x = pos.X;
                y = pos.Y;
            }

            _history.Add(new Position(x, y));
            _history.Reverse();
        }

        void RightHand()
        {
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
