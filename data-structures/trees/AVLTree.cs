using System;
using System.Collections.Generic;

namespace practicing_data_structures.data_structures.trees
{
  public sealed class AVLTree<T> where T : IComparable
  {
    public AVLTreeNode<T> Root { get; private set; }

    public void SetRoot(AVLTreeNode<T> root) => this.Root = root;

    // TODO
    public int Count => Root == null ? 0 : Root.Count;

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
      // TODO
      // Balance(node);
      node.UpdateCounts();
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

      node.UpdateHeights();
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

      FindNodeToBeDeleted(Root, value);
    }

    public void FindNodeToBeDeleted(AVLTreeNode<T> node, T value)
    {
      var comparisonResult = node.Value.CompareTo(value);

      if(comparisonResult<0)
      {
        if(node.Right==null)
        {
          throw new Exception("Item does not exist!");
        }
        
        FindNodeToBeDeleted(node.Right, value);
        return;
      }

      if(comparisonResult>0)
      {
        if(node.Left==null)
        {
          throw new Exception("Item does not exist!");
        }
        
        FindNodeToBeDeleted(node.Left, value);
        return;
      }

      if(comparisonResult==0)
      {
        Delete(node);
        return;
      }

      throw new Exception("Should not reach here!");
    }

    private void Delete(AVLTreeNode<T> node)
    {
      if (node.IsLeaf)
      {
        DeleteRootOrLeftOrRightNode(node);
        node.UpdateCounts();
        //node.UpdateHeights();
        // Balance(node);
        return;
      }

      if(node.IsRightTreeNull)
      {
        PerformDeleteWhenRightTreeIsNull(node);
        return;
      }

      if(node.IsLeftTreeNull)
      {
        PerformDeleteWhenLeftTreeIsNull(node);
        return;
      }

      var maxOfLeftNode = FindMax(node.Left);
      node.Value = maxOfLeftNode.Value;
      FindNodeToBeDeleted(node.Left, maxOfLeftNode.Value);
    }

    private void DeleteRootOrLeftOrRightNode(AVLTreeNode<T> node)
    {
      if (node.IsRoot)
      {
        DeleteRoot();
        return;
      }

      if (node.Parent.Left == node)
      {
        DeleteLeftNode(node);
        return;
      }

      if (node.Parent.Right == node)
      {
        DeleteRightNode(node);
        return;
      }

      throw new Exception("Error when deleting the node!");
    }

    private void DeleteRoot() => Root = null;

    private void DeleteLeftNode(AVLTreeNode<T> node) => node.Parent.Left = null;

    private void DeleteRightNode(AVLTreeNode<T> node) => node.Parent.Right = null;

    private void PerformDeleteWhenRightTreeIsNull(AVLTreeNode<T> node)
    {
      if(node.IsRoot)
      {
        Root.Left.Parent = null;
        Root = Root.Left;
        return;
      }

      if(node.Parent.Left == node)
      {
        node.Parent.Left = node.Left;
      }

      if(node.Parent.Right == node)
      {
        node.Parent.Right = node.Left;
      }

      node.Left.Parent = node.Parent;
    }

    private void PerformDeleteWhenLeftTreeIsNull(AVLTreeNode<T> node)
    {
      if(node.IsRoot)
      {
        Root.Right.Parent = null;
        Root = Root.Right;
        return;
      }

      if(node.Parent.Left == node)
      {
        node.Parent.Left = node.Right;
      }

      if(node.Parent.Right == node)
      {
        node.Parent.Right = node.Right;
      }

      node.Right.Parent = node.Parent;
    }

  }
}