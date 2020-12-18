using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Domain.Singletons
{
    public class ClientSingleton
    {
        private static ClientSingleton _instance;
        public List<Store> Stores {get;set;}

        private const string _path  = @"PizzaWorld.xml";

        public static ClientSingleton Instance 
        {
            get
            {
                if(Instance1 == null)
                {
                    Instance1 = new ClientSingleton();
                }
                return Instance1;
            }
        }

        public static ClientSingleton Instance1 { get => _instance; set => _instance = value; }

        private ClientSingleton()
        {
            Read();
        }
        public void GetAllStores()
        {

        }

        public void MakeAStore()
        {
            Stores.Add(new Store());
            Save();
        }
        public Store SelectStore()
        {
            int.TryParse(Console.ReadLine(), out var input);
           // Stores.FirstOrDefault(s => s. == input); // unique property, customer entered
            return Stores.ElementAtOrDefault(input); // null if there's error

            //Stores[input]; // exception
        }

        private void Save()
        {
            var file = new StreamWriter(_path);
            var xml = new XmlSerializer(typeof(List<Store>)); 

            xml.Serialize(file, Stores);
        }
        private void Read()
        {
            if(File.Exists(_path))
            {
            var file = new StreamReader(_path);
            var xml = new XmlSerializer(typeof(List<Store>));
            // compared to (List<Store>) type of casting this does not throw exception and assign Stores to null
            Stores = xml.Deserialize(file) as List<Store>; 
            }
            else
            {
                Stores = new List<Store>();
            }
            
        }

    }
}