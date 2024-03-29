using System.Collections.Generic;

namespace practicing_data_structures.data_structures.trie
{
  public sealed class ContactsWithTrie
  {
    public int[] AddOrFind(string[][] queries)
    {
      var occurences = new List<int>();
      var contacts = new Trie();

      for(var i=0; i<queries.Length; i++)
      {
        if(QueryIsAdd(queries[i]))
        {
          contacts.Add(queries[i][1]);
        }
        if(QueryIsFind(queries[i]))
        {
          var occurence = contacts.Find(queries[i][1]);
          occurences.Add(occurence);
        }
      }

      return occurences.ToArray();
    }

    public bool QueryIsAdd(string[] queries) => queries[0] == "add";
    public bool QueryIsFind(string[] queries) => queries[0] == "find";
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
      TrieNode childNode = null;
      if(children.TryGetValue(letter, out childNode))
      {
        return childNode;
      }

      return null;
    }
  }

}