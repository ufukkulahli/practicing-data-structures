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
    public void BalanceFactorTest()
    {
      // Arrange
      var left = new AVLTreeNode<int>();
      var root = new AVLTreeNode<int>();
      root.Left = left;

      // Act & Assert
      Assert.Equal(1, root.BalanceFactor);
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


  }
}