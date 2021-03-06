using System;
using System.Collections;
using System.Collections.Generic;

namespace practicing_data_structures.data_structures.lists
{
  public sealed class ArrayList<T> : IEnumerable<T>
  {
    int size  = 0;
    T[] items = new T[0];

    public IEnumerator<T> GetEnumerator()
    {
      for(var i=0; i < Count(); i++)
      {
        yield return items[i];
      }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public int Count()    => size;
    public int Capacity() => items.Length;
    public bool IsEmpty() => items.Length == 0;

    public void Add(T item)
    {
      if(HasNotEnoughCapacity())
      {
        ExpandCapacity();
      }
      items[size++] = item;
    }

    public bool Remove(T item)
    {
      var indexOfItem = IndexOf(item);
      if(ExistAt(indexOfItem))
      {
        RemoveAt(indexOfItem);
        return true;
      }
      return false;
    }

    public T First()
    {
      if(Count() == 0)
      {
        throw new IndexOutOfRangeException("No items!");
      }
      return items[0];
    }

    public T Last()
    {
      if(IsEmpty())
      {
        throw new IndexOutOfRangeException("No items!");
      }
      return items[Count() - 1];
    }

    public void Clear()
    {
      size = 0;
      Array.Clear(items, 0, size);
      items = new T[0];
    }

    public T Find(Predicate<T> p)
    {
      for(var i=0; i<size; ++i)
      {
        if(p(items[i]))
        {
          return items[i];
        }
      }
      return default(T);
    }

    public T this[int index]
    {
      get
      {
        CheckIfIndexInRange(index);
        return items[index];
      }
      set
      {
        CheckIfIndexInRange(index);
        items[index] = value;
      }
    }

    void ExpandCapacity()                  => Array.Resize<T>(ref items, NewCapacitySize());
    int NewCapacitySize()                  => NoItems() ? 1 : items.Length * 2;
    bool NoItems()                         => 0 == items.Length;
    bool ExistAt(int index)                => index >= 0;
    int IndexOf(T item)                    => Array.IndexOf(items, item);
    int SourceIndexOf(int index)           => index + 1;

    bool HasNotEnoughCapacity()            => size == items.Length;
    void ResetCell()                       => items[size] = default(T);

    void DecreaseSize()                    => size--;
    int numberOfElementsToCopy(int index)  => (size - index);
    bool NeedToCopyItems(int index)        => index < size;
    void CheckIfIndexInRange(int index)
    {
      if(index<0 || index>=size)
      {
        throw new IndexOutOfRangeException();
      }
    }

    public void RemoveAt(int index)
    {
      DecreaseSize();
      if (NeedToCopyItems(index))
      {
        Array.Copy(items, SourceIndexOf(index), items, index, numberOfElementsToCopy(index));
      }
      ResetCell();
    }
  }
}
