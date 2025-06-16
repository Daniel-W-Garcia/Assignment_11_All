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
using WPF_Demo.Data;

namespace WPF_Demo;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private ProductContext context;
    Product newProduct = new();
    
    public MainWindow(ProductContext productContext) // dependancy injection
    {
        InitializeComponent();
        context = productContext; //service provider will give instance of ProductContext
        GetProducts();
        AddProductGrid.DataContext = newProduct;
    }

    private void GetProducts()
    {
        ProductDG.ItemsSource = context.Products.ToList();
    }

    private void UpdateProductForEdit_OnClick(object sender, RoutedEventArgs e)
    {
        var row = (sender as FrameworkElement)?.DataContext as Product;
        if (row != null)
            UpdateProductGrid.DataContext = context.Products.Find(row.Id);
    }

    private void DeleteProduct_OnClick(object sender, RoutedEventArgs e)
    {
        if (sender is FrameworkElement frameworkElement && frameworkElement.DataContext is Product productToDelete)
        {
            var answer = MessageBox.Show(
                $"Are you sure you want to delete '{productToDelete.Name}'?",
                "Confirm Delete",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (answer == MessageBoxResult.Yes)
            {
                context.Products.Remove(productToDelete);
                context.SaveChanges();
                GetProducts();
            }
        }
    }

    private void AddProduct_OnClick(object sender, RoutedEventArgs e)
    {
        context.Add(newProduct);
        context.SaveChanges();
        GetProducts();
        MessageBox.Show("Product Added Successfully");
        newProduct = new Product();
        AddProductGrid.DataContext = newProduct;
    }

    private void UpdateProduct_OnClick(object sender, RoutedEventArgs e)
    {
        if (UpdateProductGrid.DataContext is Product toUpdate)
        {
            context.SaveChanges();
            GetProducts();
            MessageBox.Show("Product updated");
            UpdateProductGrid.DataContext = null;
        }
    }
}