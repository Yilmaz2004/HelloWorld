using HelloWorld.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWorld.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace HelloWorld
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewTravelPage : ContentPage
	{
		public NewTravelPage ()
		{
			InitializeComponent ();
		}

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
			Post post = new Post()
			{
				Experience = experienceEntery.Text

			};

			using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
			{
                conn.CreateTable<Post>();
                int rows = conn.Insert(post);

                if (rows > 0)
                    DisplayAlert("Success", "Experience succesfully inserted", "OK");
                else
                    DisplayAlert("Failure", "Experience failed to be inserted", "OK");
            }


            
        }
    }
}