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

  }
}