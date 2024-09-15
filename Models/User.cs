namespace DotNetHW2;

public abstract class Data
{
    public String name { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public static List<Data> dataList = new List<Data>();

    public static Data mainData { get; set; }
    
    public Data(String name, string username, string password)
    {
        this.name = name;
        this.username = username;
        this.password = password;
    }
}

public class Admin : Data
{
    public Admin(string name, string username, string passsword) : base(name, username, passsword)
    {
    }
}

public class User : Data
{
    public double credit { get; set; }
    public User(string name, string username, string passsword) : base(name, username, passsword)
    {
        this.credit = 0;
    }
}