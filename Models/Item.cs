namespace DotNetHW2;

public abstract class Item
{
    public string name { get; set; }
    public double price { get; set; }

    public Item(string name, double price)
    {
        this.name = name;
        this.price = price;
    }
}

public class Phone : Item
{
    public static double price = 100;
    public static int count = 0;
    public Phone() : base("Phone", price)
    {
        count++;
    }
}

public class Computer : Item
{
    public static double price = 200;
    public static int count=0;
    public Computer() : base("Computer", price)
    {
        count++;
    }
}