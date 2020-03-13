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

      var removed = words.Remove("hello");
      Assert.False(removed);
      Assert.Equal(1, words.Count());
      Assert.Equal(1, words.Capacity());
    }
  }
}