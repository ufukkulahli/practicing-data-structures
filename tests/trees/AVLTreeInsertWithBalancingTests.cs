using practicing_data_structures.data_structures.trees;
using Xunit;

namespace practicing_data_structures.tests.trees
{
  public class AVLTreeInsertWithBalancingTests
  {

    [Fact]
    public void SimpleInsert()
    {
      // Arrange
      var tree = new AVLTree<int>();

      // Assert
      tree.Insert(1);
      tree.Insert(2);
      tree.Insert(3);
      tree.Insert(4);
      tree.Insert(5);

      // Assert
      Assert.Equal(2, tree.Root.Value);
      Assert.Equal(1, tree.Root.Left.Value);
      Assert.Equal(4, tree.Root.Right.Value);
      Assert.Equal(3, tree.Root.Right.Left.Value);
      Assert.Equal(5, tree.Root.Right.Right.Value);
    }

    [Fact]
    public void BalanceExample1()
    {
      // Ex: Balance_When_TreeIsLeftHeavy_And_LeftChildIsLeftHeavy

      // Arrange
      var tree = new AVLTree<int>();

      // Act
      tree.Insert(9);
      tree.Insert(10);
      tree.Insert(7);
      tree.Insert(6);
      tree.Insert(5);

      // should be
      //       9
      //    6    10
      //   5 7   n n

      // Assert
      Assert.Equal(9  , tree.Root.Value);
      Assert.Equal(6  , tree.Root.Left.Value);
      Assert.Equal(10 , tree.Root.Right.Value);
      Assert.Equal(5  , tree.Root.Left.Left.Value);
      Assert.Equal(7  , tree.Root.Left.Right.Value);
      Assert.Equal(2  , tree.Root.Height);
      Assert.Equal(5  , tree.Root.Count);
    }

    [Fact]
    public void BalanceExample2()
    {
      // Ex: Balance_When_TreeIsLeftHeavy_And_LeftChildIsRightHeavy

      // Arrange
      var tree = new AVLTree<int>();

      // Act
      tree.Insert(14);
      tree.Insert(15);
      tree.Insert(7);
      tree.Insert(8);
      tree.Insert(9);


      // should be
      //       14
      //    8    15
      //   7 9

      // Assert
      Assert.Equal(14 , tree.Root.Value);

      Assert.Equal(8  , tree.Root.Left.Value);
      Assert.Equal(7  , tree.Root.Left.Left.Value);
      Assert.Equal(9  , tree.Root.Left.Right.Value);

      Assert.Equal(15, tree.Root.Right.Value);
      Assert.Null(tree.Root.Right.Right);
      Assert.Null(tree.Root.Right.Left);

      Assert.Equal(2 , tree.Root.Height);
      Assert.Equal(5 , tree.Root.Count);

      Assert.Equal(false, tree.Root.TreeIsLeftHeavy);
      Assert.Equal(false, tree.Root.TreeIsRightHeavy);
    }

  }
}