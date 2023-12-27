using ExerciseGraph;

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
        }
    }
}
