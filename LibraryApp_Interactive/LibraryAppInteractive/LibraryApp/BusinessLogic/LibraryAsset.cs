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
            _status = 0;
            _loanPeriod = new LoanPeriod();
        }
        #endregion

        #region Properties
        public Book Book
        {
            get { return _book; }
            set { _book = value; }
        }

        public int LibraryID
        {
            get { return _libID; }
            set { _libID = value; }
        }

        public AssetStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public LoanPeriod Loan
        {
            get { return _loanPeriod; }
            set { _loanPeriod = value; }
        }

        public bool IsAvailable
        {
            get { return true; }
        }
        #endregion
    }
}
