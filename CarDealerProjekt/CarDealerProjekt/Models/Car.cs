using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerProjekt.Models
{
    public class Car
    {
        public int CarID;
        public Carbrand Brand;
        public string Model;
        public double Price;
        public bool InStock = true;


        public Car(string model, double price)
        {
            Model = model;
            Price = price;

        }
    }
}
