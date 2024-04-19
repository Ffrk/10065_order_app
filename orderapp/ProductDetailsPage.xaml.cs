namespace orderapp;

public partial class ProductDetailPage : ContentPage
{
	public ProductDetailPage(MenuItem menuItem)
	{
		InitializeComponent();
        BindingContext = menuItem;
    }
}
