using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;

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
        public IEnumerable<Book> Books
        {
            get { return _bookList; }
        }
        #endregion

        #region Methods

        private int DetermineLibID()
        {
            int nextID = _libIDGeneratorSeed;
            _libIDGeneratorSeed++;
            return nextID;
        }

        private void CreateDefaultBook()
        {
            // Book 1
            Book sum = new PaperBook("The Summoning", "9780385665346");
            sum.Authors.Add("Kelly Armstrong");

            for (int i = 0; i < 3; i++) // number of copies
            {
                int id = DetermineLibID();
                LibraryAsset asset = new LibraryAsset(id, sum);
                sum.AddAsset(asset);
            }
            _bookList.Add(sum);

            // Book 2
            Book gobSlay = new PaperBook("Goblin Slayer, Manga Volume 1", "9780316439725");
            gobSlay.Authors.Add("Kumo Kagyu");

            for (int i = 0; i < 2; i++)
            {
                int id = DetermineLibID();
                LibraryAsset asset = new LibraryAsset(id, gobSlay);
                gobSlay.AddAsset(asset);
            }
            _bookList.Add(gobSlay);

            // Book 3
            Book shield = new DigitalBook("Rising of the Shield Hero, Volume 1, Light novel", "9781935548645");
            shield.Authors.Add("Aneko Yusagi");

            for (int i = 0; i < 2; i++)
            {
                int id = DetermineLibID();
                LibraryAsset asset = new LibraryAsset(id, shield);
                shield.AddAsset(asset);
            }
            _bookList.Add(shield);
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

        public List<Book> FindBooksByName(string bookName)
        {
            return _bookList
                .Where(book => book.Name != null &&
                               book.Name.Contains(bookName, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public Book FindBookByISBN(string bookISBN)
        {
            return _bookList.FirstOrDefault(book => book.ISBN == bookISBN);
        }
            public Book FindBookByAssetID(int libID)
        {
            return _bookList.FirstOrDefault(book =>
                book.Assets.Any(asset => asset.LibraryID == libID));
        }
        #endregion
    }
}
