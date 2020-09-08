namespace practicing_data_structures.data_structures.trees
{


  public sealed class AVLTree<T>
  {
    private Node<T> root;

    public int Count => 0;

    public int Height()
    {
      if (root == null)
      {
        return -1;
      }

      return root.Height;
    }

    private sealed class Node<V>
    {
      public int Height { get; private set; }
    }
  }
}