using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAppInteractive.BusinessLogic
{
    public class PaperBook : Book
    {
        #region Fields
        private int MAX_BORROW_DAYS;
        private float LATE_PENALTY_PER_DAY;
        #endregion

        #region Constructors
        public PaperBook(string bookName, string bookISBN) : base(bookName, bookISBN) 
        {
            MAX_BORROW_DAYS = 0;
            LATE_PENALTY_PER_DAY = 0;
        }
        #endregion

        #region Properties

        #endregion

        #region Methods
        // public LibraryAsset BorrowBook()

        // public TimeSpan ReturnBook(int libID)

        #endregion
    }
}
