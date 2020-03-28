using Xunit;
using practicing_data_structures.data_structures.lists;

namespace practicing_data_structures.tests
{
    public class QueueTests
  {
    [Fact]
    public void Test()
    {
      // Arrange
      var words = new Queue<string>();

      // Act
      Assert.True(words.IsEmpty);
      words.Enqueue("hello");
      words.Enqueue("world");
      
      // Assert
      Assert.Equal(2, words.Count);
    }
  }
}
