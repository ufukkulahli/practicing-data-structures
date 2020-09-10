using System.Collections.Generic;

namespace practicing_data_structures.data_structures.trees
{
  public sealed partial class AVLTree<T>
  {
    private AVLTreeNode<T> root;

    public int Count => 0;

    public int Height()
    {
      if (root == null)
      {
        return -1;
      }

      return root.Height;
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

      throw new System.NotImplementedException();
    }
  }
}