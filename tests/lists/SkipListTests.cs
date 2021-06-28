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
    public void HeightReturnsDefaultHeight_WhichIsOne()
    {
      Assert.Equal(1, new SkipList<int>().Height);
    }

    [Fact]
    public void DefaultCountIsZero()
    {
      Assert.Equal(0, new SkipList<int>().Count);
    }

  }
}