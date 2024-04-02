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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {

        GenresTableAdapter genres = new GenresTableAdapter();
        public Page2()
        {
            InitializeComponent();
            cb_BD_books.ItemsSource = genres.GetData();
            cb_BD_books.DisplayMemberPath = "Genre";
        }

        private void cb_BD_books_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_BD_books.SelectedItem != null)
            {
                var id = (int)(cb_BD_books.SelectedItem as DataRowView).Row[0];
                dg_BD_books.ItemsSource = genres.FilterByGenre(id);
            }
        }

        private void btn_reset_Click(object sender, RoutedEventArgs e)
        {
            dg_BD_books.ItemsSource = genres.GetData();
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            dg_BD_books.ItemsSource = genres.SearchByGenre(SearchText.Text);
        }
    }
}
