using System.Collections.Generic;

namespace practicing_data_structures.data_structures.graphs.search
{
  public sealed class DepthFirst<T>
  {

    public bool Find(Vertex<T> startVertex, T searchedVertexValue)
    {
      return Find(startVertex, searchedVertexValue, new HashSet<T>());
    }

    public bool Find(Vertex<T> currentVertex, T searchedVertexValue, HashSet<T> visitedVertexValues)
    {
      if(currentVertex.Value.Equals(searchedVertexValue))
      {
        return true;
      }

      visitedVertexValues.Add(currentVertex.Value);

      foreach(var vertex in currentVertex.Edges)
      {
        if( visitedVertexValues.Contains(vertex.Value) )
        {
          continue;
        }

        var found = Find(vertex, searchedVertexValue, visitedVertexValues);
        if(found)
        {
          return true;
        }
      }

      return false;
    }

  }
}
