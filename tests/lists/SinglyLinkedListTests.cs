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

      // Act
      singlyLinkedWords.Append("hello");

      // Assert
      Assert.Equal(1, singlyLinkedWords.Count);
    }
  }
}