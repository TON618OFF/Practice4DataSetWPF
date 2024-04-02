using Practice4DataSetWPF.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practice4DataSetWPF
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        AuthorsTableAdapter authors = new AuthorsTableAdapter();
        public Page1()
        {
            InitializeComponent();
            cb_BD_books.ItemsSource = authors.GetData();
            cb_BD_books.DisplayMemberPath = "AuthorSurname";
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            dg_BD_books.ItemsSource = authors.SearchByName(SearchText.Text);
        }

        private void cb_BD_books_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_BD_books.SelectedItem != null)
            {
                var id = (int)(cb_BD_books.SelectedItem as DataRowView).Row[0];
                dg_BD_books.ItemsSource = authors.FilterByIDAuthor(id);
            }
        }

        private void btn_reset_Click(object sender, RoutedEventArgs e)
        {
            dg_BD_books.ItemsSource = authors.GetData();
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page2();
            dg_BD_books.Visibility = Visibility.Collapsed;
            readertxt.Visibility = Visibility.Collapsed;
            cb_BD_books.Visibility = Visibility.Collapsed;
            SearchText.Visibility = Visibility.Collapsed;
            btn_reset.Visibility = Visibility.Collapsed;
            btn_search.Visibility = Visibility.Collapsed;
            NextPage.Visibility = Visibility.Collapsed;
            
        }
    }
}
