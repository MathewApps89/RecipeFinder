using RecipeFinder.iOS;
using RecipeFinder.Services;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NavBackButton), typeof(NavBackButtonIos))]
namespace RecipeFinder.iOS
{
    class NavBackButtonIos : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                Control.Layer.BorderColor = Color.Transparent.ToCGColor();
                Control.Layer.BackgroundColor = Color.Transparent.ToCGColor();
            }
        }
    }
}