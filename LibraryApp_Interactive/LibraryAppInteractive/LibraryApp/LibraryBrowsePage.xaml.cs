using LibraryAppInteractive.BusinessLogic;

namespace LibraryAppInteractive;

public partial class LibraryBrowsePage : ContentPage
{
    private Library _library;
    private Book _book;
    private List<Book> _bookList;
    public LibraryBrowsePage()
    {   
        InitializeComponent();
        _lstBooks.ItemsSource = _bookList;
    }

    private async Task OnSearchBook(object sender, EventArgs e)
    {
        if (sender == _btnSearch)
        {
            string bookName = _entName.Text;
            string bookISBN = _entISBN.Text;
            try
            {
                if (_entName != null)
                {
                    _library.FIndBookByName(bookName);
                }

                if (_entISBN != null)
                {
                    _library.FindBookByISBN(bookISBN);
                }
                return;
            }
            catch (ArgumentNullException ex)
            {
                await DisplayAlertAsync("Browse Page", ex.Message, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Browser Page", ex.Message, "OK");
            }
        }
    }

    private void OnBorrowBook(object sender, EventArgs e)
    {
        _book.BorrowBook();
    }

    private void OnReturnBook(object sender, EventArgs e)
    {

    }
}