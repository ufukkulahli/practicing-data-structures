using System;
using System.Collections.Generic;
using System.Linq;

namespace practicing_data_structures.data_structures.graphs
{
  public sealed class Graph<T>
  {

    private readonly IDictionary<T, Vertex<T>> vertices = new Dictionary<T, Vertex<T>>();

    public int VerticesCount => vertices.Count;
    public bool ContainsVertex(T item) => vertices.ContainsKey(item);
    public Vertex<T> GetVertex(T item) => vertices[item];

    public void AddVertex(T item)
    {
      ThrowIfNull(item);

      vertices.Add(item, new Vertex<T>(item));
    }

    public void RemoveVertex(T item)
    {
      
      ThrowIfNull(item);
      ThrowIfSourceIsAbsent(item);

      foreach(var vertice in vertices[item].Edges)
      {
        vertice.Edges.Remove(vertices[item]);
      }

      vertices.Remove(item);
    }

    public void AddEdge(T source, T destination)
    {
      ThrowIfNull(source);
      ThrowIfNull(destination);

      ThrowIfSourceIsAbsent(source);
      ThrowIfDestinationIsAbsent(destination);

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
      ThrowIfSourceIsAbsent(source);
      ThrowIfDestinationIsAbsent(destination);

      return
        vertices.EdgeExists(source, destination) &&
        vertices.EdgeExists(destination, source);
    }

    public void RemoveEdge(T source, T destination)
    {
      ThrowIfNull(source);
      ThrowIfNull(destination);

      ThrowIfSourceIsAbsent(source);
      ThrowIfDestinationIsAbsent(destination);

      if(vertices.EdgeIsAbsent(source, destination))
      {
        throw new Exception($"Edge '{source}' contains '{destination}'!");
      }

      if(vertices.EdgeIsAbsent(destination, source))
      {
        throw new Exception($"Edge '{destination}' contains '{source}'!");
      } 

      vertices[source].Edges.Remove(vertices[destination]);
      vertices[destination].Edges.Remove(vertices[source]);
    }

    public IEnumerable<T> Edges(T vertex)
    {
      ThrowIfSourceIsAbsent(vertex);

      return
        vertices[vertex].Edges.Select(e => e.Value);
    }

    private void ThrowIfNull(T item)
    {
      if (item == null)
      {
        throw new ArgumentNullException();
      }
    }

    private void ThrowIfSourceIsAbsent(T source)
    {
      if (vertices.NotContainsKey(source))
      {
        throw new Exception($"Source '{source}' Vertex is not in this graph!");
      }
    }

    private void ThrowIfDestinationIsAbsent(T destination)
    {
      if (vertices.NotContainsKey(destination))
      {
        throw new Exception($"Destination  '{destination}' Vertex is not in this graph!");
      }
    }

  }
}