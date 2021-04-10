namespace practicing_data_structures.data_structures.trie
{
  public sealed class Contacts
  {

    public int[] AddOrFind(string[][] queries)
    {
      for(var i=0; i<queries.Length; i++)
      {
        var queryIsAdd = QueryIsAdd(queries[i]);

        if (queryIsAdd)
        {
          // TODO
        }
      }

      throw new System.NotImplementedException();
    }

    public bool QueryIsAdd(string[] query)
    {
      return
        query[0] == "add";
    }

  }
}