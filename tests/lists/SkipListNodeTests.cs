using practicing_data_structures.data_structures.lists;
using Xunit;

namespace practicing_data_structures.tests.lists
{
  public class SkipListNodeTests
  {

    [Fact]
    public void IncreaseHeightTest()
    {
      Assert.Throws<System.NotImplementedException>( () => new SkipListNode<int>(10,10).IncreaseHeight() );
    }

    [Fact]
    public void DecreaseHeightTest()
    {
      Assert.Throws<System.NotImplementedException>( () => new SkipListNode<int>(10,10).DecreaseHeight() );
    }

    [Fact]
    public void HeightReturnsGivenHeight()
    {
      Assert.Equal(10, new SkipListNode<int>(10,10).Height);
    }

    [Fact]
    public void InvalidHeightCausesException()
    {
      Assert.Throws<System.ArgumentException>( () => new SkipListNode<string>("hello", 0) );
    }

  }
}