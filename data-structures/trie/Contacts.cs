namespace practicing_data_structures.data_structures.trie
{
  public sealed class Contacts
  {

    public int[] AddOrFind(string[][] queries)
    {
      for(var i=0; i<queries.Length; i++)
      {
        if(Add(queries[0]))
        {
          // TODO
        }
      }

      throw new System.NotImplementedException();
    }

    public bool Add(string[] query)
    {
      return
        query[0] == "add";
    }

  }
}