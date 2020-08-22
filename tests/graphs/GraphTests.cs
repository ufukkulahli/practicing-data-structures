using practicing_data_structures.data_structures.graphs;
using Xunit;

namespace practicing_data_structures.tests.graphs
{
  public class GraphTests
  {
    [Fact]
    public void Test()
    {
      Assert.Throws<System.NotImplementedException>( () => new Graph<int>().AddVertex(1) );
    }
  }
}