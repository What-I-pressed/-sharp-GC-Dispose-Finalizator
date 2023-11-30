using System.Net.Http.Headers;

Play play = new Play("PlayName", "Vivaldi", "Action", new DateTime(1879, 6, 21));
play.Info();
play.Dispose();
play.Info();



Shop shop = new Shop("Seim", "Stepana Bandery 30", Shop.ShopType.Grocery);
shop.Info();
shop.Dispose();
shop.Info();


class Play: IDisposable
{
    bool disposed = false;

    public string Name { get; set; }
    public string AuthorFullName { get; set; }
    public string Genre { get; set; }
    public DateTime Year { get; set; }

    public Play(string name, string authorFullName, string genre, DateTime year)
    {
        Name = name;
        AuthorFullName = authorFullName;
        Genre = genre;
        Year = year;
    }

    public void Info()
    {
        Console.WriteLine($"Play name : {Name}\nAuthor : {AuthorFullName}\n" +
            $"Genre : {Genre}\nYear of creation : {Year.Year}\n");
    }

    public virtual void Dispose()
    {
        if (!disposed)
        {
            Name = string.Empty;
            AuthorFullName = string.Empty;
            Genre = string.Empty;
            Year = new DateTime();
            disposed = true;
        }
    }

    ~Play()
    {
        Dispose();   
    }
}

class Shop : IDisposable
{
    bool disposed = false;

    public enum ShopType {
        Grocery,
        HardwareShop,
        СlothingShop,
        ShoeShop
    };

    public string Name { get; set; }
    public string Address { get; set; }
    public ShopType? shopType { get; set; }

    public Shop(string name, string address, ShopType shopType)
    {
        Name = name;
        Address = address;
        this.shopType = shopType;
    }

    public void Info()
    {
        Console.WriteLine($"Shop name : {Name}\nAddress : {Address}\nShop type : {shopType}\n");
    }

    public void SetPropeties(string name, string address, ShopType t)
    {
        Name = name;
        Address = address;
        shopType = t;
        disposed = false;
    }

    public virtual void Dispose()
    {
        if(!disposed)
        {
            Name = string.Empty;
            Address = string.Empty ;
            shopType = null;
            disposed = true;
        }
    }

    ~Shop()
    {
        Dispose();
    }
}
