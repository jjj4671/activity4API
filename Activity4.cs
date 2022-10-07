public class Order
{
    public string Item;
};

public class FoodOrderingService{
    public delegate void FoodPreparedEventHandler(object source, Eventargs args);

    public event FoodPreparedEventHandler FoodPrepared;

    public void PrepareOrder(Order order)
    {
        Console.WriteLine($"Preparing your order '{order.Item}', please wait...");
        Thread.Sleep(4000);

        OnFoodPrepared();
    }

    protected virtual void OnFoodPrepared()
    {
        if (FoodPrepared != null)
            FoodPrepared(this,null);
    }
}

public class AppService
{
    public void OnFoodPrepared(object source, Eventargs Eventargs){
        Console.WriteLine("Appservice: your food is prepared.");
    }
}

Class Program
{
    static void Main(string[] args){
        var order = new Order {Item = "Pizza with extra pepperoni"};
        var orderingservice = new FoodOrderingService();
        var appService = new AppService()
        orderingservice.FoodPrepared += appService.OnFoodPrepared;
        orderingservice.PrepareOrder(order);
        Console.ReadKey();
    }
}