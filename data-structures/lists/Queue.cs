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

    public T Dequeue()
    {
      ThrowIfEmpty();
      var top = TopItem();
      RemoveTopItem();
      DecreaseSize();
      MoveHeadPointerToNextItem();
      ResetHeadPointerIfNeeded();
      // TODO: Implement shrinking managed internal array.
      return top;
    }

    public int Count    { get => size; }
    public bool IsEmpty { get => size == 0; }
    public T Top
    {
      get
      {
        ThrowIfEmpty();
        return TopItem();
      }
    }

    void ThrowIfEmpty()
    {
      if(IsEmpty)
      {
        throw new Exception("Queue is empty!");
      }
    }

    void ExpandCapacity()
    {
      var tempItems = new T[NewCapacitySize()];
      Array.Copy(items, headPointer, tempItems, 0, size);
      items = tempItems;
    }

    void ResetHeadPointerIfNeeded()          
    {
      if(NeedResettingHeadPointer())
      {
        ResetHeadPointer();
      }
    }
    void MoveHeadPointerToNextItem() => headPointer++;
    void DecreaseSize()              => size--;
    void RemoveTopItem()             => items[headPointer] = default(T);
    T TopItem()                      => items[headPointer];
    bool HasNotEnoughCapacity()      => size == items.Length;
    bool NeedResettingTailPointer () => tailPointer == items.Length;
    bool NeedResettingHeadPointer () => headPointer == items.Length;
    void ResetTailPointer ()         => tailPointer = 0;
    void ResetHeadPointer ()         => headPointer = 0;
    void IncrementSize()             => size++;
    int NewCapacitySize()            => NoItems() ? 1 : items.Length * 2;
    bool NoItems()                   => 0 == items.Length;
  }
}
