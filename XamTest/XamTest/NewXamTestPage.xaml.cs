using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamTest
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewXamTestPage : ContentPage
	{
		public NewXamTestPage ()
		{
            InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            Book book = new Book()
            {
                Name = nameEntry.Text,
                Author = authorEntry.Text
            };

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Book>();
                var numberOfROws = conn.Insert(book);
                Navigation.PopAsync(animated:true);
                
                if (numberOfROws > 0)
                    DisplayAlert("Success", "Bobe was successfully inserted", "Fortuitous!");
                
                else
                    DisplayAlert("Failure", "Bobe failed insertion", "Unfortuitous...");
            }
            

            //DisplayAlert("Success", "You've managed to click the button!", "Fortuitous!");
        }
    }
}