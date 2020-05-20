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

      // Append
      planets.Append("World");
      Assert.Equal(1, planets.Count);

      // GetElementAt (from head)
      Assert.Equal("World", planets.GetElementAt(0));
      Assert.Throws<IndexOutOfRangeException>( () => planets.GetElementAt(999) );
      Assert.Throws<NotImplementedException>( () => planets.GetElementAt(1) );

      // RemoveAt, throws exception
      Assert.Throws<IndexOutOfRangeException>(() => planets.RemoveAt(-1));
      Assert.Throws<IndexOutOfRangeException>(() => planets.RemoveAt(2));

      // Remove, no exception
      planets.Remove("World");
      Assert.Equal(0, planets.Count);

      // RemoveAt (from head)
      planets.Append("World");
      planets.RemoveAt(0);
      Assert.Equal(0, planets.Count);

      // Append
      planets.Append("World");
      Assert.Equal(1, planets.Count);

      // RemoveAt (from tail)
      planets.Append("Mars");
      planets.RemoveAt(1);
      Assert.Equal(1, planets.Count);

      // Append
      planets.Append("Mars");
      planets.Append("Venus");
      AssertGivenPlanetsInOrder(new string[3]{"World", "Mars", "Venus"});
      AssertFirstThreePlanets();

      // GetElementAt (from tail)
      Assert.Equal("Venus", planets.GetElementAt(2));

      // Prepend
      planets.Prepend("Jupiter");
      planets.Prepend("Neptune");
      AssertGivenPlanetsInOrder(new string[5]{"Neptune", "Jupiter", "World", "Mars", "Venus"});
      AssertNewlyAddedPlanets();

      // GetElementAt (from middle)
      Assert.Equal("Jupiter", planets.GetElementAt(1));

      // FindNode ( O(n) )
      var mars = planets.FindNode("Mars");
      Assert.Equal("World", mars.Previous.Value);
      Assert.Equal("Venus", mars.Next.Value);

      // FindNode, throws exception
      Assert.Throws<Exception>( () => planets.FindNode("Pluto") );

      AssertInsertAtFunctionality();

      AssertRemoveFunctionality();

      // RemoveAt (from middle)
      planets.RemoveAt(2);
      Assert.Equal(4, planets.Count);
      AssertGivenPlanetsInOrder(new string[4]{"Neptune", "Jupiter", "Mars",  "Pluto"});

      // Clear
      planets.Clear();
      BeSureListIsClean();
    }

    void AssertInsertAtFunctionality()
    {
      // InsertAt (at head)
      planets.InsertAt(0, "Saturn");
      AssertGivenPlanetsInOrder(new string[6]{"Saturn", "Neptune", "Jupiter", "World", "Mars", "Venus"});
      Assert.Equal(6, planets.Count);

      // InsertAt (at middle)
      planets.InsertAt(3, "Mercury");
      AssertGivenPlanetsInOrder(new string[7]{"Saturn", "Neptune", "Jupiter", "Mercury", "World", "Mars", "Venus"});
      Assert.Equal(7, planets.Count);

      // InsertAt(at tail???)
      // TODO: Check
      planets.InsertAt(6, "Pluto");
      AssertGivenPlanetsInOrder(new string[8]{"Saturn", "Neptune", "Jupiter", "Mercury", "World", "Mars",  "Pluto", "Venus"});
      Assert.Equal(8, planets.Count);

      // Act && Assert
      Assert.Throws<IndexOutOfRangeException>( () => planets.InsertAt(-1, "Mercury") );
      Assert.Throws<IndexOutOfRangeException>( () => planets.InsertAt(99, "Mercury") );
    }

    void AssertRemoveFunctionality()
    {
      // Remove (from head)
      planets.Remove("Saturn");
      AssertGivenPlanetsInOrder(new string[7]{"Neptune", "Jupiter", "Mercury", "World", "Mars",  "Pluto", "Venus"});
      Assert.Equal(7, planets.Count);

      // Remove (from tail)
      planets.Remove("Venus");
      AssertGivenPlanetsInOrder(new string[6]{"Neptune", "Jupiter", "Mercury", "World", "Mars",  "Pluto"});
      Assert.Equal(6, planets.Count);

      // Remove (from middle)
      planets.Remove("World");
      AssertGivenPlanetsInOrder(new string[5]{"Neptune", "Jupiter", "Mercury", "Mars",  "Pluto"});
      Assert.Equal(5, planets.Count);
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
      Assert.Equal(planetNames.Length, planets.Count);
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
      Assert.Throws<Exception>(() => planets.RemoveAt(0));
      Assert.Throws<Exception>(() => planets.GetElementAt(999));
      Assert.Throws<Exception>(() => planets.First);
      Assert.Throws<Exception>(() => planets.Last);
      Assert.Throws<Exception>(() => planets.Remove("Neptune"));
    }
  }
}