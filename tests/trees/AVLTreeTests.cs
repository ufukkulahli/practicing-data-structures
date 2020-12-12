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
    public void InsertWhileBalancing()
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

  }
}