using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileToTree
{
    public class BST
    {

        public BSTNode root;


        public void Insert(string value)
        {
            root = InsertNode(root, value);
        }

        public bool Find(string value)
        {
            return FindValue(root, value);
        }

        private bool FindValue(BSTNode N, string value)
        {
            if (N == null)
            {
                return false;
            }
            else if (N.Value == value)
            {
                return true;
            }
            else if (StringSmaller(value, N.Value))
            {
                return FindValue(N.Left, value);
            }
            else
            {
                return FindValue(N.Right, value);
            }
        }

        public bool LSearch(string value)
        {
            return LevelSearch(root, value);
        }

        private bool LevelSearch(BSTNode N, string value)
        {
            var q = new Queue<BSTNode>();
            q.Enqueue(N);

            while (q.Count != 0)
            {
                var temp = q.Dequeue();
                if (temp.Value == value)
                    return true;
                if(temp.Left!=null)
                    q.Enqueue(temp.Left);
                if (temp.Right != null)
                    q.Enqueue(temp.Right);
            }
            return false;
        }

        private BSTNode InsertNode(BSTNode N, string value)
        {
            if (N == null)
            {
                N = new BSTNode()
                {
                    Value = value
                };
            }
            else if (StringSmaller(value, N.Value))
            {
               N.Left= InsertNode(N.Left, value);
            }
            else
            {
               N.Right= InsertNode(N.Right, value);
            }
            return N;
        }

        public void Print()
        {
            InOrder(root);
        }

        private void InOrder(BSTNode N)
        {
            if (N == null)
            {
                return;
            }
            InOrder(N.Left);
            Console.WriteLine(N.Value);
            InOrder(N.Right);
        }

        private bool StringSmaller(string value1, string value2)
        {
            int N = Math.Min(value1.Count(), value2.Count());
            char v1;
            char v2;

            for (int i = 0; i<N; i++)
            {
                v1 = value1[i];
                v2 = value2[i];
                if (v1 < v2)
                {
                    return true;
                }
                else if (v2 < v1)
                {
                    return false;
                }
                else
                {
                    continue;
                }
            }

            if (N == value2.Count())
            {
                return false;
            }
            return true;
        }
    }
}
