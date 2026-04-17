using System;
using System.Collections.Generic;
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
        }
        #endregion

        #region Properties

        #endregion

        #region Methods
        private void CreateDefaultBook()
        {

        }

        private int DetermineLibID()
        {

        }

        public Book RegisterBook(string bookName, string bookISBN, string[] authors, BookType bookType, int nCopies)
        {

        }

        public Book FIndBookByName(string bookName)
        {

        }

        public Book FindBookByISBN(string bookISBN)
        {

        }
        #endregion
    }
}
