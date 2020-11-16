using practicing_data_structures.data_structures.trees;
using Xunit;

namespace practicing_data_structures.tests.trees
{
  public class AVLTreeTests
  {

    [Fact]
    public void CountTest()
    {
      Assert.Equal(0, new AVLTree<string>().Count);
    }

    [Fact]
    public void HeightTest()
    {
      Assert.Equal(-1, new AVLTree<string>().Height());
    }

    [Fact]
    public void HeightTest2()
    {
      // Arrange
      var parent = new AVLTreeNode<string>();
      parent.Value = "hello";
      var tree = new AVLTree<string>();
      tree.SetRoot(parent);

      // Act
      var actual = tree.Height();

      // Assert
      Assert.Equal(0, actual);
    }

    [Fact]
    public void NullParentCausesToBeReturnedNull()
    {
      Assert.Null(new AVLTree<string>().Find(null, ""));
    }

    [Fact]
    public void FindMethodReturnsParentSinceItsValueIsSameWithGiven()
    {
      // Arrange
      var parent = new AVLTreeNode<string>();
      parent.Value = "hello";

      // Act
      var actual = new AVLTree<string>().Find(parent, "hello");

      // Assert
      Assert.Equal(parent, actual);
    }

    [Fact]
    public void FindMethodReturnsParentsLeftNode()
    {
      // Arrange
      var parent = new AVLTreeNode<string>();
      var left = new AVLTreeNode<string>();
      left.Value = "Parents left node";
      parent.Left = left;

      // Act
      var actual = new AVLTree<string>().Find(parent, "Parents left node");

      // Assert
      Assert.Equal(left, actual);
    }

    [Fact]
    public void FindMethodReturnsParentsLeftOfLeftNode()
    {
      // Arrange
      var parent = new AVLTreeNode<string>();

      var parentsLeftOfLeftNode = new AVLTreeNode<string>();
      parentsLeftOfLeftNode.Value = "Parents left of left node";

      var parentsLeftNode = new AVLTreeNode<string>();
      parentsLeftNode.Left = parentsLeftOfLeftNode;
      parent.Left = parentsLeftNode;

      // Act
      var actual = new AVLTree<string>().Find(parent, "Parents left of left node");

      // Assert
      Assert.Equal(parentsLeftNode, actual);
    }

    [Fact]
    public void FindMethodReturnsParentsRightNode()
    {
      // Arrange
      var parentsRightNode = new AVLTreeNode<string>();
      parentsRightNode.Value = "Parents right node";

      var parent = new AVLTreeNode<string>();
      parent.Right = parentsRightNode;

      var tree = new AVLTree<string>();

      // Act
      var actual = tree.Find(parent, "Parents right node");

      // Assert
      Assert.Equal(parentsRightNode, actual);
    }

    [Fact]
    public void ContainsTest()
    {
      // Arrange & Act & Assert
      Assert.False( new AVLTree<string>().Contains("hello") );
    }

    [Fact]
    public void ContainsTest2()
    {
      // Arrange
      var parent = new AVLTreeNode<string>();
      parent.Value = "world";
      var tree = new AVLTree<string>();
      tree.SetRoot(parent);

      // Act
      var actual = tree.Contains("world");

      // Assert
      Assert.True(actual);
    }

    [Fact]
    public void FindMaxTest()
    {
      // Arrange
      var rightOfRightNode   = new AVLTreeNode<string>();
      rightOfRightNode.Value = "rightOfRightNode";

      var rightNode          = new AVLTreeNode<string>();
      rightNode.Value        = "rightNode";
      rightNode.Right        = rightOfRightNode;

      var parent             = new AVLTreeNode<string>();
      parent.Value           = "parentNode";
      parent.Right           = rightNode;

      var tree               = new AVLTree<string>();

      // Act
      var actual             = tree.FindMax(parent);

      // Assert
      Assert.Equal("rightOfRightNode", actual.Value);
      Assert.Null(actual.Right);
    }

    [Fact]
    public void FindMinTest()
    {
      // Arrange
      var leftOfLeftNode   = new AVLTreeNode<string>();
      leftOfLeftNode.Value = "leftOfLeftNode";

      var leftNode    = new AVLTreeNode<string>();
      leftNode.Value  = "leftNode";
      leftNode.Left   = leftOfLeftNode;

      var parent    = new AVLTreeNode<string>();
      parent.Value  = "parentNode";
      parent.Left   = leftNode;

      var tree = new AVLTree<string>();
      tree.SetRoot(parent);

      // Act
      var actual = tree.FindMin();

      // Assert
      Assert.Equal("leftOfLeftNode", actual.Value);
      Assert.Null(actual.Left);
    }

    [Fact]
    public void InsertTest()
    {
      // Arrange
      var tree = new AVLTree<string>();

      // Act
      tree.Insert("hello");

      // Assert
      Assert.Equal("hello", tree.Root.Value);
      Assert.Equal(0, tree.Height());
      Assert.Equal(1, tree.Root.Count);
    }

    [Fact]
    public void InsertRightSideOfTree()
    {
      // Arrange
      var tree = new AVLTree<int>();

      // Act
      tree.Insert(4);
      tree.Insert(5);
      tree.Insert(6);

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
      tree.Insert(4);
      tree.Insert(3);
      tree.Insert(2);

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
    public void UpdateHeightOfRootNode()
    {
      // Arrange
      var tree = new AVLTree<int>();

      // Act
      tree.Insert(4); // Root

      // Assert
      Assert.Equal(0, tree.Root.Height);
    }

    [Fact]
    public void UpdateHeightOfLeftNode()
    {
      // Arrange
      var tree = new AVLTree<int>();

      // Act
      tree.Insert(4); // Root
      tree.Insert(3); // Left

      // Assert
      Assert.Equal(1, tree.Root.Height);
      Assert.Equal(0, tree.Root.Left.Height);
    }

    [Fact]
    public void UpdateHeightOfRightNode()
    {
      // Arrange
      var tree = new AVLTree<int>();

      // Act
      tree.Insert(4); // Root
      tree.Insert(5); // Right

      // Assert
      Assert.Equal(1, tree.Root.Height);
      Assert.Equal(0, tree.Root.Right.Height);
    }

    [Fact]
    public void RecomputeHeightTest()
    {
      // Arrange
      var tree = new AVLTree<int>();
      var rightOfRigh = new AVLTreeNode<int>();
      var right = new AVLTreeNode<int>();
      right.Right = rightOfRigh;
      var parent = new AVLTreeNode<int>();
      parent.Right = right;

      // Act
      tree.RecomputeHeight(parent);

      // Assert
      Assert.Equal(2, parent.Height);
      Assert.Equal(1, parent.Right.Height);
      Assert.Equal(0, parent.Right.Right.Height);
    }

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
      tree.Insert(5);
      tree.Insert(4);
      tree.Insert(3);
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
      tree.Insert(5);
      tree.Insert(6);
      tree.Insert(7);
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
      tree.Insert(4m);
      tree.Insert(3m);
      tree.Insert(3.5m);
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
      tree.Insert(5m);            //       5
      tree.Insert(4m);            //     4   n
      tree.Insert(3m);            //   3   n
      tree.Insert(3.5m);          // n  3.5
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
      tree.Insert(4m);         //    4
      tree.Insert(6m);         //  n   6
      tree.Insert(5m);         //     5 n
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
      tree.Insert(4m);
      tree.Insert(5m);
      tree.Insert(6m);
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
      tree.Insert(4m);             //         r(4)
      tree.Insert(3m);             //     l(3)    r(null)
      tree.Insert(3.5m);           // l(null) r(3.5)
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
      tree.Insert(4m);             //         r(4)
      tree.Insert(7m);             //   l(null)    r(7)
      tree.Insert(8m);             //        l(null)   r(8)
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

    [Fact]
    public void Balance_When_TreeIsLeftHeavy_And_LeftChildIsLeftHeavy()
    {
      // Arrange & Act & Assert
      var tree = new AVLTree<int>();
      tree.Insert(5);
      tree.Insert(4);
      tree.Insert(6);

      // Act & Assert
      Assert.Throws<System.NotImplementedException>( () => tree.Balance(tree.Root) );
    }

  }
}