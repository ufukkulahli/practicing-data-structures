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
      var forwards = new SkipListNode<T>[this.Height+1];

      for(var i=0; i<this.Height; i++)
      {
        forwards[i] = this.Forwards[i];
      }

      this.Forwards = forwards;
    }

    public void DecreaseHeight()
    {
      throw new System.NotImplementedException();
    }

    public void Reset()
    {
      this.Forwards = null;
    }

  }
}