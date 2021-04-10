namespace practicing_data_structures.data_structures.trie
{
  public sealed class Contacts
  {

    public int[] AddOrFind(string[][] queries)
    {
      var results = new int[0];

      for(var i=0; i<queries.Length; i++)
      {
        var queryIsAdd = QueryIsAdd(queries[i]);

        if (queryIsAdd)
        {
          // TODO
        }
      }

      return results;
    }

    public bool QueryIsAdd(string[] query)
    {
      return
        query[0] == "add";
    }

  }
}