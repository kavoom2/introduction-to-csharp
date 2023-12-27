namespace ExerciseGraph
{
    class Graph
    {
        int[,] adjustmentMatrixVersion1 = new int[6, 6]
        {
            { 0, 1, 0, 1, 0, 0 },
            { 1, 0, 1, 1, 0, 0 },
            { 0, 1, 0, 0, 0, 0 },
            { 1, 1, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 1, 0 }
        };

        List<int>[] adjustmentMatrixVersion2 = new List<int>[]
        {
            new() { 1, 3 },
            new() { 0, 2, 3 },
            new() { 1 },
            new() { 0, 1, },
            new() { 5 },
            new() { 4 }
        };

        int[,] adjustmentMatrixVersion3 = new int[6, 6]
        {
            { -1, 15, -1, 35, -1, -1 },
            { 15, -1, 5, 10, -1, -1 },
            { -1, 5, -1, -1, -1, -1 },
            { 35, 10, -1, -1, 5, -1 },
            { -1, -1, -1, 5, -1, -1 },
            { -1, -1, -1, -1, -1, -1 }
        };

        public void DFSVersion1(int currentVertex, bool[] visited)
        {
            Console.WriteLine(currentVertex);
            visited[currentVertex] = true;

            for (int nextVertex = 0; nextVertex < 6; nextVertex++)
            {
                if (adjustmentMatrixVersion1[currentVertex, nextVertex] == 0 || visited[nextVertex])
                {
                    continue;
                }

                DFSVersion1(nextVertex, visited);
            }
        }

        public void DFSVersion2(int currentVertex, bool[] visited)
        {
            Console.WriteLine(currentVertex);
            visited[currentVertex] = true;

            foreach (int nextVertex in adjustmentMatrixVersion2[currentVertex])
            {
                if (visited[nextVertex])
                {
                    continue;
                }

                DFSVersion2(nextVertex, visited);
            }
        }

        public void DepthFirstSearchAll()
        {
            bool[] visited = new bool[6];

            for (int currentVertex = 0; currentVertex < 6; currentVertex++)
            {
                if (visited[currentVertex])
                {
                    continue;
                }

                DFSVersion2(currentVertex, visited);
            }
        }

        public void BFSVersion1(int startVertex, bool[] visited)
        {
            Queue<int> queue = new();
            queue.Enqueue(startVertex);
            visited[startVertex] = true;

            while (queue.Count > 0)
            {
                int currentVertex = queue.Dequeue();
                Console.WriteLine(currentVertex);

                for (int nextVertex = 0; nextVertex < 6; nextVertex++)
                {
                    if (
                        adjustmentMatrixVersion1[currentVertex, nextVertex] == 0
                        || visited[nextVertex]
                    )
                    {
                        continue;
                    }

                    queue.Enqueue(nextVertex);
                    visited[currentVertex] = true;
                }
            }
        }

        public void BFSVersion2(int startVertex, bool[] visited)
        {
            Queue<int> queue = new();
            queue.Enqueue(startVertex);
            visited[startVertex] = true;

            while (queue.Count > 0)
            {
                int currentVertex = queue.Dequeue();
                Console.WriteLine(currentVertex);

                foreach (int nextVertex in adjustmentMatrixVersion2[currentVertex])
                {
                    if (visited[currentVertex])
                    {
                        continue;
                    }

                    queue.Enqueue(nextVertex);
                    visited[currentVertex] = true;
                }
            }
        }

        public void BreadthFirstSearchAll()
        {
            bool[] visited = new bool[6];

            for (int currentVertex = 0; currentVertex < 6; currentVertex++)
            {
                if (visited[currentVertex])
                {
                    continue;
                }

                BFSVersion1(currentVertex, visited);
            }
        }

        /// <Summary>
        ///     꺼라위키 Dijkstra 알고리즘 그림 설명을 함께 보면 좋습니다. :)
        ///     <see href="https://namu.wiki/w/%EB%8B%A4%EC%9D%B5%EC%8A%A4%ED%8A%B8%EB%9D%BC%20%EC%95%8C%EA%B3%A0%EB%A6%AC%EC%A6%98#s-3.2">꺼라위키 Dijkstra 알고리즘</see>
        /// </Summary>
        public void Dijkstra(int startVertex)
        {
            // 시작 정점에서 해당 정점까지 최단거리를 확보했는지 여부를 나타냅니다.
            bool[] visited = new bool[6];

            // 시작 정점에서 해당 정점까지 최단거리를 나타냅니다.
            // - 확인되지 않은 값은 임의의 최대값(ex. int.MaxValue)로 지정합니다.
            int[] distance = new int[6];
            Array.Fill(distance, int.MaxValue);

            // 시작 정점에서 해당 정점까지 최단거리를 확보하는 과정에서
            // 도달하기 위한 이전 정점을 나타냅니다.
            int[] parent = new int[6];
            Array.Fill(parent, -1);

            // Stage 1. 시작 정점의 최단거리를 0으로 설정합니다.
            distance[startVertex] = 0;
            parent[startVertex] = startVertex;

            while (true)
            {
                // Stage 2 - 1. 현재 탐색한 정점들 중에서 가장 가까이 있는 정점을 찾습니다.
                int closestDistance = int.MaxValue;
                int closestVertex = -1;

                for (int vertex = 0; vertex < 6; vertex++)
                {
                    if (visited[vertex])
                    {
                        continue;
                    }

                    if (distance[vertex] >= closestDistance || distance[vertex] == int.MaxValue)
                    {
                        continue;
                    }

                    closestDistance = distance[vertex];
                    closestVertex = vertex;
                }

                // Stage 3. 가장 가까이 있는 정점을 찾지 못한 경우 종료합니다. (모든 정점을 탐색한 경우~)
                if (closestVertex == -1)
                {
                    break;
                }

                // Stage 2 - 2. 현재 탐색한 정점을 경유지로 하여
                // 인접 정점을 탐색하는 경우 도달하기 까지 걸리는 거리를 계산하여 업데이트합니다. (최단거리가 갱신되는 경우~)
                visited[closestVertex] = true;

                for (int vertex = 0; vertex < 6; vertex++)
                {
                    if (adjustmentMatrixVersion3[closestVertex, vertex] == -1)
                    {
                        continue;
                    }

                    if (visited[vertex])
                    {
                        continue;
                    }

                    // 현재 탐색한 정점들 중 가장 가까이 있는 정점을 경유지로 하여 인접 정점을 탐색하므로
                    // 이전에 계산된 경로가 업데이트될 수 있습니다. (그리고 항상 더 짧은 거리가 됩니다.)
                    int nextDistance =
                        closestDistance + adjustmentMatrixVersion3[closestVertex, vertex];
                    if (nextDistance < distance[vertex])
                    {
                        distance[vertex] = nextDistance;
                        parent[vertex] = closestVertex;
                    }
                }
            }
        }
    }
}
