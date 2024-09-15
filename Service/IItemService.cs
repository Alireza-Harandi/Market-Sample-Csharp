namespace Service;

public interface IItemService
{
    public bool Signup(string name, string username, string password);
    public bool Login(string username, string password);
    public bool EditProfile(string name);
    public bool AddItem(string name);//for Admin
    public bool RemoveItem(string name);//for Admin
    public string BuyItem(string name);
    public bool IncreaseCredit(double amount);
    public bool SignupAdmin(string name, string username, string password);
    public void Logout();
    public string GetInfoAdmin();
    public string GetInfoUser();
}