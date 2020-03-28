using System;

namespace practicing_data_structures.data_structures.lists
{
  public sealed class Queue<T>
  {
    int size;
    int headPointer;
    int tailPointer;
    T[] items = new T[0];

    public void Enqueue(T item)
    {
      if(HasNotEnoughCapacity())
      {
        ExpandCapacity();
      }
      items[tailPointer++] = item;
      if(NeedResettingTailPointer())
      {
        ResetTailPointer();
      }
      IncrementSize();
    }

    public int Count    { get => size; }
    public bool IsEmpty { get => size == 0; }
    public T Top
    {
      get
      {
        if(IsEmpty)
        {
          throw new Exception("Queue is empty!");
        }
        return items[headPointer];
      }
    }

    void ExpandCapacity()
    {
      var tempItems = new T[NewCapacitySize()];
      Array.Copy(items, headPointer, tempItems, 0, size);
      items = tempItems;
    }
    bool HasNotEnoughCapacity()      => size == items.Length;
    bool NeedResettingTailPointer () => tailPointer == items.Length;
    void ResetTailPointer ()         => tailPointer = 0;
    void IncrementSize()             => size++;
    int NewCapacitySize()            => NoItems() ? 1 : items.Length * 2;
    bool NoItems()                   => 0 == items.Length;
  }
}
