namespace orderapp;

public partial class WelcomePage : ContentPage
{
    public WelcomePage()
    {
        InitializeComponent();
    }
        private async void OnEnterButtonClicked(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new FoodMenuPage());


//    < VerticalStackLayout >
 //       < Image Source = "restaurant_image.jpg" Aspect = "AspectFill" HeightRequest = "300" />
   //     < Label Text = "Taste of Canada" FontSize = "Title" FontAttributes = "Bold" Margin = "0,20,0,0" />
     //   < Label Text = "123 Main Street, Oakville, Ontatio, Canada" FontSize = "Body" Margin = "0,10,0,0" />
       // < Button Text = "Enter" Clicked = "OnEnterButtonClicked" Margin = "0,20,0,0" />
  //  </ VerticalStackLayout >

    }
}