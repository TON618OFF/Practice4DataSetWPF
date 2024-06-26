﻿using Practice4DataSetWPF.DataSet1TableAdapters;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practice4DataSetWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BooksTableAdapter books = new BooksTableAdapter();
        AuthorsTableAdapter authors = new AuthorsTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
            cb_BD_books.ItemsSource = authors.GetData();
            cb_BD_books.DisplayMemberPath = "AuthorName";
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            dg_BD_books.ItemsSource = books.SearchByName(SearchText.Text);
        }

        private void btn_reset_Click(object sender, RoutedEventArgs e)
        {
            dg_BD_books.ItemsSource = books.GetData();
        }

        private void cb_BD_books_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_BD_books.SelectedItem != null)
            {
                var id = (int)(cb_BD_books.SelectedItem as DataRowView).Row[0];
                dg_BD_books.ItemsSource = books.FilterByAuthorID(id);
            }
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page1();
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
