namespace practicing_data_structures.data_structures.trees
{
  public sealed class Node<T>
  {
    public readonly T value;
    public Node<T> Left, Right;
    public Node(T v) => value = v;
  }

  public sealed class BinaryTree<T>
  {
    public readonly Node<T> root;
    public BinaryTree(Node<T> r) => root = r;
  }
}