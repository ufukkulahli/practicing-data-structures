using practicing_data_structures.data_structures.graphs;
using Xunit;

namespace practicing_data_structures.tests.graphs
{
  public class GraphTests
  {

    [Fact]
    public void AddingNullVertexCausesException()
    {
      // ARRANGE & ACT & ASSERT
      Assert.Throws<System.ArgumentNullException>(() => new Graph<string>().AddVertex(null));
    }

    [Fact]
    public void AddVertexTest()
    {
      // ARRANGE
      var graph = new Graph<string>();

      // ACT
      graph.AddVertex("hello");

      // ASSERT
      Assert.Equal(1, graph.VerticesCount);
    }

  }
}