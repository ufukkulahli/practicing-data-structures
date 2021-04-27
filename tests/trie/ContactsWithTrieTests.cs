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
      Assert.Throws<System.NotImplementedException>( () => new Trie().Add(null));
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