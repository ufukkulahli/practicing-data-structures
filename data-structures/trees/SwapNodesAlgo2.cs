namespace practicing_data_structures.data_structures.trees
{
  public sealed class SwapNodesAlgo2
  {

    public int[][] Swap(int[][] indexes, int[] queries)
    {
      for(var i=0; i<queries.Length; i++)
      {
        Swap
        (
          indexes      : indexes,
          currIndex    : 1,
          targetDepth  : queries[i],
          currDepth    : 1
        );
      }

      return indexes;
    }

    public void Swap(int[][] indexes, int currIndex, int targetDepth, int currDepth)
    {
      if (indexes[currIndex][0]==-1  &&  (indexes[currIndex][1]==-1))
      {
          return;
      }

      SwapNodes(indexes, currIndex, targetDepth, currDepth);

      Swap(indexes, (currIndex+1), targetDepth, (currDepth+1) );
      Swap(indexes, (currIndex+1), targetDepth, (currDepth+1) );
    }

    public void SwapNodes(int[][] indexes, int currIndex, int targetDepth, int currDepth)
    {
      if (currDepth >= targetDepth  &&  currDepth % targetDepth == 0)
      {
        var tempLeftNodeValue = indexes[currIndex][0];
        indexes[currIndex][0] = indexes[currIndex][1];
        indexes[currIndex][1] = tempLeftNodeValue;
      }
    }

  }
}