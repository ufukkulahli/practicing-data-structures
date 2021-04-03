using practicing_data_structures.data_structures.trees;
using Xunit;

namespace practicing_data_structures.tests.trees
{
  public class AVLTreeInsertWithoutBalancingTests
  {

    [Fact]
    public void NodeAlreadyExistsTest()
    {
      // Arrange
      var tree = new AVLTree<int>();
      tree.Insert(4);
      tree.Insert(3);

      // Act && Assert
      Assert.Equal(1, tree.Height());
      Assert.Throws<System.Exception>( () => tree.Insert(3) );
    }

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

    [Fact]
    public void Balance_When_TreeIsLeftHeavy_And_LeftChildIsLeftHeavy()
    {
      // Arrange
      var tree = new AVLTree<int>();
      tree.Insert(9, false);         //       9
      tree.Insert(10, false);        //     7   10
      tree.Insert(7, false);         //    6 n
      tree.Insert(6, false);         //   5 n
      tree.Insert(5, false);

      // Act
      tree.Balance(tree.Root);

      // should be
      //      7
      //    6    9
      //   5 n  n 10

      // Assert
      Assert.Equal(7 , tree.Root.Value);
      Assert.Equal(9 , tree.Root.Right.Value);
      Assert.Equal(10, tree.Root.Right.Right.Value);

      Assert.Equal(6, tree.Root.Left.Value);
      Assert.Equal(5, tree.Root.Left.Left.Value);

      Assert.Equal(2,    tree.Root.Height);
      Assert.Equal(5,    tree.Root.Count);
    }

    [Fact]
    public void Balance_When_TreeIsLeftHeavy_And_LeftChildIsRightHeavy()
    {
      // Arrange
      var tree = new AVLTree<int>();
      tree.Insert(14, false);        //       14
      tree.Insert(15, false);        //     7    15
      tree.Insert(7, false);         //    n 8
      tree.Insert(8, false);         //     n 9
      tree.Insert(9, false);

      // Act
      tree.Balance(tree.Root);

      // should be
      //       8
      //    7    14
      //   n n  9 15

      // Assert
      Assert.Equal(8 , tree.Root.Value);

      Assert.Equal(14, tree.Root.Right.Value);
      Assert.Equal(9 , tree.Root.Right.Left.Value);
      Assert.Equal(15, tree.Root.Right.Right.Value);

      Assert.Equal(7 , tree.Root.Left.Value);
      Assert.Null(tree.Root.Left.Left);
      Assert.Null(tree.Root.Left.Right);

      Assert.Equal(2 , tree.Root.Height);
      Assert.Equal(5 , tree.Root.Count);

      Assert.False(tree.Root.TreeIsLeftHeavy);
      Assert.False(tree.Root.TreeIsRightHeavy);
    }

    [Fact]
    public void Balance_When_TreeIsRightHeavy_And_RightChildIsRightHeavy()
    {
      // Arrange
      var tree = new AVLTree<decimal>();
      tree.Insert(5, false);         //        5
      tree.Insert(6, false);         //     n    6
      tree.Insert(7, false);         //       5.5 7
      tree.Insert(5.5m, false);      //          n 8
      tree.Insert(8m, false);

      // Act
      tree.Balance(tree.Root);

      // should be
      //         6
      //      5     7
      //    n 5.5  n 8

      // Assert
      Assert.Equal(6    ,tree.Root.Value);

      // Left side
      Assert.Equal(5    ,tree.Root.Left.Value);
      Assert.Null(tree.Root.Left.Left);
      Assert.Equal(5.5m ,tree.Root.Left.Right.Value);

      // Right side
      Assert.Equal(7    ,tree.Root.Right.Value);
      Assert.Equal(8m   ,tree.Root.Right.Right.Value);
      Assert.Null(tree.Root.Right.Left);

      Assert.Equal(2,    tree.Root.Height);
      Assert.Equal(5,    tree.Root.Count);

      Assert.False(tree.Root.TreeIsLeftHeavy);
      Assert.False(tree.Root.TreeIsRightHeavy);
    }

    [Fact]
    public void Balance_When_TreeIsRightHeavy_And_RightChildIsLeftHeavy()
    {
      // Arrange
      var tree = new AVLTree<decimal>();
      tree.Insert(5, false);         //         5
      tree.Insert(6, false);         //     n       6
      tree.Insert(7, false);         //         5.5   7
      tree.Insert(5.5m, false);      //       5.4  n
      tree.Insert(5.4m, false);      //      5.3
      tree.Insert(5.3m, false);

      // should be
      //       5.5
      //     5     6
      //   n 5.4  n 7
      //    5.3 n
      //

      // Act
      tree.Balance(tree.Root);

      // Assert
      Assert.Equal(5.5m, tree.Root.Value);

      // Left side
      Assert.Equal(5,    tree.Root.Left.Value);
      Assert.Null(tree.Root.Left.Left);
      Assert.Equal(5.4m, tree.Root.Left.Right.Value);
      Assert.Equal(5.3m, tree.Root.Left.Right.Left.Value);

      // Right side
      Assert.Equal(6m,   tree.Root.Right.Value);
      Assert.Null(tree.Root.Right.Left);
      Assert.Equal(7m,   tree.Root.Right.Right.Value);

      Assert.Equal(3,    tree.Root.Height);
      Assert.Equal(6,    tree.Root.Count);

      Assert.False( tree.Root.TreeIsLeftHeavy);
      Assert.False(tree.Root.TreeIsRightHeavy);
    }

  }
}