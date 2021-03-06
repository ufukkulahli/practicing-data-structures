using System.Text;
using practicing_data_structures.data_structures.trees;
using Xunit;

namespace practicing_data_structures.tests.trees
{
  public class TreeTraversalTests
  {
    [Fact]
    public void InorderTraversal()
    {
      // Arrange
      var bt = new BinaryTree<int>(null);
      bt.Insert(5);
      bt.Insert(5, 10);
      bt.Insert(5, 12);
      
      bt.Insert(10, 20);
      bt.Insert(10, 22);
      
      bt.Insert(12, 30);
      bt.Insert(12, 32);

      // Should be
      //           5
      //      10       12
      //    20  22   30  32

      var sb = new StringBuilder();

      // Act
      new TreeTraversal<int>(sb).Inorder(bt.root);

      // Assert
      Assert.Equal("20->10->22->5->30->12->32", sb.ToString().TrimEnd('>').TrimEnd('-'));
    }

    [Fact]
    public void PreorderTraversal()
    {
      // Arrange
      var bt = new BinaryTree<int>(null);
      bt.Insert(5);
      bt.Insert(5, 10);
      bt.Insert(5, 12);
      
      bt.Insert(10, 20);
      bt.Insert(10, 22);
      
      bt.Insert(12, 30);
      bt.Insert(12, 32);

      // Should be
      //           5
      //      10       12
      //    20  22   30  32

      var sb = new StringBuilder();

      // Act
      new TreeTraversal<int>(sb).Preorder(bt.root);

      // Assert
      Assert.Equal("5->10->20->22->12->30->32", sb.ToString().TrimEnd('>').TrimEnd('-'));
    }

    [Fact]
    public void LevelorderTraversal()
    {
      // Arrange
      var bt = new BinaryTree<int>(null);
      bt.Insert(1);
      bt.Insert(1, 10); //delete
      bt.Insert(1, 2);
      
      bt.Insert(2, 11); //delete
      bt.Insert(2, 5);
      
      bt.Insert(5, 3);
      bt.Insert(5, 6);

      bt.Insert(3, 12); //delete
      bt.Insert(3, 4);

      bt.Delete(10);
      bt.Delete(11);
      bt.Delete(12);

      // Should be
      //           1
      //         n    2
      //            n   5
      //              3   6
      //             n 4

      var sb = new StringBuilder();

      // Act
      new TreeTraversal<int>(sb).Levelorder(bt.root);

      // Assert
      Assert.Equal("1->2->5->3->6->4", sb.ToString().TrimEnd('>').TrimEnd('-'));
    }

    [Fact]
    public void PostorderTraversal()
    {
      // Arrange
      var bt = new BinaryTree<int>(null);
      bt.Insert(5);
      bt.Insert(5, 10);
      bt.Insert(5, 12);
      
      bt.Insert(10, 20);
      bt.Insert(10, 22);
      
      bt.Insert(12, 30);
      bt.Insert(12, 32);

      // Should be
      //           5
      //      10       12
      //    20  22   30  32

      var sb = new StringBuilder();

      // Act
      new TreeTraversal<int>(sb).Postorder(bt.root);

      // Assert
      Assert.Equal("20->22->10->30->32->12->5", sb.ToString().TrimEnd('>').TrimEnd('-'));
    }

  }
}