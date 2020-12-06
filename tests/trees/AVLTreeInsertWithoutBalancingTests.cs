using practicing_data_structures.data_structures.trees;
using Xunit;

namespace practicing_data_structures.tests.trees
{
  public class AVLTreeInsertWithoutBalancingTests
  {
    [Fact]
    public void SimpleInsert()
    {
      // Arrange
      var tree = new AVLTree<string>();

      // Act
      tree.Insert("hello", false);
      tree.Insert("world", false);

      // Assert
      Assert.Equal("hello", tree.Root.Value);
      Assert.Equal(1, tree.Height());
      Assert.Equal(2, tree.Root.Count);
    }

    [Fact]
    public void InsertRightSideOfTree()
    {
      // Arrange
      var tree = new AVLTree<int>();

      // Act
      tree.Insert(4, false);
      tree.Insert(5, false);
      tree.Insert(6, false);

      // Assert
      Assert.Equal(4, tree.Root.Value);
      Assert.Equal(5, tree.Root.Right.Value);
      Assert.Equal(6, tree.Root.Right.Right.Value);
      Assert.Null(tree.Root.Left);
      Assert.Null(tree.Root.Right.Left);
      Assert.Null(tree.Root.Right.Right.Left);
      Assert.Equal(2, tree.Height());
      Assert.Equal(3, tree.Root.Count);
    }

    [Fact]
    public void InsertLeftSideOfTree()
    {
      // Arrange
      var tree = new AVLTree<int>();

      // Act
      tree.Insert(4, false);
      tree.Insert(3, false);
      tree.Insert(2, false);

      // Assert
      Assert.Equal(4, tree.Root.Value);
      Assert.Equal(3, tree.Root.Left.Value);
      Assert.Equal(2, tree.Root.Left.Left.Value);
      Assert.Null(tree.Root.Right);
      Assert.Null(tree.Root.Left.Right);
      Assert.Null(tree.Root.Left.Left.Right);
      Assert.Equal(2, tree.Height());
      Assert.Equal(3, tree.Root.Count);
    }

  }
}