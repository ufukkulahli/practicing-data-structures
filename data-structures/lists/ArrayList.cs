using System;

namespace practicing_data_structures.data_structures.lists
{
  public class ArrayList<T>
  {
    private int size  = 0;
    private T[] items = new T[0];

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

    private bool HasNotEnoughCapacity()  => size == items.Length;
    private void ExpandCapacity()        => Array.Resize<T>(ref items, NewCapacitySize());
    private int NewCapacitySize()        => NoItems() ? 1 : items.Length * 2;
    private bool NoItems()               => items.Length == 0;
  }
}