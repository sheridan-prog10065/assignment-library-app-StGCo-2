using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAppInteractive.BusinessLogic
{
    public class PaperBook : Book
    {
        #region Fields
        private const int MAX_BORROW_DAYS;
        private const float LATE_PENALTY_PER_DAY;
        #endregion

        #region Constructors
        public PaperBook(string bookName, string bookISBN)
        {

        }
        #endregion

        #region Properties

        #endregion

        #region Methods
        public LibraryAsset BorrowBook()
        {
            return null;
        }

        public TimeSpan ReturnBook(int libID)
        {

        }
        #endregion
    }
}
