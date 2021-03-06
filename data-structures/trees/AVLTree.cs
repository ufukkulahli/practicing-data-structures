using System;
using System.Collections.Generic;

namespace practicing_data_structures.data_structures.trees
{
  public sealed class AVLTree<T> where T : IComparable
  {
    public AVLTreeNode<T> Root { get; private set; }

    public void SetRoot(AVLTreeNode<T> root) => this.Root = root;

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

    public void Insert(T value, bool balanceWhileInserting=true)
    {
      if(Root == null)
      {
        Root = new AVLTreeNode<T>() {Value = value};
        return;
      }

      Insert(Root, value, balanceWhileInserting);
    }

    public void Insert(AVLTreeNode<T> node, T value, bool balanceWhileInserting=true)
    {
      var comparisonResult = node.Value.CompareTo(value);

      if(comparisonResult < 0)
      {
        InsertNodeToRight(node, value, balanceWhileInserting);
      }

      if(comparisonResult > 0)
      {
        InsertNodeToLeft(node, value, balanceWhileInserting);
      }

      if(comparisonResult == 0)
      {
        throw new Exception("Value already exists!");
      }

      UpdateHeight(node);

      if(balanceWhileInserting)
      {
        Balance(node);
      }

      node.UpdateCounts();
    }

    private void InsertNodeToRight(AVLTreeNode<T> node, T value, bool balanceWhileInserting=true)
    {
      if (node.Right == null)
      {
        node.Right = new AVLTreeNode<T>() { Parent = node, Value = value };
        return;
      }

      Insert(node.Right, value, balanceWhileInserting);
    }

    private void InsertNodeToLeft(AVLTreeNode<T> node, T value, bool balanceWhileInserting=true)
    {
      if (node.Left == null)
      {
        node.Left = new AVLTreeNode<T>() { Parent = node, Value = value };
        return;
      }

      Insert(node.Left, value, balanceWhileInserting);
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

    public void Delete(T value, bool balanceWhileDeleting=true)
    {
      if(Root==null)
      {
        throw new ArgumentNullException();
      }

      FindNodeToBeDeleted(Root, value, balanceWhileDeleting);
    }

    public void FindNodeToBeDeleted(AVLTreeNode<T> node, T value, bool balanceWhileDeleting=true)
    {
      var comparisonResult = node.Value.CompareTo(value);

      if(comparisonResult<0)
      {
        if(node.Right==null)
        {
          throw new Exception("Item does not exist!");
        }
        
        FindNodeToBeDeleted(node.Right, value, balanceWhileDeleting);
        return;
      }

      if(comparisonResult>0)
      {
        if(node.Left==null)
        {
          throw new Exception("Item does not exist!");
        }
        
        FindNodeToBeDeleted(node.Left, value, balanceWhileDeleting);
        return;
      }

      if(comparisonResult==0)
      {
        Delete(node, balanceWhileDeleting);
        return;
      }

      throw new Exception("Should not reach here!");
    }

    private void Delete(AVLTreeNode<T> node, bool balanceWhileDeleting=true)
    {
      if (node.IsLeaf)
      {
        DeleteRootOrLeftOrRightNode(node);
        node.UpdateCounts();
        node.UpdateHeights();
        if(balanceWhileDeleting)
        {
          Balance(node);
        }
        return;
      }

      if(node.IsRightTreeNull)
      {
        PerformDeleteWhenRightTreeIsNull(node);
        node.UpdateCounts();
        node.UpdateHeights();
         if(balanceWhileDeleting)
         {
           Balance(node);
         }
        return;
      }

      if(node.IsLeftTreeNull)
      {
        PerformDeleteWhenLeftTreeIsNull(node);
        node.UpdateCounts();
        node.UpdateHeights();
        if(balanceWhileDeleting)
        {
          Balance(node);
        }
        return;
      }

      var maxOfLeftNode = FindMax(node.Left);
      node.Value = maxOfLeftNode.Value;
      FindNodeToBeDeleted(node.Left, maxOfLeftNode.Value, balanceWhileDeleting);
    }

    private void DeleteRootOrLeftOrRightNode(AVLTreeNode<T> node)
    {
      if (node.IsRoot)
      {
        DeleteRoot();
        return;
      }

      if (node.IsLeftChild)
      {
        DeleteLeftNode(node);
        return;
      }

      if (node.IsRightChild)
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

      if(node.IsLeftChild)
      {
        node.Parent.Left = node.Left;
      }

      if(node.IsRightChild)
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

      if(node.IsLeftChild)
      {
        node.Parent.Left = node.Right;
      }

      if(node.IsRightChild)
      {
        node.Parent.Right = node.Right;
      }

      node.Right.Parent = node.Parent;
    }

    public void Balance(AVLTreeNode<T> node)
    {
      if(node==null || node.IsLeaf)
      {
        return;
      }

      if(node.TreeIsLeftHeavy)
      {
        if(node.LeftChildIsLeftHeavy)
        {
          RightRotate(node);
        }

        if(node.LeftChildIsRightHeavy)
        {
          LeftRotate(node.Left);
          RightRotate(node);
        }
      }

      if(node.TreeIsRightHeavy)
      {
        if(node.RightChildIsRightHeavy)
        {
          LeftRotate(node);
        }

        if(node.RightChildIsLeftHeavy)
        {
          RightRotate(node.Right);
          LeftRotate(node);
        }
      }
    }

    public void RightRotate(AVLTreeNode<T> node)
    {
      var previousRoot   = node;
      var newRoot        = node.Left;
      var leftRightChild = previousRoot.Left.Right;

      previousRoot.Left.Parent = previousRoot.Parent;

      if(previousRoot.HasParent)
      {
        if(previousRoot.IsLeftChild)
        {
          previousRoot.Parent.Left = previousRoot.Left;
        }
        if(previousRoot.IsRightChild)
        {
          previousRoot.Parent.Right = previousRoot.Left;
        }
      }

      newRoot.Right       = previousRoot;
      previousRoot.Parent = newRoot;
      newRoot.Right.Left  = leftRightChild;

      if(newRoot.Right.Left!=null)
      {
        newRoot.Right.Left.Parent = newRoot.Right;
      }

      UpdateHeight(newRoot);
      newRoot.Left?.UpdateCounts();
      newRoot.Right.UpdateCounts();
      newRoot.UpdateCounts();

      if(previousRoot==this.Root)
      {
        this.Root = newRoot;
      }

    }

    public void LeftRotate(AVLTreeNode<T> node)
    {
      var previousRoot   = node;
      var rightLeftChild = previousRoot.Right.Left;
      var newRoot        = node.Right;

      previousRoot.Right.Parent = previousRoot.Parent;

      if(previousRoot.HasParent)
      {
        if(previousRoot.IsLeftChild)
        {
          previousRoot.Parent.Left = previousRoot.Right;
        }
        if(previousRoot.IsRightChild)
        {
          previousRoot.Parent.Right = previousRoot.Right;
        }
      }

      newRoot.Left        = previousRoot;
      previousRoot.Parent = newRoot;
      newRoot.Left.Right  = rightLeftChild;

      if(newRoot.Left.Right != null)
      {
        newRoot.Left.Right.Parent = newRoot.Left;
      }

      UpdateHeight(newRoot);
      newRoot.Left.UpdateCounts();
      newRoot.Right.UpdateCounts();
      newRoot.UpdateCounts();

      if(previousRoot==this.Root)
      {
        this.Root = newRoot;
      }
    }

  }
}