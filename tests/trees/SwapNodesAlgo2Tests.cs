using practicing_data_structures.data_structures.trees;
using Xunit;

namespace practicing_data_structures.tests.trees
{
    public class SwapNodesAlgo2Tests
  {

    [Fact]
    public void SwapTest()
    {
      Assert.Throws<System.NotImplementedException>( () => new SwapNodesAlgo2().Swap(null, null) );
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
      var indexes     = new int[0][];
      var node        = 1;
      var targetDepth = 1;
      var depth       = 1;
      var results     = new int[0][];
      var swapNodesAlgo2 = new SwapNodesAlgo2();

      // Act
      swapNodesAlgo2.Swap(indexes, node, targetDepth, depth, results);

      // Assert
      Assert.Empty(results);
    }

  }
}