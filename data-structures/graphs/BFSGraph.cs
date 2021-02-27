using System.Collections.Generic;
using System.Linq;

namespace practicing_data_structures.data_structures.graphs
{
  public sealed class BFSGraph
  {
    public readonly IDictionary<int, List<int>> References = new Dictionary<int, List<int>>();
    public readonly IDictionary<int, int> Paths = new Dictionary<int, int>();
    public readonly IDictionary<int, int> Distances = new Dictionary<int, int>();
    public readonly Queue<int> WillBeVisitedNodes = new Queue<int>();

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

    public Stack<int> ShortestPath(int source, int destination)
    {
      ResetDistances();
      ResetSourcesDistance(source);
      VisitAllNodes(source);
      return BuildPath(source, destination);
    }

    public void ResetDistances()
    {
      foreach(var node in References.Keys)
      {
        Distances[node] = -1;
      }
    }

    public void ResetSourcesDistance(int source)
    {
      Distances[source] = 0;
    }

    public void VisitAllNodes(int node)
    {
      WillBeVisitedNodes.Enqueue(node);

      while(WillBeVisitedNodes.Any())
      {
        var currentNode = WillBeVisitedNodes.Dequeue();

        UpdateDistancesAndPaths(node);
      }

    }

    public void UpdateDistancesAndPaths(int node)
    {
      var nodes = References[node];
      var adjacents = nodes.Where( n => Distances[n] == -1 );

      foreach(var adjacent in adjacents)
      {
        var distanceOfNode = Distances[node];
        Distances[adjacent] = distanceOfNode + 1;

        Paths[adjacent] = node;

        WillBeVisitedNodes.Enqueue(adjacent);
      }
    }

    public Stack<int> BuildPath(int source, int destination)
    {
      var builtPaths = new Stack<int>(); 

      var currentNode = destination;

      while(currentNode != source)
      {
        builtPaths.Push(currentNode);
        currentNode = Paths[currentNode];
      }

      builtPaths.Push(source);

      return builtPaths;
    }

  }
}