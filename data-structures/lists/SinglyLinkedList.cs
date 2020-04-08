namespace practicing_data_structures.data_structures.lists
{
  public sealed class Node<T>
  {
    public T value;
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

    public void Prepend(T item)
    {
      UpdateNodeCount();
      var nodeToBePrepended = new Node<T>(item);

      if(headNode == null)
      {
        headNode = tailNode = nodeToBePrepended;
        return;
      }

      var currentHeadNode    = headNode;
      nodeToBePrepended.Next = currentHeadNode;
      headNode               = nodeToBePrepended;
    }

    public bool IsEmpty()  => nodeCount == 0;
    public int Count { get => nodeCount; }
    public T First   { get => headNode == null ? default(T) : headNode.value; }
    public T Last    { get => tailNode == null ? default(T) : tailNode.value; }

    void UpdateNodeCount() => nodeCount++;
  }
}
