using System;
using System.Collections.Generic;
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

      // Act && Assert
      // Order is: World, Mars, Venus
      planets.Append("World");
      planets.Append("Mars");
      planets.Append("Venus");
      AssertGivenPlanetsInOrder(new string[3]{"World", "Mars", "Venus"});
      AssertFirstThreePlanets();

      // Act & Assert
      // Order is: Neptune, Jupiter, World, Mars, Venus
      planets.Prepend("Jupiter");
      planets.Prepend("Neptune");
      AssertGivenPlanetsInOrder(new string[5]{"Neptune", "Jupiter", "World", "Mars", "Venus"});
      AssertNewlyAddedPlanets();

      // Act && Assert
      var mars = planets.FindNode("Mars");
      Assert.Equal("World", mars.Previous.Value);
      Assert.Equal("Venus", mars.Next.Value);
      Assert.Throws<Exception>( () => planets.FindNode("Pluto") );

      // Act && Assert
      // Order is: Neptune, Jupiter, Saturn, World, Mars, Venus
      planets.InsertAt(3, "Saturn");
      Assert.Equal(6, planets.Count);

      // Act && Assert
      planets.Clear();
      BeSureListIsClean();
    }

    void AssertGivenPlanetsInOrder(string[] planetNames)
    {
      var currentPlanet = planets.HeadNode;
      var indexOfPlanet = 0;

      while(currentPlanet != null)
      {
        var actualPreviousPlanet = GetPlanetNameOrNothing(indexOfPlanet-1, planetNames);
        var actualCurrentPlanet  = GetPlanetNameOrNothing(indexOfPlanet, planetNames);
        var actualNextPlanet     = GetPlanetNameOrNothing(indexOfPlanet+1, planetNames);

        Assert.Equal(actualPreviousPlanet , currentPlanet.Previous?.Value);
        Assert.Equal(actualCurrentPlanet  , currentPlanet.Value);
        Assert.Equal(actualNextPlanet     , currentPlanet?.Next?.Value);

        currentPlanet = currentPlanet.Next;
        indexOfPlanet++;
      }
    }

    string GetPlanetNameOrNothing(int index, string[] planetNames)
    {
      if (index < 0 || index >= planetNames.Length)
      {
        return null;
      }
      return planetNames[index];
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