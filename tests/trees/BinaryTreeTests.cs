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

    public BinaryTreeNode<int> BuildBinaryTreeFromNodes()
    {
      // Depth: 1
		  var tree = new BinaryTreeNode<int>(1);
		
        // Depth: 2
        tree.Left = new BinaryTreeNode<int>(2);
        tree.Right = new BinaryTreeNode<int>(3);
		
          // Depth: 3
          tree.Left.Left = new BinaryTreeNode<int>(4);
          tree.Left.Right = new BinaryTreeNode<int>(5);
      
          tree.Right.Left = new BinaryTreeNode<int>(6);
          tree.Right.Right = new BinaryTreeNode<int>(7);
      
            // Depth: 4
            tree.Left.Left.Left = new BinaryTreeNode<int>(8);
            tree.Left.Left.Right = new BinaryTreeNode<int>(9);

      return tree;
    }

    [Fact]
    public void FindRootNode()
    {
      // Arrange
      var bt = new BinaryTree<int>(BuildBinaryTreeFromNodes());

      // Act
      var actual = bt.Find(1);

      // Assert
      Assert.Equal( 1, actual.value );
    }

    [Fact]
    public void FindLeftNode()
    {
      // Arrange
      var bt = new BinaryTree<int>(BuildBinaryTreeFromNodes());

      // Act
      var actual = bt.Find(8);

      // Assert
      Assert.Equal( 8, actual.value );
    }

    [Fact]
    public void FindRightNode()
    {
      // Arrange
      var bt = new BinaryTree<int>(BuildBinaryTreeFromNodes());

      // Act
      var actual = bt.Find(7);

      // Assert
      Assert.Equal( 7, actual.value );
    }

    [Fact]
    public void InsertRoot()
    {
      // Arrange
      var bt = new BinaryTree<int>(null);

      // Act
      bt.Insert(2);

      // Assert
      Assert.Equal(2, bt.root.value);
    }

    [Fact]
    public void TryingToInsertOneMoreRootNodeCausesException()
    {
      // Arrange
      var bt = new BinaryTree<int>(null);
      bt.Insert(2);

      // Act & Assert
      Assert.Throws<System.Exception>( () => bt.Insert(2) );
    }

    [Fact]
    public void AbsentParentCausesException()
    {
      // Arrange
      var bt = new BinaryTree<int>(null);
      bt.Insert(2);

      // Act & Assert
      Assert.Throws<System.Exception>( () => bt.Insert(5,6) );
    }

    [Fact]
    public void ExistingNodeCausesException()
    {
      // Arrange
      var bt = new BinaryTree<int>(null);
      bt.Insert(2);

      // Act & Assert
      Assert.Throws<System.Exception>( () => bt.Insert(1,2) );
    }

    [Fact]
    public void InsertNode_To_ParentNodesLeft_When_ParentsLeftAndRightAreNull()
    {
      // Arrange
      var bt = new BinaryTree<int>(null);
      bt.Insert(2);

      // Act
      bt.Insert(2,5);

      // Assert
      Assert.Equal(2, bt.root.value);
      Assert.Equal(5, bt.root.Left.value);
      Assert.Null(bt.root.Right);
      Assert.Equal(2, bt.Count);
      Assert.Equal(1, bt.Height());
    }

    [Fact]
    public void InsertNode_To_ParentsRight_When_ParentsLeftIsNotNull_And_RightIs()
    {
      // Arrange
      var bt = new BinaryTree<int>(null);
      bt.Insert(2);
      bt.Insert(2,5);

      // Act
      bt.Insert(2,6);

      // Assert
      Assert.Equal(2, bt.root.value);
      Assert.Equal(5, bt.root.Left.value);
      Assert.Equal(6, bt.root.Right.value);
      Assert.Equal(3, bt.Count);
      Assert.Equal(1, bt.Height());
    }

    [Fact]
    public void TryingToInsertNode_To_ParentWithTwoChildren_CausesException()
    {
      // Arrange
      var bt = new BinaryTree<int>(null);
      bt.Insert(2);
      bt.Insert(2,5);
      bt.Insert(2,6);

      // Act & Assert
      Assert.Throws<System.Exception>( () => bt.Insert(2,7) );
    }

    [Fact]
    public void ContainsTest()
    {
      // Arrange
      var bt = new BinaryTree<int>(null);
      bt.Insert(2);
      bt.Insert(2,5);
      bt.Insert(2,6);

      // Act & Assert
      Assert.True(bt.Contains(2));
      Assert.True(bt.Contains(5));
      Assert.True(bt.Contains(6));
      Assert.False(bt.Contains(7));
      Assert.Equal(3, bt.Count);
      Assert.Equal(1, bt.Height());
    }

    [Fact]
    public void HeightOfEmptyTreeIsMinusOne()
    {
      // Arrange
      var bt = new BinaryTree<int>(null);

      // Act & Assert
      Assert.Equal(-1, bt.Height());
      Assert.Equal(0, bt.Count);
    }

    [Fact]
    public void HeightOfTree()
    {
      // Arrange
      var bt = new BinaryTree<int>(null);

      // Height:0
      bt.Insert(2);

      // Height:1
      bt.Insert(2,5);
      bt.Insert(2,6);

      // Height:2
      bt.Insert(5,10);
      bt.Insert(5,11);

      // Height:3
      bt.Insert(10,20);
      bt.Insert(10,21);

      // Act & Assert
      Assert.Equal(3, bt.Height());
      Assert.Equal(7, bt.Count);
    }

    [Fact]
    public void NotFoundNodeCausesException()
    {
      // Arrange
      var bt = new BinaryTree<int>(null);

      // Act & Assert
      Assert.Throws<System.Exception>( () => bt.Delete(10) );
    }

    [Fact]
    public void DeleteRootNode_When_LeftAndRightChildrenAreNull_And_NodeIsRoot()
    {
      // Arrange
      var bt = new BinaryTree<int>(null);
      bt.Insert(5);

      // Act
      bt.Delete(5);

      // Assert
      Assert.Null(bt.root);
      Assert.Equal(0, bt.Count);
      Assert.Equal(-1, bt.Height());
    }

    [Fact]
    public void DeleteLeftNode_When_LeftAndRightChildrenAreNull_And_NodeIsLeftChild()
    {
      // Arrange
      var bt = new BinaryTree<int>(null);
      bt.Insert(5);
      bt.Insert(5, 10);

      Assert.Equal(10, bt.root.Left.value);

      // Act
      bt.Delete(10);

      // Assert
      Assert.Equal(5, bt.root.value);
      Assert.Null(bt.root.Left);
      Assert.Equal(1, bt.Count);
      Assert.Equal(0, bt.Height());
    }

    [Fact]
    public void DeleteRightNode_When_LeftAndRightChildrenAreNull_And_NodeIsRightChild()
    {
      // Arrange
      var bt = new BinaryTree<int>(null);
      bt.Insert(5);
      bt.Insert(5, 10);
      bt.Insert(5, 12);

      // Pre-Act Assert
      Assert.Equal(5, bt.root.value);
      Assert.Equal(10, bt.root.Left.value);
      Assert.Equal(12, bt.root.Right.value);

      // Act
      bt.Delete(12);

      // Assert
      Assert.Equal(5, bt.root.value);
      Assert.Equal(10, bt.root.Left.value);
      Assert.Null(bt.root.Right);
      Assert.Equal(2, bt.Count);
      Assert.Equal(1, bt.Height());
    }

    [Fact]
    public void DeleteLeftNode_When_LeftIsNull_And_RightIsNot_And_NodeIsLeftChild()
    {
      // Arrange
      var bt = new BinaryTree<int>(null);
      bt.Insert(5);
      bt.Insert(5, 10);
      bt.Insert(5, 12);

      bt.Insert(10, 20);
      bt.Insert(10, 22);

      // Delete left child node to match the delete case
      bt.Delete(20);

      // Act
      bt.Delete(10);

      // Assert
      Assert.Equal(5, bt.root.value);
      Assert.Equal(12, bt.root.Right.value);
      Assert.Equal(22, bt.root.Left.value);
      Assert.Equal(3, bt.Count);
    }

    [Fact]
    public void DeleteRightNode_When_LeftIsNull_And_RightIsNot_And_NodeIsRightChild()
    {
      // Arrange
      var bt = new BinaryTree<int>(null);
      bt.Insert(5);
      bt.Insert(5, 10);
      bt.Insert(5, 12);

      bt.Insert(12, 20);
      bt.Insert(12, 22);

      // Delete left child node to match the delete case
      bt.Delete(20);

      // should be
      //       5
      //    10   12
      //        n  22

      // Act
      bt.Delete(12);

      // should be
      //       5
      //    10   22

      // Assert
      Assert.Equal(5, bt.root.value);
      Assert.Equal(10, bt.root.Left.value);
      Assert.Equal(22, bt.root.Right.value);
      Assert.Equal(3, bt.Count);
    }

    [Fact]
    public void DeleteLeftNode_When_LeftIsNotNull_And_RightIs_And_NodeIsLeftChild()
    {
      // Arrange
      var bt = new BinaryTree<int>(null);
      bt.Insert(5);
      bt.Insert(5, 10);
      bt.Insert(5, 12);
      bt.Insert(10, 20);

      // should be
      //       5
      //    10   12
      //   20 n

      // Act
      bt.Delete(10);

      // should be
      //       5
      //    20   12

      // Assert
      Assert.Equal(5, bt.root.value);
      Assert.Equal(20, bt.root.Left.value);
      Assert.Equal(12, bt.root.Right.value);
      Assert.Equal(3, bt.Count);
    }

    [Fact]
    public void DeleteRightNode_When_LeftIsNotNull_And_RightIs_And_NodeIsRightChild()
    {
      // Arrange
      var bt = new BinaryTree<int>(null);
      bt.Insert(5);
      bt.Insert(5, 10);
      bt.Insert(5, 12);
      bt.Insert(12, 20);

      // should be
      //       5
      //    10   12
      //        20 n

      // Act
      bt.Delete(12);

      // should be
      //       5
      //    10   20

      // Assert
      Assert.Equal(5, bt.root.value);
      Assert.Equal(10, bt.root.Left.value);
      Assert.Equal(20, bt.root.Right.value);
      Assert.Equal(3, bt.Count);
    }

    [Fact]
    public void TryingToDeleteNodeWithTwoChildrenCausesException()
    {
      // Arrange
      var bt = new BinaryTree<int>(null);
      bt.Insert(5);
      bt.Insert(5, 10);
      bt.Insert(5, 12);

      // Act
      Assert.Throws<System.Exception>( () => bt.Delete(5) );
    }

  }
}