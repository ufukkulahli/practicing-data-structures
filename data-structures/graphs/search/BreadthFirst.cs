using System.Collections.Generic;

namespace practicing_data_structures.data_structures.graphs.search
{
  public sealed class BreadthFirst<T>
  {
    public bool Find(Graph<T> graph, T vertexValue)
    {
      var vertexQueue = new Queue<Vertex<T>>();
      var visitedVertexValues = new HashSet<T>();

      vertexQueue.Enqueue(graph.NextVertex);
      visitedVertexValues.Add(graph.NextVertex.Value);

      while(vertexQueue.Count>0)
      {
        var currentVertex = vertexQueue.Dequeue();

        if(currentVertex.Value.Equals(vertexValue))
        {
          return true;
        }

        foreach(var edge in currentVertex.Edges)
        {
          if(visitedVertexValues.Contains(edge.Value))
          {
            continue;
          }

          visitedVertexValues.Add(edge.Value);
          vertexQueue.Enqueue(edge);
        }
      }

      throw new System.NotImplementedException("Find functionality not implemented completely!");
    }
  }
}