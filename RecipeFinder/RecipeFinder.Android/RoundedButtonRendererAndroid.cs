using Android.Content;
using Android.Graphics.Drawables;
using RecipeFinder.Droid;
using Xamarin.Forms;
using RecipeFinder.Services;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(RoundedButton), typeof(RoundedButtonRendererAndroid))]

namespace RecipeFinder.Droid
{
    public class RoundedButtonRendererAndroid : ButtonRenderer
    {
        public RoundedButtonRendererAndroid(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                var gradientDrawable = new GradientDrawable();

                gradientDrawable.SetCornerRadius(60f);
                gradientDrawable.SetStroke(3, Android.Graphics.Color.White);
                gradientDrawable.SetColor(Android.Graphics.Color.Transparent);
                Control.SetBackground(gradientDrawable);

                Control.SetPadding(50, Control.PaddingTop, Control.PaddingRight, Control.PaddingBottom);
            }

        }      
    }
}