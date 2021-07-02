using practicing_data_structures.data_structures.lists;
using Xunit;

namespace practicing_data_structures.tests.lists
{
  public class SkipListTests
  {
    [Fact]
    public void AddTest()
    {
      Assert.Throws<System.NotImplementedException>( () => new SkipList<int>().Add(1) );
    }

    [Fact]
    public void RemoveTest()
    {
      Assert.Throws<System.NotImplementedException>( () => new SkipList<int>().Remove(1) );
    }

    [Fact]
    public void ContainsTest()
    {
      Assert.Throws<System.NotImplementedException>( () => new SkipList<int>().Contains(1) );
    }

    [Fact]
    public void HeightReturnsDefaultHeight_WhichIsOne()
    {
      Assert.Equal(1, new SkipList<int>().Height);
    }

    [Fact]
    public void DefaultCountIsZero()
    {
      Assert.Equal(0, new SkipList<int>().Count);
    }

    [Fact]
    public void ResetSkipList()
    {
      // Arrange
      var list = new SkipList<int>();

      // Act
      list.Reset();

      // Assert
      Assert.Equal(0, list.Count);
      Assert.Equal(1, list.Head.Height);
      Assert.Equal(0, list.Head.Value);
    }

  }
}