using practicing_data_structures.data_structures.trie;
using Xunit;

namespace practicing_data_structures.tests.trie
{
  public class ContactsTests
  {

    [Fact]
    public void AddOrFindTest()
    {
      // Arrange
      var query   = new string[2];
      query[0]    = "add";
      query[1]    = "hack";

      var queries = new string[1][];
      queries[0]  = query;

      // Act
      System.Func<object> invokeAddOrFind =
        () => new Contacts().AddOrFind(queries);

      // Assert
      Assert.Throws<System.NotImplementedException>( invokeAddOrFind );
    }

    [Fact]
    public void QueryIsAdd()
    { 
      // Arrange
      var query = new string[2];
      query[0]  = "add";
      query[1]  = "hack";

      // Act
      var queryIsAdd = new Contacts().QueryIsAdd(query);

      // Assert
      Assert.True(queryIsAdd);
    }

  }
}