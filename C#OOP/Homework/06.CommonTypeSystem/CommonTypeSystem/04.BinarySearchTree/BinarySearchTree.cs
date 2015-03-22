using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

struct BinarySearchTree<T> : ICloneable where T : IComparable
{
    private TreeNode<T> root;

    public BinarySearchTree(T value, TreeNode<T> left = null, TreeNode<T> right = null)
    {
        root = new TreeNode<T>(value);

        if (left == null)
        {
            root.Left = null;
        }
        else
        {
            if (left.Value.CompareTo(root.Value) > 0)
            {
                throw new ArgumentException("Can't create that tree.");
            }
            else
            {
                root.Left = left.Clone();
            }
        }
        if (right == null)
        {
            root.Right = null;
        }
        else
        {
            if (right.Value.CompareTo(root.Value) < 0)
            {
                throw new ArgumentException("Can't create that tree.");
            }
            else
            {
                root.Right = right.Clone();
            }
        }
    }

    public override string ToString()
    {
        StringBuilder myReturn = new StringBuilder();
        foreach (TreeNode<T> node in root)
        {
            myReturn.Append(node.ToString() + "\n");
        }
        return myReturn.ToString();
    }

    public bool Search(T value)
    {
        foreach (TreeNode<T> node in root)
        {
            if (node.Value.CompareTo(value) == 0)
            {
                return true;
            }
        }
        return false;
    }

    public void Add(T value)
    {
        root.Add(value);
    }

    public void Delete(T value)
    {
        if (this.Search(value))
        {
            root.Delete(value);
        }
        else
        {
            Console.WriteLine("There is no such element in this tree.");
        }
    }

    public TreeNode<T> FindElem(T value)
    {
        return root.FindElem(value);
    }

    object ICloneable.Clone()
    {
        return this.Clone();
    }

    public BinarySearchTree<T> Clone()
    {
        return new BinarySearchTree<T>(this.root.Value);
    }
}
