using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab9
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TapDemo : ContentPage
    {
        int tapCount;
        readonly Label label;

        public TapDemo()
        {
            InitializeComponent();
            var image = new Image
            {
                Source = "dodge.jpg",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            var tapGestureRecongnizer = new TapGestureRecognizer();
            tapGestureRecongnizer.NumberOfTapsRequired = 2;
            tapGestureRecongnizer.Tapped += OnTapGestureRecognizerTapped;
            image.GestureRecognizers.Add(tapGestureRecongnizer);
            label = new Label
            {
                Text = "tap the photo!",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
            Content = new StackLayout { 
                Padding=new Thickness(20,100),

                Children =
                {
                    image,
                    label
                }
            };
        }

        private void OnTapGestureRecognizerTapped(object sender, EventArgs e)
        {
            tapCount++;
            label.Text = String.Format("{0} tap{1} so far!",
                tapCount,
                tapCount == 1 ? "" : "s");

            var imageSSender = (Image)sender;

            //watch the money go from color to black&white!

            if (tapCount %2 == 0 )
            {
                imageSSender.Source= "dodge.jpg";
            }
            else
            {
                imageSSender.Source = "flash.jpg";
            }
          
        }
    }
}