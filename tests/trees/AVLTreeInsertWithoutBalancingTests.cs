using practicing_data_structures.data_structures.trees;
using Xunit;

namespace practicing_data_structures.tests.trees
{
  public class AVLTreeInsertWithoutBalancingTests
  {
    [Fact]
    public void SimpleInsert()
    {
      // Arrange
      var tree = new AVLTree<string>();

      // Act
      tree.Insert("hello", balanceWhileInserting:false);
      tree.Insert("world", balanceWhileInserting:false);

      // Assert
      Assert.Equal("hello", tree.Root.Value);
      Assert.Equal(0, tree.Height());
      Assert.Equal(1, tree.Root.Count);
    }

  }
}