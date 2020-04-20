using System;
using System.Collections.Generic;
using practicing_data_structures.lists;

namespace practicing_data_structures.data_structures.lists
{
  public sealed class SinglyLinkedList<T> : IEnumerable<T>
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
      currentTailNode.Next   = nodeToBeAppended;
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

    public Node<T> GetNode(int index)
    {
      if(index == 0)
      {
        return FirstNode;
      }
      if(AtTail(index))
      {
        return LastNode;
      }
      ThrowIfOutOfRange(index);
      return NodeAt(index);
    }

    public void Clear()
    {
      headNode = tailNode = null;
      nodeCount = 0;
    }

    public void InsertAt(T item, int index)
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

      var newNodeToBeInserted  = new Node<T>(item);
      var nodeAtIndex          = NodeAt(index);
      newNodeToBeInserted.Next = nodeAtIndex.Next;
      nodeAtIndex.Next         = newNodeToBeInserted;

      UpdateNodeCount();
    }

    public void DeleteItem(T item)
    {
      var currentNode   = headNode;
      Node<T> previousNode = null;

      if(currentNode != null && currentNode.Same(item))
      {
        headNode = currentNode.Next;
        return;
      }

      while(currentNode != null && currentNode.NotSame(item))
      {
        previousNode = currentNode;
        currentNode  = currentNode.Next;
      }

      if(currentNode == null)
      {
        return;
      }

      previousNode.Next = currentNode.Next;
    }

    public T Get(int index)         => GetNode(index).value;
    public bool IsEmpty()           => nodeCount == 0;
    public int Count          { get => nodeCount; }
    public T First            { get => headNode == null ? default(T) : headNode.value; }
    public T Last             { get => tailNode == null ? default(T) : tailNode.value; }
    public Node<T> FirstNode  { get => headNode == null ? default(Node<T>) : headNode; }
    public Node<T> LastNode   { get => tailNode == null ? default(Node<T>) : tailNode; }

    public IEnumerator<T> GetEnumerator()                                          => new SinglyLinkedListEnumerator<T>(this);
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()  => this.GetEnumerator();

    void UpdateNodeCount() => nodeCount++;
    bool AtTail(int index) => index == (Count -1);
    void ThrowIfOutOfRange(int index)
    {
      if((index < 0) || (index >= Count))
      {
        throw new IndexOutOfRangeException();
      }
    }

    Node<T> NodeAt(int index)
    {
      var currentNode = headNode;
      for(var i=0; i<index; i++)
      {
        currentNode = currentNode.Next;
      }
      return currentNode;
    }
  }
}