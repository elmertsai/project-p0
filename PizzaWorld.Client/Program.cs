using System;
using System.Collections.Generic;
using System.Linq;
using PizzaWorld.Domain.Models;
using PizzaWorld.Domain.Singletons;

namespace PizzaWorld.Client
{
    class Program
    {
        private static readonly ClientSingleton _client1 = ClientSingleton.Instance;


        static void Main(string[] args)
        {
            UserView();
        }

        static void PrintAllStores()
        {

            foreach(var store in _client1.Stores)
            {
                System.Console.WriteLine(store);
            }
        }
        static void UserView()
        {
            var user = new User();
            PrintAllStores();
            user.SelectedStore =_client1.SelectStore();
            user.SelectedStore.CreateOrder();
            user.Orders.Add(user.SelectedStore.Orders.Last());
            System.Console.WriteLine(user.ToString());

        }
    }
}
