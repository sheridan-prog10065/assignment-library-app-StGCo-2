using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAppInteractive.BusinessLogic
{
    public class LoanPeriod
    {
        #region Fields
        private DateTime _borrowedOn;
        private DateTime _returnedOn;
        private DateTime _dueDate;
        #endregion

        #region Constructors
        public LoanPeriod(DateTime borrowedOn, DateTime returnedOn, DateTime dueDate)
        {
            _borrowedOn = borrowedOn;
            _returnedOn = returnedOn;
            _dueDate = dueDate;
        }

        public LoanPeriod()
        {

        }
        #endregion

        #region Properties
        public DateTime BorrowedOn
        {
            get { return _borrowedOn; }
            set { _borrowedOn = value; }
        }

        public DateTime ReturnedOn
        {
            get  {return _returnedOn; }
            set { _returnedOn = value; }
        }

        public DateTime DueDate
        {
            get { return _dueDate; }
            set { _dueDate = value; }
        }

        public TimeSpan LoanDuration
        {
            get { return _returnedOn - _borrowedOn; }
        }

        public TimeSpan LatePeriod
        { 
            get { return _dueDate < _returnedOn ? _returnedOn - _dueDate : TimeSpan.Zero; }
        }
        #endregion
    }    
}
