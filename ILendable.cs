using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfKazaretski
{
    internal interface ILendable
    {
        bool IsAvailable { get; set; }
        DateTime BorrowingDate { get; set; }
        int BorrowDays { get; set; }
        void Borrow();
        void Return();
    }
}
