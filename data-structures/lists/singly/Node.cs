using System.Collections.Generic;

namespace practicing_data_structures.data_structures.lists.singly
{
  public sealed class Node<T>
  {
    public T value;
    public Node<T> Next;
    public Node(T value)                => this.value = value;
    public bool Same(T other)           => EqualityComparer<T>.Default.Equals(value, other);
    public bool NotSame(T other)        => ! Same(other);
    public override string ToString ()  => value.ToString();
  }
}