using System.Collections.Generic;

namespace practicing_data_structures.data_structures.graphs
{
  public sealed class Vertex<T>
  {
    public readonly T Value;
    public readonly HashSet<Vertex<T>> Edges;

    public Vertex(T value)
    {
      Value = value;
      Edges = new HashSet<Vertex<T>>();
    }

    public int EdgesCount => Edges.Count;
  }
}