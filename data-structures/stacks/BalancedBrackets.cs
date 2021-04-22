using System.Collections.Generic;

namespace practicing_data_structures.data_structures.stacks
{
  public sealed class BalancedBrackets
  {
    public string IsBalanced(string brackets)
    {
      var bracketsStack = new Stack<char>();

      for(var i=0;  i<brackets.Length;  i++)
      {
        var currentBracket = brackets[i];
        var isOpenBracket  = IsOpenBracket(currentBracket);

        if(isOpenBracket)
        {
          bracketsStack.Push(currentBracket);
          continue;
        }

        // Current bracket must be a 'closed-bracket'
        var latestOpenBracket = bracketsStack.Pop();
        var isNotBalanced = NotBalanced(latestOpenBracket, currentBracket);

        if(isNotBalanced)
        {
          return "NO";
        }

      }

      return "YES";
    }

    public bool IsOpenBracket(char bracket)
    {
      return
        bracket == '{' ||
        bracket == '(' ||
        bracket == '[';
    }

    private bool NotBalanced(char currBracketFromHead, char currBracketFromTail)
    {
      return !IsBalanced(currBracketFromHead, currBracketFromTail);
    }

    public bool IsBalanced(char currBracketFromHead, char currBracketFromTail)
    {
      if(currBracketFromHead=='{')
      {
        return currBracketFromTail=='}';
      }

      if(currBracketFromHead=='[')
      {
        return currBracketFromTail==']';
      }

      if(currBracketFromHead=='(')
      {
        return currBracketFromTail==')';
      }

      return false;
    }

  }
}