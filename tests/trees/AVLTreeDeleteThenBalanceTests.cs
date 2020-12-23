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

  }
}