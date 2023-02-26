using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public class Item
    {
        public Item(string name, int quantity, double unitaryPrice)
        {
            this.name = name;
            this.quantity = quantity;
            this.unitaryPrice = unitaryPrice;
        }

        public string name {get;set;}
        public int quantity {get;set;}
        public double unitaryPrice {get;set;}
        
    }
}