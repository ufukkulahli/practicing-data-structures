namespace practicing_data_structures.data_structures.graphs.search
{
  public sealed class DepthSearch<T>
  {
    public bool Find(Vertex<T> startVertex, T searchedVertexValue)
    {
      if(startVertex.Value.Equals(searchedVertexValue))
      {
        return true;
      }

      throw new System.NotImplementedException();
    }
  }
}