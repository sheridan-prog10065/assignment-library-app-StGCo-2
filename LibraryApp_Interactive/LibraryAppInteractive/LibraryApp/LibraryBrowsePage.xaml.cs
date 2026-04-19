using LibraryAppInteractive.BusinessLogic;

namespace LibraryAppInteractive;

public partial class LibraryBrowsePage : ContentPage
{
    private Library _library;
    private Book _book;
    private List<Book> _bookList;
    public LibraryBrowsePage(Library library)
    {   
        InitializeComponent();
        _library = library;
        _bookList = new List<Book>();
        _lstBooks.ItemsSource = _bookList;
    }

    private async void OnSearchBook(object sender, EventArgs e)
    {
        {
            try
            {
                _book = null;

                if (!string.IsNullOrWhiteSpace(_entName.Text))
                {
                   _bookList =  _library.FindBooksByName(_entName.Text);
                    _lstBooks.ItemsSource = _bookList;
                }

                else if (!string.IsNullOrWhiteSpace(_entISBN.Text))
                {
                    _book = _library.FindBookByISBN(_entISBN.Text);

                    if (_book != null)
                    {
                        _bookList.Clear();
                        _bookList.Add(_book);
                        _lstBooks.ItemsSource = null;
                        _lstBooks.ItemsSource = _bookList;
                    }
                    else
                    {
                        await DisplayAlertAsync("Browse Page", "Enter a book name or book ISBN.", "OK");
                        return;
                    }            
                }

                else
                {
                    await DisplayAlertAsync("Browse Page", "Book not found.", "OK");
                    return;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Browser Page", ex.Message, "OK");
            }
        }
    }

    private async void OnBorrowBook(object sender, EventArgs e)
    {
        {
            _book = _lstBooks.SelectedItem as Book;
            if (_book == null)
            {
                await DisplayAlertAsync("Browse Page", "Please search and select a book first.", "OK");
                return;
            }
            LibraryAsset asset = _book.BorrowBook();

            if (asset != null)
            {
                await DisplayAlertAsync("Browse Page", $"Borrowed asset ID: {asset.LibraryID}", "OK");
                return;
            }

            else
            {
                await DisplayAlertAsync("Browse Page", "No available copies.", "OK");
                return;
            }
        }
    }

    private async void OnReturnBook(object sender, EventArgs e)
    {
        if (!int.TryParse(_entID.Text, out int libID))
        {
            await DisplayAlertAsync("Browse Page", "Enter a valid asset ID.", "OK");
            return;
        }

        Book book = _library.FindBookByAssetID(libID);

        if (book == null)
        {
            await DisplayAlertAsync("Browse Page", "No book found for that asset ID.", "OK");
            return;
        }

        var result = _book.ReturnBook(libID);

        await DisplayAlertAsync("Browse Page", $"Late Period: {result.Item1.Days} days\nLate Days: {result.Item2}\nPenalty: {result.Item3:C}", "OK");
    }
}