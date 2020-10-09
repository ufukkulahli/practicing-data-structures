using System;

namespace practicing_data_structures.data_structures.trees
{
  public sealed class AVLTreeNode<T> where T : IComparable
  {
    public string Identity => ToString();
    public T Value { get; set; }
    public int Height { get; set; }
    public AVLTreeNode<T> Left { get; set; }
    public AVLTreeNode<T> Right { get; set; }
    public AVLTreeNode<T> Parent { get; set; }
    public bool IsLeaf => Left==null && Right==null;
    public bool IsRoot => Parent==null;
    public bool IsRightTreeNull => Left!=null && Right==null;
    public bool IsLeftTreeNull => Left==null && Right!=null;
    public override string ToString() => $"Value:{Value?.ToString()}, Left:{Left?.Value?.ToString()}, Right:{Right?.Value?.ToString()}, Parent:{Parent?.Value?.ToString()}, Height:{Height.ToString()}";
  }
}