using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment3.ProblemDomain
{
    /// <summary>
    /// Internal node class for the linked list
    /// </summary>
    [Serializable]
    public class Node
    {
        public User Value { get; set; }
        public Node Next { get; set; }

        public Node(User value)
        {
            Value = value;
            Next = null;
        }

    }
}
