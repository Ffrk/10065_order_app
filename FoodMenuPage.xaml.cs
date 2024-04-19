using System.Collections.ObjectModel;

namespace orderapp;

public partial class FoodMenuPage : ContentPage
{
    private ObservableCollection<MenuItem> _menuItems;


    public FoodMenuPage()
    {
        InitializeComponent();
        BindingContext = this;
        LoadMenuItems();
    }

    public ObservableCollection<MenuItem> MenuItems
    {
        get { return _menuItems; }
        set
        {
            _menuItems = value;
            OnPropertyChanged(nameof(MenuItems));
        }
    }

    private void LoadMenuItems()
    {
        // Load menu items from a data source (e.g., a database, an API, or a static list)
        MenuItems = new ObservableCollection<MenuItem>
            {
                new MenuItem
                {
                    Name = "Cheeseburger",
                    Price = 9.99m,
                    ImageSource = "Cheeseburger.jpg"


                },
               /* new MenuItem
                {
                    Name = "Cheeseburger",
                    Price = 9.99m,
                    ImageSource = "cheeseburger.jpg"}*/
            };
    }

    private void OnAddToOrderButtonClicked(object sender, EventArgs e)
    {
        var selectedMenuItem = (sender as Button)?.BindingContext as MenuItem;
        if (selectedMenuItem != null)
        {
            // Add the selected menu item to the order
            AddToOrder(selectedMenuItem);

            // Navigate to the Order Summary page
            await Navigation.PushAsync(new OrderSummaryPage(OrderItems));
        }
    }

    private void AddToOrder(MenuItem menuItem)
    {
        // Check if the menu item is already in the order
        var existingOrderItem = OrderItems.FirstOrDefault(item => item.MenuItem.Name == menuItem.Name);
        if (existingOrderItem != null)
        {
            // Increment the quantity of the existing order item
            existingOrderItem.Quantity++;
        }
        else
        {
            // Create a new order item
            var orderItem = new OrderItem
            {
                MenuItem = menuItem,
                Quantity = 1
            };
            OrderItems.Add(orderItem);
        }
    }
}
}