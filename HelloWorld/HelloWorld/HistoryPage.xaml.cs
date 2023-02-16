using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWorld.Model;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HistoryPage : ContentPage
	{
		public HistoryPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

			using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
			{
                conn.CreateTable<Post>();
                var posts = conn.Table<Post>().ToList();
				postListView.ItemsSource = posts;
            }	 			
        }
		void postListView_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
		{
			var selectedPost = postListView.SelectedItem as Post;

			if (selectedPost != null)
			{
				Navigation.PushAsync(new PostDetailPage(selectedPost));
			}
		}
    }
}