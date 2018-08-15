using Android.Content;
using Android.Views;
using RecipeFinder.Services;
using RecipeFinder.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRendererAndroid))]
namespace RecipeFinder.Droid
{
    class CustomPickerRendererAndroid : Xamarin.Forms.Platform.Android.AppCompat.PickerRenderer
    {
        public CustomPickerRendererAndroid(Context context) : base(context)
        {
           
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var gradientDrawable = new GradientDrawable();
                Control.Gravity = GravityFlags.CenterHorizontal;
              
                gradientDrawable.SetCornerRadius(60f);
                gradientDrawable.SetStroke(5, Android.Graphics.Color.MintCream);
                Control.SetBackground(gradientDrawable);   
                
            }
        }
    }
}