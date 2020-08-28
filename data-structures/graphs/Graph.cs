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

    public bool ContainsVertex(T item) => vertices.ContainsKey(item);
    public Vertex<T> GetVertex(T item) => vertices[item];

    public void AddEdge(T source, T destination)
    {
      if(source==null || destination==null)
      {
        throw new ArgumentNullException();
      }

      if(vertices.NotContainsKeys(source, destination))
      {
        throw new Exception();
      }

      if(vertices.EdgeExists(source, destination) || vertices.EdgeExists(destination, source))
      {
        throw new Exception();
      }

      vertices[source].Edges.Add( vertices[destination] );
      vertices[destination].Edges.Add( vertices[source] );
    }

  }
}