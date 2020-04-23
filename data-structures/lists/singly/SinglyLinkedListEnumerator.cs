using System.Collections.Generic;
using practicing_data_structures.data_structures.lists.singly;

namespace practicing_data_structures.lists.singly
{
  public sealed class SinglyLinkedListEnumerator<T> : IEnumerator<T>
  {
    SinglyLinkedList<T> list;
    Node<T> current;

    public SinglyLinkedListEnumerator(SinglyLinkedList<T> sll)
    {
      list = sll;
      current = sll.FirstNode;
    }

    object System.Collections.IEnumerator.Current  => Current;
    public T Current                               => current.value;
    public void Reset()                            => current = list.FirstNode;

    public bool MoveNext()
    {
      current = current.Next;
      return HasNext();
    }

    public void Dispose()
    {
      current  = null;
      list     = null;
    }

    bool HasNext() => current != null;
  }
}