using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAppInteractive.BusinessLogic
{
    public class Book
    {
        #region Fields
        protected string _bookName;
        protected string _bookISBN;
        protected List<string> _bookAuthorList;
        protected List<LibraryAsset> _libAssetList;
        #endregion

        #region Constructors
        public Book(string bookName, string bookISBN)
        {
            _bookName = bookName;
            _bookISBN = bookISBN;
            _bookAuthorList = new List<string>();
            _libAssetList = new List<LibraryAsset>();
        }
        #endregion

        #region Properties
        public string Name
        {
            get { return _bookName; }
            set { _bookName = value; }
        }

        public string ISBN
        {
            get { return _bookISBN; }
            set { _bookISBN = value; }
        }

        public List<string> Authors
        {
            get { return _bookAuthorList; }
        }

        public List<LibraryAsset> Assets
        {
            get { return _libAssetList; }
        }
        #endregion

        #region Methods
       // public (bool, LibraryAsset) CheckAvailability()


       // public LibraryAsset BorrowBook()


       // public (TimeSpan, int, decimal) ReturnBook(int libID)


       // public LibraryAsset ReserveBook()


       // private LibraryAsset FindLibraryAsset(int libID)


      //  private LibraryAsset FindNextAvailableAsset()
 
        #endregion
    }
}
