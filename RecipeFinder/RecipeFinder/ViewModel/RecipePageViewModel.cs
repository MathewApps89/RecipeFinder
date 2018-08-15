using Google.Apis.Customsearch.v1.Data;
using RecipeFinder.Services;
using RecipeFinder.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace RecipeFinder.ViewModel
{
    class RecipePageViewModel : INotifyPropertyChanged
    {
        public RecipePageViewModel()
        {

        }
        //-----List that stores search results-----//
        private static IList<Result> _paging = new List<Result>();
        public static IList<Result> Paging
        {
            get { return _paging; }

            set
            {
                _paging = value;
            }
        }

        private static ObservableCollection<DisplaySearchResultsClass> _displaySearchResults = new ObservableCollection<DisplaySearchResultsClass>();
        public static ObservableCollection<DisplaySearchResultsClass> DisplaySearchesResults
        {
            get { return _displaySearchResults; }

            set
            {
                _displaySearchResults = value;
            }
        }

        private static ObservableCollection<string> _linksForOpeningOnTapped = new ObservableCollection<string>();
        public static ObservableCollection<string> LinksForOpeningOnTapped
        {
            get { return _linksForOpeningOnTapped; }

            set
            {
                _linksForOpeningOnTapped = value;
            }
        }

        private static IList<Result> _pagingImages = new List<Result>();
        public static IList<Result> PagingImages
        {
            get { return _pagingImages; }

            set
            {
                _pagingImages = value;
            }
        }

        public static void AddItemsFromPagingListToDisplaySearchList()
        {
            int imageCounter = 0;

            foreach (var item in Paging)
            {
                DisplaySearchesResults.Add(new DisplaySearchResultsClass() { Title = item.Title, Link = item.Link, Image = PagingImages[imageCounter].Link });

                imageCounter++;
            }          
        }

        private int _selectedItem;
        public int SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;

                OnPropertyChanged();
            }
        }

        private object _selectedIndexFromListview;
        public object SelectedIndexFromListview
        {
            get
            {
                return _selectedIndexFromListview;
            }
            set
            {
                _selectedIndexFromListview = value;

                OnPropertyChanged();
            }
        }

        public ICommand ItemClickCommand
        {
            get
            {
                return new Command((itemIndex) =>
                {
                    SelectedIndexFromListview = itemIndex;

                    int.TryParse(SelectedIndexFromListview.ToString(), out int selectedIndex);
                    
                    SelectedItem = selectedIndex;

                    Device.OpenUri(new Uri(LinksForOpeningOnTapped[SelectedItem]));
                                                          
                });
            }
        }

        public Command NavBackButtonClicked
        {
            get
            {
                return new Command(async () =>
                {
                    await Application.Current.MainPage.Navigation.PushAsync( new AddIngredientsPage());

                    LinksForOpeningOnTapped.Clear();
                    DisplaySearchesResults.Clear();
                    Paging.Clear();
                    PagingImages.Clear();
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
