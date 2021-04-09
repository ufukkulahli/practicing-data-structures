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

    [Fact]
    public void QueryIsAdd()
    { 
      // Arrange
      var query = new string[2];
      query[0]  = "add";
      query[1]  = "hack";

      // Act
      var queryIsAdd = new Contacts().Add(query);

      // Assert
      Assert.True(queryIsAdd);
    }

  }
}