namespace Core.Tests;
using FluentAssertions;

/*
# Shopping Basket Discount Kata

Items in a shopping basket have a unit price and quantity. Write code that will allow you to:

- find out the quantity of a particular item in the basket
- calculate the total price of the whole basket, including any applicable discount

Normally the total price is the sum of unit price * quantity for all the items. If you buy in bulk you get a discount:

- If total basket value > $100, apply a 5% discount
- If total basket value > $200, apply a 10% discount

Example

- item A: price $10, quantity 5
- Item B: price $25, quantity 2
- Item C: price $9.99, quantity 6


This basket qualifies for a 5% discount and the total price is $151.94

*/

public class UnitTest1
{
    [Fact]
    public void if_item_is_not_in_basket_returns_0()
    {
        ShoppingBasket shoppingBasket = new ShoppingBasket();

        int quantity = shoppingBasket.Get_quantity_of_particular_item_by_name("item A");
        quantity.Should().Be(0);
    }
    
    [Fact]
    public void If_basket_item_has_1_quantity_returns_1()
    {
        List<Item> items = new List<Item>();

        items.Add(new Item("item A", 1, 10));

        ShoppingBasket shoppingBasket = new ShoppingBasket(items);

        int quantity = shoppingBasket.Get_quantity_of_particular_item_by_name("item A");
        quantity.Should().Be(1);
    }

    [Fact]
    public void If_basket_total_price_is_0_returns_0()
    {
        ShoppingBasket shoppingBasket = new ShoppingBasket();

        var totalPrice = shoppingBasket.Get_total_price_without_discounts();
        totalPrice.Should().Be(0);
    }


    [Fact]
    public void If_basket_total_price_without_discounts_is_10_returns_10()
    {
        List<Item> items = new List<Item>();
        items.Add(new Item("item A", 1, 10));

        ShoppingBasket shoppingBasket = new ShoppingBasket(items);

        var totalPrice = shoppingBasket.Get_total_price_without_discounts();
        totalPrice.Should().Be(10);
    }

    [Fact]
    public void If_basket_total_price_is_100_discount_is_0_percent()
    {
        List<Item> items = new List<Item>();
        items.Add(new Item("item A", 1, 100));

        ShoppingBasket shoppingBasket = new ShoppingBasket(items);

        var totalPrice = shoppingBasket.Get_percentage_discount();
        totalPrice.Should().Be(0);

    }
    [Fact]
    public void If_basket_total_price_is_101_discount_is_5_percent()
    {
        List<Item> items = new List<Item>();
        items.Add(new Item("item A", 1, 101));

        ShoppingBasket shoppingBasket = new ShoppingBasket(items);

        var totalPrice = shoppingBasket.Get_percentage_discount();
        totalPrice.Should().Be(5);

    }
    [Fact]
    public void If_basket_total_price_is_200_discount_is_5_percent()
    {
        List<Item> items = new List<Item>();
        items.Add(new Item("item A", 1, 200));

        ShoppingBasket shoppingBasket = new ShoppingBasket(items);

        var totalPrice = shoppingBasket.Get_percentage_discount();
        totalPrice.Should().Be(5);

    }

    [Fact]
    public void If_basket_total_price_is_201_discount_is_10_percent()
    {
        List<Item> items = new List<Item>();
        items.Add(new Item("item A", 1, 201));

        ShoppingBasket shoppingBasket = new ShoppingBasket(items);

        var totalPrice = shoppingBasket.Get_percentage_discount();
        totalPrice.Should().Be(10);

    }

    [Fact]
    public void If_basket_total_price_is_250_discounted_price_is_225()
    {
        List<Item> items = new List<Item>();
        items.Add(new Item("item A", 3, 50));
        items.Add(new Item("item B", 2, 25));
        items.Add(new Item("item C", 10, 5));

        ShoppingBasket shoppingBasket = new ShoppingBasket(items);

        var discountedTotalPrice = shoppingBasket.Get_total_price_with_discounts();

        discountedTotalPrice.Should().Be(225);

    }
}