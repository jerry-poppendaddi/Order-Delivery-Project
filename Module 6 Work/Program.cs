using System;
using System.Data;

abstract class Delivery
{
    public string? Address;
        
    public DateTime DeliveryDate;
    public abstract void Description();
}

class HomeDelivery : Delivery
{
    public string? ShippingCompany;
    public object? TrackingNumber;
    
    
    public override void Description()
    { 
        Console.WriteLine("Your item will be delivered to your Address"); 
        
    }

}

class PickupDelivery : Delivery
{
    public string? PickupPlaceName;
    public string? LockerNumber;
    public override void Description()
    {
        Console.WriteLine("Your item will be delivered to your local PickUp Location");
    }
}

class StoreDelivery : Delivery
{
    public string? StoreName;

    public override void Description()
    {
        Console.WriteLine("Your item will be delivered to our Store for pickup");
    }
}

class Order<TDelivery, TProduct> where TDelivery : Delivery where TProduct : Product
{
    public TDelivery Delivery;
    public int Number;
    private TProduct Product;

   
    public void DisplayAddress()
    {
        Console.WriteLine(Delivery.Address);
    }


    public Payment Payment;
    public void SelectPayment(Payment type)
    { Payment = type; }

}

class Customer
{
    protected string? Name;
    protected string? HomeAddress;
    protected long PhoneNumber;
        
}

public class Product
{
    public string? ProductName;
    public int ArticleNumber;
    public int Price;

}

class Warehouse  //Class for List of Available Products using Indexing
{
    private Product[] List;
    public Warehouse(Product[] List)
    { 
        this.List = List;
    }
    public Product this[int index]
    {
        get
        {
            if (index >= 0 && index < List.Length)
            {
                return List[index];
            }
            else
            {
                return null;
            }
        }

        private set
        {
            if (index >= 0 && index < List.Length)
            {
                List[index] = value;
            }
        }
    }
    public Product this[string itemname]
    {
        get
        {
            for (int i = 0; i < List.Length; i++)
            {
                if (List[i].ProductName == itemname)
                {
                    return List[i];
                }
            }
            return null;
        }
    }
}
enum Payment
{
    Cash, CreditCard
}

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, let's put together a new order");

        Order<Delivery, Product> order1 = new Order<Delivery, Product>();
        order1.SelectPayment(Payment.CreditCard);
        order1.DisplayAddress();

          

        
               

    }
}