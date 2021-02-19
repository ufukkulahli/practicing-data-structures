using System.Linq;
using practicing_data_structures.data_structures.graphs;
using Xunit;

namespace practicing_data_structures.tests.graphs
{
  public class BFSGraphTests
  {
    [Fact]
    public void AddEdgeTest()
    {
      // Arrange
      var bfsGraph = new BFSGraph();

      // Act
      bfsGraph.AddEdge(1, 2);

      // Assert
      Assert.Equal(1, bfsGraph.references.First().Key);
      Assert.Equal(2, bfsGraph.references.First().Value.First());

      Assert.Equal(2, bfsGraph.references.Last().Key);
      Assert.Equal(1, bfsGraph.references.Last().Value.First());
    }

    [Fact]
    public void AddingExistingEdgesDoNothing()
    {
      // Arrange
      var bfsGraph = new BFSGraph();

      // Act
      bfsGraph.AddEdge(1, 2);
      bfsGraph.AddEdge(1, 2);

      // Assert
      Assert.Equal(2, bfsGraph.references.Count());
    }

  }
}