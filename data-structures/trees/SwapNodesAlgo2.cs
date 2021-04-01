namespace practicing_data_structures.data_structures.trees
{
  public sealed class SwapNodesAlgo2
  {

    public int[][] Swap(int[][] indexes, int[] queries)
    {
      for(var i=0; i<queries.Length; i++)
      {
        Swap(indexes, 1, queries[i], 1);
      }

      return indexes;
    }

    public void Swap(int[][] indexes, int index, int targetDepth, int depth)
    {
      if (index == -1)
      {
          return;
      }

      SwapNodes(indexes, index, targetDepth, depth);
      Swap(indexes, indexes[index+1][0], targetDepth, (depth+1) );
      Swap(indexes, indexes[index+1][1], targetDepth, (depth+1) );
    }

    public void SwapNodes(int[][] indexes, int index, int targetDepth, int depth)
    {
      if (depth >= targetDepth  &&  depth % targetDepth == 0)
      {
        var tempLeftIndex  = indexes[index][0];
        indexes[index][0]  = indexes[index][1];
        indexes[index][1]  = tempLeftIndex;
      }
    }

  }
}