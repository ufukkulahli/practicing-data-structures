using System;
using Xunit;
using practicing_data_structures.data_structures.lists.doubly;

namespace practicing_data_structures.data_structures.lists
{
  public sealed class DoublyLinkedListTests
  {
    [Fact]
    public void Test()
    {
      var words = new DoublyLinkedList<string>();
      Assert.Throws<NotImplementedException>(() => words.Append("hello"));
      Assert.Equal(0, words.Count);
      Assert.True(words.IsEmpty());
    }
  }
}
