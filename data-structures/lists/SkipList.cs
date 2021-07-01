namespace practicing_data_structures.data_structures.lists
{
  public sealed class SkipList<T>
  {
    public SkipListNode<T> Head {get; private set;} = new SkipListNode<T>(default(T), 1);
    public int Height {get => Head.Height;}
    public int Count { get; private set;} = 0;

    public void Add(T value)
    {
      throw new System.NotImplementedException();
    }

    public void Remove(T value)
    {
      throw new System.NotImplementedException();
    }

    public void Reset()
    {
      var currentNode = this.Head;
      var lastNode    = this.Head;

      while(currentNode!=null)
      {
        currentNode = currentNode.Forwards[0];
        lastNode.Reset();
        lastNode = currentNode;
      }

      this.Head = new SkipListNode<T>(default(T), 1);
      this.Count = 0;
    }

  }
}
