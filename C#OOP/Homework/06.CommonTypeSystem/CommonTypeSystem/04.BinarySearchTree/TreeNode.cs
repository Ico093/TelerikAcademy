using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class TreeNode<T> : ICloneable, IComparable, IEnumerable<TreeNode<T>> where T : IComparable
{
    T value;
    TreeNode<T> left;
    TreeNode<T> right;

    public T Value
    {
        get { return value; }
    }

    public TreeNode<T> Left
    {
        get { return left; }
        set { left = value; }
    }

    public TreeNode<T> Right
    {
        get { return right; }
        set { right = value; }
    }

    public TreeNode(T value, TreeNode<T> left = null, TreeNode<T> right = null)
    {
        this.value = value;
        if (left != null)
        {
            this.left = left.Clone();
        }
        else
        {
            this.left = null;
        }

        if (right != null)
        {
            this.right = right.Clone();
        }
        else
        {
            this.right = null;
        }
    }

    public override bool Equals(object obj)
    {
        TreeNode<T> myNode = obj as TreeNode<T>;
        return this.Equals(myNode);
    }

    public bool Equals(TreeNode<T> myNode)
    {
        return this.CompareTo(myNode) == 0 ? true : false;
    }

    public static bool operator ==(TreeNode<T> node1, TreeNode<T> node2)
    {
        return TreeNode<T>.Equals(node1, node2);
    }

    public static bool operator !=(TreeNode<T> node1, TreeNode<T> node2)
    {
        return !TreeNode<T>.Equals(node1, node2);
    }

    public override string ToString()
    {
        return String.Format("Parent: {0}", this.Value).PadRight(14) + String.Format("Left child: {0}", this.Left != null ? this.Left.Value.ToString() : "Not defined").PadRight(28) + String.Format("Right child: {0}", this.Right != null ? this.Right.Value.ToString() : "Not defined").PadRight(28);
    }

    public override int GetHashCode()
    {
        int hash = 1;
        Traverse(x => hash ^= x.GetHashCode());
        return hash;
    }

    public int CompareTo(object obj)
    {
        TreeNode<T> myNode = obj as TreeNode<T>;
        return this.CompareTo(myNode);
    }

    public int CompareTo(TreeNode<T> myNode)
    {
        return this.Value.CompareTo(myNode.Value);
    }

    object ICloneable.Clone()
    {
        return this.Clone();
    }

    public TreeNode<T> Clone()
    {
        return new TreeNode<T>(this.value, this.Left != null ? this.Left.Clone() : null, this.Right != null ? this.Right.Clone() : null);
    }

    public void Add(T value)
    {
        if (value.CompareTo(this.Value) < 0)
        {
            if (this.Left == null)
            {
                this.left = new TreeNode<T>(value);
            }
            else
            {
                this.Left.Add(value);
            }
        }
        else if (value.CompareTo(this.Value) > 0)
        {
            if (this.Right == null)
            {
                this.right = new TreeNode<T>(value);
            }
            else
            {
                this.Right.Add(value);
            }
        }
        else
        {
            Console.WriteLine("This value is already in the tree.");
        }
    }

    public void Delete(T value)
    {
        TreeNode<T> myNode = FindElem(value);
        if (myNode.Left == null && myNode.Right == null)
        {
            myNode = FindElemParent(value);
            if (myNode.Left.Value.CompareTo(value) == 0)
            {
                if (myNode.Left.Left != null)
                {
                    myNode.Left = myNode.Left.Left;
                }
                else if (myNode.Left.Right != null)
                {
                    myNode.Left = myNode.Left.Right;
                }
                else
                {
                    myNode.Left = null;
                }
            }
            else
            {
                if (myNode.Right.Left != null)
                {
                    myNode.Right = myNode.Right.Left;
                }
                else if (myNode.Right.Right != null)
                {
                    myNode.Right = myNode.Right.Right;
                }
                else
                {
                    myNode.Right = null;
                }
            }
        }
        else if (myNode.Left != null ^ myNode.Right != null)
        {
            myNode = FindElemParent(value);
            if (myNode.Left.Value.CompareTo(value) == 0)
            {
                if (myNode.Left.Left != null)
                {
                    myNode.Left = myNode.Left.Left;
                }
                else if (myNode.Left.Right != null)
                {
                    myNode.Left = myNode.Left.Right;
                }
                else
                {
                    myNode.Left = null;
                }
            }
            else
            {
                if (myNode.Right.Right != null)
                {
                    myNode.Right = myNode.Right.Right;
                }
                else if (myNode.Right.Left != null)
                {
                    myNode.Right = myNode.Right.Left;
                }
                else
                {
                    myNode.Right = null;
                }
            }
        }
        else
        {
            if (myNode.Left.Right != null)
            {
                T newValue = myNode.Left.Right.Value;
                this.Delete(myNode.Left.Right.Value);
                myNode.value = newValue;
            }
            else
            {
                T newValue = myNode.Left.Value;
                this.Delete(myNode.Left.Value);
                myNode.value = newValue;
            }
        }
    }

    public TreeNode<T> FindElem(T value)
    {
        if (value.CompareTo(this.Value) == 0)
        {
            return this;
        }
        else if (value.CompareTo(this.Value) < 0)
        {
            if (this.Left != null)
            {
                return this.Left.FindElem(value);
            }
            else
            {
                throw new ArgumentException("No such element exists.");
            }
        }
        else
        {
            if (this.Right != null)
            {
                return this.Right.FindElem(value);
            }
            else
            {
                throw new ArgumentException("No such element exists.");
            }
        }
    }

    public TreeNode<T> FindElemParent(T value)
    {
        if (this.Left != null)
        {
            if (this.Left.Value.CompareTo(value) == 0)
            {
                return this;
            }
            else
            {
                if (value.CompareTo(this.Value) < 0)
                {
                    return this.Left.FindElemParent(value);
                }
            }
        }
        if (this.Right != null)
        {
            if (this.Right.Value.CompareTo(value) == 0)
            {
                return this;
            }
            else
            {
                if (value.CompareTo(this.Value) > 0)
                {
                    return this.Right.FindElemParent(value);
                }
            }
        }
        throw new ArgumentException("No such element found.");
    }

    public void Traverse(Action<TreeNode<T>> action)
    {
        if (this != null)
        {
            action(this);
            if (this.Left != null)
            {
                this.Left.Traverse(action);
            }
            if (this.Right != null)
            {
                this.Right.Traverse(action);
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public IEnumerator<TreeNode<T>> GetEnumerator()
    {
        List<TreeNode<T>> myTree = new List<TreeNode<T>>();
        Traverse(x => myTree.Add(new TreeNode<T>(x.value, x.Left, x.Right)));

        foreach (TreeNode<T> node in myTree)
        {
            yield return node;
        }
    }
}