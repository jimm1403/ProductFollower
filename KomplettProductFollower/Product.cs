using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomplettProductFollower
{
    class Product
    {
        string name;
        string price;

        public string Name { get { return name;} }
        public string Price { get { return price; } }

        public Product(string name, string price)
        {
            this.name = name;
            this.price = price;
        }
    }
}
