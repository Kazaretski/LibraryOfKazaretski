using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfKazaretski
{
    internal class NoItemsFoundException: NullReferenceException
    {
        public string Message { get; set; }
        public NoItemsFoundException(string msg = "No items were found.")
        {
            Message = msg;
        }
    }
}
