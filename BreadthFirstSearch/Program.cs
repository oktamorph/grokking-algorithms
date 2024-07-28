Dictionary<string, string[]> graph = new Dictionary<string, string[]>();
graph.Add("you", new string[] { "alice", "bob", "claire" });
graph.Add("bob", new string[] { "anuj", "peggy" });
graph.Add("alice", new string[] { "peggy" });
graph.Add("claire", new string[] { "thom", "jonny" });
graph.Add("anuj", new string[] { });
graph.Add("peggy", new string[] { });
graph.Add("thom", new string[] { });
graph.Add("jonny", new string[] { });

Queue<string[]> queue = new Queue<string[]>();
queue.Enqueue(graph["you"]);

List<string> searchedPerson = new List<string>();

bool isPersonSeller = false;

while (queue.Count() > 0)
{
    var person = queue.Dequeue();
    for (var i = 0; i < person.Length; i++)
    {
        if (!searchedPerson.Contains(person[i]))
        {
            if (Convert.ToChar(person[i].Substring(person[i].Length - 1)) == 'm')
            {
                isPersonSeller = true;
                Console.WriteLine(person[i] + " is a mango seller!");
                break;
            }
            else
            {
                queue.Enqueue(graph[person[i]]);
                searchedPerson.Add(person[i]);
            }
        }
    }
}

if (!isPersonSeller)
    Console.WriteLine("There are no mango sellers in the graph!");
