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
        private static readonly SqlClient _sql = new SqlClient();

        static void Main(string[] args)
        {
            //_client1.MakeAStore();
            UserView();
        }

        static void PrintAllStores()
        {

            // foreach(var store in _client1.Stores)
            // {
            //     System.Console.WriteLine(store);
            // }
            var sb = new System.Text.StringBuilder();
            int counter = 1;
            sb.Append(String.Format("{0,-15} {1,-15} {2,-15}\n\n","Store Number","Store Name","Store Address"));
            foreach(var store in _client1.Stores)
            {
                sb.Append(String.Format("{0,-15} {1,-15} {2,-15}\n",counter,store.Name,store.Address));
                counter++;
            }
            Console.WriteLine(sb);
        }
        // static void PrintAllStoresWithEF()
        // {
        //     var sb = new System.Text.StringBuilder();
        //     int counter = 1;
        //     sb.Append(String.Format("{0,-10} {1,-10} {2,-10}","Store Number","Store Name","Store Address"));
        //     foreach(var store in _sql.ReadStores())
        //     {
        //         sb.Append(String.Format("{0,-10} {1,-10} {2,-10}",counter,store.Name,store.Address));
        //         counter++;
        //     }
        // }
        static void UserView()
        {
            var user = new User();

            // PrintAllStoresWithEF();
            PrintAllStores();

            user.SelectedStore =_client1.SelectStore();
            user.SelectedStore.CreateOrder();
            
            user.Orders.Add(user.SelectedStore.Orders.Last());

            System.Console.WriteLine(user.ToString());

        }
    }
}
