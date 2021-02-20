using System.Collections.Generic;

namespace practicing_data_structures.data_structures.graphs
{
  public sealed class BFSGraph
  {
    public readonly IDictionary<int, List<int>> References = new Dictionary<int, List<int>>();
    public readonly IDictionary<int, int> Paths = new Dictionary<int, int>();
    public readonly IDictionary<int, int> Distances = new Dictionary<int, int>();

    public void AddEdge(int node1, int node2)
    {
      if (!References.ContainsKey(node1))
      {
        References[node1] = new List<int>() { node2 };
      }

      if (!References.ContainsKey(node2))
      {
        References[node2] = new List<int>() { node1 };
      }

    }

    public void ShortestPath(int source, int destination)
    {
      throw new System.NotImplementedException();
    }

    public void ResetDistances()
    {
      foreach(var node in References.Keys)
      {
        Distances[node] = -1;
      }
    }

  }
}