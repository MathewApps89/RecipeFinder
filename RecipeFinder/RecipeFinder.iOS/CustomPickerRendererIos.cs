using RecipeFinder.iOS;
using RecipeFinder.Services;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRendererIos))]
namespace RecipeFinder.iOS
{
    class CustomPickerRendererIos : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.TextAlignment = UITextAlignment.Center;
                Control.Layer.CornerRadius = 30f;
                Control.Layer.BorderWidth = 1f;
            }
        }
    }
}