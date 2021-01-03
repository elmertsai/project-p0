using System;
using System.Collections.Generic;
using System.Linq;
using PizzaWorld.Domain.Abstracts;
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
            //PrebuiltPizza();
            if(_client1.UserOrStore()==1)
            {
                UserView();
            }
            else if(_client1.UserOrStore() ==2)
            {
                StoreView();
            }
            else
            {
                Console.WriteLine("Something went wrong, check UserOrStore method");
            }
            // _client1.Stores = _sql.ReadStores().ToList();
            // UserView();
        }

        static void PrintAllStores()
        {
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
        static void PrintAllStoresWithEF()
        {
            var sb = new System.Text.StringBuilder();
            int counter = 1;
            sb.Append(String.Format("{0,-15} {1,-15} {2,-15}\n\n","Store Number","Store Name","Store Address"));
            foreach(var store in _sql.ReadStores())
            {
                sb.Append(String.Format("{0,-15} {1,-15} {2,-15}\n",counter,store.Name,store.Address));
                counter++;
            }
            Console.WriteLine(sb);
        }
        static void UserView()
        {
            var user = new User();

            PrintAllStoresWithEF();
            System.Console.WriteLine("Please select a store");
            user.SelectedStore =_client1.SelectStore();
            user.SelectedStore.CreateOrder();
            
            user.Orders.Add(user.SelectedStore.Orders.Last());

            System.Console.WriteLine(user.ToString());

        }
        static void PrebuiltPizza()
        {
            Console.WriteLine("_sql.ReadPizzas().Count()");
            if(_sql.ReadPizzas().Count()>=0)
            {
                Console.WriteLine("No Pizza found in DB! Adding pizzas");
                Crust c=_sql.ReadCrust().FirstOrDefault(x => x.name.Contains("Hand Tossed"));
                Size s=_sql.ReadSize().FirstOrDefault(x => x.name.Contains("Medium"));
                Topping t1 =_sql.ReadTopping().FirstOrDefault(x => x.name.Contains("Premium Chicken"));
                Topping t2 =_sql.ReadTopping().FirstOrDefault(x => x.name.Contains("Cheese"));
                List<Topping> t = new List<Topping>{t1,t2};
                APizzaModel meatpizza1 = new Pizza(c,s,t);
                meatpizza1.name = "Medium Hand Tossed Meat Pizza";
                _sql.Save(meatpizza1);

                
                c=_sql.ReadCrust().FirstOrDefault(x => x.name.Contains("Cheese-Stuffed"));
                s=_sql.ReadSize().FirstOrDefault(x => x.name.Contains("Large"));
                t1 =_sql.ReadTopping().FirstOrDefault(x => x.name.Contains("Premium Chicken"));
                t2 =_sql.ReadTopping().FirstOrDefault(x => x.name.Contains("Cheese"));
                Topping t3 = _sql.ReadTopping().FirstOrDefault(x => x.name.Contains("Pulled Pork"));
                Topping t4 = _sql.ReadTopping().FirstOrDefault(x => x.name.Contains("Mushroom"));
                t = new List<Topping>{t1,t2,t3,t4};
                APizzaModel meatpizza2 = new Pizza(c,s,t);
                meatpizza2.name = "Large Cheese Stuffed King of Pizza";
                _sql.Save(meatpizza2);

                c=_sql.ReadCrust().FirstOrDefault(x => x.name.Contains("Thin"));
                s=_sql.ReadSize().FirstOrDefault(x => x.name.Contains("Small"));
                t1 =_sql.ReadTopping().FirstOrDefault(x => x.name.Contains("Cheese"));
                t = new List<Topping>{t1};
                APizzaModel cheesepizza = new Pizza(c,s,t);
                cheesepizza.name = "Small thin crust cheese pizza";
                _sql.Save(cheesepizza);
            }
            else
            {
                Console.WriteLine("Pizza Not empty");
            }
        }

        static void StoreView()
        {
            PrintAllStoresWithEF();
            System.Console.WriteLine("Please select a store");
            Store s = _client1.SelectStore();
            System.Console.WriteLine("Name of selected store:" + s.Name );
            System.Console.WriteLine("Order History: ");
            System.Console.WriteLine(s.Orders); //WIP

        }
    }
}
