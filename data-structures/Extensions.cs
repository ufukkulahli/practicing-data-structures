using System.Collections.Generic;
using practicing_data_structures.data_structures.graphs;

namespace practicing_data_structures.data_structures
{
  public static class Extensions
  {

    public static bool NotContainsKey<T>(this IDictionary<T, Vertex<T>> vertices, T item)
    {
      return ! vertices.ContainsKey(item);
    }

    public static bool NotContainsKeys<T>(this IDictionary<T, Vertex<T>> vertices, T item, T anOtherItem)
    {
      return
        vertices.NotContainsKey(item)
        ||
         vertices.NotContainsKey(anOtherItem);
    }

    public static bool EdgeExists<T>(this IDictionary<T, Vertex<T>> vertices, T source, T destination)
    {
      return
        vertices[source].Edges.Contains( vertices[destination] );
    }



  }
}