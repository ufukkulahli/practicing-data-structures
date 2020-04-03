namespace practicing_data_structures.data_structures.trees
{
  public sealed class Node
  {
    public readonly int value;
    public Node Left, Right;
    public Node(int v) => value = v;
  }

  public sealed class BinaryTree
  {
    readonly Node root;
    public BinaryTree(Node r) => root = r;
  }
}