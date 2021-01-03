using System;

namespace practicing_data_structures.data_structures.trees
{
  public sealed class Node<T> where T : IComparable
  {
    public readonly T value;
    public Node<T> Left, Right;
    public Node(T v) => value = v;
  }

  public sealed class BinaryTree<T> where T : IComparable
  {
    public readonly Node<T> root;
    public BinaryTree(Node<T> r) => root = r;

    public Node<T> Find(T value)
    {
      throw new System.NotImplementedException();
    }
  }
}