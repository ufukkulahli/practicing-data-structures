using System;
using System.Collections.Generic;
using System.Linq;

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

      foreach(var vertice in vertices[item].Edges)
      {
        vertice.Edges.Remove(vertices[item]);
      }

      vertices.Remove(item);
    }

    public bool ContainsVertex(T item) => vertices.ContainsKey(item);
    public Vertex<T> GetVertex(T item) => vertices[item];

    public void AddEdge(T source, T destination)
    {
      if(source==null || destination==null)
      {
        throw new ArgumentNullException("Source or Destination Vertex can not be null!");
      }

      if(vertices.NotContainsKey(source))
      {
        throw new Exception($"Source '{source}' Vertex is not in this graph!");
      }

      if(vertices.NotContainsKey(destination))
      {
        throw new Exception($"Destination  '{destination}' Vertex is not in this graph!");
      }

      if(vertices.EdgeExists(source, destination))
      {
        throw new Exception($"Edge '{source}' contains '{destination}'!");
      }

      if(vertices.EdgeExists(destination, source))
      {
        throw new Exception($"Edge '{destination}' contains '{source}'!");
      }

      vertices[source].Edges.Add( vertices[destination] );
      vertices[destination].Edges.Add( vertices[source] );
    }

    public bool HasEdge(T source, T destination)
    {
      if(vertices.NotContainsKey(source))
      {
        throw new Exception($"Source '{source}' Vertex is not in this graph!");
      }
      if (vertices.NotContainsKey(destination))
      {
        throw new Exception($"Destination  '{destination}' Vertex is not in this graph!");
      }

      return
        vertices.EdgeExists(source, destination) &&
        vertices.EdgeExists(destination, source);
    }

    public void RemoveEdge(T source, T destination)
    {
      if(source==null || destination==null)
      {
        throw new ArgumentNullException();
      }

      if(vertices.NotContainsKey(source))
      {
        throw new Exception($"Source '{source}' Vertex is not in this graph!");
      }
      if (vertices.NotContainsKey(destination))
      {
        throw new Exception($"Destination  '{destination}' Vertex is not in this graph!");
      }

      if(! vertices.EdgeExists(source, destination))
      {
        throw new Exception($"Edge '{source}' contains '{destination}'!");
      }

      if(! vertices.EdgeExists(destination, source))
      {
        throw new Exception($"Edge '{destination}' contains '{source}'!");
      } 

    }

  }
}