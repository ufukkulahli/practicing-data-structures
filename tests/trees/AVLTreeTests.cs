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

  }
}