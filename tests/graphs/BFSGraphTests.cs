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
      Assert.Equal(1, bfsGraph.References.First().Key);
      Assert.Equal(2, bfsGraph.References.First().Value.First());

      Assert.Equal(2, bfsGraph.References.Last().Key);
      Assert.Equal(1, bfsGraph.References.Last().Value.First());
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
      Assert.Equal(2, bfsGraph.References.Count());
    }

    [Fact]
    public void ResetDistances()
    {
      // Arrange
      var bfsGraph = new BFSGraph();
      bfsGraph.AddEdge(1, 2);

      // Act
      bfsGraph.ResetDistances();

      // Assert
      Assert.Equal(1, bfsGraph.Distances.First().Key);
      Assert.Equal(-1, bfsGraph.Distances.First().Value);

      Assert.Equal(2, bfsGraph.Distances.Last().Key);
      Assert.Equal(-1, bfsGraph.Distances.Last().Value);
    }

    [Fact]
    public void ResetSourcesDistance()
    {
      // Arrange
      var bfsGraph = new BFSGraph();
      bfsGraph.AddEdge(1, 2);
      bfsGraph.ResetDistances();

      // Act
      bfsGraph.ResetSourcesDistance(2);

      // Assert
      Assert.Equal(1, bfsGraph.Distances.First().Key);
      Assert.Equal(-1, bfsGraph.Distances.First().Value);

      Assert.Equal(2, bfsGraph.Distances.Last().Key);
      Assert.Equal(0, bfsGraph.Distances.Last().Value); // Was reset
    }

    [Fact]
    public void UpdateDistancesAndPaths()
    {
      // Arrange
      var bfsGraph = new BFSGraph();
      bfsGraph.AddEdge(1, 2);
      bfsGraph.ResetDistances();
      bfsGraph.ResetSourcesDistance(2);

      // Act
      bfsGraph.UpdateDistancesAndPaths(2);

      // Assert
      Assert.Equal(1, bfsGraph.Distances.First().Key);
      Assert.Equal(1, bfsGraph.Distances.First().Value); // Updated distance

      Assert.Equal(2, bfsGraph.Distances.Last().Key);
      Assert.Equal(0, bfsGraph.Distances.Last().Value);
    }

  }
}