using practicing_data_structures.data_structures.trees;
using Xunit;

namespace practicing_data_structures.tests.trees
{
  public class BinaryTreeTests
  {
    [Fact]
    public void Test()
    {
      // Arrange
      var bt = new BinaryTree<int>(BuildBinaryTreeFromNodes());

      // Act && Assert
      Assert.Equal(1, bt.root.value);

      Assert.Equal(2, bt.root.Left.value);
      Assert.Equal(3, bt.root.Right.value);

      Assert.Equal(4, bt.root.Left.Left.value);
      Assert.Equal(5, bt.root.Left.Right.value);

      Assert.Equal(8, bt.root.Left.Left.Left.value);
      Assert.Equal(9, bt.root.Left.Left.Right.value);
    }

    public Node<int> BuildBinaryTreeFromNodes()
    {
      // Depth: 1
		  var tree = new Node<int>(1);
		
        // Depth: 2
        tree.Left = new Node<int>(2);
        tree.Right = new Node<int>(3);
		
          // Depth: 3
          tree.Left.Left = new Node<int>(4);
          tree.Left.Right = new Node<int>(5);
      
          tree.Right.Left = new Node<int>(6);
          tree.Right.Right = new Node<int>(7);
      
            // Depth: 4
            tree.Left.Left.Left = new Node<int>(8);
            tree.Left.Left.Right = new Node<int>(9);

      return tree;
    }
  }
}