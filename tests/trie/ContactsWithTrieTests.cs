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
      Assert.Throws<System.NotImplementedException>( () => new TrieNode().AddChild('a'));
    }

    [Fact]
    public void GetChildTest()
    {
      Assert.Throws<System.NotImplementedException>( () => new TrieNode().GetChild('a'));
    }

  }

}