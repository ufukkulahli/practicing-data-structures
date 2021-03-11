using System.Collections.Generic;

namespace practicing_data_structures.data_structures.trees
{
  public sealed class SwapNodesAlgo
  {

    public sealed class Node
    {
      public readonly int Index, Depth;
      public Node Left, Right;

      public Node(int index, int depth, Node left, Node right)
      {
        this.Index = index;
        this.Depth = depth;
        this.Left  = left;
        this.Right = right;
      }

    }

    public void SwapInOrder(Node currentNode, int depth, int k)
    {
      if(currentNode == null)
      {
        return;
      }

      SwapInOrder(currentNode.Left , (depth+1), k);
      SwapInOrder(currentNode.Right, (depth+1), k);

      if( (depth >= k)  &&  (depth % k==0) )
      {
        var tempLeft      = currentNode.Left;
        currentNode.Left  = currentNode.Right;
        currentNode.Right = tempLeft;
      }
    }

    public void PrintInOrder(Node currentNode, List<int> indexes)
    {
      if (currentNode == null)
      {
        return;
      }

      PrintInOrder(currentNode.Left, indexes);
      indexes.Add(currentNode.Index);
      PrintInOrder(currentNode.Right, indexes);
    }

    public void Swap()
    {
      throw new System.NotImplementedException();
    }
  }
}