using System.Drawing;

namespace CSharp
{
    class Monster
    {
        public int id;

        public Monster(int id)
        {
            this.id = id;
        }
    }

    class Map
    {
        int[,] tiles =
        {
            { 1, 1, 1, 1, 1, },
            { 1, 0, 0, 0, 1, },
            { 1, 0, 0, 0, 1, },
            { 1, 0, 0, 0, 1, },
        };

        public void Render()
        {
            ConsoleColor defaultColor = Console.ForegroundColor;

            for (int y = 0; y < tiles.GetLength(0); y++)
            {
                for (int x = 0; x < tiles.GetLength(1); x++)
                {
                    if (tiles[y, x] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    Console.Write(tiles[y, x] == 1 ? "[X]" : "[ ]");
                }

                Console.WriteLine();
            }

            Console.ForegroundColor = defaultColor;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[10]; // 10 is the size of the array
            nums[0] = 1;
            nums[1] = 2;
            nums[2] = 3;
            // ...
            nums[9] = 10;
            // nums[10] = 11; // this will throw an error

            int[] nums2 = nums;
            nums2[0] = 100;

            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine(nums[i]); // 기본값이 0입니다.
            }

            foreach (int num in nums)
            {
                Console.WriteLine(num); // 1, 2, 3, ..., 10
            }

            bool[] booleans = new bool[3];
            booleans[0] = true;

            for (int i = 0; i < booleans.Length; i++)
            {
                Console.WriteLine(booleans[i]); // 기본값이 False입니다.
            }

            Console.WriteLine(GetHighestScore(new int[] { 10, 20, 30, 40, 50 })); // 50
            Console.WriteLine(GetAverageScore(new int[] { 10, 20, 30, 40, 50 })); // 30
            Console.WriteLine(GetIndexOf(new int[] { 10, 20, 30, 40, 50 }, 30)); // 2
            int[] scores = new int[] { 10, 20, 30, 40, 50 };
            Sort(scores);
            foreach (int score in scores)
            {
                Console.WriteLine(score); // 10, 20, 30, 40, 50
            }

            // 2차원 배열
            int[,] matrix = new int[2, 3]; // 2 rows + 3 columns

            Console.WriteLine(matrix[1, 2]); // 5

            Map map = new Map();
            map.Render();

            int[][] nonRectangularMatrix = new int[2][]
            {
                new int[] { 0, 1, 2 },
                new int[] { 3, 4, 5, 6, 7 },
            };

            List<float> floats = new();
            floats.Add(1.1f);
            floats.Add(2.2f);
            floats.Add(3.3f);

            floats.Insert(3, 4.4f);
            floats.Insert(1, 1.5f);

            foreach (float f in floats)
            {
                Console.WriteLine(f);
            }

            floats.Remove(1.5f);
            floats.RemoveAt(0);

            foreach (float f in floats)
            {
                Console.WriteLine(f);
            }

            floats.Clear();

            Dictionary<int, Monster> dict = new();

            for (int i = 0; i < 1000; i++)
            {
                dict.Add(i, new Monster(i));
            }

            if (dict.ContainsKey(100))
            {
                Console.WriteLine(dict[100].id);
            }

            Monster myMonster;
            bool hasMyMonster = dict.TryGetValue(100, out myMonster);

            dict.Remove(100);
            dict.Clear();
        }

        static int GetHighestScore(int[] scores)
        {
            int highestScore = 0;

            foreach (int score in scores)
            {
                if (score > highestScore)
                {
                    highestScore = score;
                }
            }

            return highestScore;
        }

        static int GetAverageScore(int[] scores)
        {
            if (scores.Length == 0)
            {
                return 0;
            }

            int sum = 0;

            foreach (int score in scores)
            {
                sum += score;
            }

            return sum / scores.Length;
        }

        static int GetIndexOf(int[] scores, int score)
        {
            int index = -1;

            for (int i = 0; i < scores.Length; i++)
            {
                if (scores[i] == score)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        static void Sort(int[] scores)
        {
            for (int i = 0; i < scores.Length; i++)
            {
                for (int j = i + 1; j < scores.Length; j++)
                {
                    if (scores[i] > scores[j])
                    {
                        int temp = scores[i];
                        scores[i] = scores[j];
                        scores[j] = temp;
                    }
                }
            }
        }
    }
}
