namespace practicing_data_structures.data_structures.lists
{
  public sealed class SkipList<T>
  {
    public SkipListNode<T> Head {get; private set;} = new SkipListNode<T>();
    public int Height {get => Head.Height;}

    public void Add(T value)
    {
      throw new System.NotImplementedException();
    }
  }
}