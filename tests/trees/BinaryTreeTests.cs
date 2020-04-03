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
      var bt = new BinaryTree(BuildBinaryTreeFromNodes());

      // Act

      // Assert
      Assert.True(true);
    }

    public Node BuildBinaryTreeFromNodes()
    {
      // Depth: 1
		  var tree = new Node(1);
		
        // Depth: 2
        tree.Left = new Node(2);
        tree.Right = new Node(3);
		
          // Depth: 3
          tree.Left.Left = new Node(4);
          tree.Left.Right = new Node(5);
      
          tree.Right.Left = new Node(4);
          tree.Right.Right = new Node(5);
      
            // Depth: 4
            tree.Left.Left.Left = new Node(4);
            tree.Left.Left.Right = new Node(5);

      return tree;
    }
  }
}