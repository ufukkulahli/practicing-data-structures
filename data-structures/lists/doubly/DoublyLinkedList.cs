using System;

namespace practicing_data_structures.data_structures.lists.doubly
{
  public sealed class DoublyLinkedList<T>
  {
    int nodeCount;
    Node<T> headNode;
    Node<T> tailNode;

    public void Append(T item)
    {
      throw new NotImplementedException();
    }

    public bool IsEmpty() => Count == 0;

    public int Count { get => nodeCount; }
    public T First   { get { ThrowIfEmpty(); return headNode.Value; } }
    public T Last    { get { ThrowIfEmpty(); return tailNode.Value; } }
    public Node<T> HeadNode { get => headNode; }
    public Node<T> TailNode { get => tailNode; }

    public void Clear()
    {
      nodeCount = 0;
      headNode = tailNode = null;
    }

    void ThrowIfEmpty()
    {
      if(IsEmpty())
      {
        throw new Exception("No items in the list!");
      }
    }
  }
}