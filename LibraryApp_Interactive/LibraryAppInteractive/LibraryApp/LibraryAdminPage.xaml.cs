using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LibraryAppInteractive.BusinessLogic;

namespace LibraryAppInteractive;

public partial class LibraryAdminPage : ContentPage
{
    private Library _library;
    private List<Book> _bookList;
    public LibraryAdminPage()
    {
        InitializeComponent();
        _bookList = new List<Book>();
    }

    private async void OnRegisterBook(object sender, EventArgs e)
    {
        if (sender == _btnRegister)
        {
            try
            {
                string bookName = _entName.Text;
                string bookISBN = _entISBN.Text;
                string bookAuthor = _entAuthor.Text;
                int nCopies = int.Parse(_entCopies.Text);
                BookType bookType = (BookType)_pckType.SelectedItem;

                Book newBook = _library.RegisterBook(bookName, bookISBN, bookAuthor, bookType, nCopies);
                _bookList.Add(newBook);
            }

            catch (FormatException ex)
            {
                await DisplayAlertAsync("Admin Page", ex.Message, "OK");
            }
            catch (ArgumentNullException ex)
            {
                await DisplayAlertAsync("Admin Page", ex.Message, "OK");
            }

            catch (Exception ex)
            {
                await DisplayAlertAsync("Admin Page", ex.Message, "OK");
            }
        }
    }

    private void OnDisplayBookAssets(object sender, EventArgs e)
    {
        if (sender == _btnAsset)
        {

        }
    }
}