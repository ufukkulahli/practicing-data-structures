using System.Collections.Generic;

namespace practicing_data_structures.data_structures.trees
{
  public sealed class SwapNodesAlgo
  {

    public sealed class Node
    {
      public readonly int Index, Depth;
      public readonly Node Left, Right;

      public Node(int index, int depth, Node left, Node right)
      {
        this.Index = index;
        this.Depth = depth;
        this.Left  = left;
        this.Right = right;
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
    }

    public void Swap()
    {
      throw new System.NotImplementedException();
    }
  }
}