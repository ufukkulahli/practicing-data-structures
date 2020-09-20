using System;
using System.Collections.Generic;

namespace practicing_data_structures.data_structures.trees
{
  public sealed partial class AVLTree<T> where T : IComparable
  {
    public AVLTreeNode<T> Root { get; private set; }

    public void SetRoot(AVLTreeNode<T> root) => this.Root = root;

    public int Count => 0;

    public int Height()
    {
      if (Root == null)
      {
        return -1;
      }

      return Root.Height;
    }

    public AVLTreeNode<T> Find(AVLTreeNode<T> parent, T value)
    {
      if (parent == null)
      {
        return parent;
      }

      if (EqualityComparer<T>.Default.Equals(parent.Value, value))
      {
        return parent;
      }

      if(Find(parent.Left, value) != null)
      {
        return parent.Left;
      }

      return Find(parent.Right, value);
    }

    public bool Contains(T value) => Find(Root, value) != null;

    public AVLTreeNode<T> FindMax(AVLTreeNode<T> node)
    {
      var next = node;

      while(next.Right != null)
      {
        next = next.Right;
      }

      return next;
    }

    public AVLTreeNode<T> FindMin()
    {
      var next = Root;

      while(next.Left != null)
      {
        next = next.Left;
      }

      return next;
    }

    public void Insert(T value)
    {
      if(Root == null)
      {
        Root = new AVLTreeNode<T>() {Value = value};
        return;
      }

      Insert(Root, value);
    }

    public void Insert(AVLTreeNode<T> node, T value)
    {
      var comparisonResult = Root.Value.CompareTo(value);

      if(comparisonResult < 0)
      {
        InsertNodeToRight(comparisonResult, value);
        return;
      }

      if(comparisonResult > 0)
      {
        InsertNodeToLeft(comparisonResult, value);
        return;
      }

      throw new Exception("Value already exists!");
    }

    private void InsertNodeToRight(int comparisonResult, T value)
    {
      if (Root.Right == null)
      {
        Root.Right = new AVLTreeNode<T>() { Parent = Root, Value = value };
        return;
      }

      Insert(Root.Right, value);
    }

    private void InsertNodeToLeft(int comparisonResult, T value)
    {
      if (Root.Left == null)
      {
        Root.Left = new AVLTreeNode<T>() { Parent = Root, Value = value };
        return;
      }

      Insert(Root.Left, value);
    }


  }
}