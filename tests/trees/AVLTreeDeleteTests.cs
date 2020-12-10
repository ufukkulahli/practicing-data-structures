using practicing_data_structures.data_structures.trees;
using Xunit;

namespace practicing_data_structures.tests.trees
{
  public class AVLTreeDeleteTests
  {

    [Fact]
    public void DeleteNullNodeTest()
    {
      // Arrange & Act & Assert
      Assert.Throws<System.ArgumentNullException>( () => new AVLTree<int>().Delete(1) );
    }

    [Fact]
    public void DeletingRightNullNodeCausesException()
    {
      // Arrange
      var tree = new AVLTree<int>();
      var parent = new AVLTreeNode<int>();
      parent.Value = 5;
      tree.SetRoot(parent);

      // Act & Assert
      Assert.Throws<System.Exception>( () => tree.Delete(6) );
    }

    [Fact]
    public void DeletingLeftNullNodeCausesException()
    {
      // Arrange
      var parent = new AVLTreeNode<int>();
      parent.Value = 5;
      var tree = new AVLTree<int>();
      tree.SetRoot(parent);

      // Act & Assert
      Assert.Throws<System.Exception>( () => tree.Delete(4) );
    }

    [Fact]
    public void DeleteRootNode()
    {
      // Arrange
      var root = new AVLTreeNode<int>();
      root.Value = 5;

      var tree = new AVLTree<int>();
      tree.SetRoot(root);

      // Act
      tree.Delete(5);

      // Assert
      Assert.False(tree.Contains(5));
      Assert.Null(tree.Root);
    }

    [Fact]
    public void DeleteRootsLeftNode()
    {
      // Arrange
      var tree = new AVLTree<int>();
      tree.Insert(5);
      tree.Insert(4);
      Assert.NotNull(tree.Root.Left);
      Assert.Equal(2, tree.Count);

      // Act
      tree.Delete(4);

      // Assert
      Assert.False(tree.Contains(4));
      Assert.NotNull(tree.Root);
      Assert.Null(tree.Root.Left);
      Assert.Equal(1, tree.Count);
    }

    [Fact]
    public void DeleteRootsRightNode()
    {
      // Arrange
      var tree = new AVLTree<int>();
      tree.Insert(5);
      tree.Insert(6);
      Assert.NotNull(tree.Root.Right);
      Assert.Equal(2, tree.Count);

      // Act
      tree.Delete(6);

      // Assert
      Assert.False(tree.Contains(6));
      Assert.NotNull(tree.Root);
      Assert.Null(tree.Root.Right);
      Assert.Equal(1, tree.Count);
    }

    [Fact]
    public void DeleteRootsLeftOfLeftNode()
    {
      // Arrange
      var tree = new AVLTree<int>();
      tree.Insert(5, false);
      tree.Insert(4, false);
      tree.Insert(3, false);

      Assert.NotNull(tree.Root.Left);
      Assert.NotNull(tree.Root.Left.Left);
      Assert.Equal(3, tree.Count);

      // Act
      tree.Delete(3);

      // Assert
      Assert.False(tree.Contains(3));
      Assert.NotNull(tree.Root);
      Assert.NotNull(tree.Root.Left);
      Assert.Null(tree.Root.Left.Left);
      Assert.Equal(2, tree.Count);
    }

    [Fact]
    public void DeleteRootsRightOfRightNode()
    {
      // Arrange
      var tree = new AVLTree<int>();
      tree.Insert(5, false);
      tree.Insert(6, false);
      tree.Insert(7, false);

      Assert.NotNull(tree.Root.Right);
      Assert.NotNull(tree.Root.Right.Right);
      Assert.Equal(3, tree.Count);

      // Act
      tree.Delete(7);

      // Assert
      Assert.False(tree.Contains(7));
      Assert.NotNull(tree.Root);
      Assert.NotNull(tree.Root.Right);
      Assert.Null(tree.Root.Right.Right);
      Assert.Equal(2, tree.Count);
    }

    [Fact]
    public void DeleteTestWhenRightTreeIsNullAndGivenNodeIsRoot()
    {
      // Arrange
      var tree = new AVLTree<decimal>();
      tree.Insert(4m, false);
      tree.Insert(3m, false);
      tree.Insert(3.5m, false);

      Assert.Equal(3, tree.Count);

      // Act
      tree.Delete(4m);

      // Assert
      Assert.Equal(2, tree.Count);
      Assert.False(tree.Contains(4m));
      Assert.Equal(3m, tree.Root.Value);
      Assert.Null(tree.Root.Left);
      Assert.Equal(3.5m, tree.Root.Right.Value);
    }

    [Fact]
    public void DeleteTest_WhenRightTreeIsNull_And_GivenNodeIsLeftChildOfParent()
    {
      // Arrange
      var tree = new AVLTree<decimal>();
      tree.Insert(5m, false);            //       5
      tree.Insert(4m, false);            //     4   n
      tree.Insert(3m, false);            //   3   n
      tree.Insert(3.5m, false);          // n  3.5

      Assert.Equal(4, tree.Count);

      // Act
      tree.Delete(4m);

      // Assert
      Assert.Equal(3, tree.Count);
      Assert.False(tree.Contains(4m));
      Assert.Equal(5m, tree.Root.Value);
      Assert.Null(tree.Root.Right);
      Assert.Equal(3m, tree.Root.Left.Value);
      Assert.Equal(5m, tree.Root.Left.Parent.Value);
      Assert.Equal(3.5m, tree.Root.Left.Right.Value);
      Assert.Equal(3m, tree.Root.Left.Right.Parent.Value);
    }

    [Fact]
    public void DeleteTest_WhenRightTreeIsNull_And_GivenNodeIsRightChildOfParent()
    {
      // Arrange
      var tree = new AVLTree<decimal>();
      tree.Insert(4m, false);         //    4
      tree.Insert(6m, false);         //  n   6
      tree.Insert(5m, false);         //     5 n

      Assert.Equal(3, tree.Count);

      // Act
      tree.Delete(6m);

      // Assert
      Assert.Equal(2, tree.Count);
      Assert.False(tree.Contains(6m));
      Assert.Equal(4m, tree.Root.Value);
      Assert.Equal(5m, tree.Root.Right.Value);
      Assert.Equal(4m, tree.Root.Right.Parent.Value);
      Assert.Null(tree.Root.Left);
    }

    [Fact]
    public void DeleteTestWhenLeftTreeIsNullAndGivenNodeIsRoot()
    {
      // Arrange
      var tree = new AVLTree<decimal>();
      tree.Insert(4m, false);
      tree.Insert(5m, false);
      tree.Insert(6m, false);

      Assert.Equal(3, tree.Count);
      Assert.Equal(2, tree.Height());

      // Act
      tree.Delete(4m);

      // Assert
      tree.RecomputeHeight(tree.Root);
      Assert.Equal(2, tree.Count);
      Assert.Equal(1, tree.Height());
      Assert.False(tree.Contains(4m));
      Assert.Equal(5m, tree.Root.Value);
      Assert.Null(tree.Root.Left);
      Assert.Equal(6m, tree.Root.Right.Value);
      Assert.Equal(5m, tree.Root.Right.Parent.Value);
    }

    [Fact]
    public void DeleteTest_WhenLeftTreeIsNull_And_GivenNodeIsLeftChildOfParent()
    {
      // Arrange
      var tree = new AVLTree<decimal>();
      tree.Insert(4m, false);             //         r(4)
      tree.Insert(3m, false);             //     l(3)    r(null)
      tree.Insert(3.5m, false);           // l(null) r(3.5)

      Assert.Equal(3, tree.Count);
      Assert.Equal(2, tree.Height());

      // Act
      tree.Delete(3m);

      // Assert
      tree.RecomputeHeight(tree.Root);
      Assert.Equal(2, tree.Count);
      Assert.Equal(1, tree.Height());
      Assert.False(tree.Contains(3m));
      Assert.Equal(4m, tree.Root.Value);
      Assert.Equal(3.5m, tree.Root.Left.Value);
      Assert.Equal(4m, tree.Root.Left.Parent.Value);
    }

    [Fact]
    public void DeleteTest_WhenLeftTreeIsNull_And_GivenNodeIsRightChildOfParent()
    {
      // Arrange
      var tree = new AVLTree<decimal>();
      tree.Insert(4m, false);             //         r(4)
      tree.Insert(7m, false);             //   l(null)    r(7)
      tree.Insert(8m, false);             //        l(null)   r(8)

      Assert.Equal(3, tree.Count);
      Assert.Equal(2, tree.Height());

      // Act
      tree.Delete(7m);

      // Assert
      tree.RecomputeHeight(tree.Root);
      Assert.Equal(2, tree.Count);
      Assert.Equal(1, tree.Height());
      Assert.False(tree.Contains(7m));
      Assert.Equal(4m, tree.Root.Value);
      Assert.Null(tree.Root.Left);
      Assert.Equal(8m, tree.Root.Right.Value);
      Assert.Equal(4m, tree.Root.Right.Parent.Value);
    }

    [Fact]
    public void DeleteFarLeftNode()
    {
      // Arrange
      var tree = new AVLTree<decimal>();
      tree.Insert(5m);
      tree.Insert(4m);
      tree.Insert(6m);
      tree.Insert(3m);
      tree.Insert(4.5m);

      // Act
      tree.Delete(4m);

      // Arrange
      Assert.False(tree.Contains(4m));
      Assert.Equal(5m, tree.Root.Value);
      Assert.Equal(6m, tree.Root.Right.Value);
      Assert.Equal(3m, tree.Root.Left.Value);
      Assert.Equal(4.5m, tree.Root.Left.Right.Value);
    }


  }
}