using CarDealerProjekt.Models;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace CarDealerProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cardealer cardealer = new Cardealer();
            string choice;

            while (true)
            {
                Console.Clear();
                Console.Title = cardealer.GetCarDealerName() + " Program";
                Console.WriteLine(cardealer.GetCarDealerName());
                Console.WriteLine("\n1. Create user\n2. Delete user\n3. Show user\n4. Add balance\n5. Check balance\n6. Show all users\n7. Buy car\n8. Add car\n9. Delete car\n10. Update car\n11. Show car\n12. Show all cars\n");
                choice = Console.ReadLine();
                switch (choice.ToLower())
                {
                    case "1" or "create user":
                        CreateUser();
                        break;
                    case "2" or "delete user":
                        DeleteUser();
                        break;
                    case "3" or "show user":
                        GetUser();
                        break;
                    case "4" or "add balance":
                        UpdateBalance();
                        break;
                    case "5" or "check balance":
                        CheckBalance();
                        break;
                    case "6" or "show all users":
                        cardealer.GetListOfPersons();
                        break;
                    case "7" or "buy car":
                        BuyCar();
                        break;
                    case "8" or "add car":
                        CreateCar();
                        break;
                    case "9" or "delete car":
                        DeleteCar();
                        break;
                    case "10" or "update car":
                        UpdateCar();
                        break;
                    case "11" or "show car":
                        GetCar();
                        break;
                    case "12" or "show all cars":
                        cardealer.GetListOfCars();
                        break;
                    default:
                        break;

                }
            }
        }
        static void GoBack()
        {
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }
        static void CreateUser()
        {
            Console.Clear();
            string firstname, lastname;
            PersonType Type = 0;
            Cardealer User = new Cardealer();

            Console.Write("First name: ");
            firstname = Console.ReadLine();
            Console.Write("Last name: ");
            lastname = Console.ReadLine();

            User.CreatePerson(firstname, lastname, Type);
        }
        static void DeleteUser()
        {
            Console.Clear();
            int personId;
            Cardealer User = new Cardealer();

            Console.WriteLine("Enter Person ID: ");
            personId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(User.DeletePersonById(personId));
            GoBack();
        }
        static void UpdateBalance()
        {
            Console.Clear();
            int personId;
            double balance;
            Cardealer User = new Cardealer();

            Console.WriteLine("Enter the id of the person: ");
            personId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the amount you want to add: ");
            balance = Convert.ToDouble(Console.ReadLine());

            User.AddBalance(personId, balance);
        }
        static void CheckBalance()
        {
            Console.Clear();
            int personId;
            Cardealer User = new Cardealer();

            Console.WriteLine("Enter the id of the person: ");
            personId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Your current balance: {0}", User.CheckBalance(personId));
            GoBack();
        }
        static void GetUser()
        {
            Console.Clear();
            int personId;
            Cardealer User = new Cardealer();

            Console.WriteLine("Enter the id of the person: ");
            personId = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            User.GetPersonById(personId);
        }
        static void CreateCar()
        {
            Console.Clear();
            int personid;
            string model;
            double price;
            Cardealer user = new Cardealer();

            Console.WriteLine("Enter your ID: ");
            personid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter car brand: ");
            if (Enum.TryParse<Carbrand>(Console.ReadLine(), ignoreCase: true, out Carbrand brand))
            {
                Console.WriteLine("Enter what model you would like to add: ");
                model = Console.ReadLine();
                Console.WriteLine("Enter the price of the model: ");
                price = Convert.ToDouble(Console.ReadLine());
                Console.Clear();

                Car newCar = new Car(model, price);

                switch (brand)
                {
                    case Carbrand.McLaren:
                        newCar.Brand = Carbrand.McLaren;
                        break;
                    case Carbrand.Koenigsegg:
                        newCar.Brand = Carbrand.Koenigsegg;
                        break;
                    case Carbrand.Aston_Martin:
                        newCar.Brand = Carbrand.Aston_Martin;
                        break;
                    case Carbrand.Bugatti:
                        newCar.Brand = Carbrand.Bugatti;
                        break;
                    case Carbrand.Bentley:
                        newCar.Brand = Carbrand.Bentley;
                        break;
                    case Carbrand.Maserati:
                        newCar.Brand = Carbrand.Maserati;
                        break;
                    case Carbrand.Zenvo:
                        newCar.Brand = Carbrand.Zenvo;
                        break;
                    case Carbrand.Lamborghini:
                        newCar.Brand = Carbrand.Lamborghini;
                        break;
                    default:
                        break;
                }
                newCar.Model = model;
                newCar.Price = price;
                user.AddCar(newCar, personid);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Unknown Carbrand\n\nKnown Carbrands:\nMcLaren\nKoenigsegg\nAston_Martin\nBugatti\nBently\nMaserati\nZenvo\nLamborghini\n");
                GoBack();
            }
        }
        static void DeleteCar()
        {
            Console.Clear();
            int personId, carId;
            Cardealer User = new Cardealer();

            Console.WriteLine("Enter your ID: ");
            personId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter car ID: ");
            carId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(User.DeleteCarById(carId, personId));
            GoBack();
        }
        static void UpdateCar()
        {
            Console.Clear();
            string model = string.Empty;
            double price = 0;
            int personId;
            Cardealer User = new Cardealer();
            Car updateCar = new Car(model, price);

            Console.WriteLine("Enter your ID: ");
            personId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(User.UpdateCar(updateCar, personId));
            GoBack();

        }
        static void BuyCar()
        {
            Console.Clear();
            int carId, personId;
            Cardealer User = new Cardealer();

            Console.Write("Enter your person ID: ");
            personId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the car ID of the car you want: ");
            carId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(User.BuyCar(carId, personId));
            GoBack();
        }
        static void GetCar()
        {
            Console.Clear();
            int carId;
            Cardealer User = new Cardealer();

            Console.WriteLine("Enter the id of the car: ");
            carId = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            User.GetCarById(carId);
        }
    }
}