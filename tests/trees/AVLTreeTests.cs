using practicing_data_structures.data_structures.trees;
using Xunit;

namespace practicing_data_structures.tests.trees
{
  public class AVLTreeTests
  {
    [Fact]
    public void Test()
    {
      Assert.Equal(0, new AVLTree().Count);
    }
  }
}