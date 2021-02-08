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

        throw new System.NotImplementedException("Searching queue functionality not implemented completely!");
      }

      throw new System.NotImplementedException("Find functionality not implemented completely!");
    }
  }
}