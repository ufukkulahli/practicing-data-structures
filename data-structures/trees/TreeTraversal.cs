using System;
using System.Text;

namespace practicing_data_structures.data_structures.trees
{
  public sealed class TreeTraversal<T> where T : IComparable
  {
    private StringBuilder sb;
    public TreeTraversal(StringBuilder sb) => this.sb = sb;

    public void Preorder(BinaryTreeNode<T> node)
    {
      if(node==null)
      {
        return;
      }

      this.sb.Append(node.value + "->");

      Preorder(node.Left);

      Preorder(node.Right);
    }

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

    public void Postorder(BinaryTreeNode<T> node)
    {
      if(node==null)
      {
        return;
      }

      Postorder(node.Left);

      Postorder(node.Right);

      this.sb.Append(node.value + "->");
    }

  }
}