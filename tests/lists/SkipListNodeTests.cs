using practicing_data_structures.data_structures.lists;
using Xunit;

namespace practicing_data_structures.tests.lists
{
  public class SkipListNodeTests
  {

    [Fact]
    public void IncreaseHeightTest()
    {
      Assert.Throws<System.NotImplementedException>( () => new SkipListNode<int>().IncreaseHeight() );
    }

    [Fact]
    public void DecreaseHeightTest()
    {
      Assert.Throws<System.NotImplementedException>( () => new SkipListNode<int>().DecreaseHeight() );
    }

    [Fact]
    public void HeightReturnsZero()
    {
      Assert.Equal(0, new SkipListNode<int>().Height);
    }

    [Fact]
    public void InvalidHeightCausesException()
    {
      Assert.Throws<System.ArgumentException>( () => new SkipListNode<string>("hello", 0) );
    }

  }
}