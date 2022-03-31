using Konphil.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Konphil.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}