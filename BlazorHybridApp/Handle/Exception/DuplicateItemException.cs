using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHybridApp.Handle.Exception
{
    public class DuplicateItemException : System.Exception
    {
        public DuplicateItemException(string message)
            : base(message)
        {
        }
    }
}
