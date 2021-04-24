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
      var queries = Queries();

      // Act
      var results = new ContactsWithoutTrie().AddOrFind(queries);

      // Assert
      Assert.Equal(2, results[0]);
      Assert.Equal(0, results[1]);
    }

    [Fact]
    public void AddOrFindTest2()
    {
      // Arrange
      var query1   = new string[2];
      query1[0]    = "add";
      query1[1]    = "ed";

      var query2   = new string[2];
      query2[0]    = "add";
      query2[1]    = "eddie";

      var query3   = new string[2];
      query3[0]    = "add";
      query3[1]    = "edward";

      var query4   = new string[2];
      query4[0]    = "find";
      query4[1]    = "ed";

      var query5   = new string[2];
      query5[0]    = "add";
      query5[1]    = "edwina";

      var query6   = new string[2];
      query6[0]    = "find";
      query6[1]    = "edw";

      var query7   = new string[2];
      query7[0]    = "find";
      query7[1]    = "a";

      var queries = new string[7][];
      queries[0]  = query1;
      queries[1]  = query2;
      queries[2]  = query3;
      queries[3]  = query4;
      queries[4]  = query5;
      queries[5]  = query6;
      queries[6]  = query7;

      // Act
      var results = new ContactsWithoutTrie().AddOrFind(queries);

      // Assert
      Assert.Equal(3, results[0]);
      Assert.Equal(2, results[1]);
      Assert.Equal(0, results[2]);
    }

    [Fact]
    public void AddOrFindTest3()
    {
      // Arrange
      var query1   = new string[2];
      query1[0]    = "add";
      query1[1]    = "bad";

      var query2   = new string[2];
      query2[0]    = "add";
      query2[1]    = "dad";

      var query3   = new string[2];
      query3[0]    = "add";
      query3[1]    = "bat";

      var query4   = new string[2];
      query4[0]    = "find";
      query4[1]    = "pad";

      var query5   = new string[2];
      query5[0]    = "find";
      query5[1]    = "ba";

      var queries = new string[5][];
      queries[0]  = query1;
      queries[1]  = query2;
      queries[2]  = query3;
      queries[3]  = query4;
      queries[4]  = query5;

      // Act
      var results = new ContactsWithoutTrie().AddOrFind(queries);

      // Assert
      Assert.Equal(0, results[0]);
      Assert.Equal(2, results[1]);
    }

    [Fact]
    public void AddOrFindTest4()
    {
      // Arrange
      var query1   = new string[2];
      query1[0]    = "find";
      query1[1]    = "joe";

      var query2   = new string[2];
      query2[0]    = "add";
      query2[1]    = "joe";

      var query3   = new string[2];
      query3[0]    = "find";
      query3[1]    = "jo";

      var query4   = new string[2];
      query4[0]    = "add";
      query4[1]    = "john";

      var query5   = new string[2];
      query5[0]    = "find";
      query5[1]    = "j";

      var queries = new string[5][];
      queries[0]  = query1;
      queries[1]  = query2;
      queries[2]  = query3;
      queries[3]  = query4;
      queries[4]  = query5;

      // Act
      var results = new ContactsWithoutTrie().AddOrFind(queries);

      // Assert
      Assert.Equal(0, results[0]);
      Assert.Equal(1, results[1]);
      Assert.Equal(2, results[2]);
    }

    [Fact]
    public void QueryIsAdd()
    { 
      // Arrange
      var query = new string[2];
      query[0]  = "add";
      query[1]  = "hack";

      // Act
      var queryIsAdd = new ContactsWithoutTrie().QueryIsAdd(query);

      // Assert
      Assert.True(queryIsAdd);
    }

    [Fact]
    public void FindTest()
    {
      // Arrange
      var queries = Queries();
      var toBeFound = "hac";

      // Act
      var occurence = new ContactsWithoutTrie().OccurenceCount(toBeFound, queries, (queries.Length-1));

      // Assert
      Assert.Equal(2, occurence);
    }

    [Fact]
    public void ToBeFoundTest()
    {
      // Arrange
      var query = new string[2];
      query[0]  = "add";
      query[1]  = "hack";

      // Act
      var toBeFound = new ContactsWithoutTrie().ToBeFound(query);

      // Assert
      Assert.Equal("hack", toBeFound);
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
}