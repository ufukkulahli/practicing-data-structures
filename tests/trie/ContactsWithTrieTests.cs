using practicing_data_structures.data_structures.trie;
using Xunit;

namespace practicing_data_structures.tests.trie
{
  public class ContactsWithTrieTests
  {

    [Fact]
    public void Test()
    {
      Assert.Throws<System.NotImplementedException>( () => new ContactsWithTrie().Add(null));
    }

  }
}