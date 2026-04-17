using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAppInteractive.BusinessLogic
{
    public class DigitalBook : Book
    {
        #region Fields
        private const int _maxBorrowDays = 30;
        private const decimal _latePenaltyPerDay = 0.25m;
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


        public override LibraryAsset BorrowBook()
        {
            LibraryAsset asset = base.BorrowBook();

            if (asset != null)
            {
                asset.Loan = new LoanPeriod();
                asset.Loan.BorrowedOn = DateTime.Now;
                asset.Loan.DueDate = DateTime.Now.AddDays(_maxBorrowDays);
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
                decimal penalty = lateDays * _latePenaltyPerDay;

                return (latePeriod, lateDays, penalty);
            }
            return (TimeSpan.Zero, 0, 0m);
        }
        #endregion
    }
}
