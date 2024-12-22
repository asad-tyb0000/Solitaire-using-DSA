using classLibrary.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classLibrary.BL
{
    internal class Node
    {
        public Cards Data { get; set; }
        public Node Next { get; set; }

        public Node(Cards data)
        {
            Data = data;
            Next = null;

        }

    }

}
