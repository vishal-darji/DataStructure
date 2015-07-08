using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructure
{
   public class BTNode
    {
       public string Name;
       public double Value;
       public BTNode Left, Right;

       public BTNode(string name, double value)
       {
           Name = name;
           Value = value;
           Left = null;
           Right = null;
       }
    }
   public class BinaryTree
   { 
        private BTNode root;     // Points to the root of the tre
		private int _count = 0;

        public BinaryTree()
		{
		    root = null;
			_count = 0;
		}
        private void killTree(ref BTNode p)
        {
            if (p != null)
            {
                killTree(ref p.Left);
                killTree(ref p.Right);
                p = null;
            }
        }
        public void clear()
        {
            killTree(ref root);
            _count = 0;
        }
        public int count()
        {
            return _count;
        }
        public BTNode findSymbol(string name)
        {
            BTNode np = root;
            int cmp;
            while (np != null)
            {
                cmp = String.Compare(name, np.Name);
                if (cmp == 0)   // found !
                    return np;

                if (cmp < 0)
                    np = np.Left;
                else
                    np = np.Right;
            }
            return null;  // Return null to indicate failure to find name
        }
        private void add(BTNode node, ref BTNode tree)
        {
            if (tree == null)
                tree = node;
            else
            {
                // If we find a node with the same name then it's 
                // a duplicate and we can't continue
                int comparison = String.Compare(node.Name, tree.Name);
                if (comparison == 0)
                    throw new Exception();

                if (comparison < 0)
                {
                    add(node, ref tree.Left);
                }
                else
                {
                    add(node, ref tree.Right);
                }
            }
        }
        public BTNode insert(string name, double d)
        {
            BTNode node = new BTNode(name, d);
            try
            {
                if (root == null)
                    root = node;
                else
                    add(node, ref root);
                _count++;
                return node;
            }
            catch (Exception)
            {
                return null;
            }
        }
        private BTNode findParent(string name, ref BTNode parent)
        {
            BTNode np = root;
            parent = null;
            int cmp;
            while (np != null)
            {
                cmp = String.Compare(name, np.Name);
                if (cmp == 0)   // found !
                    return np;

                if (cmp < 0)
                {
                    parent = np;
                    np = np.Left;
                }
                else
                {
                    parent = np;
                    np = np.Right;
                }
            }
            return null;  // Return null to indicate failure to find name
        }
        public BTNode findSuccessor(BTNode startNode, ref BTNode parent)
        {
            parent = startNode;
            // Look for the left-most node on the right side
            startNode = startNode.Right;
            while (startNode.Left != null)
            {
                parent = startNode;
                startNode = startNode.Left;
            }
            return startNode;
        }

        public void delete(string key)
        {
            BTNode parent = null;
            // First find the node to delete and its parent
            BTNode nodeToDelete = findParent(key, ref parent);
            if (nodeToDelete == null)
                throw new Exception("Unable to delete node: " + key.ToString());  // can't find node, then say so 

            // Three cases to consider, leaf, one child, two children

            // If it is a simple leaf then just null what the parent is pointing to
            if ((nodeToDelete.Left == null) && (nodeToDelete.Right == null))
            {
                if (parent == null)
                {
                    root = null;
                    return;
                }

                // find out whether left or right is associated 
                // with the parent and null as appropriate
                if (parent.Left == nodeToDelete)
                    parent.Left = null;
                else
                    parent.Right = null;
                _count--;
                return;
            }

            // One of the children is null, in this case
            // delete the node and move child up
            if (nodeToDelete.Left == null)
            {
                // Special case if we're at the root
                if (parent == null)
                {
                    root = nodeToDelete.Right;
                    return;
                }

                // Identify the child and point the parent at the child
                if (parent.Left == nodeToDelete)
                    parent.Right = nodeToDelete.Right;
                else
                    parent.Left = nodeToDelete.Right;
                nodeToDelete = null; // Clean up the deleted node
                _count--;
                return;
            }

            // One of the children is null, in this case
            // delete the node and move child up
            if (nodeToDelete.Right == null)
            {
                // Special case if we're at the root			
                if (parent == null)
                {
                    root = nodeToDelete.Left;
                    return;
                }

                // Identify the child and point the parent at the child
                if (parent.Left == nodeToDelete)
                    parent.Left = nodeToDelete.Left;
                else
                    parent.Right = nodeToDelete.Left;
                nodeToDelete = null; // Clean up the deleted node
                _count--;
                return;
            }

            // Both children have nodes, therefore find the successor, 
            // replace deleted node with successor and remove successor
            // The parent argument becomes the parent of the successor
            BTNode successor = findSuccessor(nodeToDelete, ref parent);
            // Make a copy of the successor node
            BTNode tmp = new BTNode(successor.Name, successor.Value);
            // Find out which side the successor parent is pointing to the
            // successor and remove the successor
            if (parent.Left == successor)
                parent.Left = null;
            else
                parent.Right = null;

            // Copy over the successor values to the deleted node position
            nodeToDelete.Name = tmp.Name;
            nodeToDelete.Value = tmp.Value;
            _count--;
        }
        // Simple 'drawing' routines
        private string drawNode(BTNode node)
        {
            if (node == null)
                return "empty";

            if ((node.Left == null) && (node.Right == null))
                return node.Name;
            if ((node.Left != null) && (node.Right == null))
                return node.Name + "(" + drawNode(node.Left) + ", _)";

            if ((node.Right != null) && (node.Left == null))
                return node.Name + "(_, " + drawNode(node.Right) + ")";

            return node.Name + "(" + drawNode(node.Left) + ", " + drawNode(node.Right) + ")";
        }
        public string drawTree()
        {
            return drawNode(root);
        }

   }
}
