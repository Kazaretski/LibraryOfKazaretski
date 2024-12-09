using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfKazaretski
{
    internal class Library
    {
        private static List<Book> allBooks = new List<Book>();
        private string name;
        // ------------------------
        public static Dictionary<DateTime, ReadingRoomItem> AllReadingRoom = new Dictionary<DateTime, ReadingRoomItem>();
        public static List<Book> AllBooks
        {
            get => allBooks;
        }
        public string Name
        {
            get => name;
            set { name = value; }
        }

        // ------------------------
        public Library(string name)
        {
            Name = name;
        }
        // ---------------------------------------------------------------------------------------------------------------------------------
        public static void AddBook()
        {
            List<Book> foundBooks = new List<Book>();
            Program.ColText("Title:\nAuthor:", "9");
            Console.Write("\n\nWhat's the book's title?\n> ");
            string t = Console.ReadLine();
            if (t == "" || t is null) throw new InvalidDataException("The title field cannot be left blank.");
            Console.Clear();
            Program.ColText("Title: ", "9");
            Program.ColText(t, "B");
            Program.ColText("\nAuthor: ", "9");
            Console.Write("\n\nWho's the book's author?\n> ");
            string a = Console.ReadLine();
            if (a == "" || a is null) throw new InvalidDataException("The author field cannot be left blank.");
            Console.Clear();
            foreach (Book book in AllBooks) if (book.Title.ToLower() == t.ToLower() && book.Author.ToLower() == a.ToLower()) foundBooks.Add(book);
            if (foundBooks.Count > 0) throw new DuplicateDataException("A book like this already exists.");
            Book newBook = new Book(t, a);
            Program.ColText("Title: ", "9");
            Program.ColText(t, "B");
            Program.ColText("\nAuthor: ", "9");
            Program.ColText(a, "B");
            Program.ColText($"\n\nSuccessfully added a new book: \"{newBook.Title}\" by {newBook.Author}\n", "A");
            Program.ExitSequence();
        }
        public static void AddInfoToBook()
        {
            string[] searchOptions = new string[]
            {
                "ISBN",
                "Genre",
                "Page Count",
                "Publisher",
                "Publish Year",
                "Price"
            };
            List<Book> foundBooks = new List<Book>();
            Program.ColText("Title:\nAuthor:", "9");
            Console.Write("\n\nWhat's the book's title?\n> ");
            string t = Console.ReadLine();
            if (t == "" || t is null) throw new InvalidDataException("The title field cannot be left blank.");
            Console.Clear();
            Program.ColText("Title: ", "9");
            Program.ColText(t, "B");
            Program.ColText("\nAuthor: ", "9");
            Console.Write("\n\nWho's the book's author?\n> ");
            string a = Console.ReadLine();
            if (a == "" || a is null) throw new InvalidDataException("The author field cannot be left blank.");
            Console.Clear();
            foreach (Book book in AllBooks) if (book.Title.ToLower() == t.ToLower() && book.Author.ToLower() == a.ToLower()) foundBooks.Add(book);
            if (foundBooks.Count == 0) throw new NoItemsFoundException("No book was found using your query.");
            int userInput = 69;
            string errorMsg = "";
            Book b = foundBooks[0];
            while (userInput != 0)
            {
                try
                {
                    Program.ColText("Title: ", "9");
                    Program.ColText(t, "B");
                    Program.ColText("\nAuthor: ", "9");
                    Program.ColText(a, "B");
                    Console.WriteLine("\n");
                    Program.ColText("[1] ISBN: ");
                    if (b.Isbn == 0) Console.WriteLine("[...]");
                    else
                    {
                        Console.WriteLine(b.Isbn);
                    }
                    Program.ColText("[2] Genre: ");
                    if (b.Genre == Genre.Unspecified) Console.WriteLine("[...]");
                    else
                    {
                        Console.WriteLine(b.Genre.ToString());
                    }
                    Program.ColText("[3] Page Count: ");
                    if (b.PageCount == 0) Console.WriteLine("[...]");
                    else
                    {
                        Console.WriteLine(b.PageCount);
                    }
                    Program.ColText("[4] Publisher: ");
                    if (b.Publisher is null || b.Publisher == "") Console.WriteLine("[...]");
                    else
                    {
                        Console.WriteLine(b.Publisher);
                    }
                    Program.ColText("[5] Publish Year: ");
                    if (b.PublishYear == 0) Console.WriteLine("[...]");
                    else
                    {
                        Console.WriteLine(b.PublishYear);
                    }
                    Program.ColText("[6] Price: ");
                    if (b.Price == 0) Console.WriteLine("[...]");
                    else Console.WriteLine(b.Price);
                    Console.WriteLine();
                    Program.ColText("[0] Exit\n", "C");
                    if (errorMsg.Length > 0) Program.ColText($"\n{errorMsg}\n", "C");
                    errorMsg = "";
                    Console.Write("Insert a number to change the value:\n(Or 0 to exit this submenu)\n> ");
                    userInput = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    Program.ColText("Title: ", "9");
                    Program.ColText(t, "B");
                    Program.ColText("\nAuthor: ", "9");
                    Program.ColText(a, "B");
                    Console.WriteLine("\n");
                    switch (userInput)
                    {
                        case 0: break;
                        case 1:
                            Console.Write("Input a new ISBN > ");
                            b.Isbn = Convert.ToDouble(Console.ReadLine());
                            break;
                        case 2:
                            Console.Write("Input a new Genre > ");
                            string inputGenre = Console.ReadLine();
                            switch (inputGenre.ToLower())
                            {
                                case "art": b.Genre = Genre.Art; break;
                                case "biography": b.Genre = Genre.Art; break;
                                case "comic": b.Genre = Genre.Art; break;
                                case "educational": b.Genre = Genre.Art; break;
                                case "fiction": b.Genre = Genre.Art; break;
                                case "humor": b.Genre = Genre.Art; break;
                                case "mystery": b.Genre = Genre.Art; break;
                                case "nonfiction": b.Genre = Genre.Art; break;
                                case "romance": b.Genre = Genre.Art; break;
                                case "thriller": b.Genre = Genre.Art; break;
                                default:
                                    errorMsg = "Invalid genre.";
                                    b.Genre = Genre.Unspecified;
                                    break;
                            }
                            break;
                        case 3:
                            Console.Write("Input a new page count > ");
                            b.PageCount = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 4:
                            Console.Write("Input a new publisher > ");
                            b.Publisher = Console.ReadLine();
                            break;
                        case 5:
                            Console.Write("Input a new publish year > ");
                            b.PublishYear = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 6:
                            Console.Write("Input a new price > ");
                            b.Price = Convert.ToDouble(Console.ReadLine());
                            break;
                        default:
                            errorMsg = "Invalid option. Try again.";
                            break;
                    }
                }
                catch (FormatException)
                {
                    errorMsg = "Please make sure to input a number.";
                }
                catch (OverflowException)
                {
                    errorMsg = "This number is too big for the system to understand.";
                }
                catch (Exception e)
                {
                    errorMsg = $"{e.GetType().Name}\n";
                }
                finally
                {
                    Console.Clear();
                }
            }
        }
        public static void InfoAboutBook()
        {
            List<Book> foundBooks = new List<Book>();
            Program.ColText("Title:\nAuthor:", "9");
            Program.ColText("\n\n╔══════════BOOK═INFO═════════\n║ Title: [...]\n║ Author: [...]\n║ Genre: [...]\n║\n║ ISBN: [...]\n║ Page Count: [...]\n║ Publish Year: [...]\n║ Publisher: [...]\n║\n║ Price: [...]\n╚════════════════════════════", "8");
            Console.Write("\n\nWhat's the book's title?\n> ");
            string t = Console.ReadLine();
            if (t == "" || t is null) throw new InvalidDataException("The title field cannot be left blank.");
            Console.Clear();
            Program.ColText("Title: ", "9");
            Program.ColText(t, "B");
            Program.ColText("\nAuthor: ", "9");
            Program.ColText("\n\n╔══════════BOOK═INFO═════════\n║ Title: [...]\n║ Author: [...]\n║ Genre: [...]\n║\n║ ISBN: [...]\n║ Page Count: [...]\n║ Publish Year: [...]\n║ Publisher: [...]\n║\n║ Price: [...]\n╚════════════════════════════", "8");
            Console.Write("\n\nWho's the book's author?\n> ");
            string a = Console.ReadLine();
            if (a == "" || a is null) throw new InvalidDataException("The author field cannot be left blank.");
            Console.Clear();
            foreach (Book book in AllBooks) if (book.Title.ToLower() == t.ToLower() && book.Author.ToLower() == a.ToLower()) foundBooks.Add(book);
            if (foundBooks.Count == 0) throw new NoItemsFoundException("No book was found using your query.");
            Program.ColText("Title: ", "9");
            Program.ColText(t, "B");
            Program.ColText("\nAuthor: ", "9");
            Program.ColText(a, "B");
            Program.ColText("\n\n", "4");
            foreach (Book book in foundBooks) book.ShowInfo();
            Console.WriteLine();
            Program.ExitSequence();
        }
        public static void AdvancedSearch()
        {
            string[] searchOptions = new string[]
            {
                "ISBN",
                "Genre",
                "Page Count",
                "Publisher",
                "Publish Year",
                "Price"
            };
            int searchChoice = 69;
            string errorMsg = "";
            while (searchChoice != 0)
            {
                Program.ColText("Advanced Book Searching\n", "9");
                for (int i = 0; i < searchOptions.Length; i++) Program.ColText($" [{i + 1}] {searchOptions[i]}\n", "B");
                Program.ColText("\n [0] Exit\n", "B");
                if (errorMsg.Length > 0) Program.ColText($"{errorMsg}", "C");
                errorMsg = "";
                Program.ColText("\n> ", "9");
                try
                {
                    searchChoice = Convert.ToInt32(Console.ReadLine());
                    List<Book> toSearch = new List<Book>();
                    Console.Clear();
                    switch (searchChoice)
                    {
                        case 1:
                            Program.ColText("ISBN: ", "9");
                            Console.Write("\n\nWhat's the book's ISBN?\n> ");
                            double inputISBN = Convert.ToDouble(Console.ReadLine());
                            Console.Clear();
                            Program.ColText("ISBN: ", "9");
                            Program.ColText(Convert.ToString(inputISBN), "B");
                            Console.WriteLine("\n");
                            foreach (Book i in AllBooks) if (i.Isbn == inputISBN) toSearch.Add(i);
                            if (toSearch.Count == 0) throw new NoItemsFoundException("No books were found with this ISBN.");
                            foreach (Book i in toSearch) Console.WriteLine($" - \"{i.Title}\" by {i.Author}");
                            Console.WriteLine();
                            Program.ExitSequence();
                            break;
                        case 2:
                            Program.ColText("Genre: ", "9");
                            Console.Write("\n\nWhat's the book's Genre?\n");
                            Program.ColText("(Art, Biography, Comic, Educational, Fiction...\nHumor, Mystery, NonFiction, Romance, Thriller)\n", "E");
                            Console.Write("> ");
                            string inputGenre = Console.ReadLine();
                            Genre outputGenre = Genre.Unspecified;
                            switch (inputGenre.ToLower())
                            {
                                case "art": outputGenre = Genre.Art; break;
                                case "biography": outputGenre = Genre.Biography; break;
                                case "comic": outputGenre = Genre.Comic; break;
                                case "educational": outputGenre = Genre.Educational; break;
                                case "fiction": outputGenre = Genre.Fiction; break;
                                case "humor": outputGenre = Genre.Humor; break;
                                case "mystery": outputGenre = Genre.Mystery; break;
                                case "nonfiction": outputGenre = Genre.NonFiction; break;
                                case "romance": outputGenre = Genre.Romance; break;
                                case "thriller": outputGenre = Genre.Thriller; break;
                                default: break;
                            }
                            if (outputGenre == Genre.Unspecified) throw new InvalidDataException("This genre does not exist.");
                            Console.Clear();
                            Program.ColText("Genre: ", "9");
                            Program.ColText(inputGenre, "B");
                            Console.WriteLine("\n");
                            foreach (Book i in AllBooks) if (i.Genre == outputGenre) toSearch.Add(i);
                            if (toSearch.Count == 0) throw new NoItemsFoundException("No books were found with this genre.");
                            foreach (Book i in toSearch) Console.WriteLine($" - \"{i.Title}\" by {i.Author}");
                            Console.WriteLine();
                            Program.ExitSequence();
                            break;
                        case 3:
                            Program.ColText("Minimum:\nMaximum:", "9");
                            Console.Write("\n\nWhat's the book's minimum page count?\n> ");
                            int inputMinPages = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            Program.ColText("Minimum: ", "9");
                            Program.ColText(Convert.ToString(inputMinPages), "B");
                            Program.ColText("\nMaximum:", "9");
                            Console.Write("\n\nWhat's the book's maximum page count?\n> ");
                            int inputMaxPages = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            Program.ColText("Minimum: ", "9");
                            Program.ColText(Convert.ToString(inputMinPages), "B");
                            Program.ColText("\nMaximum: ", "9");
                            Program.ColText(Convert.ToString(inputMaxPages), "B");
                            Console.WriteLine("\n");
                            foreach (Book i in AllBooks) if (i.PageCount >= inputMinPages && i.PageCount <= inputMaxPages) toSearch.Add(i);
                            if (toSearch.Count == 0) throw new NoItemsFoundException("No books were found with this page count range.");
                            foreach (Book i in toSearch) Console.WriteLine($" - \"{i.Title}\" by {i.Author}");
                            Console.WriteLine();
                            Program.ExitSequence();
                            break;
                        case 4:
                            Program.ColText("Publisher: ", "9");
                            Console.Write("\n\nWho's the book's Publisher?\n> ");
                            string inputPublisher = Console.ReadLine();
                            Console.Clear();
                            Program.ColText("Publisher: ", "9");
                            Program.ColText(inputPublisher, "B");
                            Console.WriteLine("\n");
                            foreach (Book i in AllBooks) if (i.Publisher.ToLower() == inputPublisher.ToLower()) toSearch.Add(i);
                            if (toSearch.Count == 0) throw new NoItemsFoundException("No books were found with this publisher.");
                            foreach (Book i in toSearch) Console.WriteLine($" - \"{i.Title}\" by {i.Author}");
                            Console.WriteLine();
                            Program.ExitSequence();
                            break;
                        case 5:
                            Program.ColText("Publish Year: ", "9");
                            Console.Write("\n\nWhat's the book's publish year?\n> ");
                            int inputYear = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            Program.ColText("Publish Year: ", "9");
                            Program.ColText(Convert.ToString(inputYear), "B");
                            Console.WriteLine("\n");
                            foreach (Book i in AllBooks) if (i.PublishYear == inputYear) toSearch.Add(i);
                            if (toSearch.Count == 0) throw new NoItemsFoundException("No books were found with this ISBN.");
                            foreach (Book i in toSearch) Console.WriteLine($" - \"{i.Title}\" by {i.Author}");
                            Console.WriteLine();
                            Program.ExitSequence();
                            break;
                        case 6:
                            Program.ColText("Minimum:\nMaximum:", "9");
                            Console.Write("\n\nWhat's the book's minimum price?\n> ");
                            double inputMinPrice = Convert.ToDouble(Console.ReadLine());
                            Console.Clear();
                            Program.ColText("Minimum: ", "9");
                            Program.ColText(Convert.ToString(inputMinPrice), "B");
                            Program.ColText("\nMaximum:", "9");
                            Console.Write("\n\nWhat's the book's maximum price?\n> ");
                            double inputMaxPrice = Convert.ToDouble(Console.ReadLine());
                            Console.Clear();
                            Program.ColText("Minimum: ", "9");
                            Program.ColText(Convert.ToString(inputMinPrice), "B");
                            Program.ColText("\nMaximum: ", "9");
                            Program.ColText(Convert.ToString(inputMaxPrice), "B");
                            Console.WriteLine("\n");
                            foreach (Book i in AllBooks) if (i.Price >= inputMinPrice && i.Price <= inputMaxPrice) toSearch.Add(i);
                            if (toSearch.Count == 0) throw new NoItemsFoundException("No books were found with this price range.");
                            foreach (Book i in toSearch) Console.WriteLine($" - \"{i.Title}\" by {i.Author}");
                            Console.WriteLine();
                            Program.ExitSequence();
                            break;
                    }
                }
                catch (FormatException)
                {
                    errorMsg = "Please make sure to input a number.\n";
                }
                catch (OverflowException)
                {
                    errorMsg = "This number is too big for the system to understand.\n";
                }
                catch (NoItemsFoundException e)
                {
                    errorMsg = $"{e.Message}\n";
                }
                catch (InvalidDataException e)
                {
                    errorMsg = $"{e.Message}\n";
                }
                catch (Exception e)
                {
                    errorMsg = $"{e.GetType().Name}\n";
                }
                finally
                {
                    Console.Clear();
                }
            }
        }
        public static void RemoveBook()
        {
            List<Book> foundBooks = new List<Book>();
            Program.ColText("Title:\nAuthor:", "9");
            Console.Write("\n\nWhat's the book's title?\n> ");
            string t = Console.ReadLine();
            if (t == "" || t is null) throw new InvalidDataException("The title field cannot be left blank.");
            Console.Clear();
            Program.ColText("Title: ", "9");
            Program.ColText(t, "B");
            Program.ColText("\nAuthor: ", "9");
            Console.Write("\n\nWho's the book's author?\n> ");
            string a = Console.ReadLine();
            if (a == "" || a is null) throw new InvalidDataException("The author field cannot be left blank.");
            Console.Clear();
            foreach (Book book in AllBooks) if (book.Title.ToLower() == t.ToLower() && book.Author.ToLower() == a.ToLower()) foundBooks.Add(book);
            if (foundBooks.Count == 0) throw new NoItemsFoundException("No book was found using your query.");
            Program.ColText("Title: ", "9");
            Program.ColText(t, "B");
            Program.ColText("\nAuthor: ", "9");
            Program.ColText(a, "B");
            Program.ColText("\n\n[!!] ", "4");
            Program.ColText("Are you sure you want to delete this book?", "C");
            Program.ColText(" [!!]\n", "4");
            Console.Write("Type \"yes\" to confirm: ");
            string confirmation = Console.ReadLine();
            if (confirmation.ToLower() == "yes") foreach (Book book in AllBooks) if (book.Title.ToLower() == t.ToLower() && book.Author.ToLower() == a.ToLower()) AllBooks.Remove(book);
            Console.Clear();
            Program.ColText("Title: ", "9");
            Program.ColText(t, "B");
            Program.ColText("\nAuthor: ", "9");
            Program.ColText(a, "B");
            Program.ColText("\n\nThe book has been successfully deleted.\n", "2");
            Program.ExitSequence();
        }
        public static void SearchByAuthor()
        {
            Program.ColText("Author:", "9");
            Console.Write("\n\nWhat's the author's name?\n> ");
            string a = Console.ReadLine();
            Console.Clear();
            Program.ColText("Author: ", "9");
            Program.ColText(a, "B");
            Console.WriteLine("\n");
            List<Book> query = new List<Book>();
            foreach (Book book in AllBooks) if (book.Author.ToLower() == a.ToLower()) query.Add(book);
            if (query.Count == 0) throw new NoItemsFoundException("This author was not found. Did you spell it right?");
            for (int i = 0; i < query.Count; i++) Console.WriteLine($"[{i + 1}]\t{query[i].Title}");
            Console.WriteLine();
            Program.ExitSequence();
        }
        public static void SearchByISBN(double isbn)
        {
            List<Book> byIsbn = new List<Book>();
            foreach (Book book in AllBooks) if (book.Isbn == isbn) byIsbn.Add(book);
            if (byIsbn.Count > 0) for (int i = 0; i < byIsbn.Count; i++) Console.WriteLine($"[{i + 1}]\t{byIsbn[i].Title} (by ${byIsbn[i].Author})");
            Program.ExitSequence();
        }
        public static void AllBooksByAuthor()
        {
            Program.ColText("Author:", "9");
            Console.Write("\n\nInput the name of the author:\n> ");
            string author = Console.ReadLine();
            List<Book> byAuthor = new List<Book>();
            foreach (Book book in AllBooks) if (book.Author.ToLower() == author.ToLower()) byAuthor.Add(book);
            if (byAuthor.Count <= 0) Program.ColText($"No books were found by the author {author}.\n", "C");
            else
            {
                Console.WriteLine($"Books by author {author}:");
                for (int i = 0; i < byAuthor.Count; i++) Console.WriteLine($" [{i + 1}]\t{byAuthor[i].Title}");
            }
            Program.ExitSequence();
        }
        public static void AddNewspaper()
        {
            Program.ColText("Name:\nDate:\nPublisher:", "9");
            Console.Write("\n\nWhat's the name of the newspaper?\n> ");
            string n = Console.ReadLine();
            Console.Clear();
            Program.ColText("Name: ", "9");
            Program.ColText(n, "B");
            Program.ColText("\nDate:\nPublisher:", "9");
            Console.Write("\n\nWhat is the date of this newspaper? (DD/MM/YYYY)\n(Leave blank for current date.)\n> ");
            string inputDate = Console.ReadLine();
            DateTime d = DateTime.Today;
            string[] dateValues = { Convert.ToString(d.Day), Convert.ToString(d.Month), Convert.ToString(d.Year) };
            if (inputDate.Contains("/"))
            {
                dateValues = inputDate.Split("/");
                d = new DateTime(Convert.ToInt32(dateValues[2]), Convert.ToInt32(dateValues[1]), Convert.ToInt32(dateValues[0]));
            }
            Console.Clear();
            Program.ColText("Name: ", "9");
            Program.ColText(n, "B");
            Program.ColText("\nDate: ", "9");
            Program.ColText($"{dateValues[0]}/{dateValues[1]}/{dateValues[2]}\n", "B");
            Program.ColText("Publisher:", "9");
            Console.Write("\n\nWho is the publisher of this newspaper?\n> ");
            string p = Console.ReadLine();
            Console.Clear();
            Newspaper temp = new Newspaper(n, p, d);
            Program.ColText("Name: ", "9");
            Program.ColText(n, "B");
            Program.ColText("\nDate: ", "9");
            Program.ColText($"{dateValues[0]}/{dateValues[1]}/{dateValues[2]}\n", "B");
            Program.ColText("Publisher: ", "9");
            Program.ColText(p, "B");
            Program.ColText($"\n\nSuccessfully added a new newspaper: \"{n}\" ({d.Day}/{d.Month}/{d.Year})\nPublished by {p}.\n\n", "A");
            Program.ExitSequence();
        }
        public static void AddMagazine()
        {
            Program.ColText("Name:\nMonth:\nYear:\nPublisher:", "9");
            Console.Write("\n\nWhat's the name of the magazine?\n> ");
            string n = Console.ReadLine();
            Console.Clear();
            Program.ColText("Name: ", "9");
            Program.ColText(n, "B");
            Program.ColText("\nMonth:\nYear:\nPublisher:", "9");
            Console.Write("\n\nWhat month was this magazine made?\n(Leave blank for current month.)\n> ");
            string inputMonth = Console.ReadLine();
            if (inputMonth == "") inputMonth = Convert.ToString(DateTime.Today.Month);
            byte m = Convert.ToByte(inputMonth);
            if (m > 12 || m < 1) throw new InvalidDataException("Invalid month. The value should be between 1 - 12.");
            Console.Clear();
            Program.ColText("Name: ", "9");
            Program.ColText(n, "B");
            Program.ColText("\nMonth: ", "9");
            Program.ColText(Convert.ToString(m), "B");
            Program.ColText("\nYear:\nPublisher:", "9");
            Console.Write("\n\nWhat year was this magazine made?\n(Leave blank for current year.)\n> ");
            string inputYear = Console.ReadLine();
            if (inputYear == "") inputYear = Convert.ToString(DateTime.Today.Year);
            uint y = Convert.ToUInt32(inputYear);
            if (y > 2500) throw new InvalidDataException("Invalid release-year. The value can only be 2500 max.");
            Console.Clear();
            Program.ColText("Name: ", "9");
            Program.ColText(n, "B");
            Program.ColText("\nMonth: ", "9");
            Program.ColText(Convert.ToString(m), "B");
            Program.ColText("\nYear: ", "9");
            Program.ColText(Convert.ToString(y), "B");
            Program.ColText("\nPublisher:", "9");
            Console.Write("\n\nWho is the publisher of this newspaper?\n> ");
            string p = Console.ReadLine();
            Console.Clear();
            Magazine temp = new Magazine(n, p, m, y);
            Program.ColText("Name: ", "9");
            Program.ColText(n, "B");
            Program.ColText("\nMonth: ", "9");
            Program.ColText(Convert.ToString(m), "B");
            Program.ColText("\nYear: ", "9");
            Program.ColText(Convert.ToString(y), "B");
            Program.ColText("\nPublisher: ", "9");
            Program.ColText(p, "B");
            Program.ColText($"\n\nSuccessfully added a new newspaper: \"{n}\" ({m}/{y})\nPublished by {p}.\n\n", "A");
            Program.ExitSequence();
        }
        public static void ShowAllNewspapers()
        {
            try
            {
                List<Newspaper> all = new List<Newspaper>();
                foreach (Newspaper np in AllReadingRoom.Values) if (np.Category == "Newspaper") all.Add(np);
                if (all.Count == 0) throw new NoItemsFoundException("There are no newspapers in stock right now.");
                foreach (var i in all)
                {
                    Program.ColText($" - {i.Publisher}: {i.Title}", "6");
                    Program.ColText($" [{i.Identification}]\n", "8");
                }
                Console.WriteLine("\n");
                Program.ExitSequence();
            }
            catch (Exception)
            {
                throw new NoItemsFoundException("There are no magazines in stock right now.");
            }
        }
        public static void ShowAllMagazines()
        {
            try
            {
                List<Magazine> all = new List<Magazine>();
                foreach (Magazine np in AllReadingRoom.Values) if (np.Category == "Magazine") all.Add(np);
                if (all.Count == 0) throw new NoItemsFoundException("There are no magazines in stock right now.");
                foreach (var i in all)
                {
                    Program.ColText($" - {i.Publisher}: {i.Title} ({i.Month}/{i.Year})", "D");
                    Program.ColText($" [{i.Identification}]\n", "8");
                }
                Console.WriteLine();
                Program.ExitSequence();
            }
            catch (Exception)
            {
                throw new NoItemsFoundException("There are no magazines in stock right now.");
            }
        }
        public static void AcquisitionsReadingRoomToday()
        {
            List<ReadingRoomItem> all = new List<ReadingRoomItem>();
            foreach (var rri in AllReadingRoom)
            {
                bool req1 = rri.Key.Year == DateTime.Today.Year;
                bool req2 = rri.Key.Month == DateTime.Today.Month;
                bool req3 = rri.Key.Day == DateTime.Today.Day;
                if (req1 && req2 && req3) all.Add(rri.Value);
            }
            if (all.Count == 0) throw new NoItemsFoundException("There are no new acquisitions made today.");
            foreach (var i in all)
            {
                if (i.Category == "Newspaper") Program.ColText($" - [NEWSPAPER] {i.Title} (by {i.Publisher})", "6");
                else if (i.Category == "Magazine") Program.ColText($" - [NEWSPAPER] {i.Title} (by {i.Publisher})", "D");
                Program.ColText($" [{i.Identification}]\n", "8");
            }
            Console.WriteLine();
            Program.ExitSequence();
        }
        public static void BorrowBook()
        {
            List<Book> foundBooks = new List<Book>();
            Program.ColText("Title:\nAuthor:", "9");
            Console.Write("\n\nWhat's the book's title?\n> ");
            string t = Console.ReadLine();
            if (t == "" || t is null) throw new InvalidDataException("The title field cannot be left blank.");
            Console.Clear();
            Program.ColText("Title: ", "9");
            Program.ColText(t, "B");
            Program.ColText("\nAuthor: ", "9");
            Console.Write("\n\nWho's the book's author?\n> ");
            string a = Console.ReadLine();
            if (a == "" || a is null) throw new InvalidDataException("The author field cannot be left blank.");
            Console.Clear();
            foreach (Book book in AllBooks) if (book.Title.ToLower() == t.ToLower() && book.Author.ToLower() == a.ToLower() && book.IsAvailable) foundBooks.Add(book);
            if (foundBooks.Count == 0) throw new NoItemsFoundException("Did you empty the entire library...?");
            Program.ColText("Title: ", "9");
            Program.ColText(t, "B");
            Program.ColText("\nAuthor: ", "9");
            Program.ColText(a, "B");
            foundBooks[0].Borrow();
        }
        public static void ReturnBook()
        {
            List<Book> foundBooks = new List<Book>();
            Program.ColText("Selection:\n\n", "9");
            foreach (Book book in AllBooks) if (!book.IsAvailable) foundBooks.Add(book);
            if (foundBooks.Count == 0) throw new NoItemsFoundException("You don't have any books due.");
            for (int i = 0; i < foundBooks.Count(); i++) Console.WriteLine($"[{i + 1}] \"{foundBooks[i].Title}\" by {foundBooks[i].Author}");
            Console.Write("> ");
            int inputSelection = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Program.ColText("Selection: ", "9");
            Program.ColText(Convert.ToString(inputSelection), "B");
            foundBooks[inputSelection-1].Return();
        }
    }
}
