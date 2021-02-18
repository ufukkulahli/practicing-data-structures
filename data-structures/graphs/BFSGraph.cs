using System.Collections.Generic;

namespace practicing_data_structures.data_structures.graphs
{
  public sealed class BFSGraph
  {
    public readonly IDictionary<int, List<int>> references = new Dictionary<int, List<int>>();

    public void AddEdge(int node1, int node2)
    {
      if (!references.ContainsKey(node1))
      {
        references[node1] = new List<int>() { node2 };
      }

      if (!references.ContainsKey(node2))
      {
        references[node2] = new List<int>() { node1 };
      }

    }    
  }

}