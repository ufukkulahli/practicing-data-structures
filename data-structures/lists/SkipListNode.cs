namespace practicing_data_structures.data_structures.lists
{
  public sealed class SkipListNode<T>
  {
    public T Value {get; private set;}
    public SkipListNode<T>[] Forwards;
    public int Height { get => Forwards.Length; }

    public SkipListNode(T value, int height)
    {
      if(height<1)
      {
        throw new System.ArgumentException();
      }
      this.Value = value;
      this.Forwards = new SkipListNode<T>[height];
    }

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