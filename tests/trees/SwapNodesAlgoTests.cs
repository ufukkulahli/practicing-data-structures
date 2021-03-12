using System.Collections.Generic;
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

  }

}