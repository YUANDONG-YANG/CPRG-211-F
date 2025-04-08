using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment3.ProblemDomain
{
    /// <summary>
    /// Internal node class for the linked list
    /// </summary>
    [Serializable]
    [DataContract]
    public class Node
    {
        [DataMember]
        public User Value { get; set; }

        [DataMember]
        public Node Next { get; set; }

        public Node(User value)
        {
            Value = value;
            Next = null;
        }

        // Empty constructor needed for deserialization
        public Node()
        {
        }
    }
}
