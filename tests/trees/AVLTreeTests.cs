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
    }

    [Fact]
    public void NodeAlreadyExistsTest()
    {
      // Arrange
      var tree = new AVLTree<int>();
      tree.Insert(4);
      tree.Insert(3);

      // Act && Assert
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

  }
}