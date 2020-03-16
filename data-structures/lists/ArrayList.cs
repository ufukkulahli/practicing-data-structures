using System;

namespace practicing_data_structures.data_structures.lists
{
  public sealed class ArrayList<T>
  {
    int size  = 0;
    T[] items = new T[0];

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

    bool HasNotEnoughCapacity()            => size == items.Length;
    void ExpandCapacity()                  => Array.Resize<T>(ref items, NewCapacitySize());
    int NewCapacitySize()                  => NoItems() ? 1 : items.Length * 2;
    bool NoItems()                         => 0 == items.Length;
    bool ExistAt(int index)                => index >= 0;
    int IndexOf(T item)                    => Array.IndexOf(items, item);
    void DecreaseSize()                    => size--;
    int SourceIndexOf(int index)           => index + 1;
    int numberOfElementsToCopy(int index)  => (size - index);
    bool NeedToCopyItems(int index)        => index < size;
    void ResetCell()                       => items[size] = default(T);
    void RemoveAt(int index)
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