using System;
using Xunit;
using practicing_data_structures.data_structures.lists.doubly;

namespace practicing_data_structures.data_structures.lists
{
  public sealed class DoublyLinkedListTests
  {
    DoublyLinkedList<string> words;

    [Fact]
    public void Test()
    {
      // Arrange
      words = new DoublyLinkedList<string>();

      // Assert
      BeSureListIsClean();

      // Act
      words.Append("world");
      words.Append("mars");
      words.Append("venus");

      // Assert
      AssertFirstThreeWords();

      // Act
      words.Clear();

      // Assert
      BeSureListIsClean();
    }

    void AssertFirstThreeWords()
    {
      // Head Node: 'world'
      Assert.Null(words.HeadNode.Previous);
      Assert.Equal("world", words.HeadNode.Value);
      Assert.Equal("mars", words.HeadNode.Next.Value);

      // Next Node: 'mars'
      var mars = words.HeadNode.Next;
      Assert.Equal("world", mars.Previous.Value);
      Assert.Equal("venus", mars.Next.Value);

      // Next Node: 'venus'
      var venus = mars.Next;
      Assert.Equal("mars", venus.Previous.Value);
      Assert.Null(venus.Next);

      Assert.Equal(3, words.Count);
      Assert.False(words.IsEmpty());
      Assert.Equal("world", words.First);
      Assert.Equal("venus", words.Last);
    }

    void BeSureListIsClean()
    {
      Assert.Equal(0, words.Count);
      Assert.True(words.IsEmpty());
      Assert.Null(words.HeadNode);
      Assert.Null(words.TailNode);
      Assert.Throws<Exception>(() => words.First);
      Assert.Throws<Exception>(() => words.Last);
    }
  }
}