using System;

namespace practicing_data_structures.data_structures.trees
{
  public sealed class BinaryTreeNode<T> where T : IComparable
  {
    public readonly T value;
    public BinaryTreeNode<T> Left, Right;
    public BinaryTreeNode(T v) => value = v;

    public bool Same(T other) => this.value.CompareTo(other) == 0;
  }
}