using Google.Apis.Customsearch.v1;
using Google.Apis.Services;
using RecipeFinder.ViewModel;
using System.Threading.Tasks;

namespace RecipeFinder.model
{
    public class SearchClass
    {        
        public static string Query { get; set; }

        public static Task SearchForRecipeTaskAsync()
        {
            return Task.Run(() => SearchForRecipe()).ContinueWith((SearchClass) =>
            {
                SearchForRecipeImages();
            });
        }

        //public static Task SearchForRecipeImagesTaskAsync()
        //{
        //    return Task.Run(() => SearchForRecipeImages());
        //}

        //-----Search engine for getting links and titles-----//
        public static void SearchForRecipe()
        {
            MainViewModel mainView = new MainViewModel();
            const string apiKey = "AIzaSyDaIJFcnkDTl2IXy-jxazUmtWFjxMGiwzA";
            const string searchEngineId = "003934496790675996198:prnegsihbvm";

            Query += "Recipe with ";
            foreach (var item in MainViewModel.IngredientslList)
            {
                Query +=$"{item.IngredientsEntered},";
            }           

            var customSearchService = new CustomsearchService(new BaseClientService.Initializer { ApiKey = apiKey });

            var listRequest = customSearchService.Cse.List(Query);
            listRequest.Cx = searchEngineId;       

             RecipePageViewModel.Paging = listRequest.Execute().Items;

            Query = "";
        }

        //-----Search engine for getting images (This is not implemented yet but is working and pulling images)-----//
        public static void SearchForRecipeImages()
        {
            MainViewModel mainView = new MainViewModel();
            
            const string apiKey = "AIzaSyDaIJFcnkDTl2IXy-jxazUmtWFjxMGiwzA";
            const string searchEngineId = "003934496790675996198:prnegsihbvm";

            Query += "Meals with ";
            foreach (var item in MainViewModel.IngredientslList)
            {
                Query += $"{item.IngredientsEntered},";
            }

            var customSearchService = new CustomsearchService(new BaseClientService.Initializer { ApiKey = apiKey });

            var listRequest = customSearchService.Cse.List(Query);
            listRequest.Cx = searchEngineId;

            //-----This line makes the search and image search-----//
            listRequest.SearchType = CseResource.ListRequest.SearchTypeEnum.Image;

            RecipePageViewModel.PagingImages = listRequest.Execute().Items;

            Query = "";
        }
    }
}
