using practicing_data_structures.data_structures.trees;
using Xunit;

namespace practicing_data_structures.tests.trees
{
    public class SwapNodesAlgo2Tests
  {

    [Fact]
    public void SwapTest()
    {
      // Arrange
      var indexes     = new int[3][];
      indexes[0]      = new int[1];
      indexes[1]      = new int[2];
      indexes[2]      = new int[2];

      indexes[0][0]   = 1;
      indexes[1][0]   = 2;
      indexes[1][1]   = 3;
      indexes[2][0]   = -1;
      indexes[2][1]   = -1;

      var queries     = new int[1];
      queries[0]      = 1;

      var swapNodesAlgo2 = new SwapNodesAlgo2();

      // Act
      swapNodesAlgo2.Swap(indexes, queries);

      // Assert
      Assert.Equal(3, indexes[1][0]);
      Assert.Equal(2, indexes[1][1]);
    }

    [Fact]
    public void SwapNodeTest()
    {
      // Arrange
      var indexes     = new int[1][];
      indexes[0]      = new int[2];
      indexes[0][0]   = 2;
      indexes[0][1]   = 3;

      var node        = 0;
      var targetDepth = 1;
      var depth       = 1;
      var swapNodesAlgo2 = new SwapNodesAlgo2();

      // Act
      swapNodesAlgo2.SwapNodes(indexes, node, targetDepth, depth);

      // Assert
      Assert.Equal(3, indexes[0][0]);
      Assert.Equal(2, indexes[0][1]);
    }

    [Fact]
    public void SwapTest2()
    {
      // Arrange
      var visitedNodes= new int[2][];
      var indexes     = new int[2][];
      indexes[0]      = new int[2];
      indexes[1]      = new int[2];

      indexes[0][0]   = 2;
      indexes[0][1]   = 3;
      indexes[1][0]   = -1;
      indexes[1][1]   = -1;

      var index       = 0;
      var targetDepth = 1;
      var depth       = 1;
      var swapNodesAlgo2 = new SwapNodesAlgo2();

      // Act
      swapNodesAlgo2.Swap(indexes, index, targetDepth, depth, visitedNodes);

      // Assert
      Assert.Equal(3, indexes[0][0]);
      Assert.Equal(2, indexes[0][1]);
    }

    [Fact]
    public void SwapTest3()
    {
      // Arrange
      var indexes     = new int[6][];
      indexes[0]      = new int[1];
      indexes[1]      = new int[2];
      indexes[2]      = new int[2];
      indexes[3]      = new int[2];
      indexes[4]      = new int[2];
      indexes[5]      = new int[2];

      indexes[0][0]   = 1;

      indexes[1][0]   = 2;
      indexes[1][1]   = 3;

      indexes[2][0]   = -1; // (-1==null)
      indexes[2][1]   = 4;

      indexes[3][0]   = -1;
      indexes[3][1]   = 5;

      indexes[4][0]   = -1;
      indexes[4][1]   = -1;

      indexes[5][0]   = -1;
      indexes[5][1]   = -1;

      //       1
      //   2       3
      // n  4     n  5
      //   n n      n n

      var queries     = new int[2];
      queries[0]      = 2;
      queries[1]      = 3;

      var swapNodesAlgo2 = new SwapNodesAlgo2();

      // Act
      swapNodesAlgo2.Swap(indexes, queries);

      // Arrange
      Assert.Equal(2, indexes[1][0]);
      Assert.Equal(3, indexes[1][1]);

      Assert.Equal(4,  indexes[2][0]);
      Assert.Equal(-1, indexes[2][1]);

      Assert.Equal(5,  indexes[3][0]);
      Assert.Equal(-1, indexes[3][1]);

      Assert.Equal(-1, indexes[4][0]);
      Assert.Equal(-1, indexes[4][1]);

      Assert.Equal(-1, indexes[5][0]);
      Assert.Equal(-1, indexes[5][1]);
    }

  }
}