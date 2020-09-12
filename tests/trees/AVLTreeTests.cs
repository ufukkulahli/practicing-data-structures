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

  }
}