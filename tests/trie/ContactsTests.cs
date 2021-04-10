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

      // Act
      var results = new Contacts().AddOrFind(queries);

      // Assert
      Assert.Empty(results);
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