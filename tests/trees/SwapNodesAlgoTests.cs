using System.Collections.Generic;
using System.Linq;
using practicing_data_structures.data_structures.trees;
using Xunit;

namespace practicing_data_structures.tests.trees
{
  public class SwapNodesAlgoTests
  {
    [Fact]
    public void Test()
    {
      Assert.Throws<System.NotImplementedException>( () => new SwapNodesAlgo().Swap() );
    }

    [Fact]
    public void PrintInOrderTest()
    {
      // Arrange
      var left   = new SwapNodesAlgo.Node(2, 2, null, null);
      var right  = new SwapNodesAlgo.Node(3, 3, null, null);
      var parent = new SwapNodesAlgo.Node(1, 1, left, right);
      var swapNodes = new SwapNodesAlgo();
      var indexes = new List<int>();

      // Act
      swapNodes.PrintInOrder(parent, indexes);

      // Assert
      Assert.Equal(2, indexes[0]);
      Assert.Equal(1, indexes[1]);
      Assert.Equal(3, indexes[2]);
    }

    [Fact]
    public void SwapInOrderTest()
    {
      // Arrange
      var left   = new SwapNodesAlgo.Node(2, 2, null, null);
      var right  = new SwapNodesAlgo.Node(3, 3, null, null);
      var parent = new SwapNodesAlgo.Node(1, 1, left, right);
      var swapNodes = new SwapNodesAlgo();

      // Act
      swapNodes.SwapInOrder(parent, 1, 1);

      // Assert
      Assert.Equal(3, parent.Left.Index);
      Assert.Equal(2, parent.Right.Index);
    }

    [Fact]
    public void SwapInOrderTest2()
    {
      // Arrange
      var leftOfLeft   = new SwapNodesAlgo.Node(4, 4, null, null);
      var left         = new SwapNodesAlgo.Node(2, 2, leftOfLeft, null);

      var rightOfRight = new SwapNodesAlgo.Node(5, 5, null, null);
      var right        = new SwapNodesAlgo.Node(3, 3, null, rightOfRight);

      var parent       = new SwapNodesAlgo.Node(1, 1, left, right);

      var swapNodes = new SwapNodesAlgo();

      // Act
      swapNodes.SwapInOrder(parent, 1, 1);

      // Assert
      Assert.Equal(3, parent.Left.Index);
      Assert.Equal(5, parent.Left.Left.Index);

      Assert.Equal(2, parent.Right.Index);
      Assert.Equal(4, parent.Right.Right.Index);
    }

    [Fact]
    public void BuildTreeTest()
    {
      // Arrange
      var indexes = new int[0][];
      var swapNodes = new SwapNodesAlgo();

      // Act
      var tree = swapNodes.BuildTree(indexes).ToList();

      // Assert
      Assert.Equal(1, tree[0].Index);
      Assert.Equal(1, tree[0].Depth);
    }

    [Fact]
    public void BuildTreeTest2()
    {
      // Arrange
      var indexes = new int[2][];

      indexes[0]    = new int[2];
      indexes[0][0] = 2;
      indexes[0][1] = 3;

      indexes[1]    = new int[2];
      indexes[1][0] = 4;
      indexes[1][1] = 5;

      var swapNodes = new SwapNodesAlgo();

      // Act
      var tree = swapNodes.BuildTree(indexes).ToList();

      // Assert
      Assert.Equal(2, tree[0].Depth);
      Assert.Equal(3, tree[0].Index);

      Assert.Equal(3, tree[1].Depth);
      Assert.Equal(4, tree[1].Index);

      Assert.Equal(3, tree[2].Depth);
      Assert.Equal(5, tree[2].Index);
    }

    [Fact]
    public void GivenMinusOneAsNodeIndexCausesReturningNull()
    {
      Assert.Null( new SwapNodesAlgo().BuildNode(-1, 0) );
    }

    [Fact]
    public void BuildNodeAsNormal()
    {
      // Arrange
      var nodeIndex = 1;
      var depth     = 1;
      var swapNodes = new SwapNodesAlgo();

      // Act
      var builtNode = swapNodes.BuildNode(nodeIndex, depth);

      // Assert
      Assert.Equal(1, builtNode.Index);
      Assert.Equal(2, builtNode.Depth);
    }

  }

}