using System.Collections;
using System.Linq;
using Xunit;
using practicing_data_structures.data_structures.lists;

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

      //
      words.Push("hello");
      words.Push("world");
      Assert.Equal(2, words.Count);

      //
      Assert.Equal("world", words.First());
      Assert.Equal("hello", words.Last());

      //
      Assert.Equal("world", words.Top);
      Assert.Equal(2, words.Count);

      //
      Assert.Equal("world", words.Pop());
      Assert.Equal(1, words.Count);

      //
      Assert.False(words.IsEmpty);

      //
      Assert.True(words is IEnumerable);
    }
  }
}
