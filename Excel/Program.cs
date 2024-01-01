using ExerciseGraph;
using ExercisePriorityQueue;

namespace Excel
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new();
            // graph.DepthFirstSearchAll();
            // graph.BreadthFirstSearchAll();
            graph.Dijkstra(0);

            PriorityQueue<int> priorityQueue = new();
            priorityQueue.Enqueue(5);
            priorityQueue.Enqueue(3);
            priorityQueue.Enqueue(2);
            priorityQueue.Enqueue(4);
            priorityQueue.Enqueue(1);

            while (priorityQueue.Count > 0)
            {
                Console.WriteLine(priorityQueue.Dequeue());
            }
        }
    }
}
