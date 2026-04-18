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
    private Book _book;
    public LibraryAdminPage()
    {
        InitializeComponent();
    }

    private void OnRegisterBook(object sender, EventArgs e)
    {
        if (sender == _btnRegister)
        {
            string bookName = _entName.Text;
            string bookISBN = _entISBN.Text;
            string bookAuthor = _entAuthor.Text;
            int nCopies = int.Parse(_entCopies.Text);
            BookType bookType = (BookType)_pckType.SelectedItem;

            Book newBook = _library.CreateBook(bookType, bookName, bookISBN);
            newBook.Authors.Add(bookAuthor);
            newBook.Copies = nCopies;

            _library.RegisterBook(newBook);
        }
    }

    private void OnDisplayBookAssets(object sender, EventArgs e)
    {

    }
}