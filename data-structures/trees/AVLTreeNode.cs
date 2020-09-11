namespace practicing_data_structures.data_structures.trees
{
  public sealed class AVLTreeNode<T>
  {
    public T Value { get; set; }
    public int Height { get; set; }
    public AVLTreeNode<T> Left { get; set; }
  }
}