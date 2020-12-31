using System;
using Xunit;
using practicing_data_structures.data_structures.lists;

namespace practicing_data_structures.tests.lists
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
      Assert.Equal("hello", words.Top);

      words.Enqueue("world");
      Assert.Equal(2, words.Count);
      Assert.Equal("hello", words.Top);

      words.Enqueue("home");
      Assert.Equal(3, words.Count);
      Assert.Equal("hello", words.Top);

      words.Enqueue("earth");
      Assert.Equal(4, words.Count);
      Assert.Equal("hello", words.Top);

      words.Enqueue("moon");
      Assert.Equal(5, words.Count);
      Assert.Equal("hello", words.Top);

      Assert.Equal("hello", words.Dequeue());
      Assert.Equal("world", words.Dequeue());
      Assert.Equal("home", words.Dequeue());
      Assert.Equal("earth", words.Dequeue());
      Assert.Equal("moon", words.Dequeue());
      Assert.Equal(0, words.Count);
      Assert.True(words.IsEmpty);
    }
  }
}
