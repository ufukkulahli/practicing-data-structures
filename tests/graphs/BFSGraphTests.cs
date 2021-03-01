using System.Collections.Generic;
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
    public void AddEdgeTest2()
    {
      // Arrange
      var bfsGraph = new BFSGraph();
      bfsGraph.AddEdge(1, 2);
      bfsGraph.AddEdge(1, 3);
      bfsGraph.AddEdge(1, 4);
      bfsGraph.AddEdge(4, 5);
      bfsGraph.AddEdge(2, 6);
      bfsGraph.AddEdge(4, 7);
      bfsGraph.AddEdge(5, 6);
      bfsGraph.AddEdge(6, 7);

      // Act & Assert
      var references = bfsGraph.References.ToList();
      Assert.Equal(1, references[0].Key);
      Assert.Equal(2, references[0].Value.First());
      // TODO: ASSERT REMAINING
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
    public void VisitAllNodes()
    {
      // Arrange
      var bfsGraph = new BFSGraph();
      bfsGraph.AddEdge(1, 2);
      bfsGraph.ResetDistances();
      bfsGraph.ResetSourcesDistance(2);

      // Act
      bfsGraph.VisitAllNodes(2);

      // Assert
      Assert.Equal(2, bfsGraph.Distances.Count);

      Assert.Equal(1, bfsGraph.Distances.First().Key);
      Assert.Equal(1, bfsGraph.Distances.First().Value);

      Assert.Equal(2, bfsGraph.Distances.Last().Key);
      Assert.Equal(0, bfsGraph.Distances.Last().Value);

      // Paths
      Assert.Equal(1, bfsGraph.Paths.Count);

      Assert.Equal(1, bfsGraph.Paths.Last().Key);
      Assert.Equal(2, bfsGraph.Paths.Last().Value);
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

      // Paths
      Assert.Equal(1, bfsGraph.Paths.Last().Key);
      Assert.Equal(2, bfsGraph.Paths.Last().Value);
    }

    [Fact]
    public void BuildPath()
    {
      // Arrange
      var bfsGraph = new BFSGraph();
      bfsGraph.AddEdge(1, 2);

      bfsGraph.ResetDistances();
      bfsGraph.ResetSourcesDistance(1);
      bfsGraph.VisitAllNodes(1);

      // Act
      var paths = bfsGraph.BuildPath(1,2);

      // Assert
      Assert.Equal(2, paths.Count);

      Assert.Equal(1, paths.First());
      Assert.Equal(2, paths.Last());
    }

    [Fact]
    public void ShortestPath()
    {
      // Arrange
      var bfsGraph = new BFSGraph();
      bfsGraph.AddEdge(1, 2);

      // Act & Assert
      var paths = bfsGraph.ShortestPath(1,2);

      // Assert
      Assert.Equal(2, paths.Count);

      Assert.Equal(1, paths.First());
      Assert.Equal(2, paths.Last());
    }

    [Fact]
    public void ShortestPath2()
    {
      // Arrange
      var bfsGraph = new BFSGraph();
      bfsGraph.AddEdge(1, 2);
      bfsGraph.AddEdge(1, 3);
      bfsGraph.AddEdge(1, 4);
      bfsGraph.AddEdge(4, 5);
      bfsGraph.AddEdge(2, 6);
      bfsGraph.AddEdge(4, 7);
      bfsGraph.AddEdge(5, 6);
      bfsGraph.AddEdge(6, 7);

      // Act & Assert
      Assert.Throws<KeyNotFoundException>( () => bfsGraph.ShortestPath(1,7) );
    }

  }
}