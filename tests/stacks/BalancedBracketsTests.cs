using Xunit;
using practicing_data_structures.data_structures.stacks; 

namespace practicing_data_structures.tests.stacks
{
  public class BalancedBracketsTests
  {
    [Fact]
    public void Test()
    {
      Assert.Throws<System.NotImplementedException>( () => new BalancedBrackets().IsBalanced(null) );
    }
  }
}