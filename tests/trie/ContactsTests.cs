using practicing_data_structures.data_structures.trie;
using Xunit;

namespace practicing_data_structures.tests.trie
{
  public class ContactsTests
  {

    [Fact]
    public void Test()
    {
      Assert.Throws<System.NotImplementedException>( () => new Contacts().AddOrFind(null) );
    }

  }
}