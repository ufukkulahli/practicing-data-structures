namespace practicing_data_structures.data_structures.lists
{
  public sealed class Node<T>
  {
    T value;
    Node<T> Next;
    public Node(T value) => this.value = value;
  }

  public sealed class SinglyLinkedList<T>
  {
    Node<T> head;
  }
}