using System;

namespace practicing_data_structures.data_structures.lists
{
  public sealed class ArrayList<T>
  {
    int size  = 0;
    T[] items = new T[0];

    public int Count()    => size;
    public int Capacity() => items.Length;

    public void Add(T item)
    {
      if(HasNotEnoughCapacity())
      {
        ExpandCapacity();
      }
      items[size++] = item;
    }

    bool HasNotEnoughCapacity()  => size == items.Length;
    void ExpandCapacity()        => Array.Resize<T>(ref items, NewCapacitySize());
    int NewCapacitySize()        => NoItems() ? 1 : items.Length * 2;
    bool NoItems()               => 0 == items.Length;
  }
}