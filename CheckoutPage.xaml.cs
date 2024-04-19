namespace orderapp;

public partial class CheckoutPage : ContentPage
{
    public CheckoutPage(decimal totalPrice)
    {
        InitializeComponent();
        TotalPriceLabel.Text = $"Total: ${totalPrice:F2}";
    }

    private async void OnConfirmButtonClicked(object sender, EventArgs e)
    {
        // Display a confirmation message
        await DisplayAlert("Order Received", "Thank you for your order!", "OK");

        // Navigate back to the main page or perform any other necessary actions
        await Navigation.PopToRootAsync();
    }
}