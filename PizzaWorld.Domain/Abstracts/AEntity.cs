using System;

namespace PizzaWorld.Domain.Abstracts
{
    public abstract class AEntity
    {
        public long EntityID { get;}
        protected AEntity()
        {
            EntityID = DateTime.Now.Ticks; 
        }
    }
}
