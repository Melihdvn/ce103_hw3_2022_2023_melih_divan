using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using static System.Console;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace LibraryManagement
{
    public class LibraryManager
    {
        //Menus

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
        //App

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
                string[] options = { "Book Options", /*"Category Options",*/ "About", "Options", "Exit" };
                MainMenu mainmenu = new MainMenu(prompt, options, welcome);
                int SelectedIndex = mainmenu.Run();


                switch (SelectedIndex)
                {
                    case 0:
                        DisplayBook();
                        break;
                    /* case 1:
                         DisplayCtg();
                         break;*/
                    case 1:
                        DisplayAbout();
                        break;
                    case 2:
                        DisplayOptions();
                        break;
                    case 3:
                        ExitApp();
                        break;
                }

            }
            #endregion
            #region Book menu options
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


                void AddBook()
                {
                    Clear();
                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    string filename = Path.Combine(path, "library.dat");

                    Book book = new Book();
                    Write("Please enter book id: ");
                    book.Id = Convert.ToInt32(ReadLine());
                    Write("\nPlease enter book title: ");
                    book.Title = ReadLine();
                    Write("\nPlease enter book description: ");
                    book.Description = ReadLine();
                    Write("\nPlease enter book author: ");
                    book.Authors.Add(ReadLine());
                    Write("\nPlease enter book category: ");
                    book.Categories.Add(ReadLine());

                    byte[] bookBytes = Book.BookToByteArrayBlock(book);

                    FileUtility.AppendBlock(bookBytes, filename);
                    DisplayBook();
                }
                void EditBook()
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    string filename = Path.Combine(path, "library.dat");
                    Clear();
                    int booknumber;
                    WriteLine("Please enter number of book which do you want to edit: ");
                    booknumber = Convert.ToInt32(ReadLine());

                    using (StreamReader sr = new StreamReader(File.Open("library.dat", FileMode.Open)))
                    {
                        string datalength = sr.ReadLine();
                        sr.Close();

                        Book book = new Book();
                        WriteLine("Please enter new book id: ");
                        book.Id = Convert.ToInt32(ReadLine());
                        WriteLine("Please enter new book title: ");
                        book.Title = ReadLine();
                        WriteLine("Please enter new book description: ");
                        book.Description = ReadLine();
                        WriteLine("Please enter new book author: ");
                        book.Authors.Add(ReadLine());
                        WriteLine("Please enter new book category: ");
                        book.Categories.Add(ReadLine());

                        byte[] bookBytes = Book.BookToByteArrayBlock(book);

                        FileUtility.UpdateBlock(bookBytes, booknumber, Book.BOOK_DATA_BLOCK_SIZE, filename);
                    }

                    WriteLine("Press any key to return...");
                    ReadKey(true);
                    DisplayBook();
                }
                void DeleteBook()
                {
                    using (StreamReader sr = new StreamReader(File.Open("library.dat", FileMode.Open)))
                    {
                        string datalength = sr.ReadLine();
                        sr.Close();

                        string path = AppDomain.CurrentDomain.BaseDirectory;
                        string filename = Path.Combine(path, "library.dat");
                        Clear();
                        int booknumber;
                        WriteLine("Please enter number of book which do you want to delete: ");
                        booknumber = Convert.ToInt32(ReadLine());
                        FileUtility.DeleteBlock(booknumber, Book.BOOK_DATA_BLOCK_SIZE, filename);

                        do
                        {
                            byte[] nextbookbytes = FileUtility.ReadBlock(booknumber + 1, Book.BOOK_DATA_BLOCK_SIZE, filename);
                            FileUtility.UpdateBlock(nextbookbytes, booknumber, Book.BOOK_DATA_BLOCK_SIZE, filename);
                            booknumber++;
                        } while (booknumber <= (((datalength.Length) / (Book.BOOK_DATA_BLOCK_SIZE)) - 1));

                        FileUtility.DeleteBlock(((datalength.Length) / (Book.BOOK_DATA_BLOCK_SIZE)), Book.BOOK_DATA_BLOCK_SIZE, filename);
                    }
                    DisplayBook();
                }
                void ListBook()
                {
                    Clear();
                    int i = 1;
                    using (StreamReader sr = new StreamReader(File.Open("library.dat", FileMode.Open)))
                    {
                        string datlength = sr.ReadLine();
                        sr.Close();
                        do
                        {
                            string path = AppDomain.CurrentDomain.BaseDirectory;
                            string filename = Path.Combine(path, "library.dat");


                            byte[] bookWrittenBytes = FileUtility.ReadBlock(i, Book.BOOK_DATA_BLOCK_SIZE, filename);
                            Book bookWrittenObject = Book.ByteArrayBlockToBook(bookWrittenBytes);

                            if (bookWrittenObject != null && !bookWrittenObject.Title.Contains("Borrowed"))
                            {
                                WriteLine(i + ". - " + bookWrittenObject.Id + " | " + bookWrittenObject.Title + " | Description: " + bookWrittenObject.Description + " | Author: " + bookWrittenObject.Authors[0] + " | Category: " + bookWrittenObject.Categories[0] + "\n");

                            }
                            i++;

                        } while (i < (((datlength.Length) / (Book.BOOK_DATA_BLOCK_SIZE)) + 1));
                        WriteLine("Press any key to return...");
                        ReadKey(true);
                        DisplayBook();
                    }
                }
                void ListBorrowedBook()
                {
                    Clear();
                    int i = 1;
                    using (StreamReader sr = new StreamReader(File.Open("library.dat", FileMode.Open)))
                    {
                        string datlength = sr.ReadLine();
                        sr.Close();
                        do
                        {
                            string path = AppDomain.CurrentDomain.BaseDirectory;
                            string filename = Path.Combine(path, "library.dat");


                            byte[] bookWrittenBytes = FileUtility.ReadBlock(i, Book.BOOK_DATA_BLOCK_SIZE, filename);
                            Book bookWrittenObject = Book.ByteArrayBlockToBook(bookWrittenBytes);

                            if (bookWrittenObject != null && bookWrittenObject.Title.Contains("Borrowed"))
                            {
                                WriteLine(i + ". - " + bookWrittenObject.Id + " | " + bookWrittenObject.Title + "\n");

                            }
                            i++;

                        } while (i < (((datlength.Length) / (Book.BOOK_DATA_BLOCK_SIZE)) + 1));
                        WriteLine("Press any key to return...");
                        ReadKey(true);
                        DisplayBook();
                    }
                }
                void SearchBook()
                {
                    Clear();
                    int i = 1;
                    Write("Please enter name or ID of the book which do you want to find: ");
                    var search = ReadLine();
                    if (ConversionUtility.IsNumeric(search) == false)
                    {
                        using (StreamReader sr = new StreamReader(File.Open("library.dat", FileMode.Open)))
                        {
                            Clear();
                            string datlength = sr.ReadLine();
                            sr.Close();
                            do
                            {
                                string path = AppDomain.CurrentDomain.BaseDirectory;
                                string filename = Path.Combine(path, "library.dat");


                                byte[] bookWrittenBytes = FileUtility.ReadBlock(i, Book.BOOK_DATA_BLOCK_SIZE, filename);
                                Book bookWrittenObject = Book.ByteArrayBlockToBook(bookWrittenBytes);

                                if (bookWrittenObject != null && (bookWrittenObject.Title.Contains(search)))
                                {
                                    WriteLine(i + ". - " + bookWrittenObject.Id + " | " + bookWrittenObject.Title + " | Description: " + bookWrittenObject.Description + " | Author: " + bookWrittenObject.Authors[0] + " | Category: " + bookWrittenObject.Categories[0] + "\n");
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
                                string path = AppDomain.CurrentDomain.BaseDirectory;
                                string filename = Path.Combine(path, "library.dat");


                                byte[] bookWrittenBytes = FileUtility.ReadBlock(i, Book.BOOK_DATA_BLOCK_SIZE, filename);
                                Book bookWrittenObject = Book.ByteArrayBlockToBook(bookWrittenBytes);

                                if (bookWrittenObject != null && (bookWrittenObject.Id.Equals(searchint)))
                                {
                                    WriteLine(i + ". - " + bookWrittenObject.Id + " | " + bookWrittenObject.Title + " | Description: " + bookWrittenObject.Description + " | Author: " + bookWrittenObject.Authors[0] + " | Category: " + bookWrittenObject.Categories[0] + "\n");
                                }
                                i++;

                            } while (i < (((datlength.Length) / (Book.BOOK_DATA_BLOCK_SIZE)) + 1));
                            WriteLine("Press any key to return...");
                            ReadKey(true);
                            DisplayBook();
                        }
                    }
                }
                void BorrowBook()
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    string filename = Path.Combine(path, "library.dat");
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

                        byte[] bookWrittenBytesforBorrow = FileUtility.ReadBlock(booknumber, Book.BOOK_DATA_BLOCK_SIZE, filename);
                        Book bookWrittenObject = Book.ByteArrayBlockToBook(bookWrittenBytesforBorrow);



                        Book book = new Book();
                        book.Id = bookWrittenObject.Id;
                        book.Title = bookWrittenObject.Title + "  (Borrowed by student: " + student + "  Date: " + date + ")";
                        book.Description = bookWrittenObject.Description;
                        book.Authors.Add(bookWrittenObject.Authors[0]);
                        book.Categories.Add(bookWrittenObject.Categories[0]);

                        byte[] bookBytes = Book.BookToByteArrayBlock(book);

                        FileUtility.UpdateBlock(bookBytes, booknumber, Book.BOOK_DATA_BLOCK_SIZE, filename);
                    }

                    WriteLine("Press any key to return...");
                    ReadKey(true);
                    DisplayBook();
                }
                void ReturnBook()
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    string filename = Path.Combine(path, "library.dat");
                    Clear();
                    int booknumber;
                    string bookname;
                    Write("Please enter number of book which do you want to return: ");
                    booknumber = Convert.ToInt32(ReadLine());
                    Write("\nWhat is book name: ");
                    bookname = ReadLine();


                    using (StreamReader sr = new StreamReader(File.Open("library.dat", FileMode.Open)))
                    {
                        string datalength = sr.ReadLine();
                        sr.Close();

                        byte[] bookWrittenBytesforBorrow = FileUtility.ReadBlock(booknumber, Book.BOOK_DATA_BLOCK_SIZE, filename);
                        Book bookWrittenObject = Book.ByteArrayBlockToBook(bookWrittenBytesforBorrow);



                        Book book = new Book();
                        book.Id = bookWrittenObject.Id;
                        book.Title = bookname;
                        book.Description = bookWrittenObject.Description;
                        book.Authors.Add(bookWrittenObject.Authors[0]);
                        book.Categories.Add(bookWrittenObject.Categories[0]);

                        byte[] bookBytes = Book.BookToByteArrayBlock(book);

                        FileUtility.UpdateBlock(bookBytes, booknumber, Book.BOOK_DATA_BLOCK_SIZE, filename);
                    }

                    WriteLine("Press any key to return...");
                    ReadKey(true);
                    DisplayBook();
                }

            }
            #endregion
            /* This part is removed
             * private void DisplayCtg()
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
                  string[] options = { "Add Category", "Edit Category", "Delete Category", "Back to the main menu" };
                  Menu ctgMenu = new Menu(prompt, options);
                  int SelectedIndex = ctgMenu.Run();

                  switch (SelectedIndex)
                  {
                      case 0:
                          RunMainMenu();
                          break;
                      case 1:
                          RunMainMenu();
                          break;
                      case 2:
                          RunMainMenu();
                          break;
                      case 3:
                          RunMainMenu();
                          break;
                  }

              }*/
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
                string[] options = { "Change Password", "Back to the main menu" };
                Menu optMenu = new Menu(prompt, options);
                int SelectedIndex = optMenu.Run();

                switch (SelectedIndex)
                {
                    case 0:
                        changePassword();
                        break;
                    case 1:
                        RunMainMenu();
                        break;
                }

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
        }
    }
}