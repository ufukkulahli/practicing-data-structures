using System;
using practicing_data_structures.data_structures.lists;
using Xunit;

namespace practicing_data_structures.tests.lists
{
  public class SinglyLinkedListTests
  {
    // Arrange
    SinglyLinkedList<string> singlyLinkedWords = new SinglyLinkedList<string>();

    [Fact]
    public void Test()
    {
      // Act && Assert
      ListIsTrulyEmpty();
      AppendItems();
      PrependItems();
      GetItemsByIndex();
      GetNodesByIndex();
      CheckTheNexts();
      ClearList();
    }

    void ListIsTrulyEmpty()
    {
      Assert.Equal(null, singlyLinkedWords.First);
      Assert.Equal(null, singlyLinkedWords.Last);
      Assert.Equal(0, singlyLinkedWords.Count);
      Assert.True(singlyLinkedWords.IsEmpty());
    }

    void AppendItems()
    {
      singlyLinkedWords.Append("hello");
      singlyLinkedWords.Append("world");

      Assert.Equal("hello", singlyLinkedWords.First);
      Assert.Equal("world", singlyLinkedWords.Last);
      Assert.Equal(2, singlyLinkedWords.Count);
    }

    void PrependItems()
    {
      singlyLinkedWords.Prepend("mars");
      Assert.Equal("mars", singlyLinkedWords.First);
      Assert.Equal("world", singlyLinkedWords.Last);

      singlyLinkedWords.Prepend("venus");
      Assert.Equal("venus", singlyLinkedWords.First);
      Assert.Equal("world", singlyLinkedWords.Last);

      Assert.Equal(4, singlyLinkedWords.Count);
      Assert.False(singlyLinkedWords.IsEmpty());
    }

    void GetItemsByIndex()
    {
      Assert.Throws<IndexOutOfRangeException>(() => singlyLinkedWords.Get(-1));

      var venus = singlyLinkedWords.Get(0);
      Assert.Equal("venus", venus);

      var mars = singlyLinkedWords.Get(1);
      Assert.Equal("mars", mars);

      var hello = singlyLinkedWords.Get(2);
      Assert.Equal("hello", hello);

      var world = singlyLinkedWords.Get(3);
      Assert.Equal("world", world);

      Assert.Throws<IndexOutOfRangeException>(() => singlyLinkedWords.Get(4));
    }

    void GetNodesByIndex()
    {
      var venus = singlyLinkedWords.GetNode(0);
      Assert.Equal("venus", venus.value);

      var mars = singlyLinkedWords.GetNode(1);
      Assert.Equal("mars", mars.value);

      var hello = singlyLinkedWords.GetNode(2);
      Assert.Equal("hello", hello.value);

      var world = singlyLinkedWords.GetNode(3);
      Assert.Equal("world", world.value);
    }

    void CheckTheNexts()
    {
      var venus = singlyLinkedWords.GetNode(0);
      Assert.Equal("mars", venus.Next.value);
      Assert.Equal("hello", venus.Next.Next.value);
      Assert.Equal("world", venus.Next.Next.Next.value);
      Assert.Null(venus.Next.Next.Next.Next);
    }

    void ClearList()
    {
      singlyLinkedWords.Clear();
      Assert.Equal(null, singlyLinkedWords.First);
      Assert.Equal(null, singlyLinkedWords.Last);
      Assert.Equal(0, singlyLinkedWords.Count);
      Assert.True(singlyLinkedWords.IsEmpty());
    }
  }
}
