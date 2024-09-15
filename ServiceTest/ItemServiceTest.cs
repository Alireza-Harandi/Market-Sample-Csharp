using Service;
using DotNetHW2;
using Xunit.Sdk;
using Service;

namespace ServiceTest;

public class ItemServiceTest
{
    private ItemService _sut;
    
    public ItemServiceTest()
    {
        _sut = ItemService.Instance;
        // _sut = new ItemService();
    }

    private void removeData()
    {
        Data.dataList = new List<Data>();
        Phone.count = 0;
        Computer.count = 0;
    }

    private void addData()
    {
        Data.dataList.Add(new User("user1", "username1", "password"));
        Data.dataList.Add(new User("user2", "username2", "password"));
        Data.dataList.Add(new Admin("admin3", "username3", "password"));
    }
    
    //--------------------------------------------------------------------------------------------------------
    
    [Fact]
    public void SignupTest1()
    {
        removeData();
        addData();
        bool expected = false;
        
        bool actual = _sut.Signup("name", "username2", "password");  
        
        Assert.Equal(expected,actual);
    }
    
    [Fact]
    public void SignupTest2()
    {
        removeData();
        addData();
        bool expected = true;
        
        bool actual = _sut.Signup("name", "username", "password");  
        
        Assert.Equal(expected,actual);
    }
    
    //-----------------------------------------------------

    [Fact]
    public void LoginTest1()
    {
        removeData();
        addData();
        bool expected = false;
        
        bool actual = _sut.Login("bksfkesf", "password");
        
        Assert.Equal(expected,actual);
    }
    
    [Fact]
    public void LoginTest2()
    {
        removeData();
        addData();
        bool expected = false;
        
        bool actual = _sut.Login("username1", "kndgsd");
        
        Assert.Equal(expected,actual);
    }
    
    [Fact]
    public void LoginTest3()
    {
        removeData();
        addData();
        bool expected = true;
        
        bool actual = _sut.Login("username2", "password");
        
        Assert.Equal(expected,actual);
    }
    
    //-----------------------------------------
    
    
    [Fact]
    public void EditProfileTest1()
    {
        removeData();
        addData();
        _sut.Login("username1", "password");
        string expected = "newName";
        
        _sut.EditProfile("newName");
        string actual = Data.mainData.name; 
        
        Assert.Equal(expected,actual);
    }
    
    [Fact]
    public void EditProfileTest2()
    {
        removeData();
        addData();
        _sut.Signup("name", "username1", "password");
        string expected = "newName";
        
        _sut.EditProfile("newName");
        string actual = Data.mainData.name; 
        
        Assert.Equal(expected,actual);
    }
    
    //------------------------------------------
    
    [Fact]
    public void IncreaseCreditTest()
    {
        removeData();
        addData();
        _sut.Login("username1", "password");
        double expected = 100;

        _sut.IncreaseCredit(100);
        double actual = ((User)Data.mainData).credit; 
        
        Assert.Equal(expected,actual);
    }
    
    //----------------------------------------------
    
    [Fact]
    public void AddItemTest1()
    {
        removeData();
        addData();
        bool expected = true;

        bool actual = _sut.AddItem("Phone");
        
        Assert.Equal(expected,actual);
    }
    
    [Fact]
    public void AddItemTest2()
    {
        removeData();
        addData();
        bool expected = true;

        bool actual = _sut.AddItem("Computer");
        
        Assert.Equal(expected,actual);
    }
    
    [Fact]
    public void AddItemTest3()
    {
        removeData();
        addData();
        bool expected = false;

        bool actual = _sut.AddItem("jsdks");
        
        Assert.Equal(expected,actual);
    }
    
    [Fact]
    public void AddItemTest4()
    {
        removeData();
        addData();
        int expected = 1;

        _sut.AddItem("Phone");
        int actual = Phone.count; 
        
        Assert.Equal(expected,actual);
    }
    
    [Fact]
    public void AddItemTest5()
    {
        removeData();
        addData();
        int expected = 2;

        _sut.AddItem("Phone");
        _sut.AddItem("Phone");
        int actual = Phone.count; 
        
        Assert.Equal(expected,actual);
    }
    
    //------------------------------------------------------------
    
    [Fact]
    public void RemoveItemTest1()
    {
        removeData();
        addData();
        _sut.AddItem("Phone");
        _sut.AddItem("Phone");
        int expected = 1;

        _sut.RemoveItem("Phone");
        int actual = Phone.count; 
        
        Assert.Equal(expected,actual);
    }
    
    [Fact]
    public void RemoveItemTest2()
    {
        removeData();
        addData();
        _sut.AddItem("Phone");
        int expected = 0;

        _sut.RemoveItem("Phone");
        int actual = Phone.count; 
        
        Assert.Equal(expected,actual);
    }
    
    [Fact]
    public void RemoveItemTest3()
    {
        removeData();
        addData();
        _sut.AddItem("Phone");
        bool expected = false;

        _sut.RemoveItem("Phone");
        bool actual = _sut.RemoveItem("Phone");
        
        Assert.Equal(expected,actual);
    }
    
    [Fact]
    public void RemoveItemTest4()
    {
        removeData();
        addData();
        _sut.AddItem("Phone");
        bool expected = false;

        bool actual = _sut.RemoveItem("mnmndsvc");
        
        Assert.Equal(expected,actual);
    }
    
    //--------------------------------------------------
    
    [Fact]
    public void SignupAdminTest1()
    {
        removeData();
        addData();
        bool expected = false;
        
        bool actual = _sut.SignupAdmin("name", "username2", "password");  
        
        Assert.Equal(expected,actual);
    }
    
    [Fact]
    public void SignupAdminTest2()
    {
        removeData();
        addData();
        bool expected = true;
        
        bool actual = _sut.SignupAdmin("name", "username", "password");  
        
        Assert.Equal(expected,actual);
    }
    
    //------------------------------------------------
    
    [Fact]
    public void BuyItemTest1()
    {
        removeData();
        addData();
        string expected = "not find your item";
        
        string actual = _sut.BuyItem("kjsdfdsfv");  
        
        Assert.Equal(expected,actual);
    }
    
    [Fact]
    public void BuyItemTest2()
    {
        removeData();
        addData();
        string expected = "The item is out of stock";
        
        string actual = _sut.BuyItem("Phone");  
        
        Assert.Equal(expected,actual);
    }
    
    [Fact]
    public void BuyItemTest3()
    {
        removeData();
        addData();
        _sut.AddItem("Phone");
        string expected = "you don't have enough money";
        
        string actual = _sut.BuyItem("Phone");  
        
        Assert.Equal(expected,actual);
    }
    
    [Fact]
    public void BuyItemTest4()
    {
        removeData();
        addData();
        _sut.AddItem("Phone");
        _sut.IncreaseCredit(100);
        string expected = "successful";
        
        string actual = _sut.BuyItem("Phone");  
        
        Assert.Equal(expected,actual);
    }
    
    [Fact]
    public void BuyItemTest5()
    {
        removeData();
        addData();
        _sut.AddItem("Phone");
        _sut.IncreaseCredit(105);
        double expected = 5;
        
        _sut.BuyItem("Phone");
        double actual = ((User)Data.mainData).credit;
        
        Assert.Equal(expected,actual);
    }
    
    [Fact]
    public void BuyItemTest6()
    {
        removeData();
        addData();
        _sut.AddItem("Phone");
        _sut.IncreaseCredit(105);
        int expected = 0;
        
        _sut.BuyItem("Phone");
        int actual = Phone.count;
        
        Assert.Equal(expected,actual);
    }
}