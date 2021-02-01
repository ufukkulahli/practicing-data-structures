using System;
using System.Text;

namespace practicing_data_structures.data_structures.trees
{
  public sealed class TreeTraversal<T> where T : IComparable
  {
    private StringBuilder sb;
    public TreeTraversal(StringBuilder sb) => this.sb = sb;

    public void Inorder(BinaryTreeNode<T> node)
    {
      if(node==null)
      {
        return;
      }

      Inorder(node.Left);

      this.sb.Append(node.value + "->");

      Inorder(node.Right);
    }
  }
}