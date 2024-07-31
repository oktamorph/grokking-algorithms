namespace DijkstraAlgorithm
{
    internal class Program
    {
        // list of the processed nodes
        private static List<string> processed = new List<string>();
        static void Main(string[] args)
        {
            // graph hash table
            Dictionary<string, Dictionary<string, int>> graph = new Dictionary<string, Dictionary<string, int>>();

            graph["start"] = new Dictionary<string, int>();
            graph["start"]["A"] = 6;
            graph["start"]["B"] = 2;

            graph["A"] = new Dictionary<string, int>();
            graph["A"]["FIN"] = 1;

            graph["B"] = new Dictionary<string, int>();
            graph["B"]["A"] = 3;
            graph["B"]["FIN"] = 5;

            graph["FIN"] = new Dictionary<string, int>();

            // costs hash table
            Dictionary<string, int> costs = new Dictionary<string, int>();
            costs["A"] = 6;
            costs["B"] = 2;
            costs["FIN"] = int.MaxValue;

            // parents hash table
            Dictionary<string, string> parents = new Dictionary<string, string>();
            parents["A"] = "START";
            parents["B"] = "START";
            parents["FIN"] = null;

            // implementation of the logic
            var node = FindLowestCostNode(costs);
            while (node != string.Empty)
            {
                var cost = costs[node];
                var neighbors = graph[node];

                foreach (var n in neighbors.Keys)
                {
                    var newCost = cost + neighbors[n];
                    if (costs[n] > newCost)
                    {
                        costs[n] = newCost; ;
                        parents[n] = node;
                    }
                }
                processed.Add(node);
                node = FindLowestCostNode(costs);
            }

            Console.WriteLine("Weight of the shortest path is: " + costs["FIN"]);
        }

        private static string FindLowestCostNode(Dictionary<string, int> costs)
        {
            int lowestCost = int.MaxValue;
            string lowestCostNode = string.Empty;

            foreach (var node in costs)
            {
                int cost = costs[node.Key];
                if (cost < lowestCost && !processed.Contains(node.Key))
                {
                    lowestCost = cost;
                    lowestCostNode = node.Key;
                }
            }

            return lowestCostNode;
        }

    }
}
