using System;

namespace practicing_data_structures.data_structures.trees
{
  public sealed class AVLTreeNode<T> where T : IComparable
  {
    public T Value { get; set; }

    public AVLTreeNode<T> Parent { get; set; }
    public AVLTreeNode<T> Left   { get; set; }
    public AVLTreeNode<T> Right  { get; set; }

    public int Count { get; private set; } = 1;
    public int LeftCount         => Left?.Count ?? 0;
    public int RightCount        => Right?.Count ?? 0;
    public int LeftAndRightCount => LeftCount + RightCount + 1;

    public int Height { get; set; }

    public int LeftHeight    => Left?.Height + 1 ?? 0;
    public int RightHeight   => Right?.Height + 1 ?? 0;
    public int BalanceFactor => LeftHeight - RightHeight;

    public bool TreeIsLeftHeavy  => BalanceFactor >=  2;
    public bool TreeIsRightHeavy => BalanceFactor <= -2;

    public int LeftOfLeftHeight       => Left?.Left?.Height + 1 ?? 0;
    public int RightOfLeftHeight      => Left?.Right?.Height +1 ?? 0;
    public bool LeftChildIsLeftHeavy  => LeftOfLeftHeight > RightOfLeftHeight;
    public bool LeftChildIsRightHeavy => LeftOfLeftHeight < RightOfLeftHeight;

    public int LeftOfRightHeight       => Right?.Left?.Height +1 ?? 0;
    public int RightOfRightHeight      => Right?.Right?.Height+1 ?? 0;
    public bool RightChildIsRightHeavy => RightOfRightHeight > LeftOfRightHeight;
    public bool RightChildIsLeftHeavy  => LeftOfRightHeight > RightOfRightHeight;

    public bool HasParent       => Parent != null;
    public bool IsRoot          => Parent == null;
    public bool IsLeaf          => Left == null && Right == null;
    public bool IsRightTreeNull => Left != null && Right == null;
    public bool IsLeftTreeNull  => Left == null && Right != null;

    public bool IsLeftChild =>  Parent!=null && Parent.Left==this;
    public bool IsRightChild => Parent!=null && Parent.Right==this;

    public string Identity => ToString();

    public override string ToString() => $"Value:{Value?.ToString()}, Left:{Left?.Value?.ToString()}, Right:{Right?.Value?.ToString()}, Parent:{Parent?.Value?.ToString()}, Height:{Height.ToString()}";

    public void UpdateHeights()
    {
      if(Left!=null)
      {
        Left.Height = GetBiggestHeightOfChilds(Left);
      }

      if(Right!=null)
      {
        Right.Height = GetBiggestHeightOfChilds(Right);
      }

      this.Height = GetBiggestHeightOfChilds(this);
    }

    public int GetBiggestHeightOfChilds(AVLTreeNode<T> node)
    {
      return
        Math.Max
        (
          node.Left?. Height + 1  ??  0,
          node.Right?.Height + 1  ??  0
        );
    }

    public void UpdateCounts()
    {
      var node = this;

      while(node!=null)
      {
        node.Count = node.LeftAndRightCount;
        node = node.Parent;
      }
    }

  }
}