using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TCO14
{
    public class BishopMove
    {
        public int howManyMoves(int r1, int c1, int r2, int c2)
        {
            if ((Math.Abs(r1 - r2) + Math.Abs(c1 - c2)) % 2 != 0) return -1;
            if (r1 == r2 && c1 == c2) return 0;
            if (Math.Abs(r1 - r2) == Math.Abs(c1 - c2)) return 1;
            return 2;
        }
    }

    public class BracketExpressions
    {
        Random random = new Random();

        public string ifPossible(string expression)
        {
            var expr = expression.ToCharArray();
            var br = new char[]{'(', ')', '[', ']', '{', '}'};
            var indexes = new List<int>();
            for (int i = 0; i < expression.Length; i++)
                if(expression[i]=='X')indexes.Add(i);

            var loops = indexes.Count;
            if (loops == 0)if(isOk(expr))return "possible";
            for (int crazy = 0; crazy < 30000; crazy++)
            {
                for (int i = 0; i < indexes.Count; i++)
                {
                    var x = random.Next(0, 6);
                    expr[indexes[i]] = br[x];
                }
                if (isOk(expr)) return "possible";
            }
            return "impossible";
        }

        public bool isOk(char[] expression)
        {
            var stack = new Stack<char>();
            for (int i = 0; i < expression.Length; i++)
            {
                var c = expression[i];
                if (c == '(' || c == '[' || c == '{')
                    stack.Push(c);
                if (c == ')' || c == ']' || c == '}')
                {
                    if (stack.Count == 0) return false;
                    var peak = stack.Peek();
                    if (c == ')' && peak != '(') return false;
                    if (c == ']' && peak != '[') return false;
                    if (c == '}' && peak != '{') return false;
                    stack.Pop();
                }
            }
            return stack.Count == 0;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new BracketExpressions().ifPossible("[]X"));
            Console.ReadKey();
        }
    }
}
