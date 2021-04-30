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
    public TrieNode root {get; private set;} = new TrieNode();

    public void Add(string contact)
    {
      var current = this.root;

      foreach(var letter in contact)
      {
        current.AddChild(letter);
        current = current.GetChild(letter);
        current.Size++;;
      }
    }

    public int Find(string contact)
    {
      var current = this.root;

      foreach(var letter in contact)
      {
        current = current.GetChild(letter);

        if(current == null)
        {
          return 0;
        }
      }

      return current.Size;
    }
  }

  public sealed class TrieNode
  {
    public readonly IDictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();

    public int Size = 0;

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