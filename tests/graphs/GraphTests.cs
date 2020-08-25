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

    [Fact]
    public void RemovingNullVertexCausesException()
    {
      // ARRANGE & ACT & ASSERT
      Assert.Throws<System.ArgumentNullException>(() => new Graph<string>().RemoveVertex(null));
    }

    [Fact]
    public void RemoveVertexTest()
    {
      // ARRANGE & ACT & ASSERT
      Assert.Throws<System.Exception>(() => new Graph<string>().RemoveVertex("hello"));
    }

    [Fact]
    public void NotContainsVertexTest()
    {
      // ARRANGE & ACT & ASSERT
      Assert.False( new Graph<string>().ContainsVertex("hello") );
    }

    [Fact]
    public void ContainsVertexTest()
    {
      // ARRANGE
      var graph = new Graph<string>();

      // ACT
      graph.AddVertex("hello");

      // ASSERT
      Assert.True(graph.ContainsVertex("hello"));
    }

  }
}