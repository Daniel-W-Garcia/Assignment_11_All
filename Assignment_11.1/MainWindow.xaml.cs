using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Assignment_11._1.Data;

namespace Assignment_11._1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private BooksContext context;
    private Books newBook = new Books();
    
    public MainWindow(BooksContext booksContext)
    {
        InitializeComponent();
        context = booksContext;
        GetBooks();
        AddBookGrid.DataContext = newBook;
        UpdateBookGrid.DataContext = null;
    }

    private void GetBooks()
    {
        BooksDG.ItemsSource = context.Books.ToList();
    }

    private void UpdateBookForEdit_OnClick(object sender, RoutedEventArgs e)
    {
        var row = (sender as FrameworkElement)?.DataContext as Books;
        if (row != null)
        {
            UpdateBookGrid.DataContext = context.Books.Find(row.ISBN);
        }
    }

    private void DeleteBook_OnClick(object sender, RoutedEventArgs e)
    {
        if (sender is FrameworkElement frameworkElement && frameworkElement.DataContext is Books toDelete)
        {
            var answer = MessageBox.Show(
                $"Are you sure you want to delete '{toDelete.Title}'?",
                "Confirm Delete",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (answer == MessageBoxResult.Yes)
            {
                context.Books.Remove(toDelete);
                context.SaveChanges();
                GetBooks();
            }
        }
    }

    private void AddBook_OnClick(object sender, RoutedEventArgs e)
    {
        context.Add(newBook);
        context.SaveChanges();
        GetBooks();
        MessageBox.Show("Product Added Successfully");
        newBook = new Books();
        AddBookGrid.DataContext = newBook;
    }

    private void UpdateBook_OnClick(object sender, RoutedEventArgs e)
    {
        if (UpdateBookGrid.DataContext is Books toUpdate)
        {
            context.SaveChanges();
            GetBooks();
            MessageBox.Show("Product updated");
            UpdateBookGrid.DataContext = null;
        }
    }
}