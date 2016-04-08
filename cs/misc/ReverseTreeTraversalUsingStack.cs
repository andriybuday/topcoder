using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopCoder
{
    public class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Value { get; set; }
    }

    public class ReverseTreeTraversalUsingStack
    {
        private static List<int> TraverseTree(Node root)
        {
            if (root == null)
            {
                return new List<int>();
            }
            var result = new List<int>();
            var hash = new HashSet<Node>();
            hash.Add(root);
            var stack = new Stack<Node>();
            stack.Push(root);

            while(stack.Count > 0)
            {
                var n = stack.Peek();
                if((n.Right == null || hash.Contains(n.Right)) &&
                    (n.Left == null || hash.Contains(n.Left)))
                {
                    stack.Pop();
                    result.Add(n.Value);
                }
                if(n.Right != null && !hash.Contains(n.Right))
                {
                    stack.Push(n.Right);
                    hash.Add(n.Right);
                }
                if (n.Left != null && !hash.Contains(n.Left))
                {
                    stack.Push(n.Left);
                    hash.Add(n.Left);
                }
            }
            return result;
        }

        public static void Main(String[] args)
        {
            var tree = new Node()
            {
                Value = 7,
                Left = new Node
                {
                    Value = 3,
                    Left = new Node
                    {
                        Value = 1,
                    },
                    Right = new Node
                    {
                        Value = 2,
                    }
                },
                Right = new Node
                {
                    Value = 6,
                    Left = new Node
                    {
                        Value = 4
                    },
                    Right = new Node
                    {
                        Value = 5
                    }
                }
            };

            List<int> result = TraverseTree(tree);
            for (int i = 0; i < result.Count; i++)
            {
                Console.Write("{0} ", result[i]);
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
