using System;
using System.Linq;
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
      graph.AddVertex("planets");
      graph.AddVertex("world");
      graph.AddEdge("planets", "world");

      graph.RemoveVertex("planets");
      graph.RemoveVertex("world");

      // ASSERT
      Assert.False(graph.ContainsVertex("planets"));
      Assert.False(graph.ContainsVertex("world"));
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

    [Fact]
    public void VerticesHasNoEdges()
    {
     // ARRANGE
      var graph = new Graph<string>();
      graph.AddVertex("planets");
      graph.AddVertex("stars");

      // ACT
      var hasEdge = graph.HasEdge("planets", "stars");

      // ASSERT
      Assert.False(hasEdge); 
    }

    [Fact]
    public void VerticesHasEdges()
    {
     // ARRANGE
      var graph = new Graph<string>();
      graph.AddVertex("planets");
      graph.AddVertex("stars");
      graph.AddEdge("planets", "stars");

      // ACT
      var hasEdge = graph.HasEdge("planets", "stars");

      // ASSERT
      Assert.True(hasEdge); 
    }

    [Fact]
    public void RemovingNullEdgesCausesException()
    {
      // ARRANGE & ACT & ASSERT
      Assert.Throws<System.ArgumentNullException>(() => new Graph<string>().RemoveEdge(null, ""));
      Assert.Throws<System.ArgumentNullException>(() => new Graph<string>().RemoveEdge("", null));
    }

    [Fact]
    public void RemovingNonExistingVertexCausesException()
    {
      // ARRANGE
      var graph = new Graph<string>();
      graph.AddVertex("planets");

      // Act & ASSERT
      Assert.Throws<Exception>( () => graph.RemoveEdge("planets", "jupiter") );
    }

    [Fact]
    public void RemovingNonExistingVertexCausesException2()
    {
      // ARRANGE
      var graph = new Graph<string>();
      graph.AddVertex("jupiter");

      // Act & ASSERT
      Assert.Throws<Exception>( () => graph.RemoveEdge("planets", "jupiter") );
    }

    [Fact]
    public void RemovingNonExistingEdgesCausesException()
    {
     // ARRANGE
      var graph = new Graph<string>();
      graph.AddVertex("planets");
      graph.AddVertex("stars");

      // ACT & ASSERT
      Assert.Throws<Exception>( () => graph.RemoveEdge("non_existing_edge", "stars") ); 
      Assert.Throws<Exception>( () => graph.RemoveEdge("planets", "non_existing_edge") ); 
    }

    [Fact]
    public void RemoveEdges()
    {
     // ARRANGE
      var graph = new Graph<string>();
      graph.AddVertex("planets");
      graph.AddVertex("stars");
      graph.AddEdge("planets", "stars");

      // ACT
      graph.RemoveEdge("planets", "stars");

      // ASSERT
      Assert.False(graph.HasEdge("planets", "stars")); 
      Assert.True(graph.ContainsVertex("planets")); 
      Assert.True(graph.ContainsVertex("stars")); 
    }

    [Fact]
    public void GettingEdgesOfAbsentVertexCausesException()
    {
      // ARRANGE & ACT & ASSERT
      Assert.Throws<System.Exception>(() => new Graph<string>().Edges("planets"));
    }

    [Fact]
    public void EdgeList()
    {
     // ARRANGE
      var graph = new Graph<string>();
      graph.AddVertex("planets");
      graph.AddVertex("stars");
      graph.AddEdge("planets", "stars");

      // ACT
      var edges = graph.Edges("planets");

      // ASSERT
      Assert.Equal("stars" ,edges.Single());
    }

    [Fact]
    public void ObtainNextVertex()
    {
      // Arrange
      var graph = new Graph<char>();

      graph.AddVertex('A');
      graph.AddVertex('B');

      // Act & Assert
      Assert.Equal('A', graph.FirstVertexOrNull.Value);
    }

    [Fact]
    public void NextVertexIsNull()
    {
      // Arrange
      var graph = new Graph<char>();

      // Act
      Assert.Null(graph.FirstVertexOrNull);
    }

  }
}