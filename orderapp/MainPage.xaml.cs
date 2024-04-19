namespace orderapp
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();
            viewModel = new MainViewModel();
            this.BindingContext = viewModel;
        }

        async void OnItemSelected(object sender, EventArgs e)
        {
            var menuItem = (sender as BindableObject)?.BindingContext as MenuItem;
            if (menuItem != null)
            {
                await Navigation.PushAsync(new ProductDetailPage(menuItem));
            }
        }
    }
}
