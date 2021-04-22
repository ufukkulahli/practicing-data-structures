namespace practicing_data_structures.data_structures.stacks
{
  public sealed class BalancedBrackets
  {
    public string IsBalanced(string brackets)
    {
      var headPtr = 0;
      var tailPtr = (brackets.Length-1);
      var itr     = (brackets.Length/2);

      for(var i=0; i<itr; i++)
      {
        var currBracketFromHead = brackets[headPtr];
        var currBracketFromTail = brackets[tailPtr];

        var notBalanced = NotBalanced(currBracketFromHead, currBracketFromTail);

        if(notBalanced)
        {
          return "NO";
        }

        headPtr++;
        tailPtr--;
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