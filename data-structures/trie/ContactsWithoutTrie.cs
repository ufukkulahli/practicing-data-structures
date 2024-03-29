using System.Collections.Generic;

namespace practicing_data_structures.data_structures.trie
{
  public sealed class ContactsWithoutTrie
  {

    public int[] AddOrFind(string[][] queries)
    {
      var results = new List<int>();

      for(var i=0; i<queries.Length; i++)
      {
        var queryIsFind = QueryIsFind(queries[i]);

        if (queryIsFind)
        {
          var toBeFound = ToBeFound(queries[i]);
          var occurenceOfToBeFound = OccurenceCount(toBeFound, queries, toBeFoundIndex:(i-1));
          results.Add(occurenceOfToBeFound);
        }
      }

      return results.ToArray();
    }

    public bool QueryIsAdd(string[] query)  => query[0] == "add";
    public bool QueryIsFind(string[] query) => query[0] == "find";
    public string ToBeFound(string[] query) => query[1];

    public int OccurenceCount(string toBeFound, string[][]queries, int toBeFoundIndex)
    {
      var occurence = 0;

      for(var i=toBeFoundIndex; i>=0; i--)
      {
        if(QueryIsFind(queries[i]))
        {
          continue;
        }

        var hasFound = queries[i][1].StartsWith(toBeFound);
        if (hasFound)
        {
          occurence++;
        }
      }

      return occurence;
    }

  }
}