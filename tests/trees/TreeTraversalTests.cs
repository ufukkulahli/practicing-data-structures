using System.Text;
using practicing_data_structures.data_structures.trees;
using Xunit;

namespace practicing_data_structures.tests.trees
{
  public class TreeTraversalTests
  {
    [Fact]
    public void Test()
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

      var sb = new StringBuilder();

      // Act
      new TreeTraversal<int>(sb).Inorder(bt.root);

      // Assert
      Assert.Equal("20->10->22->5->30->12->32", sb.ToString().TrimEnd('>').TrimEnd('-'));
    }
  }
}