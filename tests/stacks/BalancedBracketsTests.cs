using Xunit;
using practicing_data_structures.data_structures.stacks; 

namespace practicing_data_structures.tests.stacks
{
  public class BalancedBracketsTests
  {
    [Fact]
    public void Test()
    {
      // Arrange
      var brackets = "{[()]}";
      var bb = new BalancedBrackets();

      // Act
      var isBalanced = bb.IsBalanced(brackets);

      // Assert
      Assert.Equal("YES", isBalanced);
    }

    [Fact]
    public void BracketsAreNotBalanced()
    {
      // Arrange
      var brackets = "{[(}]}";
      var bb = new BalancedBrackets();

      // Act
      var isBalanced = bb.IsBalanced(brackets);

      // Assert
      Assert.Equal("NO", isBalanced);
    }

    [Fact]
    public void BracketsAreBalanced()
    {
      // Arrange
      var brackets = "{(([])[])[]}";
      var bb = new BalancedBrackets();

      // Act
      var isBalanced = bb.IsBalanced(brackets);

      // Assert
      Assert.Equal("YES", isBalanced);
    }

    [Fact]
    public void BracketsAreNotBalanced2()
    {
      // Arrange
      var brackets = "{(([])[])[]]}";
      var bb = new BalancedBrackets();

      // Act
      var isBalanced = bb.IsBalanced(brackets);

      // Assert
      Assert.Equal("NO", isBalanced);
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

    [Fact]
    public void BracketsAreOpen()
    {
      Assert.True(new BalancedBrackets().IsOpenBracket('{'));
      Assert.True(new BalancedBrackets().IsOpenBracket('('));
      Assert.True(new BalancedBrackets().IsOpenBracket('['));
    }

    [Fact]
    public void BracketAreNotOpen()
    {
      Assert.False(new BalancedBrackets().IsOpenBracket('}'));
      Assert.False(new BalancedBrackets().IsOpenBracket(')'));
      Assert.False(new BalancedBrackets().IsOpenBracket(']'));
    }

  }
}