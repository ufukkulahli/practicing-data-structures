namespace practicing_data_structures.data_structures.lists
{
  public sealed class SkipListNode<T>
  {
    public SkipListNode<T>[] Forwards;
    public int Height { get => Forwards?.Length ?? 0; }

    public void IncreaseHeight()
    {
      throw new System.NotImplementedException();
    }

    public void DecreaseHeight()
    {
      throw new System.NotImplementedException();
    }

  }
}