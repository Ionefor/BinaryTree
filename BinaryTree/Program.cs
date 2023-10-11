using System.Xml.Linq;
using System.Collections.Generic;
namespace BinaryTree
{
    public class TreeNode
    {
        public int Value { get; }
        public TreeNode LeftNode { get; set; }
        public TreeNode RightNode { get; set; }
        public TreeNode(int value)
        {
            Value = value;
        }
    }
    public class BinaryTree
    {
        private int _count;
        private TreeNode _root;
        public TreeNode Root => _root;
        public int Count => _count;
        public void Insert(int value)
        {
            if (_root == null)
            {
                _root = new TreeNode(value);
                _count++;
            }
            else
            {
                Add(_root, value);
            }
        }    
        public void Preorder()
        {
            if (_root != null)
            {
                DFS(_root);
            }
            else
            {
                Console.WriteLine("Бинарное дерево пусто");
            }
        }
        public void BFS()
        {            
            if (_root != null)
            {
                var queue = new Queue<TreeNode>();
                queue.Enqueue(_root);

                while (queue.Count > 0)
                {
                    TreeNode CurrentNode = queue.Dequeue();

                    Console.WriteLine(CurrentNode.Value);

                    if (CurrentNode.LeftNode!= null)
                    {
                        queue.Enqueue(CurrentNode.LeftNode);
                    }
                        
                    if (CurrentNode.RightNode != null)
                    {
                        queue.Enqueue(CurrentNode.RightNode);
                    }                       
                }
            }
            else
            {
                Console.WriteLine("Бинарное дерево пусто");
            }
        }
        private void Add(TreeNode node, int value)
        {
            if (value < node.Value)
            {
                if (node.LeftNode == null)
                {
                    node.LeftNode = new TreeNode(value);
                    _count++;
                }
                else
                {
                    Add(node.LeftNode, value);
                }
            }
            else
            {
                if (node.RightNode == null)
                {
                    node.RightNode = new TreeNode(value);
                    _count++;
                }
                else
                {
                    Add(node.RightNode, value);
                }
            }
        }
        private void DFS(TreeNode node)
        {
            Console.WriteLine(node.Value);

            if (node.LeftNode != null)
            {
                DFS(node.LeftNode);
            }

            if (node.RightNode != null)
            {
                DFS(node.RightNode);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            
            tree.Insert(33);
            tree.Insert(324);
            tree.Insert(3);
            tree.Insert(2);
            tree.Insert(1);
            tree.Insert(76);
            tree.Preorder();
            tree.BFS();
        }
    }
}