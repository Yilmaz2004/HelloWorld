using HelloWorld.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostDetailPage : ContentPage
    {
        Post selectedPost;
        public PostDetailPage(Post selectedPost)
        {
            InitializeComponent();
            this.selectedPost = selectedPost;

            experienceEntry.Text = selectedPost.Experience;

        }

        private void UpdateButton_Clicked(object sender, EventArgs e)
        {
            selectedPost.Experience= experienceEntry.Text;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Update(selectedPost);

                if (rows > 0)
                    DisplayAlert("Success", "Experience succesfully Updated", "OK");
                else
                    DisplayAlert("Failure", "Experience failed to be Updated", "OK");
            }
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Delete(selectedPost); 

                if (rows > 0)
                    DisplayAlert("Success", "Experience succesfully Deleted", "OK");
                else
                    DisplayAlert("Failure", "Experience failed to be Deleted", "OK");
            }
        }
    }
}