using System;
using Xunit;
using practicing_data_structures.data_structures.lists.doubly;

namespace practicing_data_structures.data_structures.lists
{
  public sealed class DoublyLinkedListTests
  {
    DoublyLinkedList<string> planets;

    [Fact]
    public void Test()
    {
      // Arrange
      planets = new DoublyLinkedList<string>();

      // Assert
      BeSureListIsClean();

      // Act
      planets.Append("World");
      planets.Append("Mars");
      planets.Append("Venus");

      // Assert
      AssertFirstThreePlanets();

      planets.Prepend("Jupiter");
      planets.Prepend("Neptune");

      // Assert
      AssertNewlyAddedPlanets();

      // Act
      planets.Clear();

      // Assert
      BeSureListIsClean();
    }

    void AssertFirstThreePlanets()
    {
      // Head Node: 'world'
      Assert.Null(planets.HeadNode.Previous);
      Assert.Equal("World", planets.HeadNode.Value);
      Assert.Equal("Mars", planets.HeadNode.Next.Value);

      // Next Node: 'mars'
      var mars = planets.HeadNode.Next;
      Assert.Equal("World", mars.Previous.Value);
      Assert.Equal("Venus", mars.Next.Value);

      // Next Node: 'Venus'
      var venus = mars.Next;
      Assert.Equal("Mars", venus.Previous.Value);
      Assert.Null(venus.Next);

      Assert.Equal(3, planets.Count);
      Assert.False(planets.IsEmpty());
      Assert.Equal("World", planets.First);
      Assert.Equal("Venus", planets.Last);
    }

    void AssertNewlyAddedPlanets()
    {
      // New Head Node: 'Neptune'
      var neptune = planets.HeadNode;
      Assert.Null(neptune.Previous);
      Assert.Equal("Neptune", neptune.Value);
      Assert.Equal("Jupiter", neptune.Next.Value);

      // Next Node: 'Jupiter'
      var jupiter = neptune.Next;
      Assert.Equal("Neptune", jupiter.Previous.Value);
      Assert.Equal("World", jupiter.Next.Value);

      // Next Node: 'World'
      var world = jupiter.Next;
      Assert.Equal("Jupiter", world.Previous.Value);
      Assert.Equal("Mars", world.Next.Value);

      Assert.Equal(5, planets.Count);
      Assert.False(planets.IsEmpty());
      Assert.Equal("Neptune", planets.First);
      Assert.Equal("Venus", planets.Last);
    }

    void BeSureListIsClean()
    {
      Assert.Equal(0, planets.Count);
      Assert.True(planets.IsEmpty());
      Assert.Null(planets.HeadNode);
      Assert.Null(planets.TailNode);
      Assert.Throws<Exception>(() => planets.First);
      Assert.Throws<Exception>(() => planets.Last);
    }
  }
}