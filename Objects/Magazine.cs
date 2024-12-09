using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LibraryOfKazaretski
{
    internal class Magazine : ReadingRoomItem
    {
        private byte month;
        public byte Month
        {
            get { return month; }
            set
            {
                if (month > 12) throw new ArgumentException("Invalid month. The value should be between 1 - 12.");
                month = value;
            }
        }
        private uint year;
        public uint Year
        {
            get { return year; }
            set
            {
                if (year > 2500) throw new ArgumentException("Invalid release-year. The value can only be 2500 max.");
                year = value;
            }
        }
        // ------------------------
        public override string Identification
        {
            get
            {
                string acronym = "";
                switch (Publisher.ToLower())
                {
                    case "the brussels times":
                        acronym = "TBT";
                        break;
                    case "humo":
                        acronym = "HM";
                        break;
                    case "knack":
                        acronym = "KN";
                        break;
                    case "flair":
                        acronym = "FLR";
                        break;
                    case "libelle":
                        acronym = "LBL";
                        break;
                    case "van nu en straks":
                        acronym = "VNS";
                        break;
                    case "yeti":
                        acronym = "YT";
                        break;
                    default:
                        acronym = Publisher.Substring(0, 3);
                        break;
                }
                return $"{acronym}-{Month}-{Year}";
            }
        }
        public override string Category
        {
            get { return "Magazine"; }
        }
        // ------------------------
        public Magazine(string title, string publisher, byte month, uint year) : base(title, publisher)
        {
            Month = month;
            Year = year;
        }
    }
}
