using System.Collections.ObjectModel;

namespace orderapp;

public partial class OrderSummaryPage : ContentPage
{
    private ObservableCollection<OrderItem> _orderItems;
    private decimal _totalPrice;

    public OrderSummaryPage(ObservableCollection<OrderItem> orderItems)
    {
        InitializeComponent();
        _orderItems = orderItems;
        BindingContext = this;
        CalculateTotalPrice();
    }

    public ObservableCollection<OrderItem> OrderItems
    {
        get { return _orderItems; }
        set
        {
            _orderItems = value;
            OnPropertyChanged(nameof(OrderItems));
            CalculateTotalPrice();
        }
    }

    public decimal TotalPrice
    {
        get { return _totalPrice; }
        set
        {
            _totalPrice = value;
            OnPropertyChanged(nameof(TotalPrice));
        }
    }

    private void CalculateTotalPrice()
    {
        TotalPrice = OrderItems.Sum(item => item.MenuItem.Price * item.Quantity);
    }

    private async void OnRemoveButtonClicked(object sender, EventArgs e)
    {
        // Get the selected order item
        var orderItem = (sender as Button)?.BindingContext as OrderItem;
        if (orderItem != null)
        {
            // Remove the order item from the collection
            OrderItems.Remove(orderItem);
        }
    }

    private async void OnCheckoutButtonClicked(object sender, EventArgs e)
    {
        // Navigate to the Checkout page, passing the total price
        await Navigation.PushAsync(new CheckoutPage(TotalPrice));
    }
}