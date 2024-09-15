using DotNetHW2;

namespace Service;


public class ItemService : IItemService
{
    private ItemService()
    {
    }

    private static ItemService itemService;

    public static ItemService Instance
    {
        get
        {
            if (itemService == null)
                itemService = new ItemService();
            return itemService;
        }
    } 
    
    public bool Signup(string name, string username, string password)
    {
        foreach (var VARIABLE in Data.dataList)
        {
            if (VARIABLE.username.Equals(username))
                return false;
        }
        
        User temp = new User(name, username, password);
        Data.dataList.Add(temp);
        Data.mainData = temp;
        return true;
    }

    public bool Login(string username, string password)
    {
        foreach (var VARIABLE in Data.dataList)
        {
            if (VARIABLE.username.Equals(username) && VARIABLE.password.Equals(password))
            {
                Data.mainData = VARIABLE;
                return true;
            }
        }
        
        return false;
    }

    public bool EditProfile(string name)
    {
        Data.mainData.name = name;
        return true;
    }

    public string BuyItem(string name)
    {
        if (name.Equals("Phone"))
        {
            if (Phone.count < 1)
                return "The item is out of stock";
            else if (((User)Data.mainData).credit < Phone.price)
                return "you don't have enough money";
            ((User)Data.mainData).credit -= Phone.price;
            Phone.count -= 1;
            return "successful";
        }
        else if (name.Equals("Computer"))
        {
            if (Computer.count < 1)
                return "The item is out of stock";
            else if (((User)Data.mainData).credit < Computer.price)
                return "you don't have enough money";
            ((User)Data.mainData).credit -= Computer.price;
            Phone.count -=1;
            return "successful";
        }
        else
            return "not find your item";
    }

    public bool IncreaseCredit(double amount)
    {
        ((User)Data.mainData).credit += amount;
        return true;
    }

    public bool AddItem(string name)
    {
        if (name.Equals("Phone"))
        {
            Phone temp = new Phone();
            return true;
        }
        else if (name.Equals("Computer"))
        {
            Computer temp = new Computer();
            return true;
        }
        else
            return false;
    }

    public bool RemoveItem(string name)
    {
        if (name.Equals("Phone"))
        {
            if(Phone.count < 1)
                return false;
            Phone.count -= 1;
            return true;
        }
        else if (name.Equals("Computer"))
        {
            if (Computer.count < 1)
                return false;
            Computer.count -= 1;
            return true;
        }
        else
            return false;
    }

    public bool SignupAdmin(string name, string username, string password)
    {
        foreach (var VARIABLE in Data.dataList)
        {
            if (VARIABLE.username.Equals(username))
                return false;
        }
        
        Admin temp = new Admin(name, username, password);
        Data.dataList.Add(temp);
        Data.mainData = temp;
        return true;
    }

    public void Logout()
    {
        Data.mainData = null;
    }

    public string GetInfoUser()
    {
        return $"name: {Data.mainData.name}\nusername: {Data.mainData.username}\npassword: {Data.mainData.password}\ncredit: {((User)Data.mainData).credit}";
    }

    public string GetInfoAdmin()
    {
        return $"name: {Data.mainData.name}\nusername: {Data.mainData.username}\npassword: {Data.mainData.password}";
    }
    
    
}