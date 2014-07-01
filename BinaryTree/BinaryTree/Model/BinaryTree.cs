using System;
using System.Collections.Generic;

namespace BinaryTree.Model
{
    public class BST
    {
        private BSTNode root;

        public BSTNode Root()
        {
            return root;
        }

        public BSTNode Insert(int value)
        {
            if (root == null){
                root = CreateNode(value);
                return root;
            }
            return InsertNode(value, root);
        }

        public bool Search(int value)
        {
            if (root == null)
                return false;
            
            return SearchNode(value, root);
        }

        public int Max()
        {
            if (root == null)
                return -1;
            return FindMax(root);
        }

        public int Min()
        {
            if (root == null)
                return -1;
            return FindMin(root);
        }

        public void Clear()
        {
            root = null;
        }

        public int Height()
        {
            return FindHeight(root);
        }

        public void Print()
        {
            Console.WriteLine("Preorder print:");
            Preorder(root);
            Console.WriteLine("\nInorder print:");
            Inorder(root);
            Console.WriteLine("\nPostorder print:");
            Postorder(root);
        }

        public void Delete(int value)
        {
            root = DeleteGo(root, value);
        }

        public void IsBST()
        {
            if (CheckIfSorted(BSTCheck(root, new List<int>())))
            {
                Console.WriteLine("Winner, we have a BST!");
            }
            else
            {
                Console.WriteLine("This makes me a said panda. :(");
            }
        }

        public void  BreadthFirstSearch()
        {
            var queue = new Queue<BSTNode>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                var temp = queue.Dequeue();
                if (temp.Left != null)
                {
                    queue.Enqueue(temp.Left);
                }

                if (temp.Right != null)
                {
                    queue.Enqueue(temp.Right);
                }

                Console.WriteLine(temp.Value);
            }

        }

        public void RandomlyModify(int target, int value)
        {
            FindNode(root, target).Value = value;
        }

        private BSTNode InsertNode(int value, BSTNode N)
        {
            if (N == null)
            {
                N = CreateNode(value);
            }
            else if (value <= N.Value)
            {
                N.Left = InsertNode(value, N.Left);
            }
            else
            {
                N.Right = InsertNode(value, N.Right);
            }
            return N;
        }

        private bool SearchNode(int value, BSTNode N)
        {
            if (N.Value == value)
            {
                return true;
            }
            else if (value < N.Value)
            {
                return SearchNode(value, N.Left);
            }
            else
            {
                return SearchNode(value, N.Right);
            }
        }



        private int FindMax(BSTNode N)
        {
            if (N.Right == null)
            {
                return N.Value;
            }
            else
            {
                return FindMax(N.Right);
            }
        }

        private int FindMin(BSTNode N)
        {
            if (N.Left == null)
            {
                return N.Value;
            }
            else
            {
                return FindMin(N.Left);
            }
        }

        private int FindHeight(BSTNode N)
        {
            if (N == null)
            {
                return -1;
            }

            return Math.Max(FindHeight(N.Left), FindHeight(N.Right)) + 1;
        }

        private void Preorder(BSTNode N)
        {
            if (N == null)
                return;

            Console.WriteLine(N.Value);
            Preorder(N.Left);
            Preorder(N.Right);
        }

        private void Inorder(BSTNode N)
        {
            if (N == null)
                return;

            Inorder(N.Left);
            Console.WriteLine(N.Value);
            Inorder(N.Right);
        }


        private void Postorder(BSTNode N)
        {
            if (N == null)
                return;
            Postorder(N.Left);
            Postorder(N.Right);
            Console.WriteLine(N.Value);
        }

        private BSTNode DeleteGo(BSTNode N, int value)
        {
            if (N == null)
                return null;
            else if (value < N.Value)
            {
                N.Left = DeleteGo(N.Left, value);
            }
            else if (value > N.Value)
            {
                N.Right = DeleteGo(N.Right, value);
            }
            //we found it
            else
            {
                //if leave, just delete it 
                if (N.Left == null && N.Right == null)
                    N = null;
                //if has only one connection, reatach
                else if (N.Left == null)
                {
                    N = N.Right;   
                }
                else if (N.Right == null)
                {
                    N = N.Left;
                }
                 //if has to children, find max in left or min in right, replace current and delete max/min
                else
                {
                    N = FMax(N.Left);
                    DeleteGo(N, value);
                }
            }
            return N;
        }

        private BSTNode FMax(BSTNode N)
        {
            if (N == null)
                return N;
            return FMax(N.Left);
        }

        private List<int> BSTCheck(BSTNode N, List<int> items)
        {
            //preored
            if (N == null){
                return items;
            }
            BSTCheck(N.Left, items);          
            items.Add(N.Value);
            BSTCheck(N.Right, items);
            return items;
        }

        private bool CheckIfSorted(List<int> items )
        {
            var previous = int.MinValue;
            foreach (var item in items)
            {
                if (item > previous)
                    previous = item;
                else
                    return false;
            }
            return true;
        }

        private BSTNode CreateNode(int value)
        {
            return new BSTNode() {Value = value};
        }

        private BSTNode FindNode(BSTNode N, int value)
        {
            if (N == null)
            {
                return null;
            }
            else if (N.Value > value)
                return FindNode(N.Left, value);
            else if (N.Value < value)
                return FindNode(N.Right, value);
            else
                return N;
        }
    }
}
