﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Test
{
    static void Main()
    {
        BinarySearchTree<double> tree = new BinarySearchTree<double>(8);

        //tree.Add(10);
        //tree.Add(1);
        //tree.Add(6);
        //tree.Add(4);
        //tree.Add(7);
        //tree.Add(11);
        //tree.Add(14);
        //tree.Add(13);

        tree.Add(4);
        tree.Add(12);
        tree.Add(2);
        tree.Add(6);
        tree.Add(1);
        tree.Add(3);
        tree.Add(5);
        tree.Add(7);
        tree.Add(10);
        tree.Add(9);
        tree.Add(11);
        tree.Add(14);
        tree.Add(15);
        tree.Add(13);
        tree.Add(2.4);
        tree.Add(3.4);

        tree.Delete(4);


        Console.WriteLine(tree.ToString());
    }
}