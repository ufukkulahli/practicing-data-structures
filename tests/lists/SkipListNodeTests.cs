using practicing_data_structures.data_structures.lists;
using Xunit;

namespace practicing_data_structures.tests.lists
{
  public class SkipListNodeTests
  {

    [Fact]
    public void IncreaseHeightTest()
    {
      // Arrange
      var node = new SkipListNode<int>(1,1);

      // Act
      node.IncreaseHeight();

      // Assert
      Assert.Equal(2, node.Height);
    }

    [Fact]
    public void DecreaseHeightTest()
    {
            // Arrange
      var node = new SkipListNode<int>(1,5);

      // Act
      node.DecreaseHeight();

      // Assert
      Assert.Equal(4, node.Height);
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

    [Fact]
    public void ResetForwards()
    {
      // Arrange
      var node = new SkipListNode<int>(1,1);
      
      // Pre-Assert
      Assert.NotNull(node.Forwards);

      // Act
      node.Reset();

      // Assert
      Assert.Null(node.Forwards);
    }

    [Fact]
    public void ValidateHeight()
    {
      Assert.Throws<System.IndexOutOfRangeException>( () => new SkipListNode<int>(1,1).Invalid(10) );
    }

    [Fact]
    public void Indexing()
    {
      // Arrange
      var node = new SkipListNode<int>(1,1);

      // Act
      node[0]=new SkipListNode<int>(5,5);
      var first = node[0];

      // Assert
      Assert.Equal(5, first.Value);
      Assert.Equal(5, first.Height);
    }

  }
}