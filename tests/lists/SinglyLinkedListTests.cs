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
      Assert.Equal(null, singlyLinkedWords.First);
      Assert.Equal(null, singlyLinkedWords.Last);
      Assert.Equal(0, singlyLinkedWords.Count);

      singlyLinkedWords.Append("hello");
      singlyLinkedWords.Append("world");

      // Assert
      Assert.Equal("hello", singlyLinkedWords.First);
      Assert.Equal("world", singlyLinkedWords.Last);
      Assert.Equal(2, singlyLinkedWords.Count);
    }
  }
}
