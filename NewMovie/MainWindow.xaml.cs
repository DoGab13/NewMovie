using Microsoft.VisualBasic;
using System.IO;
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

namespace NewMovie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainPage1 = new MainPage1();
        }
        private MainPage1 mainPage1;
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = mainPage1;
            mainPage1.BTN_NewMovie.Click += BTN_NewMovie_Click;
            mainPage1.BTN_DeleteMovie.Click += BTN_DeleteMovie_Click;
            mainPage1.BTN_NEditMovie.Click += BTN_NEditMovie_Click;
        }

        private void BTN_NEditMovie_Click(object sender, RoutedEventArgs e)
        {
            if(mainPage1.LB_Movie.SelectedItem != null)
            {
                var movie = (Movie)mainPage1.LB_Movie.SelectedItem;
                var page = new MovieEditorPage();
                page.TB_Star.Text = movie.Star;
                page.TB_Director.Text = movie.Director;
                page.TB_Type.Text = movie.Type;
                page.DP_Year.Text text = movie.Year;
                page.BTN_Cancel.Click += MovieEditorPage_BTN_Cancel_Click;
                page.BTN_Save.Click += MovieEditorPage_BTN_Save_Existing_Click;
                MainFrame.Content = page;
            }
           
        }

        private void MovieEditorPage_BTN_Save_Existing_Click(object sender, RoutedEventArgs e)
        {
            var page = (MovieEditorPage)MainFrame.Content;
            var movie = (Movie)mainPage1.LB_Movie.SelectedItem;
            movie.Star = page.TB_Star.Text;
            movie.Director = page.TB_Director.Text;
            movie.Type = page.TB_Type.Text;
            movie.Year = page.DP_Year.SelectedDate;
            mainPage1.LB_Movie.Items.Refresh();
           
            mainPage1.LB_Movie.Items.Add(movie);
            MainFrame.Content = mainPage1;
        }

        private void BTN_DeleteMovie_Click(object sender, RoutedEventArgs e)
        {
            if (mainPage1.LB_Movie.SelectedItem != null)
            {
               var result = MessageBox.Show("Biztos, hogy törölni akarja a kiválasztott filmet?", "Törlés...", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                   mainPage1.LB_Movie.Items.Remove(mainPage1.LB_Movie.SelectedItem);
                }
            }
            
        }
        private void BTN_NewMovie_Click(object sender, RoutedEventArgs e)
        {
            var page = new MovieEditorPage();
            MainFrame.Content = page;
            page.BTN_Cancel.Click += MovieEditorPage_BTN_Cancel_Click;
            page.BTN_Save.Click += MovieEditorPage_BTN_Save_Click;
        }

        private void MovieEditorPage_BTN_Save_Click(object sender, RoutedEventArgs e)
        {
            var page = (MovieEditorPage)MainFrame.Content;
            var movie = new Movie()
            {
               Star = page.TB_Star.Text,
               Director = page.TB_Director.Text,
               Type = page.TB_Type.Text,
               Year = page.DP_Year.SelectedDate,
            };
            mainPage1.LB_Movie.Items.Add(movie);
            MainFrame.Content = mainPage1; 
        }

        private void MovieEditorPage_BTN_Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = mainPage1;
        }

        private void BTN_Cancel_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}