using System;
using System.Collections.Generic;

namespace practicing_data_structures.data_structures.lists
{
  public sealed class Node<T>
  {
    public T value;
    public Node<T> Next;
    public Node(T value) => this.value = value;
    public bool Same(T other) => EqualityComparer<T>.Default.Equals(value, other);
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

      var currentNode = headNode;
      for(var i=0; i<index; i++)
      {
        currentNode = currentNode.Next;
      }
      return currentNode;
    }

    public void Clear()
    {
      headNode = tailNode = null;
      nodeCount = 0;
    }

    public T Get(int index)         => GetNode(index).value;
    public bool IsEmpty()           => nodeCount == 0;
    public int Count          { get => nodeCount; }
    public T First            { get => headNode == null ? default(T) : headNode.value; }
    public T Last             { get => tailNode == null ? default(T) : tailNode.value; }
    public Node<T> FirstNode  { get => headNode == null ? default(Node<T>) : headNode; }
    public Node<T> LastNode   { get => tailNode == null ? default(Node<T>) : tailNode; }

    void UpdateNodeCount() => nodeCount++;
    bool AtTail(int index) => index == (Count -1);
    void ThrowIfOutOfRange(int index)
    {
      if((index < 0) || (index >= Count))
      {
        throw new IndexOutOfRangeException();
      }
    }
  }
}
