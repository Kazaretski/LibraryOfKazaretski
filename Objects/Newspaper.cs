using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfKazaretski
{
    internal class Newspaper : ReadingRoomItem
    {
        private DateTime release;
        public DateTime Release
        {
            get { return release; }
            set { release = value; }
        }
        // ------------------------
        public override string Identification
        {
            get
            {
                string acronym = "";
                switch (Publisher.ToLower())
                {
                    case "gazet van antwerpen":
                        acronym = "GVA";
                        break;
                    case "het laatste nieuws":
                        acronym = "HLN";
                        break;
                    case "het nieuwsblad":
                        acronym = "HNB";
                        break;
                    case "de standaard":
                        acronym = "DS";
                        break;
                    case "de morgen":
                        acronym = "DM";
                        break;
                    case "de tijd":
                        acronym = "DT";
                        break;
                    default:
                        acronym = Publisher.Substring(0, 3);
                        break;
                }
                return $"{acronym}-{Release.Day:d2}-{Release.Month:d2}-{Release.Year:d4}";
            }
        }
        public override string Category
        {
            get { return "Newspaper"; }
        }
        // ------------------------
        public Newspaper(string title, string publisher, DateTime date) : base(title, publisher)
        {
            Release = date;
        }
    }
}
