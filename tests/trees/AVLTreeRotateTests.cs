using practicing_data_structures.data_structures.trees;
using Xunit;

namespace practicing_data_structures.tests.trees
{
  public class AVLTreeRotateTests
  {

    [Fact]
    public void RightRotateWhenNodeIsRoot()
    {
      // Arrange
      var tree = new AVLTree<decimal>();
      tree.Insert(4m);            //     4
      tree.Insert(3m);            //   3  4.5
      tree.Insert(4.5m);
      tree.Insert(2m);

      // Act
      tree.RightRotate(tree.Root);

      // should be
      //    3
      //  2   4
      //     n 4.5

      // Assert
      Assert.Equal(3m   , tree.Root.Value);
      Assert.Equal(2m   , tree.Root.Left.Value);
      Assert.Equal(4m   , tree.Root.Right.Value);
      Assert.Equal(null , tree.Root.Right.Left);
      Assert.Equal(4.5m , tree.Root.Right.Right.Value);
      Assert.Equal(4    , tree.Count);
    }

    [Fact]
    public void RightRotateWhenNodeIsLeftChild()
    {
      // Arrange
      var tree = new AVLTree<decimal>();
      tree.Insert(5m);            //       5
      tree.Insert(4m);            //     4   n
      tree.Insert(3m);            //   3  4.5
      tree.Insert(4.5m);          //  2 n
      tree.Insert(2m);

      // Act
      tree.RightRotate(tree.Root.Left);

      // should be
      //      5
      //    3   n
      //  2   4
      //     n 4.5

      // Assert
      Assert.Equal(5m   , tree.Root.Value);
      Assert.Equal(null , tree.Root.Right);
      Assert.Equal(3m   , tree.Root.Left.Value);
      Assert.Equal(2m   , tree.Root.Left.Left.Value);
      Assert.Equal(4m   , tree.Root.Left.Right.Value);
      Assert.Equal(4.5m , tree.Root.Left.Right.Right.Value);
      Assert.Equal(5    , tree.Count);
    }

    [Fact]
    public void RightRotateWhenNodeIsRightChild()
    {
      // Arrange
      var tree = new AVLTree<decimal>();
      tree.Insert(4m);         //     4
      tree.Insert(6m);         //  n      6
      tree.Insert(5m);         //      5     6.5
      tree.Insert(6.5m);       //   4.5 5.5
      tree.Insert(5.5m);
      tree.Insert(4.5m);

      // Act
      tree.RightRotate(tree.Root.Right);

      // should be
      //     4
      //  n     5
      //    4.5    6
      //        5.5 6.5

      // Assert
      Assert.Equal(4m   , tree.Root.Value);
      Assert.Equal(null , tree.Root.Left);
      Assert.Equal(5m   , tree.Root.Right.Value);
      Assert.Equal(4.5m , tree.Root.Right.Left.Value);
      Assert.Equal(6m   , tree.Root.Right.Right.Value);
      Assert.Equal(6.5m , tree.Root.Right.Right.Right.Value);
      Assert.Equal(5.5m , tree.Root.Right.Right.Left.Value);
      Assert.Equal(6    , tree.Count);
    }

    [Fact]
    public void LeftRotateWhenNodeIsRoot()
    {
      // Arrange
      var tree = new AVLTree<decimal>();
      tree.Insert(4m);            //     4
      tree.Insert(3m);            //   3     4.5
      tree.Insert(4.5m);          //  2 n   n   6
      tree.Insert(2m);
      tree.Insert(6m);

      // Act
      tree.LeftRotate(tree.Root);

      // should be
      //    4.5
      //   4   6
      //  3 n
      // 2 n

      // Assert
      Assert.Equal(4.5m , tree.Root.Value);
      Assert.Equal(6m   , tree.Root.Right.Value);
      Assert.Equal(4m   , tree.Root.Left.Value);
      Assert.Equal(3m   , tree.Root.Left.Left.Value);
      Assert.Equal(2m   , tree.Root.Left.Left.Left.Value);
      Assert.Equal(5    , tree.Count);
    }

    [Fact]
    public void LeftRotateWhenNodeIsLeftChild()
    {
      // Arrange
      var tree = new AVLTree<decimal>();
      tree.Insert(4m);            //      4
      tree.Insert(3m);            //    3   n
      tree.Insert(2m);            //  2  3.5
      tree.Insert(3.5m);          //     n 3.7 
      tree.Insert(3.7m);

      // Act
      tree.LeftRotate(tree.Root.Left);

      // should be
      //       4
      //   3.5   n
      //  3  3.7
      // 2 n

      // Assert
      Assert.Equal(4m   , tree.Root.Value);
      Assert.Equal(null , tree.Root.Right);
      Assert.Equal(3.5m , tree.Root.Left.Value);
      Assert.Equal(3.7m , tree.Root.Left.Right.Value);
      Assert.Equal(3m   , tree.Root.Left.Left.Value);
      Assert.Equal(2m   , tree.Root.Left.Left.Left.Value);
      Assert.Equal(5    , tree.Count);
    }

    [Fact]
    public void LeftRotateWhenNodeIsRightChild()
    {
      // Arrange
      var tree = new AVLTree<decimal>();
      tree.Insert(4m);         //     4
      tree.Insert(6m);         //  n      6
      tree.Insert(5m);         //      5     6.5
      tree.Insert(6.5m);       //   4.5 5.5
      tree.Insert(5.5m);
      tree.Insert(4.5m);
      tree.Insert(7m);

      // Act
      tree.LeftRotate(tree.Root.Right);

      // should be
      //     4
      //  n     6.5
      //       6   7
      //      5
      //   4.5 5.5

      // Assert
      Assert.Equal(4m   , tree.Root.Value);
      Assert.Equal(null , tree.Root.Left);
      Assert.Equal(6.5m , tree.Root.Right.Value);
      Assert.Equal(7m   , tree.Root.Right.Right.Value);
      Assert.Equal(6m   , tree.Root.Right.Left.Value);
      Assert.Equal(5m   , tree.Root.Right.Left.Left.Value);
      Assert.Equal(4.5m , tree.Root.Right.Left.Left.Left.Value);
      Assert.Equal(5.5m , tree.Root.Right.Left.Left.Right.Value);
      Assert.Equal(null , tree.Root.Right.Right.Right);
      Assert.Equal(7    , tree.Count);
    }

  }
}