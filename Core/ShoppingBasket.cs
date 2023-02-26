namespace Core;
public class ShoppingBasket
{
    private List<Item> items { get; set; }

    public ShoppingBasket()
    {
        this.items = new List<Item>();
    }    

    public ShoppingBasket(List<Item> items)
    {
        this.items = items;
    }    

    public int Get_quantity_of_particular_item_by_name(string itemName)
    {

        Item? foundItem = this.items.Find(item => item.name == itemName);
        if(foundItem == null)
        {
            return 0;
        }
        return foundItem.quantity;
    }

    public double Get_total_price_without_discounts()
    {
        return this.items.Sum(item => item.quantity * item.unitaryPrice);
    }

    public int Get_percentage_discount()
    {
        Double total_price = this.Get_total_price_without_discounts();
        if(total_price > 200){
            return 10;
        }
        if(total_price > 100){
            return 5;
        }
        return 0;
    }

    public object Get_total_price_with_discounts()
    {
        double total_price_without_discounts = Get_total_price_without_discounts();
        double discounts = Get_percentage_discount();

        return total_price_without_discounts - (Math.Round((total_price_without_discounts * discounts)/100,2));
    }
}
