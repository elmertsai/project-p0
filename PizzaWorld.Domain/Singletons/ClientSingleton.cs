using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Domain.Singletons
{
    public class ClientSingleton
    {
        private static ClientSingleton _instance;
        public List<Store> Stores {get;set;}
        public static ClientSingleton Instance 
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new ClientSingleton();
                }
                return _instance;
            }
        }
        private ClientSingleton()
        {
            Stores = new List<Store>();
        }
        public void GetAllStores()
        {

        }

        public void MakeAStore()
        {
            var s = new Store();
            Stores.Add(s);
            Save();
        }

        private void Save()
        {
            string path  = @"PizzaWorld.xml";
            var file = new StreamWriter(path);
            var xml = new XmlSerializer(typeof(List<Store>)); 

            xml.Serialize(file, Stores);
        }
    }
}