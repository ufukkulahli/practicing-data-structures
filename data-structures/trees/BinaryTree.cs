using System;

namespace practicing_data_structures.data_structures.trees
{
  public sealed class BinaryTree<T> where T : IComparable
  {
    public BinaryTreeNode<T> root { get; private set; }

    public int Count { get; private set; }

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
        this.Count++;
        return;
      }

      throw new Exception("There is already a root node!");
    }

    public void Insert(T parent, T child)
    {
      if(root==null)
      {
        this.root = new BinaryTreeNode<T>(null, child);
        this.Count++;
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
        this.Count++;
        return;
      }

      if(parentNode.Left!=null && parentNode.Right==null)
      {
        parentNode.Right = new BinaryTreeNode<T>(parentNode, child);
        this.Count++;
        return;
      }

      throw new Exception("Parent have already two children!");
    }

    public bool Contains(T value) => Find(value) == null ? false : true;

    public int Height() => Height(this.root);

    public int Height(BinaryTreeNode<T> node)
    {
      if(node == null)
      {
        return -1;
      }

      return
        Math.Max
        (
          Height(node.Left),
          Height(node.Right)
        ) + 1;
    }

    public void Delete(T value)
    {
      var node = Find(value);

      if(node==null)
      {
        throw new System.Exception("Node could not be found!");
      }

      if(node.IsLeaf)
      {
        this.Count--;

        if(node.IsRoot)
        {
          DeleteRoot();
          return;
        }

        if(node.IsLeftChild)
        {
          DeleteLeftNode(node);
          return;
        }

        if(node.IsRightChild)
        {
          DeleteRightNode(node);
          return;
        }

        throw new Exception("Unknown state!");
      }

      if(node.Left==null && node.Right!=null)
      {
        this.Count--;
        node.Right.Parent = node.Parent;

        if(node.IsLeftChild)
        {
          node.Parent.Left = node.Right;
          return;
        }

        if(node.IsRightChild)
        {
          node.Parent.Right = node.Right;
          return;
        }

        throw new Exception("Unknown state!");
      }

      if(node.Left!=null && node.Right==null)
      {
        this.Count--;
        node.Left.Parent = node.Parent;

        if(node.IsLeftChild)
        {
          node.Parent.Left = node.Left;
          return;
        }

        if(node.IsRightChild)
        {
          node.Parent.Right = node.Left;
          return;
        }

        throw new Exception("Unknown state!");
      }

      throw new System.Exception();
    }

    private void DeleteRoot() => this.root=null;
    private void DeleteLeftNode(BinaryTreeNode<T> node) => node.Parent.Left = null;
    private void DeleteRightNode(BinaryTreeNode<T> node) => node.Parent.Right = null;

  }
}