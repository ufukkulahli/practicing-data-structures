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
      Assert.Throws<System.NotImplementedException>( () => new ContactsWithTrie().Add(null));
    }

    [Fact]
    public void FindTest()
    {
      Assert.Throws<System.NotImplementedException>( () => new ContactsWithTrie().Find(null));
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
      Assert.Throws<System.NotImplementedException>( () => new Trie().Find(null));
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