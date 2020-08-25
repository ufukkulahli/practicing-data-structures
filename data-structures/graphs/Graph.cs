using System;
using System.Collections.Generic;

namespace practicing_data_structures.data_structures.graphs
{
  public sealed class Graph<T>
  {

    private readonly IDictionary<T, Vertex<T>> vertices = new Dictionary<T, Vertex<T>>();
    public int VerticesCount => vertices.Count;

    public void AddVertex(T item)
    {
      if (item == null)
      {
        throw new ArgumentNullException();
      }

      vertices.Add(item, new Vertex<T>(item));
    }

    public void RemoveVertex(T item)
    {
      if (item == null)
      {
        throw new ArgumentNullException();
      }

      if(vertices.NotContainsKey(item))
      {
        throw new Exception("Vertex not found!");
      }

      // TODO: REMOVE EDGES

      vertices.Remove(item);
    }



  }
}