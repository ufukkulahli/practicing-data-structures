using System;

namespace practicing_data_structures.data_structures.trees
{
  public sealed class BinaryTree<T> where T : IComparable
  {
    public BinaryTreeNode<T> root { get; private set; }
    public BinaryTree(BinaryTreeNode<T> r) => root = r;

    public BinaryTreeNode<T> Find(T value)
    {
      return root == null ? null : Find(root, value);
    }

    private BinaryTreeNode<T> Find(BinaryTreeNode<T> parent, T value)
    {
      if(parent == null)
      {
        return parent;
      }

      if(parent.Same(value))
      {
        return parent;
      }

      var nodeFromLeftSide = Find(parent.Left, value);
      if( nodeFromLeftSide != null )
      {
        return nodeFromLeftSide;
      }

      return Find(parent.Right, value);
    }

    public void Insert(T parent, T child)
    {
      if(root==null)
      {
        this.root = new BinaryTreeNode<T>(null, child);
        return;
      }
    }

  }
}