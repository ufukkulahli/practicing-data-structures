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

    public LinkedList<Node> BuildTree(int[][] indexes)
    {
      var root = BuildRoot();

      var currentNode = root;

      var nodesQueue = new LinkedList<Node>();
      nodesQueue.AddLast(currentNode);

      var numberOfNodes = indexes.Length;

      for(var index=0; index<numberOfNodes; index++)
      {
        currentNode        = nodesQueue.First.Value;
        nodesQueue.RemoveFirst();

        var leftNodeIndex  = indexes[index][0];
        var rightNodeIndex = indexes[index][1];

        currentNode.Left  = BuildNode(leftNodeIndex,  currentNode.Depth);
        currentNode.Right = BuildNode(rightNodeIndex, currentNode.Depth);

        if(currentNode.Left != null  &&  currentNode.Left.Index != -1)
        {
          nodesQueue.AddLast(currentNode.Left);
        }

        if(currentNode.Right != null  &&  currentNode.Right.Index != -1)
        {
          nodesQueue.AddLast(currentNode.Right);
        }
      }

      return nodesQueue;
    }

    private Node BuildRoot() => new Node(1, 1, null, null);

    public Node BuildNode(int nodeIndex, int depth)
    {
      if(nodeIndex == -1)
      {
        return null;
      }

      return new Node(nodeIndex, (depth+1), null, null);
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

    public int[][] Check(int[][] indexes, int[] queries, Node root)
    {
      int[][] result = new int[queries.Length][];

      for(var index=0;  index<queries.Length;  index++)
      {
        SwapInOrder(root, 1, queries[index]);
        var tempIndexes = new List<int>();
        PrintInOrder(root, tempIndexes);

        var vals = new int[tempIndexes.Count];
        vals = tempIndexes.ToArray();
        result[index] = vals;
      }

      return result;
    }

    public void Swap()
    {
      throw new System.NotImplementedException();
    }
  }
}