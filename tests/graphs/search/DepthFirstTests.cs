using practicing_data_structures.data_structures.graphs;
using practicing_data_structures.data_structures.graphs.search;
using Xunit;

namespace practicing_data_structures.tests.graphs.search
{
  public class DepthFirstTests
  {

    [Fact]
    public void SearchedVertexValueIsTheFirstOne()
    {
      // Arrange
      var graph = new Graph<char>();

      graph.AddVertex('A');
      graph.AddVertex('B');

      var depthFirst = new DepthSearch<char>();

      // Act & Assert
      Assert.True(depthFirst.Find(graph.FirstVertexOrNull, 'A'));
    }

    [Fact]
    public void SearchedVertexValueIsTheEdgeOfFirstVertex()
    {
      // Arrange
      var graph = new Graph<char>();

      graph.AddVertex('A');
      graph.AddVertex('B');

      graph.AddEdge('A', 'B');

      var depthFirst = new DepthSearch<char>();

      // Act & Assert
      Assert.True(depthFirst.Find(graph.FirstVertexOrNull, 'B'));
    }

    [Fact]
    public void SearchedVertexValueIsNotFound()
    {
      // Arrange
      var graph = new Graph<char>();

      graph.AddVertex('A');
      graph.AddVertex('B');

      graph.AddEdge('A', 'B');

      var depthFirst = new DepthSearch<char>();

      // Act & Assert
      Assert.False(depthFirst.Find(graph.FirstVertexOrNull, 'X'));
    }

  }
}
