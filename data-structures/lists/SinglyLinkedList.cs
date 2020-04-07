namespace practicing_data_structures.data_structures.lists
{
  public sealed class Node<T>
  {
    T value;
    public Node<T> Next;
    public Node(T value) => this.value = value;
  }

  public sealed class SinglyLinkedList<T>
  {
    Node<T> headNode;
    Node<T> tailNode;
    int nodeCount;

    public void Append(T item)
    {
      UpdateNodeCount();
      var nodeToBeAppended = new Node<T>(item);

      if(headNode == null)
      {
        headNode = tailNode = nodeToBeAppended;
        return;
      }

      var currentTailNode    = tailNode;
      nodeToBeAppended.Next  = currentTailNode;
      tailNode               = nodeToBeAppended;
    }

    public int Count { get => nodeCount; }

    void UpdateNodeCount() => nodeCount++;
  }
}