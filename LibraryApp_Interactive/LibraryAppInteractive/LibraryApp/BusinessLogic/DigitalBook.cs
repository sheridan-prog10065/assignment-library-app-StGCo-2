using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAppInteractive.BusinessLogic
{
    public class DigitalBook : Book
    {
        #region Fields
        private int _maxBorrowDays;
        private float _latePenaltyPerDay;
        #endregion

        #region Constructors
        public DigitalBook(string bookName, string bookISBN) : base(bookName, bookISBN)
        {

        }

        #endregion

        #region Properties

        #endregion

        #region Methods
        // private DetermineLoanLicense()


        // public LibraryAsset BorrowBook()


        // public ReturnBook(int libID)

        #endregion
    }
}
