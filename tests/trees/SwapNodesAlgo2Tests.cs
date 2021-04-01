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
      swapNodesAlgo2.Swap(indexes, index, targetDepth, depth);

      // Assert
      Assert.Equal(3, indexes[0][0]);
      Assert.Equal(2, indexes[0][1]);
    }

  }
}