using practicing_data_structures.data_structures.trees;
using Xunit;

namespace practicing_data_structures.tests.trees
{
  public class AVLTreeDeleteThenBalanceTests
  {

    [Fact]
    public void Delete_When_NodeIsLeaf_And_LeftChild()
    {
      // Arrange
      var tree = new AVLTree<int>();

      tree.Insert(10);
      tree.Insert(12);
      tree.Insert(14);
      tree.Insert(16);
      tree.Insert(18);

      Assert.Equal(12, tree.Root.Value);
      Assert.Equal(10, tree.Root.Left.Value);
      Assert.Equal(16, tree.Root.Right.Value);
      Assert.Equal(14, tree.Root.Right.Left.Value);
      Assert.Equal(18, tree.Root.Right.Right.Value);

      // Act
      tree.Delete(10);

      // Assert
      Assert.Equal(12, tree.Root.Value);
      // Left side
      Assert.Equal(null, tree.Root.Left);
      // Right side
      Assert.Equal(16, tree.Root.Right.Value);
      Assert.Equal(14, tree.Root.Right.Left.Value);
      Assert.Equal(18, tree.Root.Right.Right.Value);
    }

    [Fact]
    public void Delete_When_NodeIsLeaf_And_RightChild()
    {
      // Arrange
      var tree = new AVLTree<int>();

      tree.Insert(18); 
      tree.Insert(16); 
      tree.Insert(14); 
      tree.Insert(12); 
      tree.Insert(10); 

      Assert.Equal(16, tree.Root.Value);
      Assert.Equal(12, tree.Root.Left.Value);
      Assert.Equal(18, tree.Root.Right.Value);
      Assert.Equal(10, tree.Root.Left.Left.Value);
      Assert.Equal(14, tree.Root.Left.Right.Value); 

      // Act
      tree.Delete(18);

      // Assert
      Assert.Equal(16, tree.Root.Value);
      // Left
      Assert.Equal(12, tree.Root.Left.Value);
      Assert.Equal(10, tree.Root.Left.Left.Value);
      Assert.Equal(14, tree.Root.Left.Right.Value); 
      // Right
      Assert.Equal(null, tree.Root.Right);
    }


    [Fact]
    public void Delete_When_RightTreeIsNull_And_NodeIsRoot()
    {
      // Arrange
      var tree = new AVLTree<int>();

      tree.Insert(18);
      tree.Insert(16);

      Assert.Equal(18, tree.Root.Value);
      Assert.Equal(16, tree.Root.Left.Value);
      Assert.Equal(null, tree.Root.Right);

      // Act
      tree.Delete(18);

      // Assert
      Assert.Equal(16, tree.Root.Value);
      // Left
      Assert.Equal(null, tree.Root.Left);
      // Right
      Assert.Equal(null, tree.Root.Right);
    }

    [Fact]
    public void Delete_When_RightTreeIsNull_And_NodeIsLeftChild()
    {
      // Arrange
      var tree = new AVLTree<int>();
      tree.Insert(10);
      tree.Insert(8);
      tree.Insert(6);
      tree.Insert(4);

      Assert.Equal(8, tree.Root.Value);
      Assert.Equal(10, tree.Root.Right.Value);
      Assert.Equal(6, tree.Root.Left.Value);
      Assert.Equal(4, tree.Root.Left.Left.Value);

      // Act
      tree.Delete(6);

      // Assert
      Assert.Equal(8, tree.Root.Value);
      Assert.Equal(10, tree.Root.Right.Value);
      Assert.Equal(4, tree.Root.Left.Value);
    }

    [Fact]
    public void Delete_When_RightTreeIsNull_And_NodeIsRightChild()
    {
      // Arrange
      var tree = new AVLTree<int>();
      tree.Insert(4);
      tree.Insert(6);
      tree.Insert(8);
      tree.Insert(7);

      Assert.Equal(6, tree.Root.Value);
      Assert.Equal(4, tree.Root.Left.Value);
      Assert.Equal(8, tree.Root.Right.Value);
      Assert.Equal(7, tree.Root.Right.Left.Value);

      // Act
      tree.Delete(8);

      // Assert
      Assert.Equal(6, tree.Root.Value);
      Assert.Equal(4, tree.Root.Left.Value);
      Assert.Equal(7, tree.Root.Right.Value);
    }

    [Fact]
    public void Delete_When_LeftTreeIsNull_And_NodeIsRoot()
    {
      // Arrange
      var tree = new AVLTree<int>();

      tree.Insert(16);
      tree.Insert(18);

      Assert.Equal(16, tree.Root.Value);
      Assert.Equal(18, tree.Root.Right.Value);
      Assert.Equal(null, tree.Root.Left);

      // Act
      tree.Delete(16);

      // Assert
      Assert.Equal(18, tree.Root.Value);
      // Left
      Assert.Equal(null, tree.Root.Left);
      // Right
      Assert.Equal(null, tree.Root.Right);
    }

    [Fact]
    public void Delete_When_LeftTreeIsNull_And_NodeIsLeftChild()
    {
      // Arrange
      var tree = new AVLTree<int>();
      tree.Insert(10);
      tree.Insert(8);
      tree.Insert(6);
      tree.Insert(7);

      Assert.Equal(8, tree.Root.Value);
      Assert.Equal(6, tree.Root.Left.Value);
      Assert.Equal(10, tree.Root.Right.Value);
      Assert.Equal(7, tree.Root.Left.Right.Value);

      // Act
      tree.Delete(6);

      // Assert
      Assert.Equal(8, tree.Root.Value);
      Assert.Equal(7, tree.Root.Left.Value);
      Assert.Equal(10, tree.Root.Right.Value);
    }

  }
}