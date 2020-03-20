using practicing_data_structures.data_structures.lists;
using Xunit;

namespace practicing_data_structures.tests
{
  public class StackTests
  {
    [Fact]
    public void Test()
    {
      // Arrange
      var words = new Stack<string>();

      // Act && Assert
      words.Push("hello");
      Assert.Equal(1, words.Count);
    }
  }
}