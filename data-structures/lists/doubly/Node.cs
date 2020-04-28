namespace practicing_data_structures.data_structures.lists.doubly
{
  public sealed class Node<T>
  {
    public T Value { get; set; }
    public Node<T> Previous { get; set; }
    public Node<T> Next { get; set; }

    public Node(T value) : this (value, null, null) {}
    public Node(T value, Node<T> previous, Node<T> next)
    {
      Value    = value;
      Previous = previous;
      Next     = next;
    }
  }
}
