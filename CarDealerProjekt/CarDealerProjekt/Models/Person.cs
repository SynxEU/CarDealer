using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerProjekt.Models
{
    class Person
    {
        public int PersonId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public PersonType Type { get; set; }
        public double Balance { get; set; }
        public List<Car> BoughtCars;
    }
}
