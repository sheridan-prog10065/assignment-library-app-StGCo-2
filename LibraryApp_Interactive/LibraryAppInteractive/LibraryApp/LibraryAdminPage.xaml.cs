using LibraryAppInteractive.BusinessLogic;
using System.Linq;

namespace LibraryAppInteractive;

public partial class LibraryAdminPage : ContentPage
{
    private Library _library;
    private Book _book;
    private List<Book> _bookList;
    private List<LibraryAsset> _assets;

    public LibraryAdminPage(Library library)
    {
        InitializeComponent();
        _library = library;
        _bookList = _library.Books.ToList();
        _assets = new List<LibraryAsset>();
        _lstBooks.ItemsSource = _bookList;
        _lstAssets.ItemsSource = _assets;
    }

    private async void OnRegisterBook(object sender, EventArgs e)
    {
        try
        {
            string bookName = _entName.Text;
            string bookISBN = _entISBN.Text;
            string bookAuthor = _entAuthor.Text;

            if (!int.TryParse(_entCopies.Text, out int nCopies))
            {
                await DisplayAlertAsync("Admin Page", "Enter a valid number of copies.", "OK");
                return;
            }

            if (_pckType.SelectedItem == null)
            {
                await DisplayAlertAsync("Admin Page", "Select a book type.", "OK");
                return;
            }

            BookType bookType = (BookType)Enum.Parse(typeof(BookType), _pckType.SelectedItem.ToString());

            Book newBook = _library.RegisterBook(bookName, bookISBN, bookAuthor, bookType, nCopies);
            _bookList.Add(newBook);

            _lstBooks.ItemsSource = null;
            _lstBooks.ItemsSource = _bookList;

            await DisplayAlertAsync("Admin Page", "Book registered successfully.", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Admin Page", ex.Message, "OK");
        }
    }

    private async void OnSearch(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(_entSearchName.Text))
            {
                _bookList = _library.FindBooksByName(_entSearchName.Text);
                _lstBooks.ItemsSource = null;
                _lstBooks.ItemsSource = _bookList;

                if (_bookList.Count == 0)
                {
                    await DisplayAlertAsync("Admin Page", "Book not found.", "OK");
                }

                return;
            }
            else if (!string.IsNullOrWhiteSpace(_entSearchISBN.Text))
            {
                _book = _library.FindBookByISBN(_entSearchISBN.Text);

                _bookList.Clear();

                if (_book != null)
                {
                    _bookList.Add(_book);
                    _lstBooks.ItemsSource = null;
                    _lstBooks.ItemsSource = _bookList;
                }
                else
                {
                    await DisplayAlertAsync("Admin Page", "Book not found.", "OK");
                    return;
                }
            }
            else
            {
                await DisplayAlertAsync("Admin Page", "Enter a book name or ISBN.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Admin Page", ex.Message, "OK");
        }
    }

    private void OnSelectedBook(object sender, SelectionChangedEventArgs e)
    {
        _book = e.CurrentSelection.FirstOrDefault() as Book;

        if (_book != null)
        {
            _assets.Clear();
            _assets.AddRange(_book.Assets);
            _lstAssets.ItemsSource = null;
            _lstAssets.ItemsSource = _assets;
        }
    }
}