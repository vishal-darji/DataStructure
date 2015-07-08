using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine('Z' > 'B');
            Console.ReadLine();
            //Console.WriteLine("Test Deletion method\n");
            BinaryTree bt;
            //bt = new BinaryTree();
            //bt.insert("50", 50);
            //bt.insert("60", 60);
            //bt.insert("40", 40);
            //bt.insert("30", 30);
            //bt.insert("20", 20);
            //bt.insert("35", 35);
            //bt.insert("45", 45);
            //bt.insert("44", 44);
            //bt.insert("46", 46);
            //Console.WriteLine("Number of nodes in the tree = {0}\n", bt.count());

            //Console.WriteLine("Original: " + bt.drawTree());
            //bt.delete("40");
            //Console.WriteLine("Delete node 40: " + bt.drawTree());
            //bt.delete("45");
            //Console.WriteLine("Delete node 45: " + bt.drawTree());

            //Console.WriteLine("\nSimple one layered tree");
            //bt = new BinaryTree();
            //bt.insert("50", 50);
            //bt.insert("20", 20);
            //bt.insert("90", 90);
            //Console.WriteLine("\nOriginal: " + bt.drawTree());
            //bt.delete("50");
            //Console.WriteLine("Delete node 50: " + bt.drawTree());

            //bt = new BinaryTree();
            //bt.insert("50", 50);
            //bt.insert("20", 20);
            //bt.insert("90", 90);
            //Console.WriteLine("\nOriginal: " + bt.drawTree());
            //bt.delete("20");
            //Console.WriteLine("Delete node 20: " + bt.drawTree());

            //bt = new BinaryTree();
            //bt.insert("50", 50);
            //bt.insert("20", 20);
            //bt.insert("90", 90);
            //Console.WriteLine("\nOriginal: " + bt.drawTree());
            //bt.delete("90");
            //Console.WriteLine("Delete node 90: " + bt.drawTree());
            //bt.delete("20");
            //Console.WriteLine("Delete node 20: " + bt.drawTree());
            //bt.delete("50");
            //Console.WriteLine("Delete node 50: " + bt.drawTree());

            Console.WriteLine("\n");
            bt = new BinaryTree();
            bt.insert("L", 1);
            bt.insert("D", 2);
            bt.insert("C", 3);
            bt.insert("A", 4);
            bt.insert("H", 5);
            bt.insert("F", 6);
            bt.insert("J", 7);
            bt.insert("P", 8);
            Console.WriteLine("Original: " + bt.drawTree());
            bt.delete("J");
            Console.WriteLine("Delete J: " + bt.drawTree());
            bt.delete("C");
            Console.WriteLine("Delete C: " + bt.drawTree());
            bt.delete("L");
            Console.WriteLine("Delete L: " + bt.drawTree());
            bt.delete("D");
            Console.WriteLine("Delete D: " + bt.drawTree());
            bt.delete("A");
            Console.WriteLine("Delete A: " + bt.drawTree());

            Console.ReadLine();

        }
    }
}
