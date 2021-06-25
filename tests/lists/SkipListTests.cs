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
    public void HeightReturnsZero()
    {
      Assert.Equal(0, new SkipList<int>().Height);
    }

  }
}