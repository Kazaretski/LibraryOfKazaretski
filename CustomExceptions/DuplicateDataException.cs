using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfKazaretski
{
    internal class DuplicateDataException : ArgumentException
    {
        public string Message { get; set; }
        public DuplicateDataException(string msg = "Data with these values already exists.")
        {
            Message = msg;
        }
    }
}
