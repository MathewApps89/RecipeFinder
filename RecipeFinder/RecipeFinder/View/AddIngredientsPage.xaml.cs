using System;
using RecipeFinder.ViewModel;
using Xamarin.Forms;
using RecipeFinder.Services;
using Xamarin.Forms.Xaml;

namespace RecipeFinder.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddIngredientsPage : ContentPage
    {
        MainViewModel mainView = new MainViewModel();

        public AddIngredientsPage()
        {
            InitializeComponent();

            //--Binding here due to list being static. Can not bind a static list in xmal--//
            IngredientsListViewList.ItemsSource = MainViewModel.IngredientslList;

            IngredientsEntryBox.Text = "";
        }
        //-----Click event that triggers a command, sends the value the user wants to remove and removes it from the ingredient list-----//
        private void Remove_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;

            var ingredients = button?.BindingContext as Ingredients;

            var vm = BindingContext as MainViewModel;
            //-----Executes the logic from the viewmodel-----//
            vm?.RemoveSpecificIngredient.Execute(ingredients);
        }
        //-----Completed event that triggers a command, sends the value and adds the typed ingredient to the ingredient list-----//
        private void IngredientsEntryBox_Completed(object sender, EventArgs e)
        {
            var itemEntered = sender as Entry;

            var vm = BindingContext as MainViewModel;
            //-----Executes the logic from the viewmodel-----//
            vm?.AddFromEntryBox.Execute(itemEntered.Text);

            itemEntered.Text = "";
        }
    }
}