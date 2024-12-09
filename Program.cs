namespace LibraryOfKazaretski
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library lib = new Library("MainLib");
            List<Book> fromFile = Book.GetBooksFromFile(@"..\..\..\list.csv");
            string[] menuOptions = new string[] {
                "Add book to library",
                "Add information to a book",
                "View book information",
                "View all books by author",
                "Advanced book searching",
                "Remove book from library",
                "Add newspaper to reading room",
                "Add magazine to reading room",
                "Show all newspapers",
                "Show all magazines",
                "Today's reading room acquisitions",
                "Borrow a book",
                "Return a book"
            };
            for (int i = 0; i < menuOptions.Length; i++) menuOptions[i] = $"[{i + 1}] {menuOptions[i]}";
            int menuChoice = 420;
            string sysMsg = "";
            while (menuChoice != 0)
            {
                try
                {
                    IntroWindow(menuOptions);
                    if (sysMsg.Length > 0) ColText($"{sysMsg}", "C");
                    sysMsg = "";
                    Console.Write("Choose an option: ");
                    menuChoice = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    switch (menuChoice)
                    {
                        case 0: break;
                        case 1: Library.AddBook(); break;
                        case 2: Library.AddInfoToBook(); break;
                        case 3: Library.InfoAboutBook(); break;
                        case 4: Library.SearchByAuthor(); break;
                        case 5: Library.AdvancedSearch(); break;
                        case 6: Library.RemoveBook(); break;
                        case 7: Library.AddNewspaper(); break;
                        case 8: Library.AddMagazine(); break;
                        case 9: Library.ShowAllNewspapers(); break;
                        case 10: Library.ShowAllMagazines(); break;
                        case 11: Library.AcquisitionsReadingRoomToday(); break;
                        case 12: Library.BorrowBook(); break;
                        case 13: Library.ReturnBook(); break;
                        default: sysMsg = "Invalid choice. Please try again.\n"; break;
                    }
                }
                catch (FormatException)
                {
                    sysMsg = "Please make sure to input a number.\n";
                }
                catch (OverflowException)
                {
                    sysMsg = "This number is too big for the system to understand.\n";
                }
                catch (NoItemsFoundException e)
                {
                    sysMsg = $"{e.Message}\n";
                }
                catch (InvalidDataException e)
                {
                    sysMsg = $"{e.Message}\n";
                }
                catch (DuplicateDataException e)
                {
                    sysMsg = $"{e.Message}\n";
                }
                catch (Exception e)
                {
                    sysMsg = $"{e.GetType().Name}\n";
                }
                finally
                {
                    Console.Clear();
                }
            }

        }
        // ---------------------------------------------------------------------------------------------------------------------------------
        private static void PrintLogo(int shelfLength = 10)
        {
            string line = string.Concat(Enumerable.Repeat("═", shelfLength));
            ColText($"╔{line}╗              ╔{line}╗\n║", "6");
            PrintLogoBooks(shelfLength);
            ColText("║              ║", "6");
            PrintLogoBooks(shelfLength);
            ColText($"║\n╠{line}╣", "6");
            ColText("  Library of  ", "F");
            ColText($"╠{line}╣\n║", "6");
            PrintLogoBooks(shelfLength);
            ColText("║", "6");
            ColText("  Kazaretski  ", "F");
            ColText("║", "6");
            PrintLogoBooks(shelfLength);
            ColText($"║\n╚{line}╝              ╚{line}╝\n", "6");
        }
        private static void PrintLogoBooks(int l)
        {
            Random rng = new Random();
            string randColors = "2345689ABCDEF";
            string randVariant = "▒▓█▄ ▄█▓▒";
            for (int i = 0; i < l; i++)
            {
                string pickColor = Convert.ToString(randColors[rng.Next(randColors.Length)]);
                string pickVariant = Convert.ToString(randVariant[rng.Next(randVariant.Length)]);
                ColText(pickVariant, pickColor);
            }
        }
        private static void IntroWindow(string[] options)
        {
            try
            {
                string longest = "";
                string exit = "[0] Exit";
                for (int i = 0; i < options.Length; i++) if (options[i].Length > longest.Length) longest = options[i];
                int width = Math.Max(longest.Length, Math.Max(longest.Length, exit.Length)) + 2;
                string stripe = string.Concat(Enumerable.Repeat("═", width));
                PrintLogo(12);
                Console.WriteLine($"╔{stripe}╗");
                foreach (string option in options) Console.WriteLine($"║ {option}{"║".PadLeft(width - option.Length)}");
                Console.Write($"║ {string.Concat(Enumerable.Repeat("-", width - 2))} ║\n║ ");
                ColText(exit, "C");
                Console.WriteLine($"{"║".PadLeft(width - exit.Length)}\n╚{stripe}╝");
            }
            catch (Exception)
            {
                for (int i = 0; i < options.Length; i++) Console.WriteLine($"- {options[i]}");
            }
        }
        public static void ExitSequence()
        {
            ColText("[Press ENTER to continue.] ", "8");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.ReadLine();
            Console.ResetColor();
            Console.Clear();
        }
        public static void ColText(string msg = "ERROR: No text provided", string col = "7")
        {
            col = col.Substring(0, 1).ToUpper();
            switch (col)
            {
                case "0": Console.ForegroundColor = ConsoleColor.Black; break;
                case "1": Console.ForegroundColor = ConsoleColor.DarkBlue; break;
                case "2": Console.ForegroundColor = ConsoleColor.DarkGreen; break;
                case "3": Console.ForegroundColor = ConsoleColor.DarkCyan; break;
                case "4": Console.ForegroundColor = ConsoleColor.DarkRed; break;
                case "5": Console.ForegroundColor = ConsoleColor.DarkMagenta; break;
                case "6": Console.ForegroundColor = ConsoleColor.DarkYellow; break;
                case "7": Console.ForegroundColor = ConsoleColor.Gray; break;
                case "8": Console.ForegroundColor = ConsoleColor.DarkGray; break;
                case "9": Console.ForegroundColor = ConsoleColor.Blue; break;
                case "A": Console.ForegroundColor = ConsoleColor.Green; break;
                case "B": Console.ForegroundColor = ConsoleColor.Cyan; break;
                case "C": Console.ForegroundColor = ConsoleColor.Red; break;
                case "D": Console.ForegroundColor = ConsoleColor.Magenta; break;
                case "E": Console.ForegroundColor = ConsoleColor.Yellow; break;
                case "F": Console.ForegroundColor = ConsoleColor.White; break;
                default: Console.ResetColor(); break;
            }
            Console.Write(msg);
            Console.ResetColor();
        }
    }
}
