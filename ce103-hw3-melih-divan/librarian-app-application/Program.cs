using System;
using System.IO;
using static System.Console;
using LibraryManagement;

namespace librarianApp
{
    #region Starting app with password function
    class Program
    {
        static void Main()
        {
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
    }
    #endregion
}
