using System;

namespace practicing_data_structures.data_structures.trees
{
  public sealed class BinaryTree<T> where T : IComparable
  {
    public readonly BinaryTreeNode<T> root;
    public BinaryTree(BinaryTreeNode<T> r) => root = r;

    public BinaryTreeNode<T> Find(T value)
    {
      throw new System.NotImplementedException();
    }
  }
}