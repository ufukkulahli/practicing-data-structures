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
    public void FindTest()
    {
      // Arrange
      var parent = new AVLTreeNode<string>();
      parent.Value = "hello";

      // Act
      var node = new AVLTree<string>().Find(parent, "hello");

      // Assert
      Assert.Equal(parent, node);
    }

  }
}