using System;
using System.Collections.Generic;

namespace practicing_data_structures.data_structures.trees
{
  public sealed class AVLTree<T> where T : IComparable
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
      var comparisonResult = node.Value.CompareTo(value);

      if(comparisonResult < 0)
      {
        InsertNodeToRight(node, value);
      }

      if(comparisonResult > 0)
      {
        InsertNodeToLeft(node, value);
      }

      if(comparisonResult == 0)
      {
        throw new Exception("Value already exists!");
      }

      UpdateHeight(node);
    }

    private void InsertNodeToRight(AVLTreeNode<T> node, T value)
    {
      if (node.Right == null)
      {
        node.Right = new AVLTreeNode<T>() { Parent = node, Value = value };
        return;
      }

      Insert(node.Right, value);
    }

    private void InsertNodeToLeft(AVLTreeNode<T> node, T value)
    {
      if (node.Left == null)
      {
        node.Left = new AVLTreeNode<T>() { Parent = node, Value = value };
        return;
      }

      Insert(node.Left, value);
    }

    public void UpdateHeight(AVLTreeNode<T> node)
    {
      if(node==null)
      {
        return;
      }

      if(node.Left!=null)
      {
        node.Left.Height = FindBiggest(node.Left);
      }

      if(node.Right!=null)
      {
        node.Right.Height = FindBiggest(node.Right);
      }

      node.Height = FindBiggest(node);

    }

    private int FindBiggest(AVLTreeNode<T> node)
    {
      return
        Math.Max
        (
          node.Left?. Height + 1  ??  0,
          node.Right?.Height + 1  ??  0
        );
    }

    public void RecomputeHeight(AVLTreeNode<T> node)
    {
      if(node == null)
      {
        return;
      }

      RecomputeHeight(node.Left);
      RecomputeHeight(node.Right);
      UpdateHeight(node);
    }

    public void Delete(T value)
    {
      if(Root==null)
      {
        throw new ArgumentNullException();
      }

      Delete(Root, value);
    }

    public void Delete(AVLTreeNode<T> node, T value)
    {
      var comparisonResult = node.Value.CompareTo(value);

      if(comparisonResult<0)
      {
        if(node.Right==null)
        {
          throw new Exception("Item does not exist!");
        }
        
        Delete(node.Right, value);
      }
    }

  }
}