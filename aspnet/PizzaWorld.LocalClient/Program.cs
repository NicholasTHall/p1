using System;
using System.Collections.Generic;
using System.Linq;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.LocalClient
{
  class Program
  {
    private readonly static SqlClient _sql = new SqlClient();
    static void Main(string[] args)
    {
      bool userAction = true;
      while (userAction)
      {
        Console.WriteLine("Choose action (number)");
        Console.WriteLine(""
        + "1. Create New User\n"
        + "2. Select User\n"
        + "3. Select Store\n"
        + "4. Quit");
        int.TryParse(Console.ReadLine(), out int input);
        switch (input)
        {
          case 1:
            MakeNewUser();
            break;
          case 2:
            PrintAllUsersEF();
            var user = _sql.SelectUser();
            if (!(user == null)) { UserView(user); }
            else { Console.WriteLine("That user does not exist"); }
            break;
          case 3:
            PrintAllStoresEF();
            var store = _sql.SelectStore();
            if (!(store == null)) { StoreView(store); }
            else { Console.WriteLine("That store does not exist"); }
            break;
          case 4:
            userAction = false;
            break;
          default:
            Console.WriteLine("Unknown input try again");
            break;
        }
      }
    }

    static void PrintAllStoresEF()
    {
      foreach (var store in _sql.ReadStores())
      {
        Console.WriteLine(store);
      }
    }

    static void PrintAllUsersEF()
    {
      foreach (var user in _sql.ReadUsers())
      {
        Console.WriteLine(user.Name);
      }
    }
    static void StoreView(Store store)
    {
      bool storeAction = true;
      while (storeAction)
      {
        Console.WriteLine("Choose action (number)");
        Console.WriteLine(""
        + "1. OrderHistory Action\n"
        + "2. Sales Action\n"
        + "3. Cancel");
        int.TryParse(Console.ReadLine(), out int input);
        switch (input)
        {
          case 1:
            StoreHistoryView(store);
            break;
          case 2:
            StoreSalesView(store);
            break;
          case 3:
            storeAction = false;
            return;
          default:
            Console.WriteLine("Unknown input try again");
            break;
        }
      }
    }

    static void StoreHistoryView(Store store)
    {
      bool storeAction = true;
      while (storeAction)
      {
        Console.WriteLine("Choose action (number)");
        Console.WriteLine(""
        + "1. Full Order History\n"
        + "2. Filter Order History by a user\n"
        + "3. Cancel");
        int.TryParse(Console.ReadLine(), out int input);
        switch (input)
        {
          case 1:
            Console.WriteLine(store.OrderHistory());
            break;
          case 2:
            PrintAllUsersEF();
            var user = _sql.SelectUser();
            if (!(user == null)) { Console.WriteLine(store.UserOrderHistory(user)); }
            else { Console.WriteLine("That user does not exist"); }
            break;
          case 3:
            storeAction = false;
            return;
          default:
            Console.WriteLine("Unknown input try again");
            break;
        }
      }
    }

    static void StoreSalesView(Store store)
    {
      bool storeAction = true;
      while (storeAction)
      {
        Console.WriteLine("Choose action (number)");
        Console.WriteLine(""
        + "1. Weekly revenue\n"
        + "2. Weekly pizza type and count\n"
        + "3. Monthly revenue\n"
        + "4. Monthly pizza type and count\n"
        + "5. Cancel");
        int.TryParse(Console.ReadLine(), out int input);
        switch (input)
        {
          case 1:
            Console.WriteLine(store.WeeklyRevenue());
            break;
          case 2:
            Console.WriteLine(store.WeeklyPizzaStats());
            break;
          case 3:
            Console.WriteLine(store.MonthlyRevenue());
            break;
          case 4:
            Console.WriteLine(store.MonthlyPizzaStats());
            break;
          case 5:
            storeAction = false;
            return;
          default:
            Console.WriteLine("Unknown input try again");
            break;
        }
      }
    }

    static void UserView(User user)
    {
      bool userAction = true;
      while (userAction)
      {
        Console.WriteLine("Choose action (number)");
        Console.WriteLine(""
        + "1. Get OrderHistory\n"
        + "2. Make Order\n"
        + "3. Cancel");
        int.TryParse(Console.ReadLine(), out int input);
        switch (input)
        {
          case 1:
            Console.WriteLine(user.OrderHistory());
            break;
          case 2:
            if (UserMakeOrder(user)) { userAction = false; }
            break;
          case 3:
            userAction = false;
            return;
          default:
            Console.WriteLine("Unknown input try again");
            break;
        }
      }
    }

    static void MakeNewUser()
    {
      var user = new User();
      Console.WriteLine("Enter username for new user");
      user.Name = Console.ReadLine();
      _sql.SaveUser(user);
    }

    static void UserOrderHistory(User user)
    {
      Console.WriteLine(user.OrderHistory());
    }

    static bool UserMakeOrder(User user)
    {
      bool addpizzas = true;
      if (user.OrderTimeLimitCheck())
      {
        Console.WriteLine("Cannot place an order within two hours of another order");
        return false;
      }

      PrintAllStoresEF();
      var store = _sql.SelectStore();
      if (store == null)
      {
        Console.WriteLine("That store does not exist");
        return false;
      }
      if (!(user.SelectedStore == null))
      {
        if (!user.SelectedStore.Equals(store))
        {
          if (user.StoreChangeCheck())
          {
            Console.WriteLine("Cannot changes stores within 24 hours of another order");
            return false;
          }
        }
      }

      user.SelectedStore = store;
      user.SelectedStore.CreateOrder();
      user.Orders.Add(user.SelectedStore.Orders.Last());
      while (addpizzas)
      {
        Console.WriteLine("Choose action (number)");
        Console.WriteLine(""
        + "1. Order Summary\n"
        + "2. Order CustomPizza\n"
        + "3. Order MeatPizza\n"
        + "4. Order BuffaloChickenPizza\n"
        + "5. Order HawaiianPizza\n"
        + "6. Order PillyCheeseSteakPizza\n"
        + "7. Order GlutenFreePizza\n"
        + "8. Remove a Pizza\n"
        + "9. Finish Order");
        int.TryParse(Console.ReadLine(), out int input);
        switch (input)
        {
          case 1:
            Console.WriteLine(user.OrderSummmary());
            break;
          case 2:
            user.Orders.Last().MakeCustomPizza();
            user.Orders.Last().LimitCheck();
            break;
          case 3:
            user.Orders.Last().MakeMeatPizza();
            user.Orders.Last().LimitCheck();
            break;
          case 4:
            user.Orders.Last().MakeBuffaloChickenPizza();
            user.Orders.Last().LimitCheck();
            break;
          case 5:
            user.Orders.Last().MakeHawaiianPizza();
            user.Orders.Last().LimitCheck();
            break;
          case 6:
            user.Orders.Last().MakePillyCheeseSteakPizza();
            user.Orders.Last().LimitCheck();
            break;
          case 7:
            user.Orders.Last().MakeGlutenFreePizza();
            user.Orders.Last().LimitCheck();
            break;
          case 8:
            Console.WriteLine(user.OrderSummmary());
            Console.WriteLine("Choose a pizza to remove (number)");
            int.TryParse(Console.ReadLine(), out int pizzaSelect);
            user.Orders.Last().DeletePizza(pizzaSelect - 1);
            break;
          case 9:
            addpizzas = false;
            break;
          default:
            Console.WriteLine("Unknown input try again");
            break;
        }
      }

      user.Orders.Last().OrderDate = DateTime.Now;
      _sql.Update();

      Console.WriteLine(user.OrderSummmary());
      return true;
    }
  }
}
