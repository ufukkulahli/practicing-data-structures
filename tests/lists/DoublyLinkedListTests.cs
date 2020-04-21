using System;
using Xunit;

namespace practicing_data_structures.data_structures.lists
{
  public sealed class DoublyLinkedListTests
  {
    [Fact]
    public void Test()
    {
      var words = new DoublyLinkedList<string>();
      Assert.Throws<NotImplementedException>(() => words.Append("hello"));
    }
  }
}
