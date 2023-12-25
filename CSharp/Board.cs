namespace Algorithm
{
    class Board
    {
        public TileType[,] Tile = new TileType[0, 0];
        public int Size = 0;
        public int DestX { get; private set; }
        public int DestY { get; private set; }

        public enum TileType
        {
            Empty,
            Wall,
            Invalid,
        }

        Player _player;

        public void Initialize(int size, Player player)
        {
            if (size % 2 == 0)
            {
                return;
            }

            Size = size;
            Tile = new TileType[Size, Size];
            _player = player;

            DestX = Size - 2;
            DestY = Size - 2;

            GenerateSideWinderMaze();
        }

        void GenerateBinaryTreeMaze()
        {
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                    {
                        Tile[y, x] = TileType.Wall;
                        continue;
                    }

                    Tile[y, x] = TileType.Empty;
                }
            }

            Random rand = new();
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (y % 2 == 0 || x % 2 == 0)
                    {
                        continue;
                    }

                    if (y == Size - 2 && x == Size - 2)
                    {
                        continue;
                    }

                    if (y == Size - 2)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        continue;
                    }

                    if (x == Size - 2)
                    {
                        Tile[y + 1, x] = TileType.Empty;
                        continue;
                    }

                    if (rand.Next(0, 2) == 0)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                    }
                    else
                    {
                        Tile[y + 1, x] = TileType.Empty;
                    }
                }
            }
        }

        void GenerateSideWinderMaze()
        {
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                    {
                        Tile[y, x] = TileType.Wall;
                        continue;
                    }

                    Tile[y, x] = TileType.Empty;
                }
            }

            Random rand = new();
            for (int y = 0; y < Size; y++)
            {
                int count = 1;

                for (int x = 0; x < Size; x++)
                {
                    if (y % 2 == 0 || x % 2 == 0)
                    {
                        continue;
                    }

                    if (y == Size - 2 && x == Size - 2)
                    {
                        continue;
                    }

                    if (y == Size - 2)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        continue;
                    }

                    if (x == Size - 2)
                    {
                        Tile[y + 1, x] = TileType.Empty;
                        continue;
                    }

                    if (rand.Next(0, 2) == 0)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        count++;
                    }
                    else
                    {
                        int randomIndex = rand.Next(0, count);
                        Tile[y + 1, x - randomIndex * 2] = TileType.Empty;
                        count = 1;
                    }
                }
            }
        }

        public void Render()
        {
            ConsoleColor prevColor = Console.ForegroundColor;

            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (_player.PosX == x && _player.PosY == y)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write('◎');
                        continue;
                    }

                    if (DestX == x && DestY == y)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("◆");
                        continue;
                    }

                    Console.ForegroundColor = GetTileColor(Tile[y, x]);
                    Console.Write('●');
                }

                Console.WriteLine();
            }

            Console.ForegroundColor = prevColor;
        }

        static ConsoleColor GetTileColor(TileType type)
        {
            switch (type)
            {
                case TileType.Empty:
                {
                    return ConsoleColor.Green;
                }
                case TileType.Wall:
                {
                    return ConsoleColor.Red;
                }
                default:
                {
                    return ConsoleColor.Green;
                }
            }
        }

        public TileType GetTileType(int x, int y)
        {
            if (x < 0 || x >= Size || y < 0 || y >= Size)
            {
                return TileType.Invalid;
            }

            return Tile[y, x];
        }
    }
}
