using practicing_data_structures.data_structures.trees;
using Xunit;

namespace practicing_data_structures.tests.trees
{
  public class BinaryTreeNodeTests
  {

    [Fact]
    public void ValuesAreSame()
    {
      Assert.True( new BinaryTreeNode<int>(10).Same(10) );
    }

    [Fact]
    public void ValuesAreNotSame()
    {
      Assert.False( new BinaryTreeNode<int>(10).Same(-10) );
    }

    [Fact]
    public void NodeIsRoot()
    {
      Assert.True( new BinaryTreeNode<int>(10).IsRoot );
    }

    [Fact]
    public void NodeIsNotRoot()
    {
      // Arrange
      var parent = new BinaryTreeNode<int>(10);
      var leftChild = new BinaryTreeNode<int>(5);
      leftChild.Parent = parent;
      parent.Left = leftChild;

      // Act & Assert
      Assert.False( leftChild.IsRoot );
      Assert.True( parent.IsRoot );
    }

    [Fact]
    public void NodeIsLeaf()
    {
      Assert.True( new BinaryTreeNode<int>(10).IsLeaf );
    }

    [Fact]
    public void NodeIsNotLeaf()
    {
      // Arrange
      var parent = new BinaryTreeNode<int>(10);
      var leftChild = new BinaryTreeNode<int>(5);
      leftChild.Parent = parent;
      parent.Left = leftChild;

      // Act & Assert
      Assert.False( parent.IsLeaf );
      Assert.True ( leftChild.IsLeaf );
    }

  }
}