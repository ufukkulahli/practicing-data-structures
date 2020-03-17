using System;
using System.Collections.Generic;
using practicing_data_structures.data_structures.lists;
using Xunit;

namespace practicing_data_structures
{
  public class ArrayListTest
  {
    [Fact]
    public void Test()
    {
      // Arrange
      var words = new ArrayList<string>();

      // Act && Assert
      Assert.Equal(0, words.Count());
      Assert.Equal(0, words.Capacity());

      words.Add("hello");
      Assert.Equal(1, words.Count());
      Assert.Equal(1, words.Capacity());
      Assert.Equal("hello", words.First());
      Assert.Equal("hello", words.Last());

      var found = words.Find(w => w == "hello");
      Assert.Equal("hello", found);

      var removed = words.Remove("hello");
      Assert.True(removed);
      Assert.Equal(0, words.Count());
      Assert.Equal(1, words.Capacity());
      Assert.False(words.IsEmpty());

      words.Clear();
      Assert.Equal(0, words.Count());
      Assert.Equal(0, words.Capacity());
      Assert.True(words.IsEmpty());
    }
  }
}