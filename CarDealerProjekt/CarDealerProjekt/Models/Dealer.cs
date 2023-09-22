using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerProjekt.Models
{
    internal class Dealer : Person
    {
        public Dealer(string firstname, string lastname, int personId, double balance)
        {
            PersonId = personId;
            Firstname = firstname;
            Lastname = lastname;
            Type = PersonType.Dealer;
            Balance = balance;
        }
    }
}
