using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfKazaretski
{
    public enum Genre
    {
        Art, Biography, Comic, Educational, Fiction, Humor, Mystery, NonFiction, Romance, School, SelfHelp, Thriller, Unspecified
    }
    class Book : ILendable
    {
        private string title;
        private string author;
        private double isbn;
        private Genre genre;
        private int pageCount;
        private string publisher;
        private int publishYear;
        private double price;
        private bool isAvailable;
        private DateTime borrowingDate;
        private int borrowDays;
        // ------------------------
        public string Title
        {
            get => title;
            set { title = value; }
        }
        public string Author
        {
            get => author;
            set { author = value; }
        }
        public double Isbn
        {
            get => isbn;
            set
            {
                if (Convert.ToString(value).Length > 13) value = Convert.ToDouble(Convert.ToString(value).Substring(0, 13));
                else if (Convert.ToString(value).Length < 13) throw new InvalidDataException("An ISBN needs to be comprised of 13 characters.");
                isbn = value;
            }
        }
        public Genre Genre
        {
            get => genre;
            set { genre = value; }
        }
        public int PageCount
        {
            get => pageCount;
            set { pageCount = value; }
        }
        public string Publisher
        {
            get => publisher;
            set
            {
                publisher = value;
                if (value == "" || value is null) publisher = "(Unknown Publisher)";
            }
        }
        public int PublishYear
        {
            get => publishYear;
            set { publishYear = value; }
        }
        public double Price
        {
            get => price * 100 / 100;
            set { price = value; }
        }
        public bool IsAvailable
        {
            get => isAvailable;
            set { isAvailable = value; }
        }
        public DateTime BorrowingDate
        {
            get => borrowingDate;
            set { borrowingDate = value; }
        }
        public int BorrowDays
        {
            get
            {
                if (Genre == Genre.Educational) return 10;
                return 20;
            }
            set { borrowDays = value; }
        }
        // ------------------------
        public Book(string title, string author)
        {
            Title = title;
            Author = author;
            Genre = Genre.Unspecified;
            IsAvailable = true;
            Library.AllBooks.Add(this);
        }
        public void ShowInfo()
        {
            Program.ColText("╔══════════BOOK═INFO═════════\n║ Title: ", "9");
            Console.Write(Title);
            Program.ColText("\n║ Author: ", "9");
            Console.WriteLine(Author);
            Program.ColText("║ ", "9");
            if (Genre == Genre.Unspecified) Program.ColText("Genre: [...]\n", "8");
            else
            {
                Program.ColText("Genre: ", "9");
                Console.WriteLine(Genre);
            }
            Program.ColText("║\n║ ", "9");
            if (Isbn == 0) Program.ColText("ISBN: [...]\n", "8");
            else
            {
                Program.ColText("ISBN: ", "9");
                Console.WriteLine(Isbn);
            }
            Program.ColText("║ ", "9");
            if (PageCount == 0) Program.ColText("Page Count: [...]\n", "8");
            else
            {
                Program.ColText("Page Count: ", "9");
                Console.WriteLine(PageCount);
            }
            Program.ColText("║ ", "9");
            if (PublishYear == 0) Program.ColText("Publish Year: [...]\n", "8");
            else
            {
                Program.ColText("Publish Year: ", "9");
                Console.WriteLine(PublishYear);
            }
            Program.ColText("║ ", "9");
            if (Publisher is null || Publisher == "") Program.ColText("Publisher: [...]\n", "8");
            else
            {
                Program.ColText("Publisher: ", "9");
                Console.WriteLine(Publisher);
            }
            Program.ColText("║\n║ ", "9");
            if (Price == 0) Program.ColText("Price: [...]\n", "8");
            else
            {
                Program.ColText("Price: ", "9");
                Console.WriteLine($"${Price}");
            }
            Program.ColText("╚════════════════════════════\n", "9");
        }
        public static List<Book> GetBooksFromFile(string path)
        {
            List<Book> exports = new List<Book>();
            try
            {
                string[] fileLines = File.ReadAllLines(path);
                List<string[]> data = new List<string[]>();
                for (int i = 0; i < fileLines.Length; i++) data.Add(fileLines[i].Split(";;"));
                foreach (var entry in data)
                {
                    Book toAdd = new Book(entry[0], entry[1]);
                    if (!(entry[2] is null)) toAdd.Isbn = Convert.ToDouble(entry[2]);
                    switch (entry[3])
                    {
                        case "Art": toAdd.Genre = Genre.Art; break;
                        case "Biography": toAdd.Genre = Genre.Biography; break;
                        case "Comic": toAdd.Genre = Genre.Comic; break;
                        case "Educational": toAdd.Genre = Genre.Educational; break;
                        case "Fiction": toAdd.Genre = Genre.Fiction; break;
                        case "Humor": toAdd.Genre = Genre.Humor; break;
                        case "Mystery": toAdd.Genre = Genre.Mystery; break;
                        case "NonFiction": toAdd.Genre = Genre.NonFiction; break;
                        case "Romance": toAdd.Genre = Genre.Romance; break;
                        case "Thriller": toAdd.Genre = Genre.Thriller; break;
                        default: toAdd.Genre = Genre.Unspecified; break;
                    }
                    if (!(entry[4] is null)) toAdd.PageCount = Convert.ToInt32(entry[4]);
                    if (!(entry[5] is null)) toAdd.Publisher = entry[5];
                    if (!(entry[6] is null)) toAdd.PublishYear = Convert.ToInt32(entry[6]);
                    if (!(entry[7] is null)) toAdd.Price = Convert.ToDouble(entry[7]);
                    if (!(entry[8] is null)) toAdd.IsAvailable = Convert.ToBoolean(entry[8]);
                    exports.Add(toAdd);
                }
            }
            catch (Exception e)
            {
                Program.ColText($"[{e.GetType().Name}] {e.Message}\n", "C");
            }
            return exports;
        }
        public void Borrow()
        {
            IsAvailable = false;
            Console.WriteLine($"\n\nYou are now borrowing this book. Please return it within {BorrowDays} days.");
            Program.ExitSequence();
        }
        public void Return()
        {
            IsAvailable = true;
            Console.WriteLine("\n\nThank you for returning the book!");
            Program.ExitSequence();
        }
    }
}
