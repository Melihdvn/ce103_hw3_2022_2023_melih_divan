using System;
using System.Collections.Generic;
using System.Data;

namespace LibraryManagement
{
    public class Book
    {
        #region Public Constants
        public const int ID_LENGTH = 4;

        public const int TITLE_MAX_LENGTH = 100;

        public const int DESCRIPTION_MAX_LENGTH = 300;

        public const int YEAR_LENGTH = 20;

        public const int PAGES_LENGTH = 15;

        public const int ABSTRACT_LENGTH = 500;

        public const int CITY_LENGTH = 60;

        public const int EDITION_LENGTH = 40;

        public const int PUBLISHER_LENGTH = 60;

        public const int URL_LENGTH = 160;

        public const int CATALOGID_LENGTH = 110;

        public const int PRICE_LENGTH = 20;

        public const int RACKNO_LENGTH = 15;

        public const int ROWNO_LENGTH = 15;

        public const int STATUS_LENGTH = 40;

        public const int RETURN_LENGTH = 50;

        public const int GIVEN_LENGTH = 50;

        public const int AUTHORS_MAX_COUNT = 5;
        public const int AUTHORS_NAME_MAX_LENGTH = 100;

        public const int TAG_MAX_COUNT = 5;
        public const int TAG_NAME_MAX_LENGTH = 100;

        public const int EDITORS_MAX_COUNT = 5;
        public const int EDITORS_NAME_MAX_LENGTH = 100;

        public const int CATEGORY_MAX_COUNT = 5;
        public const int CATEGORY_NAME_MAX_LENGTH = 100;

        public const int BOOK_DATA_BLOCK_SIZE = ID_LENGTH +
                                                TITLE_MAX_LENGTH +
                                                DESCRIPTION_MAX_LENGTH +
                                                YEAR_LENGTH + 
                                                PAGES_LENGTH +
                                                ABSTRACT_LENGTH +
                                                CITY_LENGTH +
                                                EDITION_LENGTH +
                                                PUBLISHER_LENGTH + 
                                                URL_LENGTH + 
                                                CATALOGID_LENGTH + 
                                                PRICE_LENGTH +
                                                RACKNO_LENGTH +
                                                ROWNO_LENGTH +
                                                STATUS_LENGTH + 
                                                RETURN_LENGTH + 
                                                GIVEN_LENGTH +
                                                (TAG_MAX_COUNT * TAG_NAME_MAX_LENGTH) + 
                                                (EDITORS_MAX_COUNT * EDITORS_NAME_MAX_LENGTH) +
                                                (AUTHORS_MAX_COUNT * AUTHORS_NAME_MAX_LENGTH) +
                                                (CATEGORY_MAX_COUNT * CATEGORY_NAME_MAX_LENGTH);
        #endregion

        #region Private Fields
        private int _id;
        private string _title;
        private string _description;
        private string _year;
        private string _pages;
        private string _abstract;
        private string _city;
        private string _edition;
        private string _publisher;
        private string _catalogid;
        private string _price;
        private string _rackno;
        private string _rowno;
        private string _status;
        private string _return;
        private string _given;
        private string _url;
        private List<string> _authors;
        private List<string> _tags;
        private List<string> _editors;
        private List<string> _categories;
        #endregion

        #region Public Properties
        public int Id { get { return _id; } set { _id = value; } }
        public string Title { get { return _title; } set { _title = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public string Year { get { return _year; } set { _year = value; } }
        public string Pages { get { return _pages; } set { _pages = value; } }
        public string Abstract { get { return _abstract; } set { _abstract = value; } }
        public string City { get { return _city; } set { _city = value; } }
        public string Edition { get { return _edition; } set { _edition = value; } }
        public string Publisher { get { return _publisher; } set { _publisher = value; } }
        public string CatalogId { get { return _catalogid; } set { _catalogid = value; } }
        public string Price { get { return _price; } set { _price = value; } }
        public string RackNo { get { return _rackno; } set { _rackno = value; } }
        public string RowNo { get { return _rowno; } set { _rowno = value; } }
        public string Status { get { return _status; } set { _status = value; } }
        public string Return { get { return _return; } set { _return = value; } }
        public string Given { get { return _given; } set { _given = value; } }
        public string Url { get { return _url; } set { _url = value; } }
        public List<string> Authors { get { return _authors; } set { _authors = value; } }
        public List<string> Tags { get { return _tags; } set { _tags = value; } }
        public List<string> Editors { get { return _editors; } set { _editors = value; } }
        public List<string> Categories { get { return _categories; } set { _categories = value; } }
        #endregion

        #region Constructors
        public Book()
        {
            _authors = new List<string>();
            _tags = new List<string>();
            _editors = new List<string>();
            _categories = new List<string>();
        }
        #endregion

        #region Utility Methods
        public static byte[] BookToByteArrayBlock(Book book)
        {
            int index = 0;

            byte[] dataBuffer = new byte[BOOK_DATA_BLOCK_SIZE];

            #region copy book id
            byte[] idBytes = ConversionUtility.IntegerToByteArray(book.Id);
            Array.Copy(idBytes, 0, dataBuffer, index, idBytes.Length);
            index += Book.ID_LENGTH;
            #endregion

            #region copy book title
            byte[] titleBytes = ConversionUtility.StringToByteArray(book.Title);
            Array.Copy(titleBytes, 0, dataBuffer, index, titleBytes.Length);
            index += Book.TITLE_MAX_LENGTH;
            #endregion

            #region copy book description
            byte[] descBytes = ConversionUtility.StringToByteArray(book.Description);
            Array.Copy(descBytes, 0, dataBuffer, index, descBytes.Length);
            index += Book.DESCRIPTION_MAX_LENGTH;
            #endregion

            #region copy book year
            byte[] yearBytes = ConversionUtility.StringToByteArray(book.Year);
            Array.Copy(yearBytes, 0, dataBuffer, index, yearBytes.Length);
            index += Book.YEAR_LENGTH;
            #endregion

            #region copy book pages
            byte[] pageBytes = ConversionUtility.StringToByteArray(book.Pages);
            Array.Copy(pageBytes, 0, dataBuffer, index, pageBytes.Length);
            index += Book.PAGES_LENGTH;
            #endregion

            #region copy book abstract
            byte[] abstractBytes = ConversionUtility.StringToByteArray(book.Abstract);
            Array.Copy(abstractBytes, 0, dataBuffer, index, abstractBytes.Length);
            index += Book.ABSTRACT_LENGTH;
            #endregion

            #region copy book city
            byte[] cityBytes = ConversionUtility.StringToByteArray(book.City);
            Array.Copy(cityBytes, 0, dataBuffer, index, cityBytes.Length);
            index += Book.CITY_LENGTH;
            #endregion

            #region copy book edition
            byte[] editionBytes = ConversionUtility.StringToByteArray(book.Edition);
            Array.Copy(editionBytes, 0, dataBuffer, index, editionBytes.Length);
            index += Book.EDITION_LENGTH;
            #endregion

            #region copy book publisher
            byte[] publisherBytes = ConversionUtility.StringToByteArray(book.Publisher);
            Array.Copy(publisherBytes, 0, dataBuffer, index, publisherBytes.Length);
            index += Book.PUBLISHER_LENGTH;
            #endregion

            #region copy book catalogid
            byte[] catalogBytes = ConversionUtility.StringToByteArray(book.CatalogId);
            Array.Copy(catalogBytes, 0, dataBuffer, index, catalogBytes.Length);
            index += Book.CATALOGID_LENGTH;
            #endregion

            #region copy book price
            byte[] priceBytes = ConversionUtility.StringToByteArray(book.Price);
            Array.Copy(priceBytes, 0, dataBuffer, index, priceBytes.Length);
            index += Book.PRICE_LENGTH;
            #endregion

            #region copy book rack
            byte[] rackBytes = ConversionUtility.StringToByteArray(book.RackNo);
            Array.Copy(rackBytes, 0, dataBuffer, index, rackBytes.Length);
            index += Book.RACKNO_LENGTH;
            #endregion

            #region copy book row
            byte[] rowBytes = ConversionUtility.StringToByteArray(book.RowNo);
            Array.Copy(rowBytes, 0, dataBuffer, index, rowBytes.Length);
            index += Book.ROWNO_LENGTH;
            #endregion

            #region copy book status
            byte[] statusBytes = ConversionUtility.StringToByteArray(book.Status);
            Array.Copy(statusBytes, 0, dataBuffer, index, statusBytes.Length);
            index += Book.STATUS_LENGTH;
            #endregion

            #region copy book return date
            byte[] returnBytes = ConversionUtility.StringToByteArray(book.Return);
            Array.Copy(returnBytes, 0, dataBuffer, index, returnBytes.Length);
            index += Book.RETURN_LENGTH;
            #endregion

            #region copy book given date
            byte[] givenBytes = ConversionUtility.StringToByteArray(book.Given);
            Array.Copy(givenBytes, 0, dataBuffer, index, givenBytes.Length);
            index += Book.GIVEN_LENGTH;
            #endregion

            #region copy book url
            byte[] urlBytes = ConversionUtility.StringToByteArray(book.Url);
            Array.Copy(urlBytes, 0, dataBuffer, index, urlBytes.Length);
            index += Book.URL_LENGTH;
            #endregion

            #region copy book authors
            byte[] authorBytes = ConversionUtility.StringListToByteArray(book.Authors,
                                                                            Book.AUTHORS_MAX_COUNT,
                                                                            Book.AUTHORS_NAME_MAX_LENGTH);
            Array.Copy(authorBytes, 0, dataBuffer, index, authorBytes.Length);
            index += authorBytes.Length;
            #endregion

            #region copy book tags
            byte[] tagBytes = ConversionUtility.StringListToByteArray(book.Tags,
                                                                            Book.TAG_MAX_COUNT,
                                                                            Book.TAG_NAME_MAX_LENGTH);
            Array.Copy(tagBytes, 0, dataBuffer, index, tagBytes.Length);
            index += tagBytes.Length;
            #endregion

            #region copy book editors
            byte[] editorBytes = ConversionUtility.StringListToByteArray(book.Editors,
                                                                            Book.EDITORS_MAX_COUNT,
                                                                            Book.EDITORS_NAME_MAX_LENGTH);
            Array.Copy(editorBytes, 0, dataBuffer, index, editorBytes.Length);
            index += editorBytes.Length;
            #endregion


            #region copy book categories
            byte[] categoryBytes = ConversionUtility.StringListToByteArray(book.Categories,
                                                                            Book.CATEGORY_MAX_COUNT,
                                                                            Book.CATEGORY_NAME_MAX_LENGTH);
            Array.Copy(categoryBytes, 0, dataBuffer, index, categoryBytes.Length);
            index += categoryBytes.Length;
            #endregion

            if (index != dataBuffer.Length)
            {
                throw new ArgumentException("Index and DataBuffer Size Not Matched");
            }

            return dataBuffer;
        }

        public static Book ByteArrayBlockToBook(byte[] byteArray)
        {

            Book book = new Book();

            if (byteArray.Length != BOOK_DATA_BLOCK_SIZE)
            {
                throw new ArgumentException("Byte Array Size Not Match with Constant Data Block Size");
            }

            int index = 0;

            //byte[] dataBuffer = new byte[BOOK_DATA_BLOCK_SIZE];

            #region copy book id
            byte[] idBytes = new byte[Book.ID_LENGTH];
            Array.Copy(byteArray, index, idBytes, 0, idBytes.Length);
            book.Id = ConversionUtility.ByteArrayToInteger(idBytes);

            index += Book.ID_LENGTH;
            #endregion

            #region copy book title
            byte[] titleBytes = new byte[Book.TITLE_MAX_LENGTH];
            Array.Copy(byteArray, index, titleBytes, 0, titleBytes.Length);
            book.Title = ConversionUtility.ByteArrayToString(titleBytes);

            index += Book.TITLE_MAX_LENGTH;
            #endregion

            #region copy book description
            byte[] descBytes = new byte[Book.DESCRIPTION_MAX_LENGTH];
            Array.Copy(byteArray, index, descBytes, 0, descBytes.Length);
            book.Description = ConversionUtility.ByteArrayToString(descBytes);

            index += Book.DESCRIPTION_MAX_LENGTH;
            #endregion

            #region copy book year
            byte[] yearBytes = new byte[Book.YEAR_LENGTH];
            Array.Copy(byteArray, index, yearBytes, 0, yearBytes.Length);
            book.Year = ConversionUtility.ByteArrayToString(yearBytes);

            index += Book.YEAR_LENGTH;
            #endregion

            #region copy book pages
            byte[] pageBytes = new byte[Book.PAGES_LENGTH];
            Array.Copy(byteArray, index, pageBytes, 0, pageBytes.Length);
            book.Pages = ConversionUtility.ByteArrayToString(pageBytes);

            index += Book.PAGES_LENGTH;
            #endregion

            #region copy book abstract
            byte[] abstractBytes = new byte[Book.ABSTRACT_LENGTH];
            Array.Copy(byteArray, index, abstractBytes, 0, abstractBytes.Length);
            book.Abstract = ConversionUtility.ByteArrayToString(abstractBytes);

            index += Book.ABSTRACT_LENGTH;
            #endregion

            #region copy book city
            byte[] cityBytes = new byte[Book.CITY_LENGTH];
            Array.Copy(byteArray, index, cityBytes, 0, cityBytes.Length);
            book.City = ConversionUtility.ByteArrayToString(cityBytes);

            index += Book.CITY_LENGTH;
            #endregion

            #region copy book edition
            byte[] editionBytes = new byte[Book.EDITION_LENGTH];
            Array.Copy(byteArray, index, editionBytes, 0, editionBytes.Length);
            book.Edition = ConversionUtility.ByteArrayToString(editionBytes);

            index += Book.EDITION_LENGTH;
            #endregion

            #region copy book publisher
            byte[] publisherBytes = new byte[Book.PUBLISHER_LENGTH];
            Array.Copy(byteArray, index, publisherBytes, 0, publisherBytes.Length);
            book.Publisher = ConversionUtility.ByteArrayToString(publisherBytes);

            index += Book.PUBLISHER_LENGTH;
            #endregion

            #region copy book catalogid
            byte[] catalogBytes = new byte[Book.CATALOGID_LENGTH];
            Array.Copy(byteArray, index, catalogBytes, 0, catalogBytes.Length);
            book.CatalogId = ConversionUtility.ByteArrayToString(catalogBytes);

            index += Book.CATALOGID_LENGTH;
            #endregion

            #region copy book price
            byte[] priceBytes = new byte[Book.PRICE_LENGTH];
            Array.Copy(byteArray, index, priceBytes, 0, priceBytes.Length);
            book.Price = ConversionUtility.ByteArrayToString(priceBytes);

            index += Book.PRICE_LENGTH;
            #endregion

            #region copy book rackno
            byte[] rackBytes = new byte[Book.RACKNO_LENGTH];
            Array.Copy(byteArray, index, rackBytes, 0, rackBytes.Length);
            book.RackNo = ConversionUtility.ByteArrayToString(rackBytes);

            index += Book.RACKNO_LENGTH;
            #endregion

            #region copy book rowno
            byte[] rowBytes = new byte[Book.ROWNO_LENGTH];
            Array.Copy(byteArray, index, rowBytes, 0, rowBytes.Length);
            book.RowNo = ConversionUtility.ByteArrayToString(rowBytes);

            index += Book.ROWNO_LENGTH;
            #endregion

            #region copy book status
            byte[] statusBytes = new byte[Book.STATUS_LENGTH];
            Array.Copy(byteArray, index, statusBytes, 0, statusBytes.Length);
            book.Status = ConversionUtility.ByteArrayToString(statusBytes);

            index += Book.STATUS_LENGTH;
            #endregion

            #region copy book returndate
            byte[] returnBytes = new byte[Book.RETURN_LENGTH];
            Array.Copy(byteArray, index, returnBytes, 0, returnBytes.Length);
            book.Return = ConversionUtility.ByteArrayToString(returnBytes);

            index += Book.RETURN_LENGTH;
            #endregion

            #region copy book givendate
            byte[] givenBytes = new byte[Book.GIVEN_LENGTH];
            Array.Copy(byteArray, index, givenBytes, 0, givenBytes.Length);
            book.Given = ConversionUtility.ByteArrayToString(givenBytes);

            index += Book.GIVEN_LENGTH;
            #endregion

            #region copy book url
            byte[] urlBytes = new byte[Book.URL_LENGTH];
            Array.Copy(byteArray, index, urlBytes, 0, urlBytes.Length);
            book.Url = ConversionUtility.ByteArrayToString(urlBytes);

            index += Book.URL_LENGTH;
            #endregion

            #region copy book authors

            byte[] authorBytes = new byte[Book.AUTHORS_MAX_COUNT * Book.AUTHORS_NAME_MAX_LENGTH];

            Array.Copy(byteArray, index, authorBytes, 0, authorBytes.Length);

            book.Authors = ConversionUtility.ByteArrayToStringList(authorBytes,
                                                                            Book.AUTHORS_MAX_COUNT,
                                                                            Book.AUTHORS_NAME_MAX_LENGTH);

            index += authorBytes.Length;
            #endregion

            #region copy book tags

            byte[] tagBytes = new byte[Book.TAG_MAX_COUNT * Book.TAG_NAME_MAX_LENGTH];

            Array.Copy(byteArray, index, tagBytes, 0, tagBytes.Length);

            book.Tags = ConversionUtility.ByteArrayToStringList(tagBytes,
                                                                            Book.TAG_MAX_COUNT,
                                                                            Book.TAG_NAME_MAX_LENGTH);

            index += tagBytes.Length;
            #endregion

            #region copy book editors

            byte[] editorBytes = new byte[Book.EDITORS_MAX_COUNT * Book.EDITORS_NAME_MAX_LENGTH];

            Array.Copy(byteArray, index, editorBytes, 0, editorBytes.Length);

            book.Editors = ConversionUtility.ByteArrayToStringList(editorBytes,
                                                                            Book.EDITORS_MAX_COUNT,
                                                                            Book.EDITORS_NAME_MAX_LENGTH);

            index += editorBytes.Length;
            #endregion


            #region copy book categories
            byte[] categoryBytes = new byte[Book.CATEGORY_MAX_COUNT * Book.CATEGORY_NAME_MAX_LENGTH];

            Array.Copy(byteArray, index, categoryBytes, 0, categoryBytes.Length);

            book.Categories = ConversionUtility.ByteArrayToStringList(categoryBytes,
                                                                            Book.CATEGORY_MAX_COUNT,
                                                                            Book.CATEGORY_NAME_MAX_LENGTH);

            index += categoryBytes.Length;
            #endregion

            if (index != byteArray.Length)
            {
                throw new ArgumentException("Index and DataBuffer Size Not Matched");
            }

            if (book.Id == 0)
            {
                return null;
            }
            else
            {
                return book;
            }

        }
        #endregion

    }

}
