namespace practicing_data_structures.data_structures.trees
{
  public sealed class SwapNodesAlgo2
  {

    public int[][] Swap(int[][] indexes, int[] queries)
    {
      throw new System.NotImplementedException();
    }

    public void Swap(int[][] indexes, int node, int targetDepth, int depth, int[][] result)
    {
      if (node == -1)
      {
          return;
      }

      SwapNodes(indexes, node, targetDepth, depth);

      throw new System.NotImplementedException();
    }

    public void SwapNodes(int[][] indexes, int node, int targetDepth, int depth)
    {
      if (depth % targetDepth == 0)
      {
        var tempLeftIndex = indexes[node][0];
        indexes[node][0]  = indexes[node][1];
        indexes[node][1]  = tempLeftIndex;
      }
    }

  }
}