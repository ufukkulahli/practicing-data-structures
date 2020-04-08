using practicing_data_structures.data_structures.lists;
using Xunit;

namespace practicing_data_structures.tests.lists
{
  public class SinglyLinkedListTests
  {
    [Fact]
    public void Test()
    {
      // TODO: Continue implementing.

      // Arrange
      var singlyLinkedWords = new SinglyLinkedList<string>();

      // Act && Assert

      // Ensure list is empty
      Assert.Equal(null, singlyLinkedWords.First);
      Assert.Equal(null, singlyLinkedWords.Last);
      Assert.Equal(0, singlyLinkedWords.Count);
      Assert.True(singlyLinkedWords.IsEmpty());

      // Append
      singlyLinkedWords.Append("hello");
      singlyLinkedWords.Append("world");

      Assert.Equal("hello", singlyLinkedWords.First);
      Assert.Equal("world", singlyLinkedWords.Last);
      Assert.Equal(2, singlyLinkedWords.Count);

      // Prepend
      singlyLinkedWords.Prepend("mars");
      Assert.Equal("mars", singlyLinkedWords.First);
      Assert.Equal("world", singlyLinkedWords.Last);

      singlyLinkedWords.Prepend("venus");
      Assert.Equal("venus", singlyLinkedWords.First);
      Assert.Equal("world", singlyLinkedWords.Last);

      Assert.Equal(4, singlyLinkedWords.Count);
      Assert.False(singlyLinkedWords.IsEmpty());
    }
  }
}
