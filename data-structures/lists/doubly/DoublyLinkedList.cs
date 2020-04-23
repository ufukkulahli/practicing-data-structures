using System;

namespace practicing_data_structures.data_structures.lists.doubly
{
  public sealed class DoublyLinkedList<T>
  {
    int nodeCount;

    public void Append(T item)
    {
      throw new NotImplementedException();
    }

    public int Count   { get => nodeCount; }
    public bool IsEmpty() => Count == 0;
  }
}
