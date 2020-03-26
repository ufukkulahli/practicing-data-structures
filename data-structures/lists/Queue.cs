using System;
using System.Collections;
using System.Collections.Generic;

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
      throw new NotImplementedException();
      if(HasNotEnoughCapacity())
      {
        // TODO: implement
      }
      items[tailPointer++] = item;
      if(NeedResettingTailPointer())
      {
        ResetTailPointer();
      }
      IncrementSize();
    }

    bool HasNotEnoughCapacity()=> size == items.Length;
    bool NeedResettingTailPointer () => tailPointer == items.Length;
    void ResetTailPointer () => tailPointer = 0;
    void IncrementSize() => size++;
  }
}