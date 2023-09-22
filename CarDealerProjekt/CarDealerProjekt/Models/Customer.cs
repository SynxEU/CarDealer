using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CarDealerProjekt.Models
{
    class Customer : Person
    {
        public Customer(string firstname, string lastname, int personid, double balance)
        {
            PersonId = personid;
            Firstname = firstname;
            Lastname = lastname;
            Type = PersonType.Customer;
            Balance = balance;
        }
    }
}
