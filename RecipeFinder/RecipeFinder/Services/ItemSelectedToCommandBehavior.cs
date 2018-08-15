using RecipeFinder.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace RecipeFinder.Services
{
    class ItemSelectedToCommandBehavior : Behavior<ListView>
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(
                propertyName: "Command",
                returnType: typeof(ICommand),
                declaringType: typeof(ItemSelectedToCommandBehavior)
                );

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.ItemSelected += BindableOnItemSelected;
            bindable.BindingContextChanged += BindableOnBindingContextChanged;
        }

        private void BindableOnBindingContextChanged(object sender, EventArgs e)
        {
            var lv = sender as ListView;
            BindingContext = lv?.BindingContext;
        }

        private void BindableOnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var index =
            RecipePageViewModel.DisplaySearchesResults.IndexOf(e.SelectedItem);

            Command.Execute(index);
            
            //((ListView)sender).SelectedItem = null;
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.ItemSelected -= BindableOnItemSelected;
            bindable.BindingContextChanged -= BindableOnBindingContextChanged;
        }
    }
}
