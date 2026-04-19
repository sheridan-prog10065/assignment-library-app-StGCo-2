using LibraryAppInteractive.BusinessLogic;

namespace LibraryAppInteractive;

public partial class AppShell : Shell
{
    private Library _library;

    public AppShell()
    {
        InitializeComponent();

        _library = new Library();

        BrowseShellContent.Content = new LibraryBrowsePage(_library);
        AdminShellContent.Content = new LibraryAdminPage(_library);
    }
}