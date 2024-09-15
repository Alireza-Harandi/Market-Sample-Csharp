using DotNetHW2;
using Service;

public class Program
{
    private static string[] answer;
    public static void Main(string[] args)
    {
        //add Admin
        ItemService.Instance.SignupAdmin("admin1", "a1", "pass");
        FirstMenu();
    }

    private static void FirstMenu()
    {
        //login -->  login username password
        //signup --> signup name username password
        //exit
        
        answer = Console.ReadLine()!.Split(" ");
        if (answer[0] == "login")
        {
            bool result = ItemService.Instance.Login(answer[1], answer[2]);
            if (result)
            {
                Console.WriteLine("Welcome!");
                if (Data.mainData is User)
                    UserMenu();
                else
                    AdminMenu();
            }
            else
            {
                Console.WriteLine("Wrong username or password!");
                FirstMenu();
            }
        }
        else if (answer[0] == "signup")
        {
            bool result = ItemService.Instance.Signup(answer[1], answer[2], answer[3]);
            if (result)
            {
                Console.WriteLine("Welcome!");
                UserMenu();
            }
            else
            {
                Console.WriteLine("Wrong username or password!");
                FirstMenu();
            }
            
        }
        else if (answer[0] == "exit")
            return;
        else
        {
            Console.WriteLine("The cmd entered was invalid!");
            FirstMenu();
        }
    }

    private static void UserMenu()
    {
        //edit --> edit name
        // increaseCredit --> increaseCredit amount
        //buy --> buy name
        //panel --> panel
        //logout --> logout
        
        answer = Console.ReadLine()!.Split(" ");
        if (answer[0] == "edit")
        {
            ItemService.Instance.EditProfile(answer[1]);
            Console.WriteLine("successful edited profile!");
            UserMenu();
        }
        else if (answer[0] == "increaseCredit")
        {
            ItemService.Instance.IncreaseCredit(double.Parse(answer[1]));
            Console.WriteLine("successful increasing credit!");
            UserMenu();
        }
        else if (answer[0] == "panel")
        {
            Console.WriteLine(ItemService.Instance.GetInfoUser());
            UserMenu();
        }
        else if (answer[0] == "buy")
        {
            Console.WriteLine(ItemService.Instance.BuyItem(answer[1]));
            UserMenu();
        }
        else if (answer[0] == "logout")
        {
            ItemService.Instance.Logout();
            FirstMenu();
        }
        else
        {
            Console.WriteLine("The cmd entered was invalid!");
            UserMenu();
        }
    }

    private static void AdminMenu()
    {
        //add --> add name
        //edit --> edit name
        //panel
        //logout --> logout
        
        answer = Console.ReadLine()!.Split(" ");
        if (answer[0] == "add")
        {
            bool result = ItemService.Instance.AddItem(answer[1]);
            if(result)
                Console.WriteLine("successful adding item!");
            else
                Console.WriteLine("Item not found!");
            AdminMenu();
        }
        else if (answer[0] == "remove")
        {
            bool result = ItemService.Instance.RemoveItem(answer[1]);
            if(result)
                Console.WriteLine("successful removing item!");
            else
                Console.WriteLine("cant remove item or item not found!");
            AdminMenu();
        }
        else if (answer[0] == "panel")
        {
            Console.WriteLine(ItemService.Instance.GetInfoAdmin());
            AdminMenu();
        }
        else if (answer[0] == "logout")
        {
            ItemService.Instance.Logout();
            FirstMenu();
        }
        else if (answer[0] == "edit")
        {
            ItemService.Instance.EditProfile(answer[1]);
            Console.WriteLine("successful edited profile!");
            AdminMenu();
        }
        else
        {
            Console.WriteLine("The cmd entered was invalid!");
            AdminMenu();
        }
    }
}