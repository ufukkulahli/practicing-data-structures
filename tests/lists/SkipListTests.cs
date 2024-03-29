using practicing_data_structures.data_structures.lists;
using Xunit;

namespace practicing_data_structures.tests.lists
{
  public class SkipListTests
  {
    [Fact]
    public void AddTest()
    {
      // Arrange
      var list = new SkipList<int>();

      // Act
      list.Add(99);

      // Assert
      Assert.Equal(1, list.Count);
    }

    [Fact]
    public void NodesToBeUpdated()
    {
      // Arrange
      var list = new SkipList<int>();

      // Act
      var nodes = list.NodesToBeUpdated(5);

      // Assert
      Assert.Equal(1, nodes.Length);
      Assert.Equal(1, nodes[0].Height);
      Assert.Equal(0, nodes[0].Value);
    }

    [Fact]
    public void ThrowsIfInsertsDuplicate()
    {
      // Arrange
      var node = new SkipListNode<int>(1, 1);
      node.Forwards = new SkipListNode<int>[1] { new SkipListNode<int>(1,1) };
      var nodes = new SkipListNode<int>[1]{ node };
      var valueToBeAdded = 1;
      var list = new SkipList<int>();

      // Act && Assert
      Assert.Throws<System.ArgumentException>( () => list.ThrowIfTryToInsertDuplicate(valueToBeAdded, nodes) );
    }

    [Fact]
    public void GenerateHeightOfNewNodeAlwaysGreaterThanZero()
    {
      // Arrange
      var list = new SkipList<int>();

      // Act
      var height = list.GenerateHeightOfNewNode();

      // Assert
      Assert.NotEqual(0, height);
    }

    [Fact]
    public void CompareAndHandleTheCurrentHeightToTheHeadHeight()
    {
      // Arrange
      var list = new SkipList<int>();
      var node = new SkipListNode<int>(5,1);
      var height = 10;

      // Act
      list.HandleHeadHeightAndSetNewNode(height, node);

      // Assert
      Assert.Equal(2, list.Head.Height);
      Assert.Equal(5, list.Head[1].Value);
    }

    [Fact]
    public void Add()
    {
      // Arrange
      var node1 = new SkipListNode<int>(2,2);
      var node2 = new SkipListNode<int>(3,3);

      var nodesToBeUpdated   = new SkipListNode<int>[1];
      nodesToBeUpdated[0]    = node1;
      nodesToBeUpdated[0][0] = node2;

      var list = new SkipList<int>();
      var newNode = new SkipListNode<int>(1,1);

      // Act
      list.AddTheNewNode(newNode, nodesToBeUpdated);

      // Assert
      Assert.Equal(3, newNode[0].Value);
      Assert.Equal(3, newNode[0].Height);

      Assert.Equal(1, nodesToBeUpdated[0][0].Value);
      Assert.Equal(1, nodesToBeUpdated[0][0].Height);
    }

    [Fact]
    public void RemoveTest()
    {
      // Arrange
      var list = new SkipList<int>();
      list.Add(1);

      // Act
      var removed = list.Remove(1);

      // Assert
      Assert.True(removed);
      Assert.Equal(1, list.Height);
    }

    [Fact]
    public void RemovingNonExistingNodeReturnsFalse()
    {
      // Arrange
      var list = new SkipList<int>();
      list.Add(1);

      // Act
      var removed = list.Remove(2);

      // Assert
      Assert.False(removed);
      Assert.Equal(1, list.Height);
    }

    [Fact]
    public void NothingToRemove()
    {
      Assert.False(new SkipList<int>().Remove(1));
    }

    [Fact]
    public void DoesNotContainsTest()
    {
      // Arrange
      var list = new SkipList<int>();
      
      // Act
      var contains = list.Contains(5);

      // Assert
      Assert.False(contains);
    }

    [Fact]
    public void ContainsTest()
    {
      // Arrange
      var list = new SkipList<int>();
      list.Add(5);
      
      // Act
      var contains = list.Contains(5);

      // Assert
      Assert.True(contains);
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