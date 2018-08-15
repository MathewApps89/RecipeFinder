using RecipeFinder.Services;
using RecipeFinder.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerUwp))]
namespace RecipeFinder.UWP
{
    public class CustomPickerUwp : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.BorderBrush = new SolidColorBrush(Colors.MintCream);
               
            }          
        }
    }
}
