using System;

namespace practicing_data_structures.data_structures.trees
{
  public sealed class AVLTreeNode<T> where T : IComparable
  {
    public T Value { get; set; }

    public AVLTreeNode<T> Parent { get; set; }
    public AVLTreeNode<T> Left   { get; set; }
    public AVLTreeNode<T> Right  { get; set; }

    public int Height { get; set; }
    
    public int LeftHeight    => Left?.Height + 1 ?? 0;
    public int RightHeight   => Right?.Height + 1 ?? 0;
    public int BalanceFactor => LeftHeight - RightHeight;

    public bool TreeIsLeftHeavy  => BalanceFactor >=  2;
    public bool TreeIsRightHeavy => BalanceFactor <= -2;

    public bool IsRoot          => Parent == null;
    public bool IsLeaf          => Left == null && Right == null;
    public bool IsRightTreeNull => Left != null && Right == null;
    public bool IsLeftTreeNull  => Left == null && Right != null;

    public string Identity => ToString();
    
    public override string ToString() => $"Value:{Value?.ToString()}, Left:{Left?.Value?.ToString()}, Right:{Right?.Value?.ToString()}, Parent:{Parent?.Value?.ToString()}, Height:{Height.ToString()}";
  }
}