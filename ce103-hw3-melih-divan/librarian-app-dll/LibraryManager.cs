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
    public static class LibraryManager
    {
        public static bool IsNumeric(object Expression)
        {
            double retNum;

            bool isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        public static void InsertBook(Book book)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string filename = Path.Combine(path, "library.dat");

            byte[] bookBytes = Book.BookToByteArrayBlock(book);
            FileUtility.AppendBlock(bookBytes, filename);
        }

        public static void InsertCategory(Category category)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string filename = Path.Combine(path, "category.dat");

            byte[] catBytes = Category.CategoryToByteArrayBlock(category);
            FileUtility.AppendBlock(catBytes, filename);
        }

        public static void UpdateBook(Book book, int booknumber)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string filename = Path.Combine(path, "library.dat");

            byte[] bookBytes = Book.BookToByteArrayBlock(book);
            FileUtility.UpdateBlock(bookBytes, booknumber, Book.BOOK_DATA_BLOCK_SIZE, filename);
        }

        public static void UpdateCategory(Category category, int catnumber)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string filename = Path.Combine(path, "category.dat");

            byte[] catBytes = Category.CategoryToByteArrayBlock(category);
            FileUtility.UpdateBlock(catBytes, catnumber, Category.CATEGORY_MAX_LENGTH, filename);
        }

        public static void DeleteBook(int booknumber)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string filename = Path.Combine(path, "library.dat");

            using (StreamReader sr = new StreamReader(File.Open("library.dat", FileMode.Open)))
            {
                string datalength = sr.ReadLine();
                sr.Close();
                FileUtility.DeleteBlock(booknumber, Book.BOOK_DATA_BLOCK_SIZE, filename);
                do
                {
                    byte[] nextbookbytes = FileUtility.ReadBlock(booknumber + 1, Book.BOOK_DATA_BLOCK_SIZE, filename);
                    FileUtility.UpdateBlock(nextbookbytes, booknumber, Book.BOOK_DATA_BLOCK_SIZE, filename);
                    booknumber++;
                } while (booknumber <= (((datalength.Length) / (Book.BOOK_DATA_BLOCK_SIZE)) - 1));

                FileUtility.DeleteBlock(((datalength.Length) / (Book.BOOK_DATA_BLOCK_SIZE)), Book.BOOK_DATA_BLOCK_SIZE, filename);
            }
        }

        public static void DeleteCategory(int catnumber)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string filename = Path.Combine(path, "category.dat");

            using (StreamReader sr = new StreamReader(File.Open("category.dat", FileMode.Open)))
            {
                string datalength = sr.ReadLine();
                sr.Close();
                FileUtility.DeleteBlock(catnumber, Category.CATEGORY_MAX_LENGTH, filename);
                do
                {
                    byte[] nextbookbytes = FileUtility.ReadBlock(catnumber + 1, Category.CATEGORY_MAX_LENGTH, filename);
                    FileUtility.UpdateBlock(nextbookbytes, catnumber, Category.CATEGORY_MAX_LENGTH, filename);
                    catnumber++;
                } while (catnumber <= (((datalength.Length) / (Category.CATEGORY_MAX_LENGTH)) - 1));

                FileUtility.DeleteBlock(((datalength.Length) / (Category.CATEGORY_MAX_LENGTH)), Category.CATEGORY_MAX_LENGTH, filename);
            }
        }

        public static Book ReadBook(int booknumber)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string filename = Path.Combine(path, "library.dat");

            byte[] bookWrittenBytesforBorrow = FileUtility.ReadBlock(booknumber, Book.BOOK_DATA_BLOCK_SIZE, filename);
            Book bookWrittenObject = Book.ByteArrayBlockToBook(bookWrittenBytesforBorrow);
            return bookWrittenObject;
        }

        public static Category ReadCategory(int catnumber)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string filename = Path.Combine(path, "category.dat");



            byte[] categoryWrittenBytes = FileUtility.ReadBlock(catnumber, Category.CATEGORY_MAX_LENGTH, filename);
            Category categoryWrittenObject = Category.ByteArrayBlockToCategory(categoryWrittenBytes);
            return categoryWrittenObject;
        }
    }
}