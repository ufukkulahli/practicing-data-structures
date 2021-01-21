using System;

namespace practicing_data_structures.data_structures.trees
{
  public sealed class BinaryTreeNode<T> where T : IComparable
  {
    public readonly T value;
    public BinaryTreeNode<T> Left, Right, Parent;
    public BinaryTreeNode(T v) => value = v;

    public BinaryTreeNode(BinaryTreeNode<T> parent, T value)
    {
      this.Parent = parent;
      this.value  = value;
    }

    public bool Same(T other) => this.value.CompareTo(other) == 0;

    public bool IsRoot => this.Parent == null;
    public bool IsLeaf => this.Left==null && this.Right==null;
    public bool IsLeftChild => this.Parent.Left == this;
    public bool IsRightChild => this.Parent.Right == this;

  }
}