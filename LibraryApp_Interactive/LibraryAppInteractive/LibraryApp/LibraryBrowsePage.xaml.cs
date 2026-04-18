using LibraryAppInteractive.BusinessLogic;

namespace LibraryAppInteractive;

public partial class LibraryBrowsePage : ContentPage
{
    private Library _library;
    private Book _book;
    public LibraryBrowsePage()
    {   
        InitializeComponent();
        _library = new Library();
    }

    //public OnSearchBook()


    // public OnBorrowBook()


    // public OnReturnBook()

}