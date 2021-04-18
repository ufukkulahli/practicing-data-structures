namespace practicing_data_structures.data_structures.stacks
{
  public sealed class BalancedBrackets
  {
    public string IsBalanced(string brackets)
    {
      throw new System.NotImplementedException();
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