using practicing_data_structures.data_structures.trees;
using Xunit;

namespace practicing_data_structures.tests.trees
{
  public class AVLTreeNodeTests
  {

    [Fact]
    public void LeftHeightTest()
    {
      // Arrange & Act & Assert
      Assert.Equal(0, new AVLTreeNode<int>().LeftHeight);
    }

    [Fact]
    public void LeftHeightTest2()
    {
      // Arrange
      var left = new AVLTreeNode<int>();
      var root = new AVLTreeNode<int>();
      root.Left = left;

      // Act & Assert
      Assert.Equal(1, root.LeftHeight);
    }

    [Fact]
    public void RightHeightTest()
    {
      // Arrange & Act & Assert
      Assert.Equal(0, new AVLTreeNode<int>().RightHeight);
    }

    [Fact]
    public void RightHeightTest2()
    {
      // Arrange
      var right = new AVLTreeNode<int>();
      var root = new AVLTreeNode<int>();
      root.Right = right;

      // Act & Assert
      Assert.Equal(1, root.RightHeight);
    }

    [Fact]
    public void BalanceFactorForLeftHeavyTree()
    {
      // Arrange
      var leftOfLeft = new AVLTreeNode<int>();
      var left       = new AVLTreeNode<int>();
      left.Left      = leftOfLeft;

      var root       = new AVLTreeNode<int>();
      root.Left      = left;

      root.UpdateHeights();

      // Act & Assert
      Assert.Equal(2, root.BalanceFactor);
      Assert.True(root.TreeIsLeftHeavy);
      Assert.False(root.TreeIsRightHeavy);
      Assert.True(root.LeftChildIsLeftHeavy);
      Assert.False(root.LeftChildIsRightHeavy);
      Assert.False(root.RightChildIsRightHeavy);
      Assert.True(root.RightChildIsLeftHeavy);
    }

    [Fact]
    public void BalanceFactorForRightHeavyTree()
    {
      // Arrange
      var rightOfRight = new AVLTreeNode<int>();
      var right        = new AVLTreeNode<int>();
      right.Right      = rightOfRight;
      
      var root         = new AVLTreeNode<int>();
      root.Right       = right;

      root.UpdateHeights();

      // Act & Assert
      Assert.Equal(-2, root.BalanceFactor);
      Assert.True(root.TreeIsRightHeavy);
      Assert.False(root.TreeIsLeftHeavy);

      Assert.False(root.RightChildIsRightHeavy);
      Assert.True(root.RightChildIsLeftHeavy);
      Assert.False(root.LeftChildIsLeftHeavy);
      Assert.True(root.LeftChildIsRightHeavy);
    }

    [Fact]
    public void DefaultCountTest()
    {
      Assert.Equal(1, new AVLTreeNode<int>().Count);
    }

  }
}