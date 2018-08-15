using System.Collections.Generic;
using System.Collections.ObjectModel;
using RecipeFinder.Services;
using Xamarin.Forms;
using Google.Apis.Customsearch.v1.Data;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms.Internals;
using RecipeFinder.model;
using RecipeFinder.View;
using System.Threading.Tasks;

namespace RecipeFinder.ViewModel
{

    public class MainViewModel : INotifyPropertyChanged
    {
        //-----Bound to spinner to active and de-active-----//
        private bool _isDoneLoading;
        public bool IsDoneLoading
        {
            get { return _isDoneLoading; }

            set
            {
                _isDoneLoading = value;
                OnPropertyChanged();
            }
        }

        //-----List for pickers-----//
        private List<string> _meats = new List<string>
        {
            "Meats","American Bison","Antelope","Beef","Boar","Bushpig","Capybara","Caraba","Caribou","Deer","Goat","Hog","Lamb","Moose","Opossum","Peccary","Pika","Pork","Rabbit","Sheep","Veal","Yak"
        };
        public List<string> Meats
        {
            get { return _meats; }

            set
            {
                _meats = value;
            }
        }
        private List<string> _riceAndGrains = new List<string>
        {
            "Rice & Grains","Amaranth","Barley","Bread","Brown rice","Buckwheat","Bulgur","Corn","Cornmeal","Crackers","Millet","Oatmeal","Pasta","Popcorn","Quinoa","White rice","Rolled oats","rye","Sorghum","tortillas","Triticale"
        };
        public List<string> RiceAndGrains
        {
            get { return _riceAndGrains; }

            set
            {
                _riceAndGrains = value;
            }
        }
        private List<string> _beansAndLegumes = new List<string>
        {
              "Beans & Legumes","Aduke Beans","Alfalfa","Anasazi Beans","Azuki Beans","Bean Sprouts","Beans, Snap","Black Beans","Black-Eyed Peas","Broad Beans","Calypso","Cannellini Beans","Copper Beans","Edamame","Fava Beans","Garbanzo Beans","Green Beans","Jicama","Kidney Beans","Lentils","Lentils, Green,","Lentils, Yellow","Lima Beans","Mung Beans","Navy Beans","Northern Beans","Pea Pods","Peanuts","Peas, Green","Pinto Beans","Red Beans","Soy Beans","Soy Beans, Black","Soy Beans, Red","Speckled Cranberry Beans","Tamarind Beans","Wax Beans","White Beans"
        };
        public List<string> BeansAndLegumes
        {
            get { return _beansAndLegumes; }

            set
            {
                _beansAndLegumes = value;
            }
        }
        private List<string> _seafood = new List<string>
        {
            "Seafood","Anchovy","Basa","Bass","Carp","Catfish","Cod","Flounder","Grouper","Haddock","Halibut","Herring","Kingfish","Mackerel","Mahi Mahi","Marlin","Orange Roughy","Perch","Pike","Pollock","Salmon","Sardine","Snapper","Sole","Swordfish","Tilapia","Trout","Tuna","Walleye","**Shellfish**","Abalone","Clam","Conch","Crab","Crayfish","Cuttlefish","Lobster","Loc","Mussel","Octopus","Oyster","Prawn","Scallop","Shrimp","Snail"
        };
        public List<string> Seafood
        {
            get { return _seafood; }

            set { _seafood = value; }
        }
        private List<string> _poultry = new List<string>
        {
            "Poultry","Chicken","Cornish Hen","Dove","Duck","Emu","Goose","Grouse","Guinea fowl","Ostrich","Partridge","Pheasant","Pigeon","Quail","Turkey","**Eggs**","Chicken Eggs","Duck Eggs","Goose Eggs","Hen Eggs","Quail Eggs",
        };
        public List<string> Poultry
        {
            get { return _poultry; }

            set
            {
                _poultry = value;
            }
        }
        private List<string> _produce = new List<string>
        {
            "Produce","Artichokes","Asparagus","Avocados","Bell peppers","Broccoli","Brussels sprouts","Cabbage","Carrots","Cauliflower","Celery","Chard","Cilantro","Collard greens","Cucumbers","Eggplant","Escarole","Garlic","Gingerroot","Green beans","kale","Lettuce","Mushrooms","Mustard greens","Okra","Onions","Parsley","Peppers","Potatoes","Pumpkin","Radishes","Scallions","Spinach","Squash","Sweet-potatoes","Thyme","Tomatoes","Turnip greens","**Fruits**","Apple","Apricot","Apricot lassi","Banana","Blueberry","Cherry","Durian","Feijoa","Fig","Grape","Grapefruit","Guava","Honeydew","Kiwifruit","Lemon","Lime","Longan","Lychee","Mandarin","Mango","Mangosteen","Melon platter","Nashi","Nectarine","Orange","Passionfruit","Pawpaw","Peach","Pear","Persimmon","Pineapple","Plum","Poached pears","Pomegranate","Pomelo","Rambutan","Raspberry","Rhubarb","Rockmelon","Star fruit","Strawberry","Tamarillo","Tangelo","Watermelon"
        };
        public List<string> Produce
        {
            get { return _produce; }

            set
            {
                _produce = value;
            }
        }

        //-----List that stores ingredients entered-----//
        private static ObservableCollection<Ingredients> _ingredients = new ObservableCollection<Ingredients>();
        public static ObservableCollection<Ingredients> IngredientslList
        {
            get { return _ingredients; }

            set
            {
                _ingredients = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainViewModel()
        {
            ToggleSearchButtonEnabled = true;
            ToggleSearchButtonVisable = false;
            ToggleClearAllButton = true;
            ToggleHelperLabelMethod();
            ToggleCurrentIngredientLabelMethod();
            ToggleSeachButtonMethod();
            ToggleLogoMethod();
        }

        public void PullFromSearchAddToOpenLinkList()
        {
            foreach (var item in RecipePageViewModel.DisplaySearchesResults)
            {
                RecipePageViewModel.LinksForOpeningOnTapped.Add(item.Link);
            }
        }
        #region TogglePropertiesAndMethods
        //-----Turns current ingredient label on and off-----//
        public void ToggleCurrentIngredientLabelMethod()
        {
            if (IngredientslList.Count == 0)
            {
                ToggleCurrentIngredientLabel = false;
            }
            else
            {
                ToggleCurrentIngredientLabel = true;
            }
        }

        private bool _toggleCurrentIngredientLabel;
        public bool ToggleCurrentIngredientLabel
        {
            get { return _toggleCurrentIngredientLabel; }

            set
            {
                _toggleCurrentIngredientLabel = value;
                OnPropertyChanged();
            }
        }
        //-----turns logo on and off-----//
        public void ToggleLogoMethod()
        {
            if (IngredientslList.Count == 0)
            {
                ToggleLogo = true;
            }
            else
            {
                ToggleLogo = false;
            }
        }

        private bool _toggleLogo;
        public bool ToggleLogo
        {
            get { return _toggleLogo; }

            set
            {
                _toggleLogo = value;
                OnPropertyChanged();
            }
        }
        //-----Turns clear all button on and off-----//
        private bool _toggleClearAllButton;
        public bool ToggleClearAllButton
        {
            get { return _toggleClearAllButton; }

            set
            {
                _toggleClearAllButton = value;
                OnPropertyChanged();
            }
        }
        //-----Turns helper label on and off-----//
        public void ToggleHelperLabelMethod()
        {
            if (IngredientslList.Count == 0)
            {
                ToggleHelperLabel = true;
            }
            else
            {
                ToggleHelperLabel = false;
            }
        }

        private bool _toggleHelperLabel;
        public bool ToggleHelperLabel
        {
            get { return _toggleHelperLabel; }

            set
            {
                _toggleHelperLabel = value;
                OnPropertyChanged();
            }
        }
        //-----Turns search button on and off-----//
        public void ToggleSeachButtonMethod()
        {
            if (IngredientslList.Count == 0)
            {
                ToggleSearchButtonVisable = false;
            }
            else
            {
                ToggleSearchButtonVisable = true;
            }
        }

        private bool _toggleSearchButtonVisable;
        public bool ToggleSearchButtonVisable
        {
            get { return _toggleSearchButtonVisable; }

            set
            {
                _toggleSearchButtonVisable = value;
                OnPropertyChanged();
            }
        }

        private bool _toggleSearchButtonEnabled;
        public bool ToggleSearchButtonEnabled
        {
            get { return _toggleSearchButtonEnabled; }

            set
            {
                _toggleSearchButtonEnabled = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region SelectionPickers
        //-----Adds ingredient from picker to the ingredient list-----//
        private int _meatsSelectedIndex;
        public int MeatSelectedIndex
        {
            get
            {
                return _meatsSelectedIndex;
            }
            set
            {
                if (_meatsSelectedIndex != value)
                {
                    _meatsSelectedIndex = value;

                    OnPropertyChanged(nameof(MeatSelectedIndex));

                    string SelectedMeat = Meats[_meatsSelectedIndex];

                    if (_meatsSelectedIndex != 0)
                    {
                        IngredientslList.Add(new Ingredients(SelectedMeat));
                    }
                    _meatsSelectedIndex = 0;

                    ToggleHelperLabelMethod();
                    ToggleCurrentIngredientLabelMethod();
                    ToggleSeachButtonMethod();
                    ToggleLogoMethod();
                }
            }
        }
        //-----Adds ingredient from picker to the ingredient list-----//
        private int _seafoodSelectedIndex;
        public int SeafoodSelectedIndex
        {
            get
            {
                return _seafoodSelectedIndex;
            }
            set
            {
                if (_seafoodSelectedIndex != value)
                {
                    _seafoodSelectedIndex = value;

                    OnPropertyChanged(nameof(SeafoodSelectedIndex));

                    string SelectedSeafood = Seafood[_seafoodSelectedIndex];

                    if (_seafoodSelectedIndex != 0 && SelectedSeafood != "**Shellfish**")
                    {
                        IngredientslList.Add(new Ingredients(SelectedSeafood));
                    }
                    _seafoodSelectedIndex = 0;

                    ToggleHelperLabelMethod();
                    ToggleCurrentIngredientLabelMethod();
                    ToggleSeachButtonMethod();
                    ToggleLogoMethod();
                }
            }
        }
        //-----Adds ingredient from picker to the ingredient list-----//
        private int _poultrySelectedIndex;
        public int PoultrySelectedIndex
        {
            get
            {
                return _poultrySelectedIndex;
            }
            set
            {
                if (_poultrySelectedIndex != value)
                {
                    _poultrySelectedIndex = value;

                    OnPropertyChanged(nameof(PoultrySelectedIndex));

                    string SelectedPoultry = Poultry[_poultrySelectedIndex];

                    if (_poultrySelectedIndex != 0 && SelectedPoultry != "**Eggs**")
                    {
                        IngredientslList.Add(new Ingredients(SelectedPoultry));
                    }
                    _poultrySelectedIndex = 0;

                    ToggleHelperLabelMethod();
                    ToggleCurrentIngredientLabelMethod();
                    ToggleSeachButtonMethod();
                    ToggleLogoMethod();
                }
            }
        }
        //-----Adds ingredient from picker to the ingredient list-----//
        private int _produceSelectedIndex;
        public int ProduceSelectedIndex
        {
            get
            {
                return _produceSelectedIndex;
            }
            set
            {
                if (_produceSelectedIndex != value)
                {
                    _produceSelectedIndex = value;

                    OnPropertyChanged(nameof(ProduceSelectedIndex));

                    string SelectedProduce = Produce[_produceSelectedIndex];

                    if (_produceSelectedIndex != 0)
                    {
                        IngredientslList.Add(new Ingredients(SelectedProduce));
                    }
                    _produceSelectedIndex = 0;

                    ToggleHelperLabelMethod();
                    ToggleCurrentIngredientLabelMethod();
                    ToggleSeachButtonMethod();
                    ToggleLogoMethod();
                }
            }
        }
        //-----Adds ingredient from picker to the ingredient list-----//
        private int _riceAndGrainsSelectedIndex;
        public int RiceAndGrainsSelectedIndex
        {
            get
            {
                return _riceAndGrainsSelectedIndex;
            }
            set
            {
                if (_riceAndGrainsSelectedIndex != value)
                {
                    _riceAndGrainsSelectedIndex = value;

                    OnPropertyChanged(nameof(RiceAndGrainsSelectedIndex));

                    string SelectedRiceAndGrains = RiceAndGrains[_riceAndGrainsSelectedIndex];

                    if (_riceAndGrainsSelectedIndex != 0)
                    {
                        IngredientslList.Add(new Ingredients(SelectedRiceAndGrains));
                    }
                    _riceAndGrainsSelectedIndex = 0;

                    ToggleHelperLabelMethod();
                    ToggleCurrentIngredientLabelMethod();
                    ToggleSeachButtonMethod();
                    ToggleLogoMethod();
                }
            }
        }
        //-----Adds ingredient from picker to the ingredient list-----//
        private int _beansAndLegumesSelectedIndex;
        public int BeansAndLegumesSelectedIndex
        {
            get
            {
                return _beansAndLegumesSelectedIndex;
            }
            set
            {
                if (_beansAndLegumesSelectedIndex != value)
                {
                    _beansAndLegumesSelectedIndex = value;

                    OnPropertyChanged(nameof(BeansAndLegumesSelectedIndex));

                    string SelectedBeansAndLegumes = BeansAndLegumes[_beansAndLegumesSelectedIndex];

                    if (_beansAndLegumesSelectedIndex != 0)
                    {
                        IngredientslList.Add(new Ingredients(SelectedBeansAndLegumes));
                    }
                    _beansAndLegumesSelectedIndex = 0;

                    ToggleHelperLabelMethod();
                    ToggleCurrentIngredientLabelMethod();
                    ToggleSeachButtonMethod();
                    ToggleLogoMethod();
                }
            }
        }
        #endregion

        //-----Clears all ingredients-----//
        public Command ClearAllIngredients
        {
            get
            {
                return new Command(() =>
                {
                    IngredientslList.Clear();
                    RecipePageViewModel.Paging.Clear();
                    RecipePageViewModel.PagingImages.Clear();
                    RecipePageViewModel.DisplaySearchesResults.Clear();
                    RecipePageViewModel.LinksForOpeningOnTapped.Clear();

                    ToggleHelperLabelMethod();
                    ToggleCurrentIngredientLabelMethod();
                    ToggleSeachButtonMethod();
                    ToggleLogoMethod();
                });
            }
        }
        //-----Enables users to type in ingredient-----//
        public Command AddFromEntryBox
        {
            get
            {
                return new Command((itemEntered) =>
                {
                    if (itemEntered.ToString() != "")
                    {
                        MainViewModel.IngredientslList.Add(new Ingredients(itemEntered.ToString()));

                        ToggleHelperLabelMethod();
                        ToggleCurrentIngredientLabelMethod();
                        ToggleSeachButtonMethod();
                        ToggleLogoMethod();
                    }
                    if (itemEntered.ToString() == "")
                    {
                        return;
                    }
                });
            }
        }
        //-----Enables users to remove specific items from the ingredient list-----//
        public Command RemoveSpecificIngredient
        {
            get
            {
                return new Command((itemToRemove) =>
                {
                    var removeAtIndex = IngredientslList.IndexOf(itemToRemove);

                    IngredientslList.RemoveAt(removeAtIndex);

                    ToggleHelperLabelMethod();
                    ToggleCurrentIngredientLabelMethod();
                    ToggleSeachButtonMethod();
                    ToggleLogoMethod();
                });
            }
        }

        public Command SearchForRecipeButtonClicked
        {
            get
            {
                return new Command(async() =>
                {
                    //-----Disable search button while searching-----//
                    ToggleSearchButtonEnabled = false;
                    //-----Turns off the clear ingredients button while search is running-----//
                    ToggleClearAllButton = false;
                    //-----Turns on loading spinner while search is running-----//
                    IsDoneLoading = true;                    

                    await SearchClass.SearchForRecipeTaskAsync();

                    RecipePageViewModel.DisplaySearchesResults.Clear();

                    RecipePageViewModel.AddItemsFromPagingListToDisplaySearchList();

                    PullFromSearchAddToOpenLinkList();

                    await Application.Current.MainPage.Navigation.PushAsync(new RecipePage());

                    //-----Turns off loading spinner after search-----//
                    IsDoneLoading = false;
                    //-----Turns on the clear ingredients button after search-----//
                    ToggleClearAllButton = true;
                    //-----Enable search button while after search-----//
                    ToggleSearchButtonEnabled = true;
                });
            }
        }
    }
}
