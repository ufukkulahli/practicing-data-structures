using System;
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

      // Act && Assert
      Assert.True(words.IsEmpty);
      Assert.Equal(0, words.Count);
      words.Enqueue("hello");
      Assert.Equal(1, words.Count);
      words.Enqueue("world");
      Assert.Equal(2, words.Count);
      Assert.Equal("world", words.Top);
      // TODO: Make work.
      //Assert.Equal("hello", words.Dequeue());
      //Assert.Equal("world", words.Dequeue());
    }
  }
}
