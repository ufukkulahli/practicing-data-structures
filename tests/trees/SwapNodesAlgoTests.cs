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

  }

}