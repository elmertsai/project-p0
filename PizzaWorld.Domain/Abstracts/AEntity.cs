using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
