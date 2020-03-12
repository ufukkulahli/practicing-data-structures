using System;
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
      var al = new ArrayList<string>();

      // Act
      var count = al.Count();
      Assert.Equal(0, count);


      // Assert
    }
  }
}