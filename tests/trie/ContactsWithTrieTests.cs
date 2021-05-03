using System.Linq;
using practicing_data_structures.data_structures.trie;
using Xunit;

namespace practicing_data_structures.tests.trie
{
  public class ContactsWithTrieTests
  {

    [Fact]
    public void AddTest()
    {
      // Arrange
      var queries = Queries();
      var contacts = new ContactsWithTrie();

      // Act
      var result = contacts.AddOrFind(queries);

      // Should be
      Assert.Equal(2, result[0]);
      Assert.Equal(0, result[1]);
    }

    [Fact]
    public void QueryTests()
    {
      Assert.True(new ContactsWithTrie().QueryIsAdd(new string[1]{"add"}));
      Assert.False(new ContactsWithTrie().QueryIsAdd(new string[1]{"addd"}));
      Assert.True(new ContactsWithTrie().QueryIsFind(new string[1]{"find"}));
      Assert.False(new ContactsWithTrie().QueryIsFind(new string[1]{"findd"}));
    }

    private string[][] Queries()
    {
      var query1   = new string[2];
      query1[0]    = "add";
      query1[1]    = "hack";

      var query2   = new string[2];
      query2[0]    = "add";
      query2[1]    = "hackerrank";

      var query3   = new string[2];
      query3[0]    = "find";
      query3[1]    = "hac";

      var query4   = new string[2];
      query4[0]    = "find";
      query4[1]    = "hak";

      var queries = new string[4][];
      queries[0]  = query1;
      queries[1]  = query2;
      queries[2]  = query3;
      queries[3]  = query4;

      return queries;
    }

  }

  public class TrieTests
  {

    [Fact]
    public void AddTest()
    {
      // Arrange
      var trie = new Trie();

      // Act
      trie.Add("joe");

      // Assert
      Assert.Equal('j', trie.root.children.Single().Key);
      Assert.Equal('o', trie.root.children.Single().Value.children.Single().Key);
      Assert.Equal('e', trie.root.children.Single().Value.children.Single().Value.children.Single().Key);
    }

    [Fact]
    public void AddTest2()
    {
      // Arrange
      var trie = new Trie();

      // Act && Assert
      trie.Add("joe");
      Assert.Equal('j', trie.root.children.Single().Key);
      Assert.Equal('o', trie.root.children.Single().Value.children.Single().Key);
      Assert.Equal('e', trie.root.children.Single().Value.children.Single().Value.children.Single().Key);

      // Act && Assert
      trie.Add("jon");
      Assert.Equal('j', trie.root.children.Single().Key);
      Assert.Equal('o', trie.root.children.Single().Value.children.Single().Key);
      Assert.Equal('e', trie.root.children.Single().Value.children.Single().Value.children.First().Key);
      Assert.Equal('n', trie.root.children.Single().Value.children.Single().Value.children.Last().Key);
    }

    [Fact]
    public void FindTest()
    {
      // Arrange
      var trie = new Trie();
      trie.Add("joe");
      trie.Add("jon");

      // Act
      var occurence = trie.Find("jo");

      // Assert
      Assert.Equal(2, occurence);
    }

  }

  public class TrieNodeTests
  {

    [Fact]
    public void AddChildTest()
    {
      // Arrange
      var trieNode = new TrieNode();

      // Act
      trieNode.AddChild('a');
      trieNode.AddChild('b');

      // Assert
      Assert.Equal(2, trieNode.children.Count);
      Assert.Equal('a', trieNode.children.Keys.First());
      Assert.Equal('b', trieNode.children.Keys.Last());
    }

    [Fact]
    public void GetChildTest()
    {
      // Arrange
      var trieNode = new TrieNode();
      trieNode.AddChild('a');
      trieNode.AddChild('b');

      // Act
      var tn = trieNode.GetChild('b');

      // Assert
      Assert.Empty(tn.children);
    }

  }

}