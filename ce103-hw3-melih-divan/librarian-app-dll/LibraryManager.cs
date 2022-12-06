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
    }
}