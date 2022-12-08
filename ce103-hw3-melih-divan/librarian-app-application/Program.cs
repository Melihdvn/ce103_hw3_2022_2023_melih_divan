using System;
using System.IO;
using static System.Console;
using LibraryManagement;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;

namespace librarianApp
{
    #region Starting app with password function
    class Program
    {
        static void Main()
        {
            CursorVisible = false;
            Title = "Librarian App - Login Screen";
            string passwordAttempt, password = string.Empty;
            LibraryManager.App libraryApp = new LibraryManager.App();
            BackgroundColor = ConsoleColor.DarkGray;
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine(@"

████████████████████████████████████████████████████████████████████████████████████
██                                                                                ██
██  _       _  _                        _                        By Melih Divan   ██
██ | |     (_)| |                      (_)                   /\                   ██
██ | |      _ | |__   _ __  __ _  _ __  _   __ _  _ __      /  \    _ __   _ __   ██
██ | |     | || '_ \ | '__|/ _` || '__|| | / _` || '_ \    / /\ \  | '_ \ | '_ \  ██
██ | |____ | || |_) || |  | (_| || |   | || (_| || | | |  / ____ \ | |_) || |_) | ██
██ |______||_||_.__/ |_|   \__,_||_|   |_| \__,_||_| |_| /_/    \_\| .__/ | .__/  ██
██                                                                 | |    | |     ██
██                                                                 |_|    |_|     ██
██                                                                                ██
████████████████████████████████████████████████████████████████████████████████████
");
            ResetColor();
            ForegroundColor = ConsoleColor.Black;
            BackgroundColor = ConsoleColor.White;
            WriteLine("Welcome to the Librarian App");
            ResetColor();
            ForegroundColor = ConsoleColor.DarkRed;


            if (File.Exists("password.txt"))
            {
            Write("Please enter password: ");
            ForegroundColor = ConsoleColor.White;
            passwordAttempt = ReadLine();
            
                using (StreamReader sr = new StreamReader(File.Open("password.txt", FileMode.Open)))
                {
                    password = sr.ReadLine();
                    sr.Close();
                }

                if (passwordAttempt == password)
                {
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine("Login Success.");
                    ForegroundColor = ConsoleColor.White;
                    WriteLine("Press any key to continue...");
                    ReadKey(true);
                    libraryApp.Start();
                }
                else
                {
                    int i = 3;
                    while (i > 0)
                    {
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine("Wrong password. \n You have " + (i) + " attempts left.");
                        ForegroundColor = ConsoleColor.DarkRed;
                        Write("Please enter password: ");
                        ForegroundColor = ConsoleColor.White;
                        passwordAttempt = ReadLine();
                        if (passwordAttempt == password)
                        {
                            ForegroundColor = ConsoleColor.Green;
                            WriteLine("Login Success.");
                            ForegroundColor = ConsoleColor.White;
                            WriteLine("Press any key to continue...");
                            ReadKey(true);
                            libraryApp.Start();
                        }
                        --i;
                    }
                    if (i == 0)
                    {
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine("Login Failed. \n App will close.");
                        ReadKey(true);

                    }
                }
            }
            else
            {
                Write("Please create a password: ");
                ForegroundColor = ConsoleColor.White;
                password = ReadLine();
                using (StreamWriter sw = new StreamWriter(File.Create("password.txt")))
                {
                    sw.Write(password);
                    sw.Close();
                }
                ForegroundColor = ConsoleColor.Green;
                WriteLine("Password successfully created. Press any key to continue...");
                ResetColor();
                ReadKey(true);
                libraryApp.Start();
            }

        }
    }
    #endregion
    public class LibraryManager
    {


        #region Menu 
        class Menu
        {
            private int SelectedIndex;
            private string[] Options;
            private string Prompt;

            public Menu(string prompt, string[] options)
            {
                Prompt = prompt;
                Options = options;
                SelectedIndex = 0;
            }

            private void DisplayOptions()
            {
                BackgroundColor = ConsoleColor.DarkGray;
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine(Prompt);
                for (int i = 0; i < Options.Length; i++)
                {
                    string currentOption = Options[i];
                    string prefix;

                    if (i == SelectedIndex)
                    {
                        prefix = "  ►";
                        ForegroundColor = ConsoleColor.Black;
                        BackgroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        prefix = "  ";
                        ForegroundColor = ConsoleColor.White;
                        BackgroundColor = ConsoleColor.Black;
                    }
                    WriteLine($"{prefix} << {currentOption} >>");
                }
                ResetColor();
            }

            public int Run()
            {
                ConsoleKey keyPressed;
                do
                {
                    Clear();
                    DisplayOptions();


                    ConsoleKeyInfo keyInfo = ReadKey(true);
                    keyPressed = keyInfo.Key;

                    //Update SelectedIndex based on arrow keys.
                    if (keyPressed == ConsoleKey.DownArrow)
                    {
                        SelectedIndex++;
                        if (SelectedIndex == Options.Length)
                        {
                            SelectedIndex = 0;
                        }
                    }
                    else if (keyPressed == ConsoleKey.UpArrow)
                    {
                        SelectedIndex--;
                        if (SelectedIndex == -1)
                        {
                            {
                                SelectedIndex = Options.Length - 1;
                            }
                        }
                    }
                } while (keyPressed != ConsoleKey.Enter);

                return SelectedIndex;
            }
        }
        #endregion
        #region Menu which has welcome text (Main Menu)
        class MainMenu
        {
            private int SelectedIndex;
            private string[] Options;
            private string Prompt;
            private string Welcome;

            public MainMenu(string prompt, string[] options, string welcome)
            {
                Prompt = prompt;
                Options = options;
                Welcome = welcome;
                SelectedIndex = 0;
            }

            private void DisplayOptions()
            {
                BackgroundColor = ConsoleColor.DarkGray;
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine(Prompt);
                ResetColor();
                ForegroundColor = ConsoleColor.DarkRed;
                WriteLine(Welcome);
                for (int i = 0; i < Options.Length; i++)
                {
                    string currentOption = Options[i];
                    string prefix;

                    if (i == SelectedIndex)
                    {
                        prefix = "  ►";
                        ForegroundColor = ConsoleColor.Black;
                        BackgroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        prefix = "  ";
                        ForegroundColor = ConsoleColor.White;
                        BackgroundColor = ConsoleColor.Black;
                    }
                    WriteLine($"{prefix} << {currentOption} >>");
                }
                ResetColor();
            }

            public int Run()
            {
                ConsoleKey keyPressed;
                do
                {
                    Clear();
                    DisplayOptions();


                    ConsoleKeyInfo keyInfo = ReadKey(true);
                    keyPressed = keyInfo.Key;

                    //Update SelectedIndex based on arrow keys.
                    if (keyPressed == ConsoleKey.DownArrow)
                    {
                        SelectedIndex++;
                        if (SelectedIndex == Options.Length)
                        {
                            SelectedIndex = 0;
                        }
                    }
                    else if (keyPressed == ConsoleKey.UpArrow)
                    {
                        SelectedIndex--;
                        if (SelectedIndex == -1)
                        {
                            {
                                SelectedIndex = Options.Length - 1;
                            }
                        }
                    }
                } while (keyPressed != ConsoleKey.Enter);

                return SelectedIndex;
            }
        }
        #endregion


        public class App
        {
            #region Start section
            public void Start()
            {
                Title = "Librarian App";
                RunMainMenu();
            }
            #endregion
            #region Main menu
            private void RunMainMenu()
            {
                string prompt = @"

████████████████████████████████████████████████████████████████████████████████████
██                                                                                ██
██  _       _  _                        _                        By Melih Divan   ██
██ | |     (_)| |                      (_)                   /\                   ██
██ | |      _ | |__   _ __  __ _  _ __  _   __ _  _ __      /  \    _ __   _ __   ██
██ | |     | || '_ \ | '__|/ _` || '__|| | / _` || '_ \    / /\ \  | '_ \ | '_ \  ██
██ | |____ | || |_) || |  | (_| || |   | || (_| || | | |  / ____ \ | |_) || |_) | ██
██ |______||_||_.__/ |_|   \__,_||_|   |_| \__,_||_| |_| /_/    \_\| .__/ | .__/  ██
██                                                                 | |    | |     ██
██                                                                 |_|    |_|     ██
██                                                                                ██
████████████████████████████████████████████████████████████████████████████████████
";
                ResetColor();
                string welcome = "            Welcome to the Librarian app! What would you like to do? \n       (Use Arrow Keys to cycle through options and press enter to select.)\n";
                string[] options = { "Book Options", "Category Options", "Borrow History", "About", "Options", "Exit" };
                MainMenu mainmenu = new MainMenu(prompt, options, welcome);
                int SelectedIndex = mainmenu.Run();


                switch (SelectedIndex)
                {
                    case 0:
                        DisplayBook();
                        break;
                    case 1:
                        DisplayCtg();
                        break;
                    case 2:
                        DisplayBorrowHistory();
                        break;
                    case 3:
                        DisplayAbout();
                        break;
                    case 4:
                        DisplayOptions();
                        break;
                    case 5:
                        ExitApp();
                        break;
                }

            }
            #region Main menu options functions
            #region Book menu 
            private void DisplayBook()
            {
                string prompt = @"

████████████████████████████████████████████████████████████████████████████████████
██                                                                                ██
██  _       _  _                        _                        By Melih Divan   ██
██ | |     (_)| |                      (_)                   /\                   ██
██ | |      _ | |__   _ __  __ _  _ __  _   __ _  _ __      /  \    _ __   _ __   ██
██ | |     | || '_ \ | '__|/ _` || '__|| | / _` || '_ \    / /\ \  | '_ \ | '_ \  ██
██ | |____ | || |_) || |  | (_| || |   | || (_| || | | |  / ____ \ | |_) || |_) | ██
██ |______||_||_.__/ |_|   \__,_||_|   |_| \__,_||_| |_| /_/    \_\| .__/ | .__/  ██
██                                                                 | |    | |     ██
██                                                                 |_|    |_|     ██
██                                                                                ██
████████████████████████████████████████████████████████████████████████████████████
";
                string[] options = { "Add Book", "Edit Book", "Delete Book", "List Books", "List Borrowed Books", "Search Books", "Borrow Book", "Return Book", "Back to the main menu" };
                Menu bookMenu = new Menu(prompt, options);
                int SelectedIndex = bookMenu.Run();

                switch (SelectedIndex)
                {
                    case 0:
                        AddBook();
                        break;
                    case 1:
                        EditBook();
                        break;
                    case 2:
                        DeleteBook();
                        break;
                    case 3:
                        ListBook();
                        break;
                    case 4:
                        ListBorrowedBook();
                        break;
                    case 5:
                        SearchBook();
                        break;
                    case 6:
                        BorrowBook();
                        break;
                    case 7:
                        ReturnBook();
                        break;
                    case 8:
                        RunMainMenu();
                        break;
                }

                #region Book menu options functions
                void AddBook()
                {
                    Clear();
                    Book book = new Book();
                    Write("Please enter book id: ");
                    book.Id = Convert.ToInt32(ReadLine());
                    Write("\nPlease enter book title: ");
                    book.Title = " Title: " + ReadLine();
                    Write("\nPlease enter book description: ");
                    book.Description = " Description: " + ReadLine();
                    Write("\nPlease enter book year: ");
                    book.Year = " Year: " + ReadLine();
                    Write("\nPlease enter book pages: ");
                    book.Pages = " Pages: " + ReadLine();
                    Write("\nPlease enter book abstract: ");
                    book.Abstract = " Abstract: " + ReadLine();
                    Write("\nPlease enter book city: ");
                    book.City = " City: " + ReadLine();
                    Write("\nPlease enter book edition: ");
                    book.Edition = " Edition: " + ReadLine();
                    Write("\nPlease enter book publisher: ");
                    book.Publisher = " Publisher: " + ReadLine();
                    Write("\nPlease enter book catalogid: ");
                    book.CatalogId = " CatalogID: " + ReadLine();
                    Write("\nPlease enter book price: ");
                    book.Price = " Price: " + ReadLine();
                    Write("\nPlease enter book rack: ");
                    book.RackNo = " Rack: " + ReadLine();
                    Write("\nPlease enter book row: ");
                    book.RowNo = " Row: " + ReadLine();
                    book.Status = " In library";
                    Write("\nPlease enter book enter date: ");
                    book.Return = " Date: Firstly added to library at: " + ReadLine() + " date";
                    book.Given = " Given: -";
                    Write("\nPlease enter book url: ");
                    book.Url = " Url: " + ReadLine();
                    Write("\nPlease enter book author: ");
                    book.Authors.Add(" Author: " + ReadLine());
                    Write("\nPlease enter book tag: ");
                    book.Tags.Add(" Tag: " + ReadLine());
                    Write("\nPlease enter book editor: ");
                    book.Editors.Add(" Editor: " + ReadLine());

                    Clear();
                    ListCategoryForAddBook();
                    int catnumber;
                    Write("\nPlease enter book category number which you want to add: ");
                    catnumber = Convert.ToInt32(ReadLine());
                    Category category = LibraryManagement.LibraryManager.ReadCategory(catnumber);
                    book.Categories.Add(category.Name + "| ");

                    LibraryManagement.LibraryManager.InsertBook(book);

                    DisplayBook();
                }
                void EditBook()
                {
                    Clear();
                    int booknumber;
                    if (File.Exists("library.dat"))
                    {
                        Write("Please enter number of book which do you want to edit: ");
                        booknumber = Convert.ToInt32(ReadLine());


                        using (StreamReader sr = new StreamReader(File.Open("library.dat", FileMode.Open)))
                        {
                            string datalength = sr.ReadLine();
                            sr.Close();

                            Book book = new Book();
                            Write("\nPlease enter book id: ");
                            book.Id = Convert.ToInt32(ReadLine());
                            Write("\nPlease enter book title: ");
                            book.Title = " Title: " + ReadLine();
                            Write("\nPlease enter book description: ");
                            book.Description = " Description: " + ReadLine();
                            Write("\nPlease enter book year: ");
                            book.Year = " Year: " + ReadLine();
                            Write("\nPlease enter book pages: ");
                            book.Pages = " Pages: " + ReadLine();
                            Write("\nPlease enter book abstract: ");
                            book.Abstract = " Abstract: " + ReadLine();
                            Write("\nPlease enter book city: ");
                            book.City = " City: " + ReadLine();
                            Write("\nPlease enter book edition: ");
                            book.Edition = " Edition: " + ReadLine();
                            Write("\nPlease enter book publisher: ");
                            book.Publisher = " Publisher: " + ReadLine();
                            Write("\nPlease enter book catalogid: ");
                            book.CatalogId = " CatalogID: " + ReadLine();
                            Write("\nPlease enter book price: ");
                            book.Price = " Price: " + ReadLine();
                            Write("\nPlease enter book rack: ");
                            book.RackNo = " Rack: " + ReadLine();
                            Write("\nPlease enter book row: ");
                            book.RowNo = " Row: " + ReadLine();
                            book.Status = " In library";
                            Write("\nPlease enter book edit date: ");
                            book.Return = " Date edited: " + ReadLine();
                            book.Given = " Given: -";
                            Write("\nPlease enter book url: ");
                            book.Url = " Url: " + ReadLine();
                            Write("\nPlease enter book author: ");
                            book.Authors.Add(" Author: " + ReadLine());
                            Write("\nPlease enter book tag: ");
                            book.Tags.Add(" Tag: " + ReadLine());
                            Write("\nPlease enter book editor: ");
                            book.Editors.Add(" Editor: " + ReadLine());
                            Clear();
                            ListCategoryForAddBook();
                            int catnumber;
                            Write("\nPlease enter book category number which you want to add: ");
                            catnumber = Convert.ToInt32(ReadLine());
                            Category category = LibraryManagement.LibraryManager.ReadCategory(catnumber);
                            book.Categories.Add(" Category: " + category.Name);


                            LibraryManagement.LibraryManager.UpdateBook(book, booknumber);
                        }
                    }
                    else { WriteLine("Library file couldn't found."); }

                    WriteLine("Press any key to return...");
                    ReadKey(true);
                    DisplayBook();
                }
                void DeleteBook()
                {
                    if (File.Exists("library.dat"))
                    {
                            Clear();
                            int booknumber;
                            WriteLine("Please enter number of book which do you want to delete: ");
                            booknumber = Convert.ToInt32(ReadLine());

                        LibraryManagement.LibraryManager.DeleteBook(booknumber);
                    }
                    
                    else 
                    { Clear(); WriteLine("Library file couldn't found."); }

                    WriteLine("Press any key to return...");
                    ReadKey(true);
                    DisplayBook();
                }
                void ListBook()
                {
                    Clear();
                    if (File.Exists("library.dat"))
                    {
                        int i = 1;
                        using (StreamReader sr = new StreamReader(File.Open("library.dat", FileMode.Open)))
                        {
                            string datlength = sr.ReadLine();
                            sr.Close();
                            do
                            {
                                Book bookWrittenObject = LibraryManagement.LibraryManager.ReadBook(i);

                                if (bookWrittenObject != null && !bookWrittenObject.Status.Contains("Borrowed"))
                                {
                                    WriteLine("Book number : " + i);
                                    WriteLine("ID:" + bookWrittenObject.Id + "\n" + bookWrittenObject.Title + "\n" + bookWrittenObject.Description + "\n" + bookWrittenObject.Year + "\n" + bookWrittenObject.Pages);
                                    WriteLine(bookWrittenObject.Abstract + "\n" + bookWrittenObject.City + "\n" + bookWrittenObject.Edition + "\n" + bookWrittenObject.Publisher);
                                    WriteLine(bookWrittenObject.CatalogId + "\n" + bookWrittenObject.Price + "\n" + bookWrittenObject.RackNo + "\n" + bookWrittenObject.RowNo);
                                    WriteLine(bookWrittenObject.Return + "\n" + bookWrittenObject.Given + "\n" + bookWrittenObject.Url + "\n" + bookWrittenObject.Authors[0]);
                                    WriteLine(bookWrittenObject.Tags[0]);
                                    WriteLine(bookWrittenObject.Editors[0] + "\n" + bookWrittenObject.Categories[0]);
                                    WriteLine("----------------------------------------------------------------------------------------");
                                }
                                i++;

                            } while (i < (((datlength.Length) / (Book.BOOK_DATA_BLOCK_SIZE)) + 1));

                            WriteLine("Press any key to return...");
                            ReadKey(true);
                            DisplayBook();
                        }
                    }
                    else { Clear(); WriteLine("Library file couldn't found."); }

                    WriteLine("Press any key to return...");
                    ReadKey(true);
                    DisplayBook();
                }
                void ListBorrowedBook()
                {
                    Clear();
                    if (File.Exists("library.dat"))
                    {
                        int i = 1;
                        using (StreamReader sr = new StreamReader(File.Open("library.dat", FileMode.Open)))
                        {
                            string datlength = sr.ReadLine();
                            sr.Close();
                            do
                            {
                                Book bookWrittenObject = LibraryManagement.LibraryManager.ReadBook(i);

                                if (bookWrittenObject != null && bookWrittenObject.Status.Contains("Borrow"))
                                {
                                    WriteLine(i + ". - ID: " + bookWrittenObject.Id + " | " + bookWrittenObject.Title + " | " + bookWrittenObject.Authors[0] + " | " + bookWrittenObject.Given + " " + bookWrittenObject.Status + "\n");
                                }
                                i++;

                            } while (i < (((datlength.Length) / (Book.BOOK_DATA_BLOCK_SIZE)) + 1));
                            WriteLine("Press any key to return...");
                            ReadKey(true);
                            DisplayBook();
                        }
                    }
                    else { Clear(); WriteLine("Library file couldn't found."); }

                    WriteLine("Press any key to return...");
                    ReadKey(true);
                    DisplayBook();
                }
                void SearchBook()
                {
                    Clear();
                    int i = 1;
                    if (File.Exists("library.dat"))
                    {
                        Write("Please enter name, ID, Author or Category of the book which do you want to find: ");
                        var search = ReadLine();
                        if (LibraryManagement.LibraryManager.IsNumeric(search) == false)
                        {
                            using (StreamReader sr = new StreamReader(File.Open("library.dat", FileMode.Open)))
                            {
                                Clear();
                                string datlength = sr.ReadLine();
                                sr.Close();
                                do
                                {
                                Book bookWrittenObject = LibraryManagement.LibraryManager.ReadBook(i);

                                    if (bookWrittenObject != null && (bookWrittenObject.Title.Contains(search) | (bookWrittenObject.Authors[0].Contains(search) | (bookWrittenObject.Categories[0].Contains(search)))))
                                    {
                                        WriteLine(i + ". - " + bookWrittenObject.Id + " | " + bookWrittenObject.Title + " | " + bookWrittenObject.Description + " | " + bookWrittenObject.Authors[0] + " | " + bookWrittenObject.Status + "\n");
                                    }
                                    i++;

                                } while (i < (((datlength.Length) / (Book.BOOK_DATA_BLOCK_SIZE)) + 1));
                                WriteLine("Press any key to return...");
                                ReadKey(true);
                                DisplayBook();
                            }
                        }
                        else
                        {
                            int searchint = Convert.ToInt32(search);

                            using (StreamReader sr = new StreamReader(File.Open("library.dat", FileMode.Open)))
                            {
                                Clear();
                                string datlength = sr.ReadLine();
                                sr.Close();
                                do
                                {
                                Book bookWrittenObject = LibraryManagement.LibraryManager.ReadBook(i);

                                    if (bookWrittenObject != null && (bookWrittenObject.Id.Equals(searchint)))
                                    {
                                        WriteLine(i + ". - " + bookWrittenObject.Id + " | " + bookWrittenObject.Title + " | " + bookWrittenObject.Description + " | " + bookWrittenObject.Authors[0] + " | " + bookWrittenObject.Status + "\n");
                                    }
                                    i++;

                                } while (i < (((datlength.Length) / (Book.BOOK_DATA_BLOCK_SIZE)) + 1));
                                WriteLine("Press any key to return...");
                                ReadKey(true);
                                DisplayBook();
                            }
                        }
                    }
                    else { Clear(); WriteLine("Library file couldn't found."); }

                    WriteLine("Press any key to return...");
                    ReadKey(true);
                    DisplayBook();
                }
                void BorrowBook()
                {
                    if (File.Exists("library.dat"))
                    {
                        Clear();
                        int booknumber;
                        string student;
                        string date;
                        Write("Please enter number of book which do you want to borrow: ");
                        booknumber = Convert.ToInt32(ReadLine());
                        Write("\nWhat is the name of student who got the book: ");
                        student = ReadLine();
                        Write("\nDate: ");
                        date = ReadLine();


                        using (StreamReader sr = new StreamReader(File.Open("library.dat", FileMode.Open)))
                        {
                            string datalength = sr.ReadLine();
                            sr.Close();

                            Book bookWrittenObject = LibraryManagement.LibraryManager.ReadBook(booknumber);


                            if (bookWrittenObject != null)
                            {
                                Book book = new Book();
                                book = bookWrittenObject;
                                book.Status = " Borrowed by student: " + student;
                                book.Given = " Given date: " + date;
                                string write;
                                string writepath;
                                writepath = "borrowed.txt";
                                write = "ID: " + bookWrittenObject.Id + " | " + bookWrittenObject.Title + " | " + date + " Borrowed by: " + student + "\n";
                                using (StreamWriter sw = File.AppendText(writepath))
                                {
                                    sw.WriteLine(write);
                                    sw.Close();
                                }

                                LibraryManagement.LibraryManager.UpdateBook(book, booknumber);
                            }

                            WriteLine("Press any key to return...");
                            ReadKey(true);
                            DisplayBook();
                        }
                    }
                    else { Clear(); WriteLine("Library file couldn't found."); }
                    WriteLine("Press any key to return...");
                    ReadKey(true);
                    DisplayBook();
                }
                void ReturnBook()
                {
                    if (File.Exists("library.dat"))
                    {
                        string path = AppDomain.CurrentDomain.BaseDirectory;
                        string filename = Path.Combine(path, "library.dat");
                        Clear();
                        int booknumber;
                        string returndate;
                        Write("Please enter number of book which do you want to return: ");
                        booknumber = Convert.ToInt32(ReadLine());
                        Write("\nPlease enter return date: ");
                        returndate = ReadLine();


                        using (StreamReader sr = new StreamReader(File.Open("library.dat", FileMode.Open)))
                        {
                            string datalength = sr.ReadLine();
                            sr.Close();

                            byte[] bookWrittenBytesforBorrow = FileUtility.ReadBlock(booknumber, Book.BOOK_DATA_BLOCK_SIZE, filename);
                            Book bookWrittenObject = Book.ByteArrayBlockToBook(bookWrittenBytesforBorrow);

                            Book book = new Book();
                            book = bookWrittenObject;
                            book.Status = " In library";
                            book.Return = " Return date: " + returndate;


                            byte[] bookBytes = Book.BookToByteArrayBlock(book);

                            FileUtility.UpdateBlock(bookBytes, booknumber, Book.BOOK_DATA_BLOCK_SIZE, filename);
                        }

                        WriteLine("Press any key to return...");
                        ReadKey(true);
                        DisplayBook();
                    }
                    else { Clear(); WriteLine("Library file couldn't found."); }
                    WriteLine("Press any key to return...");
                    ReadKey(true);
                    DisplayBook();
                }
                #endregion

            }
            #endregion
            #region Category menu
            private void DisplayCtg()
            {
                string prompt = @"

  ████████████████████████████████████████████████████████████████████████████████████
  ██                                                                                ██
  ██  _       _  _                        _                        By Melih Divan   ██
  ██ | |     (_)| |                      (_)                   /\                   ██
  ██ | |      _ | |__   _ __  __ _  _ __  _   __ _  _ __      /  \    _ __   _ __   ██
  ██ | |     | || '_ \ | '__|/ _` || '__|| | / _` || '_ \    / /\ \  | '_ \ | '_ \  ██
  ██ | |____ | || |_) || |  | (_| || |   | || (_| || | | |  / ____ \ | |_) || |_) | ██
  ██ |______||_||_.__/ |_|   \__,_||_|   |_| \__,_||_| |_| /_/    \_\| .__/ | .__/  ██
  ██                                                                 | |    | |     ██
  ██                                                                 |_|    |_|     ██
  ██                                                                                ██
  ████████████████████████████████████████████████████████████████████████████████████
  ";
                string[] options = { "Add Category", "List Category", "Edit Category", "Delete Category", "Back to the main menu" };
                Menu ctgMenu = new Menu(prompt, options);
                int SelectedIndex = ctgMenu.Run();

                switch (SelectedIndex)
                {
                    case 0:
                        AddCategory();
                        break;
                    case 1:
                        ListCategory();
                        break;
                    case 2:
                        EditCategory();
                        break;
                    case 3:
                        DeleteCategory();
                        break;
                    case 4:
                        RunMainMenu();
                        break;
                }

            }

            private void AddCategory()
            {
                Clear();
                Category category = new Category();
                Write("\nPlease enter category name: ");
                category.Name = ReadLine();

                LibraryManagement.LibraryManager.InsertCategory(category);

                DisplayCtg();
            }
            private void ListCategory()
            {
                Clear();
                if (File.Exists("category.dat"))
                {
                    int i = 1;
                    using (StreamReader sr = new StreamReader(File.Open("category.dat", FileMode.Open)))
                    {
                        string datlength = sr.ReadLine();
                        sr.Close();
                        do
                        {
                            Category categoryWrittenObject = LibraryManagement.LibraryManager.ReadCategory(i);

                            if (categoryWrittenObject != null)
                            {
                                WriteLine("Category number : " + i);
                                WriteLine("Name: " + categoryWrittenObject.Name);
                                WriteLine("-----------------------");
                            }
                            i++;

                        } while (i < (((datlength.Length) / (Category.CATEGORY_MAX_LENGTH)) + 1));

                        WriteLine("Press any key to return...");
                        ReadKey(true);
                        DisplayCtg();
                    }
                }
                else { Clear(); WriteLine("Category file couldn't found."); }

                WriteLine("Press any key to return...");
                ReadKey(true);
                DisplayCtg();
            }
            private void ListCategoryForAddBook()
            {
                Clear();
                if (File.Exists("category.dat"))
                {
                    int i = 1;
                    using (StreamReader sr = new StreamReader(File.Open("category.dat", FileMode.Open)))
                    {
                        string datlength = sr.ReadLine();
                        sr.Close();
                        do
                        {
                            Category categoryWrittenObject = LibraryManagement.LibraryManager.ReadCategory(i);

                            if (categoryWrittenObject != null)
                            {
                                WriteLine("Category number : " + i);
                                WriteLine("Name: " + categoryWrittenObject.Name);
                                WriteLine("-----------------------");
                            }
                            i++;

                        } while (i < (((datlength.Length) / (Category.CATEGORY_MAX_LENGTH)) + 1));
                    }
                }
                else { Clear(); WriteLine("Category file couldn't found."); }
            }
            private void EditCategory()
            {
                Clear();
                int catnumber;
                if (File.Exists("category.dat"))
                {
                    Write("Please enter number of book which do you want to edit: ");
                    catnumber = Convert.ToInt32(ReadLine());


                    using (StreamReader sr = new StreamReader(File.Open("category.dat", FileMode.Open)))
                    {
                        string datalength = sr.ReadLine();
                        sr.Close();

                        Category category = new Category();
                        Write("\nPlease enter book title: ");
                        category.Name = ReadLine();


                        LibraryManagement.LibraryManager.UpdateCategory(category, catnumber);
                    }
                }
                else { WriteLine("Category file couldn't found."); }

                WriteLine("Press any key to return...");
                ReadKey(true);
                DisplayCtg();
            }
            private void DeleteCategory()
            {
                if (File.Exists("category.dat"))
                {
                    Clear();
                    int catnumber;
                    WriteLine("Please enter number of category which do you want to delete: ");
                    catnumber = Convert.ToInt32(ReadLine());

                    LibraryManagement.LibraryManager.DeleteCategory(catnumber);
                }

                else
                { Clear(); WriteLine("Category file couldn't found."); }

                WriteLine("Press any key to return...");
                ReadKey(true);
                DisplayCtg();
            }


            #endregion
            #region Borrow History Menu
            private void DisplayBorrowHistory()
            {
                if (File.Exists("borrowed.txt"))
                {
                    Clear();
                    string path = "borrowed.txt";
                    using (StreamReader sr = File.OpenText(path))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(s);
                        }
                        sr.Close();
                    }
                }
                else { Write("History is empty"); }
                WriteLine("\nPress any key to return to the menu...");
                ReadKey(true);
                RunMainMenu();
            }
            #endregion
            #region About menu
            private void DisplayAbout()
            {
                Clear();
                BackgroundColor = ConsoleColor.DarkGray;
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine(@"

████████████████████████████████████████████████████████████████████████████████████
██                                                                                ██
██  _       _  _                        _                        By Melih Divan   ██
██ | |     (_)| |                      (_)                   /\                   ██
██ | |      _ | |__   _ __  __ _  _ __  _   __ _  _ __      /  \    _ __   _ __   ██
██ | |     | || '_ \ | '__|/ _` || '__|| | / _` || '_ \    / /\ \  | '_ \ | '_ \  ██
██ | |____ | || |_) || |  | (_| || |   | || (_| || | | |  / ____ \ | |_) || |_) | ██
██ |______||_||_.__/ |_|   \__,_||_|   |_| \__,_||_| |_| /_/    \_\| .__/ | .__/  ██
██                                                                 | |    | |     ██
██                                                                 |_|    |_|     ██
██                                                                                ██
████████████████████████████████████████████████████████████████████████████████████
");
                ResetColor();
                WriteLine("This app was created by Melih Divan");
                string request = "https://github.com/melihdvn/";
                ProcessStartInfo ps = new ProcessStartInfo
                {
                    FileName = request,
                    UseShellExecute = true
                };
                Process.Start(ps);
                WriteLine("This is an app for librarians");
                WriteLine("This app is developed for ce homework");
                WriteLine("\nPress any key to return to the menu...");
                ReadKey(true);
                RunMainMenu();
            }
            #endregion
            #region Options menu
            private void DisplayOptions()
            {
                string prompt = @"

████████████████████████████████████████████████████████████████████████████████████
██                                                                                ██
██  _       _  _                        _                        By Melih Divan   ██
██ | |     (_)| |                      (_)                   /\                   ██
██ | |      _ | |__   _ __  __ _  _ __  _   __ _  _ __      /  \    _ __   _ __   ██
██ | |     | || '_ \ | '__|/ _` || '__|| | / _` || '_ \    / /\ \  | '_ \ | '_ \  ██
██ | |____ | || |_) || |  | (_| || |   | || (_| || | | |  / ____ \ | |_) || |_) | ██
██ |______||_||_.__/ |_|   \__,_||_|   |_| \__,_||_| |_| /_/    \_\| .__/ | .__/  ██
██                                                                 | |    | |     ██
██                                                                 |_|    |_|     ██
██                                                                                ██
████████████████████████████████████████████████████████████████████████████████████
";
                string[] options = { "Change Password", "Delete All Data", "Back to the main menu" };
                Menu optMenu = new Menu(prompt, options);
                int SelectedIndex = optMenu.Run();

                switch (SelectedIndex)
                {
                    case 0:
                        changePassword();
                        break;
                    case 1:
                        DeleteData();
                        break;
                    case 2:
                        RunMainMenu();
                        break;
                }

                #region Options menu options functions
                void changePassword()
                {
                    Clear();
                    File.Delete("password.txt");
                    string password = string.Empty;
                    Write("Please enter new password: ");
                    password = ReadLine();
                    using (StreamWriter sw = new StreamWriter(File.Create("password.txt")))
                    {
                        sw.Write(password);
                        sw.Close();
                    }

                    WriteLine("Done...");
                    ReadKey(true);
                    DisplayOptions();
                }
                void DeleteData() 
                {
                    Clear();
                    ForegroundColor = ConsoleColor.DarkRed;
                    WriteLine("Are you sure you want to delete all files? All files will be deleted permanently. \n    (Enter to confirm or Backspace to return)");
                    ResetColor();
                    ConsoleKey keyPressed;
                    ConsoleKeyInfo keyInfo = ReadKey(true);
                    keyPressed = keyInfo.Key;


                    if (keyPressed == ConsoleKey.Enter)
                    {
                        FileUtility.DeleteFile("library.dat");
                        FileUtility.DeleteFile("password.txt");
                        FileUtility.DeleteFile("borrowed.txt");
                        RunMainMenu();
                    }
                    if (keyPressed == ConsoleKey.Backspace)
                    {
                        RunMainMenu();
                    }

                }
                #endregion
            }
            #endregion
            #region Exit app section
            private void ExitApp()
            {
                Clear();
                BackgroundColor = ConsoleColor.DarkGray;
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine(@"

████████████████████████████████████████████████████████████████████████████████████
██                                                                                ██
██  _       _  _                        _                        By Melih Divan   ██
██ | |     (_)| |                      (_)                   /\                   ██
██ | |      _ | |__   _ __  __ _  _ __  _   __ _  _ __      /  \    _ __   _ __   ██
██ | |     | || '_ \ | '__|/ _` || '__|| | / _` || '_ \    / /\ \  | '_ \ | '_ \  ██
██ | |____ | || |_) || |  | (_| || |   | || (_| || | | |  / ____ \ | |_) || |_) | ██
██ |______||_||_.__/ |_|   \__,_||_|   |_| \__,_||_| |_| /_/    \_\| .__/ | .__/  ██
██                                                                 | |    | |     ██
██                                                                 |_|    |_|     ██
██                                                                                ██
████████████████████████████████████████████████████████████████████████████████████
");
                ResetColor();

                WriteLine("Are you sure you want to exit? (Enter to confirm or Backspace to return)");
                ConsoleKey keyPressed;
                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;


                if (keyPressed == ConsoleKey.Enter)
                {
                    Environment.Exit(0);
                }
                if (keyPressed == ConsoleKey.Backspace)
                {
                    RunMainMenu();
                }

            }
            #endregion
            #endregion
            #endregion
        }
    }
    
}
