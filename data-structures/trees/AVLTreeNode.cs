using System;

namespace practicing_data_structures.data_structures.trees
{
  public sealed class AVLTreeNode<T> where T : IComparable
  {
    public T Value { get; set; }
    public int Height { get; set; }
    public AVLTreeNode<T> Left { get; set; }
    public AVLTreeNode<T> Right { get; set; }
    public AVLTreeNode<T> Parent { get; set; }
  }
}