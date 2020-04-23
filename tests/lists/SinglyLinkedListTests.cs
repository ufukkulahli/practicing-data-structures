using System;
using System.Collections;
using practicing_data_structures.data_structures.lists.singly;
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
      IterateList();
      IterateViaIEnumerableInterface();
      InsertItemAtIndex();
      DeleteItem();
      ClearList();
    }

    void ListIsTrulyEmpty()
    {
      Assert.Null(singlyLinkedWords.First);
      Assert.Null(singlyLinkedWords.Last);
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
      Assert.Equal("venus", venus.value);
      Assert.Equal("mars", venus.Next.value);
      Assert.Equal("hello", venus.Next.Next.value);
      Assert.Equal("world", venus.Next.Next.Next.value);
      Assert.Null(venus.Next.Next.Next.Next);
    }

    void IterateList()
    {
      var enumerator = singlyLinkedWords.GetEnumerator();

      Assert.Equal("venus", enumerator.Current);
      Assert.True(enumerator.MoveNext());

      Assert.Equal("mars", enumerator.Current);
      Assert.True(enumerator.MoveNext());

      Assert.Equal("hello", enumerator.Current);
      Assert.True(enumerator.MoveNext());

      Assert.Equal("world", enumerator.Current);
      Assert.False(enumerator.MoveNext());
    }

    void IterateViaIEnumerableInterface()
    {
      var names = new SinglyLinkedList<string>();
      names.Append("hello");
      names.Append("world");

      // To obtain 'System.Collections.IEnumerator' instance;
      // call, System.Collections.IEnumerable.GetEnumerator() after casting 'SinglyLinkedList'.
      var namesEnumerator = ((IEnumerable)names).GetEnumerator();

      Assert.Equal("hello", namesEnumerator.Current);
      Assert.True(namesEnumerator.MoveNext());

      Assert.Equal("world", namesEnumerator.Current);
      Assert.False(namesEnumerator.MoveNext());
    }

    void InsertItemAtIndex()
    {
      singlyLinkedWords.InsertAt("jupiter", 0);
      var jupiter = singlyLinkedWords.GetNode(0);
      Assert.Equal("jupiter", singlyLinkedWords.First);
      Assert.Equal("jupiter", jupiter.value);
      Assert.Equal("venus", jupiter.Next.value);
      Assert.Equal("mars", jupiter.Next.Next.value);
      Assert.Equal("hello", jupiter.Next.Next.Next.value);
      Assert.Equal("world", jupiter.Next.Next.Next.Next.value);
      Assert.Null(jupiter.Next.Next.Next.Next.Next);
      Assert.Equal("world", singlyLinkedWords.Last);
    }

    void DeleteItem()
    {
      singlyLinkedWords.DeleteItem("hello");
      var jupiter = singlyLinkedWords.GetNode(0);
      Assert.Equal("jupiter", jupiter.value);
      Assert.Equal("venus", jupiter.Next.value);
      Assert.Equal("mars", jupiter.Next.Next.value);
      Assert.Equal("world", jupiter.Next.Next.Next.value);
      Assert.Null(jupiter.Next.Next.Next.Next);
      Assert.Equal("world", singlyLinkedWords.Last);
    }

    void ClearList()
    {
      singlyLinkedWords.Clear();
      Assert.Null(singlyLinkedWords.First);
      Assert.Null(singlyLinkedWords.Last);
      Assert.Equal(0, singlyLinkedWords.Count);
      Assert.True(singlyLinkedWords.IsEmpty());
    }
  }
}
