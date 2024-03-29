using System;

namespace practicing_data_structures.data_structures.lists
{
  public sealed class SkipListNode<T> where T: IComparable<T>
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

    public SkipListNode<T> this[int height]
    {
      get
      {
          ThrowIfInvalid(height);
          return this.Forwards[height];
      }
      set
      {
          ThrowIfInvalid(height);
          this.Forwards[height] = value;
      }
    }

    public void ThrowIfInvalid(int height)
    {
      if (height < 0 || height >= this.Height)
      {
        throw new System.IndexOutOfRangeException();
      }
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
      if(this.Height==1)
      {
        return;
      }

      var forwards = new SkipListNode<T>[this.Height-1];

      for(var i=0; i<this.Height-1; i++)
      {
        forwards[i] = this.Forwards[i];
      }

      this.Forwards = forwards;
    }

    public void Reset()
    {
      this.Forwards = null;
    }

  }
}