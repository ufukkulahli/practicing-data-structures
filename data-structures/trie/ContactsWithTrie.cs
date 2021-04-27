using System.Collections.Generic;

namespace practicing_data_structures.data_structures.trie
{
  public sealed class ContactsWithTrie
  {

    public void Add(string contact)
    {
      throw new System.NotImplementedException();
    }

    public void Find(string contact)
    {
      throw new System.NotImplementedException();
    }

  }

  public sealed class Trie
  {
    public void Add(string contact)
    {
      throw new System.NotImplementedException();
    }

    public int Find(string contact)
    {
      throw new System.NotImplementedException();
    }
  }

  public sealed class TrieNode
  {
    public readonly IDictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();

    public void AddChild(char letter)
    {
      if (!children.ContainsKey(letter))
      {
        children.Add(letter, new TrieNode());
      }
    }

    public TrieNode GetChild(char letter)
    {
      return children[letter];
    }
  }

}