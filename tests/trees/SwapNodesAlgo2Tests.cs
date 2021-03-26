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