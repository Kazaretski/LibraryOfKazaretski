using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfKazaretski
{
    internal abstract class ReadingRoomItem
    {
        private string title;
        private string publisher;
        public abstract string Identification { get; }
        public abstract string Category { get; }
        // ------------------------
        public string Title
        {
            get { return title; }
        }
        public string Publisher
        {
            get { return publisher; }
            set
            {
                publisher = value;
                if (value == "" || value is null) publisher = "(Unknown Publisher)";
            }
        }
        // ------------------------
        protected ReadingRoomItem(string title, string publisher)
        {
            this.title = title;
            Publisher = publisher;
            Library.AllReadingRoom[DateTime.Now] = this;
        }
    }
}
