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

  }
}