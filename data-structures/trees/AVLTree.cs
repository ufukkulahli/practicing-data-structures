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

    public Node<T> Find(Node<T> parent, T value)
    {
      if(parent == null)
      {
        return parent;
      }
      throw new System.NotImplementedException();
    }

    public sealed class Node<V>
    {
      public int Height { get; private set; }
    }
  }
}