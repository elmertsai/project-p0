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
            PrebuiltPizza();
            int choice = _client1.UserOrStore();
            _client1.Stores = _sql.ReadStores().ToList();
            
            if(choice==1)
            {
                UserView();
            }
            else if(choice ==2)
            {
                StoreView();
            }
            else
            {
                Console.WriteLine("Something went wrong, check UserOrStore method");
            }

        }

       // Print and Select methods
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
        static Store SelectStore()
        {
            bool done = false;
            var input = 0;
            while(!done)
            {
                int.TryParse(Console.ReadLine(), out input);
            

                if(input > _sql.ReadStores().ToList().Count|| input <=0)
                {
                    Console.WriteLine("Please enter a valid input (Number representing the store)");
                }
                else
                {
                    Console.WriteLine("Selecting store...\n\n");
                    done = true;
                }
                 
            }

            return _sql.ReadStores().ToList().ElementAtOrDefault(input-1); // null if there's error

        }

        static void PrintAllOrders()
        {
        }
        static void PrintAllUsers()
        {
            var sb = new System.Text.StringBuilder();
            int counter = 1;
            sb.Append(String.Format("{0,-15} {1,-15}\n\n","User Number","User Name"));
            foreach(var user in _sql.ReadUsers().ToList())
            {
                sb.Append(String.Format("{0,-15} {1,-15} \n",counter,user.Name));
                counter++;
            }
            Console.WriteLine(sb);
        }
        static User SelectUser()
        {
           bool done = false;
            var input = 0;
            while(!done)
            {
                int.TryParse(Console.ReadLine(), out input);

                if(input > _sql.ReadUsers().ToList().Count|| input <=0)
                {
                    Console.WriteLine("Please enter a valid input (Number representing the User)");
                }
                else
                {
                    Console.WriteLine("Welcome back, "+ _sql.ReadUsers().ToList().ElementAtOrDefault(input-1).Name + " !");
                    return _sql.ReadUsers().ToList().ElementAtOrDefault(input-1);
                } 
            }
            Console.WriteLine("An unknown error has occured, please check SelectUser method");
            return new User();
        }
        static void PrintAllStoresWithEF()
        {
            var sb = new System.Text.StringBuilder();
            int counter = 1;
            sb.Append(String.Format("{0,-15} {1,-15} {2,-15}\n\n","Store Number","Store Name","Store Address"));
            foreach(var store in _sql.ReadStores().ToList())
            {
                sb.Append(String.Format("{0,-15} {1,-15} {2,-15}\n",counter,store.Name,store.Address));
                counter++;
            }
            Console.WriteLine(sb);
        }
        static void PrintAllPizzas()
        {
            var sb = new System.Text.StringBuilder();
            int counter = 1;
            sb.Append(String.Format("{0,-15} {1,-15} {2,-15}\n\n","Pizza Number","Pizza Name","Price"));
            foreach(var pizza in _sql.ReadPizzas().ToList())
            {
                sb.Append(String.Format("{0,-15} {1,-15} {2,-15}\n",counter,pizza.name,pizza.price));
                counter++;
            }
            Console.WriteLine(sb);  
        }

        static void PrintAllCrusts()
        {
            var sb = new System.Text.StringBuilder();
            int counter = 1;
            sb.Append(String.Format("{0,-15} {1,-15} {2,-15}\n\n","Crust Number","Curst Name","Crust Price"));
            foreach(var crust in _sql.ReadCrust().ToList())
            {
                sb.Append(String.Format("{0,-15} {1,-15} {2,-15}\n",counter,crust.name,crust.price));
                counter++;
            }
            Console.WriteLine(sb);
        }
        static Crust SelectCrust()
        {
            bool done = false;
            var input = 0;
            while(!done)
            {
                int.TryParse(Console.ReadLine(), out input);

                if(input > _sql.ReadCrust().ToList().Count|| input <=0)
                {
                    Console.WriteLine("Please enter a valid input (Number representing the crust)");
                }
                else
                {
                    Console.WriteLine("Adding Crust "+ _sql.ReadCrust().ToList().ElementAtOrDefault(input-1).name+" to Pizza...");
                    done = true;

                }
                 
            }
            return _sql.ReadCrust().ToList().ElementAtOrDefault(input-1); // null if there's error
        }
        static void PrintAllSizes()
        {
            var sb = new System.Text.StringBuilder();
            int counter = 1;
            sb.Append(String.Format("{0,-15} {1,-15} {2,-15}\n\n","Size Number","Size Name","Size Price"));
            foreach(var size in _sql.ReadSize().ToList())
            {
                sb.Append(String.Format("{0,-15} {1,-15} {2,-15}\n",counter,size.name,size.price));
                counter++;
            }
            Console.WriteLine(sb);
        }
        static Size SelectSize()
        {
            bool done = false;
            var input = 0;
            while(!done)
            {
                int.TryParse(Console.ReadLine(), out input);

                if(input > _sql.ReadSize().ToList().Count|| input <=0)
                {
                    Console.WriteLine("Please enter a valid input (Number representing the size)");
                }
                else
                {
                    Console.WriteLine("Adding Size "+ _sql.ReadSize().ToList().ElementAtOrDefault(input-1).name+" to Pizza...");
                    done = true;

                }
                 
            }
            return _sql.ReadSize().ToList().ElementAtOrDefault(input-1); // null if there's error
        }
        static void PrintAllToppings()
        {
            var sb = new System.Text.StringBuilder();
            int counter = 1;
            sb.Append(String.Format("{0,-15} {1,-15} {2,-15}\n\n","Topping Number","Topping Name","Topping Price"));
            foreach(var topping in _sql.ReadTopping().ToList())
            {
                sb.Append(String.Format("{0,-15} {1,-15} {2,-15}\n",counter,topping.name,topping.price));
                counter++;
            }
            Console.WriteLine(sb);

        }
        static Topping SelectTopping()
        {
            bool done = false;
            var input = 0;
            while(!done)
            {
                int.TryParse(Console.ReadLine(), out input);

                if(input > _sql.ReadTopping().ToList().Count|| input <=0)
                {
                    Console.WriteLine("Please enter a valid input (Number representing the topping)");
                }
                else
                {
                    Console.WriteLine("Adding Topping "+ _sql.ReadTopping().ToList().ElementAtOrDefault(input-1).name+" to Pizza...");
                    done = true;

                }
                 
            }
            return _sql.ReadTopping().ToList().ElementAtOrDefault(input-1); // null if there's error
        }
        static void UserView()
        {
            User user= new User();
            bool done = false;
            var input = 0;
            //create or use as existing user
            Console.WriteLine("Welcome to the user interfact, please select one of the following options: ");
            Console.WriteLine("1) Use app as an existing user");
            Console.WriteLine("2) Use app as a new user");
            while(!done)
            {
                int.TryParse(Console.ReadLine(), out input);

                if(input == 1)
                {
                    PrintAllUsers();
                    user = SelectUser();
                    done = true;
                }
                else if(input == 2)
                {
                    user = CreateNewUser();
                    done = true;
                } 
                else
                {
                    Console.WriteLine("Please enter a valid option. (number 1 or 2)");
                }
            }
            // check if the user is properly defined
            if(user.Name == null)
            {
                Console.WriteLine("Name is not properly defined, check the associated methods");
            }
            // User Menu
            PrintAllStoresWithEF();
            System.Console.WriteLine("Please select a store");
            user.SelectedStore =SelectStore();

            Console.WriteLine("Selected Store is: ");
            Console.WriteLine(user.SelectedStore);

            //Make Pizza
            
            user.SelectedStore.CreateOrder(MakePizza(),user);
            
            user.Orders.Add(user.SelectedStore.Orders.Last());
            _sql.UpdateUser(user);
            _sql.UpdateStore(user.SelectedStore);
            UserMenu(user);
            System.Console.WriteLine("Thank you for choosing to use this app!");
            

        }
        static void UserMenu(User user)
        {
            Console.WriteLine("Please Select one of options: ");
            Console.WriteLine("1) See order history");
            Console.WriteLine("2) Make a new order");
            Console.WriteLine("3) Exit Program");
            var input = 0;
            int.TryParse(Console.ReadLine(), out input);

            if(input == 1)
            {
                List<Order> o= _sql.OrderHistoryByUser(user).ToList();
                Console.WriteLine(String.Format("{0,-25} {1,-25} {2,-25} {3,-25} {4,-25}\n","Order ID","Store Name","User Name","price","date"));
                foreach( var order in o)
                {
                    Console.WriteLine(String.Format("{0,-25} {1,-25} {2,-25} {3,-25} {4,-25}\n",order.EntityID,order.Store.Name,order.User.Name,order.price,order.Ordertime));
                } 

            }
            else if(input == 2)
            {
                UserView();
            }
            else if(input == 3)
            {
                Console.WriteLine("Exiting Program...");
                Console.WriteLine("Thank you for using the pizza app!");
            } 
            else
            {
                Console.WriteLine("Invalid options");
            }
            
        }
        static APizzaModel SelectPizza()
        {
            PrintAllPizzas();
            APizzaModel pizza = new Pizza();
            bool done = false;
            var input = 0;
            Console.WriteLine("Please choose one of the pizza");
            while(!done)
            {
                int.TryParse(Console.ReadLine(), out input);

                if(input > _sql.ReadPizzas().ToList().Count|| input <=0)
                {
                  Console.WriteLine("Please enter a valid option");

                }
                else
                {
                    pizza = _sql.ReadPizzas().ToList().ElementAtOrDefault(input-1);
                    return pizza;
                } 
            }
            if(pizza.name ==null)
            {
                Console.WriteLine("WARNING: error in SelectPizza Statement");
            }
            return pizza;
        }
        static List<APizzaModel> MakePizza()
        {
            bool done = false;
            bool done2 = false;
            var input = 0;
            List<APizzaModel> Pizzas = new List<APizzaModel>();
            while(!done)
            {
                var sb = new System.Text.StringBuilder();
                int counter = 1;
                Order temp_o = new Order(Pizzas);
                Console.WriteLine("Shopping Cart: ");
                sb.Append(String.Format("{0,-25} {1,-25} {2,-25}\n","Pizza Number","Pizza Name","Total Price"));
                sb.Append(String.Format("{0,-25} {1,-25} {2,-25}\n","","",temp_o.price));
                foreach(var p in Pizzas)
                {
                    sb.Append(String.Format("{0,-25} {1,-25} {2,-25}\n",counter,p.name,p.price));
                    counter++;
                }
                
                
                Console.WriteLine(sb);

                Console.WriteLine("Choose one of the following options:");
                Console.WriteLine("1) Preset Pizza");
                Console.WriteLine("2) Custom Pizza");
                Console.WriteLine("3) Finish and checkout");
                int.TryParse(Console.ReadLine(), out input);

                if(input == 1)
                {
                    if(temp_o.price<=250 || temp_o.Pizzas.Count<=50)
                    {
                    APizzaModel p = SelectPizza();
                    Pizzas.Add(p);
                    Console.WriteLine("You have selected:");
                    Console.WriteLine("Pizza name: "+ p.name, "Price: $" +p.price);
                    }
                    else
                    {
                        Console.WriteLine("Too many pizzas in cart! Limist to $250 per order or 50 items");
                    }
                }
                else if(input == 2)
                {
                    if(temp_o.price<=250 || temp_o.Pizzas.Count<=50)
                    {
                    PrintAllCrusts();
                    Crust c =SelectCrust();
                    PrintAllSizes();
                    Size s = SelectSize();
                    List<Topping> ts = new List<Topping>();
                    while(!done2)
                    {
                        input = 0;
                        var t = new Topping();
                        Console.WriteLine("Please select one of the options: ");
                        Console.WriteLine("1) Add more toppings, "+ts.Count+"/5 Toppings");
                        Console.WriteLine("2) Stop");
                        int.TryParse(Console.ReadLine(), out input);

                        if(input == 1)
                        {
                            if(ts.Count<5)
                            {
                            PrintAllToppings();
                            ts.Add(SelectTopping());
                            
                            }
                            else
                            {
                                Console.WriteLine("Too many toppings!");
                            }
                        }
                        else if(input ==2)
                        {
                            done2 = true;
                            Console.WriteLine("Finished adding toppings...");
                        }
                        else
                        {
                            Console.WriteLine("Please select a valid option");
                        }
                    
                    }
                    Console.WriteLine("Adding custom built Pizza...");
                    Pizzas.Add(new Pizza(c,s,ts){name="CustomPizza"});
                    }
                    else
                    {
                        Console.WriteLine("Too many pizzas in cart! Limist to $250 per order or 50 items");
                    }
                    
                } 
                else if(input == 3)
                {
                    Console.WriteLine("Checking out...");
                    return Pizzas;
                }
                else
                {
                    Console.WriteLine("Please enter a valid option. (number 1, 2, or 3)");
                }
            
            }
            Console.WriteLine("WARNING: Error in MakePizza method");
            return Pizzas;
        }
        
        static void PrebuiltPizza()
        {
            if(_sql.ReadPizzas().Count()==0)
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
        static User CreateNewUser()
        { 
            bool done = false;
            User user = new User();
            Console.WriteLine("Please enter an username");
            var input = "";
            while(!done)
            {
            input = Console.ReadLine();
            // if(_sql.ReadUsers().ToList().FirstOrDefault(n => n.Name== input)!=null)
            if(_sql.ReadUsers().ToList().FirstOrDefault(n => n.Name== input)!=null)
            {
                Console.WriteLine("Username already exist, please enter another one");
            }
            else
            {
                user.Name = input;
                Console.WriteLine("Saving new user "+user.Name + "...");
                _sql.Save(user);
                done = true;
            }

            }

            return user;
        }
        static void StoreView()
        {
            bool done = false;
            var input = 0;
            PrintAllStoresWithEF();
            System.Console.WriteLine("Please select a store");
            Store s = SelectStore();
            User u = new User();
            System.Console.WriteLine("Name of selected store:  " + s.Name );
            while(!done)
            {
                Console.WriteLine("Please select one of the actions");
                Console.WriteLine("1) Check store order history");
                Console.WriteLine("2) Check order history of a user");
                Console.WriteLine("3) Exist Program");
                int.TryParse(Console.ReadLine(), out input);

                if(input == 1)
                {
                    if(s.Orders.Count ==0)
                    {
                        Console.WriteLine("There are no orders in this store");
                    }
                    else if(s.Orders == null)
                    {
                        Console.WriteLine("Order is null, check method");
                    }
                    else
                    {
                        Console.WriteLine("Checking order history...");
                        List<Order> orderhistory = new List<Order>();
                        orderhistory = _sql.OrderHistoryByStore(s).ToList();
                        Console.WriteLine("There are: "+orderhistory.Count+" order(s) for this store");

                        // Console.WriteLine(String.Format("{0,-20} {1,-20} {2,-20} {3,-20}\n\n",
                        //                             "Order ID","User Name","Order Time","Order Price"));
                        // Console.WriteLine("DEBUG: "+s.Orders);
                        
                        Console.WriteLine(String.Format("{0,-25} {1,-25} {2,-25} {3,-25} {4,-25}\n","Order ID","Store Name","User Name","price","date"));
                        foreach( var order in orderhistory)
                        {
                            Console.WriteLine(String.Format("{0,-25} {1,-25} {2,-25} {3,-25} {4,-25}\n",order.EntityID,order.Store.Name,order.User.Name,order.price,order.Ordertime));
                        } 
                        
                    }
                }
                else if(input == 2)
                {
                    Console.WriteLine("Selecting user...\n\n");
                    PrintAllUsers();
                    u = SelectUser();
                    if(u.Orders.Intersect(s.Orders).Any()==false)
                    {
                        Console.WriteLine("User not found within this store\n");

                    } 
                    else
                    {
                        
                        List<Order>orders = _sql.OrderHistoryByUser(u).Where(o=>o.Store.Name==s.Name).ToList();
                        Console.WriteLine("User: "+u.Name+" has "+orders.Count+" orders");
                        Console.WriteLine("The las order price was "+ orders.Last().price);
                        Console.WriteLine(String.Format("{0,-25} {1,-25} {2,-25} {3,-25} {4,-25}\n","Order ID","Store Name","User Name","price","date"));
                        foreach( var order in orders)
                        {
                            Console.WriteLine(String.Format("{0,-25} {1,-25} {2,-25} {3,-25} {4,-25}\n",order.EntityID,order.Store.Name,order.User.Name,order.price,order.Ordertime));
                        } 
                    }
                }
                else if(input ==3)
                {
                    done = true;
                    Console.WriteLine("Exiting program...");
                }
                else 
                {
                    Console.WriteLine("Please enter a valid option");
                }
            }


        }
    }
}
