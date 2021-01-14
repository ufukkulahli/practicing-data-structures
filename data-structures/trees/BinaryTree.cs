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

    public void Insert(T parent)
    {
      if(root==null)
      {
        this.root = new BinaryTreeNode<T>(parent);
        return;
      }

      throw new Exception("There is already a root node!");
    }

    public void Insert(T parent, T child)
    {
      if(root==null)
      {
        this.root = new BinaryTreeNode<T>(null, child);
        return;
      }

      var parentNode = Find(parent);

      if(parentNode==null)
      {
        throw new Exception("Parent node does not exists!");
      }

      if(Find(root, child)!=null)
      {
        throw new Exception("Node already exists!");
      }

      if(parentNode.Left==null && parentNode.Right==null)
      {
        parentNode.Left = new BinaryTreeNode<T>(parentNode, child);
        return;
      }

      if(parentNode.Left!=null && parentNode.Right==null)
      {
        parentNode.Right = new BinaryTreeNode<T>(parentNode, child);
        return;
      }

      throw new Exception("Parent have already two children!");
    }

  }
}