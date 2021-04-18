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

    [Fact]
    public void BracketsBalanced1()
    {
      // Arrange
      var bracketOpen = '{';
      var bracketClose = '}';

      // Act
      var isBalanced = new BalancedBrackets().IsBalanced(bracketOpen, bracketClose);

      // Assert
      Assert.True(isBalanced);
    }

    [Fact]
    public void BracketsBalanced2()
    {
      // Arrange
      var bracketOpen = '[';
      var bracketClose = ']';

      // Act
      var isBalanced = new BalancedBrackets().IsBalanced(bracketOpen, bracketClose);

      // Assert
      Assert.True(isBalanced);
    }

    [Fact]
    public void BracketsBalanced3()
    {
      // Arrange
      var bracketOpen = '(';
      var bracketClose = ')';

      // Act
      var isBalanced = new BalancedBrackets().IsBalanced(bracketOpen, bracketClose);

      // Assert
      Assert.True(isBalanced);
    }

    [Fact]
    public void BracketsNotBalanced()
    {
      // Arrange
      var bracketOpen = '(';
      var bracketClose = ']';

      // Act
      var isBalanced = new BalancedBrackets().IsBalanced(bracketOpen, bracketClose);

      // Assert
      Assert.False(isBalanced);
    }

  }
}