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
      UpdateNodeCount();

      var nodeToBeAppended = new Node<T>(item);

      if(HeadNode == null)
      {
        headNode = tailNode = nodeToBeAppended;
        return;
      }

      var currentTailNode = tailNode;
      currentTailNode.Next = nodeToBeAppended;
      nodeToBeAppended.Previous = currentTailNode;
      tailNode = nodeToBeAppended;
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

      var currentHeadNode      = headNode;
      nodeToBePrepended.Next   = currentHeadNode;
      currentHeadNode.Previous = nodeToBePrepended;
      headNode                 = nodeToBePrepended;
    }

    public Node<T> FindNode(T item)
    {
      ThrowIfEmpty();

      var currentNode = headNode;

      while(currentNode != null)
      {
        if(currentNode.Same(item))
        {
          return currentNode;
        }
        currentNode = currentNode.Next;
      }

      throw new Exception("Item does not exist!");
    }

    Node<T> FindNodeAt(int index)
    {
      var currentNode = headNode;
      var order = 0;

      while(order < index)
      {
        currentNode = currentNode.Next;
        order++;
      }
      return currentNode;
    }

    public void InsertAt(int index, T item)
    {
      if(index == 0)
      {
        Prepend(item);
        return;
      }

      if(index == Count)
      {
        Append(item);
        return;
      }

      ThrowIfOutOfRange(index);

      var previousNodeOf_NodeToBeInserted = GetNodeAt(index-1);
      var previousNodes_NextNode          = previousNodeOf_NodeToBeInserted.Next;
      var newNodeToBeInserted             = new Node<T>(item);

      if(previousNodes_NextNode != null)
      {
        previousNodeOf_NodeToBeInserted.Next.Previous = newNodeToBeInserted;
      }

      newNodeToBeInserted.Next                = previousNodes_NextNode;
      previousNodeOf_NodeToBeInserted.Next    = newNodeToBeInserted;
      newNodeToBeInserted.Previous            = previousNodeOf_NodeToBeInserted;
      UpdateNodeCount();
    }

    public void Clear()
    {
      nodeCount = 0;
      headNode = tailNode = null;
    }

    public void Remove(T item)
    {
      ThrowIfEmpty();

      if(headNode.Same(item))
      {
        RemoveHeadNode();
        return;
      }

      if(tailNode.Same(item))
      {
        RemoveTailNode();
        return;
      }

      var foundNode       = FindNode(item);
      var newPreviousNode = foundNode.Previous;
      var newNextNode     = foundNode.Next;

      if(newPreviousNode != null)
      {
        newPreviousNode.Next = newNextNode;
      }
      if(newNextNode != null)
      {
        newNextNode.Previous = newPreviousNode;
      }
      DecreaseNodeCount();
    }

    public void RemoveAt(int index)
    {
      ThrowIfEmpty();
      ThrowIfOutOfRange(index);
      if(index == 0)
      {
        RemoveHeadNode();
        return;
      }
      if(LastItem(index))
      {
        RemoveTailNode();
        return;
      }

      var foundNode       = FindNodeAt(index);
      var newPreviousNode = foundNode.Previous;
      var newNextNode     = foundNode.Next;

      newPreviousNode.Next = newNextNode;
      newNextNode.Previous = newPreviousNode;
      DecreaseNodeCount();
    }

    void RemoveHeadNode()
    {
      headNode = headNode.Next;
      if(headNode != null)
      {
        headNode.Previous = null;
      }
      DecreaseNodeCount();
    }

    void RemoveTailNode()
    {
      tailNode = tailNode.Previous;
      tailNode.Next = null;
      DecreaseNodeCount();
    }

    public bool IsEmpty() => Count == 0;

    public int Count { get => nodeCount; }
    public T First   { get { ThrowIfEmpty(); return headNode.Value; } }
    public T Last    { get { ThrowIfEmpty(); return tailNode.Value; } }
    public Node<T> HeadNode { get => headNode; }
    public Node<T> TailNode { get => tailNode; }

    void ThrowIfEmpty()
    {
      if(IsEmpty())
      {
        throw new Exception("No items in the list!");
      }
    }

    void ThrowIfOutOfRange(int index)
    {
      if(index < 0 || index > Count)
      {
        throw new IndexOutOfRangeException();
      }
    }

    Node<T> GetNodeAt(int index)
    {
      var currentNode = headNode;
      for(var i=0; i < index; i++)
      {
        currentNode = currentNode.Next;
      }
      return currentNode;
    }

    void UpdateNodeCount() => nodeCount++;
    void DecreaseNodeCount() => nodeCount--;
    bool LastItem(int index) => index == Count - 1;
  }
}