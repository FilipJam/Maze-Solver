using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    internal class Node
    {
        private Node next;
        private int[] val;

        public Node(int[] val)
        {
            this.val = val;
        }

        public Node Next { get => next; set => next = value; }
        public int[] Value { get => val; }
    }
}
