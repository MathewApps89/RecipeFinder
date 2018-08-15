using RecipeFinder.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RecipeFinder.model;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms.Internals;

namespace RecipeFinder.View
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipePage : ContentPage
    {
        //-----When android hardware back button is pressed this clears the lists that need clearing-----//
        protected override bool OnBackButtonPressed()
        {
            RecipePageViewModel.LinksForOpeningOnTapped.Clear();
            RecipePageViewModel.DisplaySearchesResults.Clear();
            RecipePageViewModel.Paging.Clear();
            RecipePageViewModel.PagingImages.Clear();
            return base.OnBackButtonPressed();
        }

        public RecipePage()
        {          
            InitializeComponent();
            //-----Binding here due to list being static. Cant bind in xaml when list is static-----//
            RecipeListViewList.ItemsSource = RecipePageViewModel.DisplaySearchesResults;
        }
    }
}