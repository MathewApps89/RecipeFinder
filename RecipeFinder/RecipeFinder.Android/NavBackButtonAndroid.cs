using Android.Content;
using Android.Graphics.Drawables;
using RecipeFinder.Droid;
using RecipeFinder.Services;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(NavBackButton), typeof(NavBackButtonAndroid))]
namespace RecipeFinder.Droid
{
    public class NavBackButtonAndroid : ButtonRenderer
    {
        public NavBackButtonAndroid(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                var gradientDrawable = new GradientDrawable();

                gradientDrawable.SetStroke(0, Android.Graphics.Color.Transparent);
                gradientDrawable.SetColor(Android.Graphics.Color.Transparent);
                Control.SetBackground(gradientDrawable);

                Control.SetPadding(50, Control.PaddingTop, Control.PaddingRight, Control.PaddingBottom);
            }

        }
    }
}