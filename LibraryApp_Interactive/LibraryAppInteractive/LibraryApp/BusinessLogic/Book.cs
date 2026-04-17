using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
            set { _bookAuthorList= value; }
        }

        public IEnumerable<LibraryAsset> Assets
        {
            get { return _libAssetList; }
        }
        #endregion

        #region Methods
        public (bool, LibraryAsset) CheckAvailability()
        {
            LibraryAsset asset = _libAssetList.FirstOrDefault(iAsset => iAsset.IsAvailable);
            return(asset != null, asset);
        }


        public virtual LibraryAsset BorrowBook()
        {
            LibraryAsset asset = _libAssetList.FirstOrDefault(iAsset => iAsset.IsAvailable);

            if (asset != null)
            {
                asset.Status = AssetStatus.Loaned;
                return asset;
            }

            return null;
        }


       public virtual (TimeSpan, int, decimal) ReturnBook(int libID)
        {
            LibraryAsset asset = _libAssetList.FirstOrDefault(iAsset => iAsset.LibraryID == libID);
            if(asset != null)
            {
                asset.Status = AssetStatus.Available;

                return (TimeSpan.Zero, 0, 0m);
            }
            return (TimeSpan.Zero, 0, 0m);
        }


        public LibraryAsset ReserveBook()
        {
            LibraryAsset asset = _libAssetList.FirstOrDefault(iAsset => iAsset.Status == AssetStatus.Available);
            if (asset != null)
            {
                asset.Status = AssetStatus.Reserved;
                return asset;
            }
            return null;
        }


       private LibraryAsset FindLibraryAsset(int libID)
        {
            return _libAssetList.FirstOrDefault(iAsset => iAsset.LibraryID==libID);
        }


      private LibraryAsset FindNextAvailableAsset()
        {
            return _libAssetList.FirstOrDefault(iAsset => iAsset.IsAvailable);
        }
 
        #endregion
    }
}
