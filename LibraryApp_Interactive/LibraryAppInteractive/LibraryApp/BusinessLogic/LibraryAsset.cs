using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAppInteractive.BusinessLogic
{
    public class LibraryAsset
    {
        #region Fields
        private Book _book;
        private int _libID;
        private AssetStatus _status;
        private LoanPeriod _loanPeriod;
        #endregion

        #region Constructors
        public LibraryAsset(int libID, Book book)
        {
            _book = book;
            _libID = libID;
            _status = null;
            _loanPeriod = null;
        }
        #endregion

        #region Properties
        public Book Book
        {
            get { return _book; }
        }

        public int LibraryID
        {
            get { return _libID; }
        }

        public AssetStatus Status
        {
            get { return _status; }
        }

        public LoanPeriod Loan
        {
            get { return _loanPeriod; }
        }

        public bool IsAvailable
        {
            get { return null; }
        }
        #endregion

        #region Methods

        #endregion
    }
}
