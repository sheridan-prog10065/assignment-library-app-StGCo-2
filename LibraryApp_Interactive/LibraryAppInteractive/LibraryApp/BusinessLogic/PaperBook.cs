using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LibraryAppInteractive.BusinessLogic
{
    public class PaperBook : Book
    {
        #region Fields
        private const int MAX_BORROW_DAYS =30;
        private const decimal LATE_PENALTY_PER_DAY = 0.25m;
        #endregion

        #region Constructors
        public PaperBook(string bookName, string bookISBN) : base(bookName, bookISBN) 
        {

        }
        #endregion

        #region Properties

        #endregion

        #region Methods
        public override LibraryAsset BorrowBook()
        {
            LibraryAsset asset = base.BorrowBook();

            if (asset != null)
            {
                asset.Loan = new LoanPeriod();
                asset.Loan.BorrowedOn = DateTime.Now;
                asset.Loan.DueDate = DateTime.Now.AddDays(MAX_BORROW_DAYS);
                asset.Loan.ReturnedOn = DateTime.MinValue;

            }

            return asset;
        }

        public override (TimeSpan, int, decimal) ReturnBook(int libID)
        {
            LibraryAsset asset = _libAssetList.FirstOrDefault(iAsset => iAsset.LibraryID == libID);
            if (asset != null)
            {
                asset.Loan.ReturnedOn = DateTime.Now;
                asset.Status = AssetStatus.Available;

                TimeSpan latePeriod = asset.Loan.LatePeriod;
                int lateDays = latePeriod.Days;
                decimal penalty = lateDays * LATE_PENALTY_PER_DAY;

                return (latePeriod, lateDays, penalty);
            }
            return (TimeSpan.Zero, 0, 0m);
        }

        #endregion
    }
}
