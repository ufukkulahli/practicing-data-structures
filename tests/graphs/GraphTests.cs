using System;
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
      Assert.Equal(0, graph.GetVertex("hello").EdgesCount);
    }

    [Fact]
    public void RemovingNullVertexCausesException()
    {
      // ARRANGE & ACT & ASSERT
      Assert.Throws<System.ArgumentNullException>(() => new Graph<string>().RemoveVertex(null));
    }

    [Fact]
    public void RemovingAbsentVertexCausesException()
    {
      // ARRANGE & ACT & ASSERT
      Assert.Throws<System.Exception>(() => new Graph<string>().RemoveVertex("hello"));
    }

    [Fact]
    public void RemoveVertexTest()
    {
      // ARRANGE
      var graph = new Graph<string>();

      // ACT
      graph.AddVertex("hello");
      graph.RemoveVertex("hello");

      // ASSERT
      Assert.False(graph.ContainsVertex("hello"));
      Assert.Equal(0, graph.VerticesCount);
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
      Assert.Equal(1, graph.VerticesCount);
      Assert.Equal(0, graph.GetVertex("hello").EdgesCount);
    }

    [Fact]
    public void GetVertexTest()
    {
      // ARRANGE
      var graph = new Graph<string>();
      graph.AddVertex("hello");

      // ACT
      var vertex = graph.GetVertex("hello");

      // ASSERT
      Assert.Equal("hello", vertex.Value);
      Assert.Equal(1, graph.VerticesCount);
      Assert.Equal(0, vertex.EdgesCount);
    }

    [Fact]
    public void AddingNullEdgeCausesException()
    {
      Assert.Throws<ArgumentNullException>( () => new Graph<string>().AddEdge(null, "jupiter") );
      Assert.Throws<ArgumentNullException>( () => new Graph<string>().AddEdge("planets", null) );
    }

    [Fact]
    public void AddingEdgeToNonExistingVerticesCausesException()
    {
      Assert.Throws<Exception>( () => new Graph<string>().AddEdge("planets", "jupiter") );
    }

    [Fact]
    public void AlreadyAddedEdgesCausesException()
    {
      // ARRANGE
      var graph = new Graph<string>();
      graph.AddVertex("planets");
      graph.AddVertex("stars");

      // ACT
      graph.AddEdge("planets", "stars");

      // ASSERT
      Assert.Equal(2, graph.VerticesCount);
      Assert.Throws<Exception>( () => graph.AddEdge("planets", "stars"));
      Assert.Throws<Exception>( () => graph.AddEdge("stars", "planets"));
    }

    [Fact]
    public void AddingEdge()
    {
      // ARRANGE
      var graph = new Graph<string>();
      graph.AddVertex("planets");
      graph.AddVertex("stars");

      // ACT
      graph.AddEdge("planets", "stars");

      // ASSERT
      Assert.Equal(2, graph.VerticesCount);
    }

  }
}