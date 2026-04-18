using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LibraryAppInteractive.BusinessLogic
{
    public class Library
    {
        #region Fields
        private List<Book> _bookList;
        private int _libIDGeneratorSeed;
        private const int DEFAULT_LIBID_START = 100;
        #endregion

        #region Constructors
        public Library()
        {
            _bookList = new List<Book>();
            _libIDGeneratorSeed = DEFAULT_LIBID_START;
            CreateDefaultBook();
        }
        #endregion

        #region Properties

        #endregion

        #region Methods
        private void CreateDefaultBook()
        {
            Book sum = new Book("The Summoning", "9780385665346");
            sum.Authors.Add("Kelly Armstrong");
            _bookList.Add(sum);

            Book gobSlay = new Book("Goblin Slayer, Manga Volume 1", "9780316439725");
            gobSlay.Authors.Add("Kumo Kagyu");
            _bookList.Add(gobSlay);

            Book shield = new Book("Rising of the Shield Hero, Volume 1, Light novel", "9781935548645");
            shield.Authors.Add("Aneko Yusagi");
            _bookList.Add(shield);
        }

        private int DetermineLibID()
        {
            int nextID = _libIDGeneratorSeed;
            _libIDGeneratorSeed++;
            return nextID;
        }

        public Book RegisterBook(string bookName, string bookISBN, string authors, BookType bookType, int nCopies)
        {
            Book newBook;

            if (bookType == BookType.Paper)
            {
                newBook = new PaperBook(bookName, bookISBN);
            }
            else
            {
                newBook = new DigitalBook(bookName, bookISBN);
            }

            newBook.Authors.Add(authors);

            for (int iAsset = 0; iAsset < nCopies; iAsset++)
            {
                LibraryAsset asset = new LibraryAsset(DetermineLibID(), newBook);
                newBook.AddAsset(asset);
            }

            _bookList.Add(newBook);
            return newBook;
        }

        public Book FIndBookByName(string bookName)
        {
            return _bookList.FirstOrDefault(book => book.Name == bookName);
        }

        public Book FindBookByISBN(string bookISBN)
        {
            return _bookList.FirstOrDefault(book => book.ISBN == bookISBN);
        }
        #endregion
    }
}
