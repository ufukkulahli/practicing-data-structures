using practicing_data_structures.data_structures.graphs;
using practicing_data_structures.data_structures.graphs.search;
using Xunit;

namespace practicing_data_structures.tests.graphs.search
{
  public class BreadthFirstTests
  {
    [Fact]
    public void Test()
    {
      // Arrange
      var graph = new Graph<char>();

      graph.AddVertex('A');
      graph.AddVertex('B');
      graph.AddVertex('C');
      graph.AddVertex('D');

      graph.AddEdge('A', 'B');
      graph.AddEdge('B', 'C');
      graph.AddEdge('C', 'D');

      var breadthFirst = new BreadthFirst<char>();

      // Act & Assert
      Assert.True(breadthFirst.Find(graph, 'A'));
    }

    [Fact]
    public void VisitEdgesOfVertex()
    {
      // Arrange
      var graph = new Graph<char>();

      graph.AddVertex('A');
      graph.AddVertex('B');
      graph.AddVertex('C');
      graph.AddVertex('D');

      graph.AddEdge('A', 'B');
      graph.AddEdge('B', 'C');
      graph.AddEdge('C', 'D');

      var breadthFirst = new BreadthFirst<char>();

      // Act & Assert
      Assert.True(breadthFirst.Find(graph, 'B'));
    }

  }
}