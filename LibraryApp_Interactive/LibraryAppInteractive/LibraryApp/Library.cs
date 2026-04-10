using LibraryAppInteractive.BusinessLogic;

namespace LibraryAppInteractive;

/// <summary>
/// Defines the Library class used to manage the library books and assets.
///
/// NOTE: A single object/instance of this class (called a "singleton") is created and shared automatically
/// with the two pages in the application through the process of Dependency Injection handled and configured
/// in MauiProgram class.  
/// </summary>
public class Library
{
    #region Fields
    private List<Book> _bookList;
    private int lidIDGeneratorSeed;
    private const int DEFAULT_LIBID_START;
    #endregion

    #region Constructors
    public Library()
    {
        _bookList = new List<Book>();
        _libIDGeneratorSeed = 0;
        _DEFAULT_LIBID_START = 100;
    }
    #endregion

    #region Properties

    #endregion

    #region Methods
    private void CreateDefaultBooks()
    {

    }

    private int DetermineLibID()
    {

    }
    
    public Book RegisterBook(string bookName, string[] bookISBN, BookType bookType, int nCopies)
    {

    }

    public Book FindBookByName(string bookName)
    {

    }

    public Book FindBookByISBN(string bookISBN)
    {

    }
    #endregion
}