using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
          
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Book>();

                var books = conn.Table<Book>().ToList();
                booksListView.ItemsSource = books;
                
                //booksListView.ItemSelected
                
            }

            
        }

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewXamTestPage());
            
        }

        public void OnMore(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("MORE", "Nothing here yet...", "OK");
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);


            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {

                var item = mi.CommandParameter as object;
                conn.Delete(item);

                var books = conn.Table<Book>().ToList();
                booksListView.ItemsSource = books;

            
                DisplayAlert("DELETED", "Bobe has been deleted!", "OK");

            }



            
        }
    }
}
