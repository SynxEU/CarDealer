using CarDealerProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Collections;
using System.Diagnostics;
using System.Reflection;

namespace CarDealerProjekt
{
    internal class Cardealer
    {
        public List<Person> Person = new List<Person>();
        public List<Car> Cars = new List<Car>();
        public Cardealer()
        {
            LoadCars();
            GetCarDealerName();
            List<Person> Person = new List<Person>();
        }
        public void GoBack()
        {
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }
        public string SQLConnection()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath("C:\\Users\\jonkn0001.PCSYD\\Downloads\\CarDealerProjekt\\CarDealerProjekt")
                .AddJsonFile("appsettings.json")
                .Build();
            string connectionString = config.GetConnectionString("Default");
            return connectionString;
        }
        public int EmployeeCheck(int personId)
        {
            int employeeId = 0;
            string employeeCheck = "EmployeeCheck";
            using (SqlConnection conn = new SqlConnection(SQLConnection()))
            {
                conn.Open();
                SqlCommand com = new SqlCommand(employeeCheck, conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@PersonID", personId.ToString());
                com.ExecuteNonQuery();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    employeeId = reader.GetInt32(0);
                }
                reader.Close();
            }
            return employeeId;
        }
        public string GetCarDealerName()
        {
            return "Prestige Motors";
        }
        public int CreatePerson(string firstname, string lastname, PersonType Type)
        {
            string query = "StoreUsers";
            string user;
            int personId = 0;
            double balance = 0;
            Customer customer = new Customer(firstname, lastname, personId, balance);
            Dealer dealer = new Dealer(firstname, lastname, personId, balance);

            Console.Write("Buyer or dealer: ");
            user = Console.ReadLine();

            if (user.ToLower() == "buyer")
            {
                customer.Firstname = firstname;
                customer.Lastname = lastname;
                customer.Balance = balance;
                Person.Add(customer);
            }
            if (user.ToLower() == "dealer")
            {
                dealer.Firstname = firstname;
                dealer.Lastname = lastname;
                dealer.Balance = balance;
                Person.Add(dealer);
            }

            Console.Clear();
            foreach (var p in Person)
            {
                using (SqlConnection conn = new SqlConnection(SQLConnection()))
                {
                    conn.Open();
                    SqlCommand com = new SqlCommand(query, conn);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@fName", p.Firstname.ToString());
                    com.Parameters.AddWithValue("@lName", p.Lastname.ToString());
                    com.Parameters.AddWithValue("@bal", p.Balance.ToString());
                    com.Parameters.AddWithValue("@type", Convert.ToInt32(p.Type));
                    com.ExecuteNonQuery();
                }
                Console.WriteLine("Id: None\nFirst name: {0}\nLast name: {1}\nBalance: {2}\nType: {3}", p.Firstname, p.Lastname, p.Balance, p.Type);
            }
            GoBack();
            return personId;
        }
        public string DeletePersonById(int personId)
        {
            string query = "DeleteUser";

            using (SqlConnection conn = new SqlConnection(SQLConnection()))
            {
                conn.Open();
                SqlCommand com = new SqlCommand(query, conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@PersonID", personId.ToString());
                com.ExecuteNonQuery();
            }

            Console.Clear();
            
            return "User has now been deleted";
        }
        public string AddBalance(int personId, double balance) 
        {
            double currentBalance = 0;
            string query = "UpdateBalance", newBalance;

            currentBalance = Convert.ToDouble(CheckBalance(personId)) + balance;

            using (SqlConnection conn = new SqlConnection(SQLConnection()))
            {
                conn.Open();
                SqlCommand com = new SqlCommand(query, conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@PersonID", personId.ToString());
                com.Parameters.AddWithValue("@Balance", currentBalance.ToString());
                com.ExecuteNonQuery();
            }

            Console.Clear();
            Console.WriteLine("Your new balance: {0}",currentBalance);

            newBalance = currentBalance.ToString();
            GoBack();

            return newBalance;
        }
        public double CheckBalance(int personId)
        {
            string query = "CheckBalance";
            double currentBalance = 0;
            int balance = 0;

            using (SqlConnection conn = new SqlConnection(SQLConnection()))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PersonID", personId.ToString());
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    balance = reader.GetInt32(0);
                }
                reader.Close();
            }

            currentBalance = Convert.ToDouble(balance);

            Console.Clear();

            return currentBalance;
        }
        public Person GetPersonById(int personId)
        {
            Person person = new Person();
            string query = "GetPerson";

            using (SqlConnection conn = new SqlConnection(SQLConnection()))
            {
                conn.Open();
                SqlCommand com = new SqlCommand(query, conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@PersonID", personId.ToString());
                com.ExecuteNonQuery();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    person.PersonId = reader.GetInt32(0);
                    person.Firstname = reader.GetString(1);
                    person.Lastname = reader.GetString(2);
                    person.Type = (PersonType)reader.GetInt32(3);
                    person.Balance = reader.GetInt32(4);

                    Console.WriteLine("PersonID: {0}", person.PersonId);
                    Console.WriteLine("Firstname: {0}", person.Firstname);
                    Console.WriteLine("Lastname: {0}", person.Lastname);
                    Console.WriteLine("Type: {0}", person.Type);
                    Console.WriteLine("Balance: {0}\n", person.Balance);
                }
                reader.Close();
            }
            GoBack();
            return person;
        }
        public List<Person> GetListOfPersons()
        {
            Console.Clear();

            List<Person> persons = new List<Person>();
            string query = "GetListOfUsers";

            using (SqlConnection conn = new SqlConnection(SQLConnection()))
            {
                conn.Open();
                SqlCommand com = new SqlCommand(query, conn);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Person person = new Person();
                    person.PersonId = reader.GetInt32(0);
                    person.Firstname = reader.GetString(1);
                    person.Lastname = reader.GetString(2);
                    person.Type = (PersonType)Enum.ToObject(typeof(PersonType), reader.GetInt32(3));
                    person.Balance = reader.GetInt32(4);
                    persons.Add(person);
                    foreach (var p in persons)
                    {
                        Console.WriteLine("PersonID: {0}", p.PersonId);
                        Console.WriteLine("Firstname: {0}", p.Firstname);
                        Console.WriteLine("Lastname: {0}", p.Lastname);
                        Console.WriteLine("Type: {0}", p.Type);
                        Console.WriteLine("Balance: {0}\n", p.Balance);
                    }
                }
                reader.Close();
            }
            GoBack();
            return persons;
        }
        public int AddCar(Car newCar, int personId)
        {
            string query = "StoreCars";
            int carId;

            if (EmployeeCheck(personId) == Convert.ToInt32(PersonType.Dealer))
            {
                Cars.Clear();
                Console.WriteLine("Brand: {0}\nModel: {1}\nPrice: {2}$\nIn stock: {3}", newCar.Brand, newCar.Model, newCar.Price, newCar.InStock);
                Cars.Add(newCar);
                foreach (var c in Cars)
                {
                    using (SqlConnection conn = new SqlConnection(SQLConnection()))
                    {
                        conn.Open();
                        SqlCommand com = new SqlCommand(query, conn);
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@Brand", Convert.ToInt32(c.Brand));
                        com.Parameters.AddWithValue("@Model", c.Model.ToString());
                        com.Parameters.AddWithValue("@Price", c.Price.ToString());
                        com.Parameters.AddWithValue("@InStock", c.InStock.ToString());
                        com.ExecuteNonQuery();
                    }
                }
                Cars.Remove(newCar);
            }
            else
            {
                Console.WriteLine("You are not a dealer\nYou can't add cars.");
            }
            GoBack();
            return carId;
        }
        public string DeleteCarById(int carId, int personId)
        {
            string query = "DeleteCar";

            if (EmployeeCheck(personId) == Convert.ToInt32(PersonType.Dealer))
            {

                using (SqlConnection conn = new SqlConnection(SQLConnection()))
                {
                    conn.Open();
                    SqlCommand com = new SqlCommand(query, conn);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@CarID", carId.ToString());
                    com.ExecuteNonQuery();
                }
                return "Car has now been deleted";
            }
            else
            {
                Console.Clear();
                return "You are not a dealer\nYou can't delete cars.";
            }
        }
        public string UpdateCar(Car updateCar, int personId)
        {
            string query = "UpdateCar";
            int carId;
            double price;

            Console.Write("Enter Car ID: ");
            carId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the price of the car: ");
            price = Convert.ToInt32(Console.ReadLine());

            if (EmployeeCheck(personId) == Convert.ToInt32(PersonType.Dealer))
            {

                using (SqlConnection conn = new SqlConnection(SQLConnection()))
                {
                    conn.Open();
                    SqlCommand com = new SqlCommand(query, conn);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@CarID", carId.ToString());
                    com.Parameters.AddWithValue("@Price", price.ToString());
                    com.ExecuteNonQuery();
                }
                updateCar.Price = price;
                return $"You have now updated car with ID: {carId}";
            }
            else
            {
                Console.Clear();
                return "You are not a dealer\nYou can't update cars.";
            }
        }
        public Car GetCarById(int carId)
        {
            string model = "";
            double price = 0;
            string query = "GetCarById";
            Car car = new Car(model, price);

            using (SqlConnection conn = new SqlConnection(SQLConnection()))
            {
                conn.Open();
                SqlCommand com = new SqlCommand(query, conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@CarID", carId.ToString());
                com.ExecuteNonQuery();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    car.CarID = reader.GetInt32(0);
                    car.Brand = (Carbrand)Enum.ToObject(typeof(Carbrand), reader.GetInt32(1));
                    car.Model = reader.GetString(2);
                    car.Price = reader.GetInt32(3);
                    car.InStock = Convert.ToBoolean(reader.GetString(4));

                    Console.WriteLine("CarID: {0}", car.CarID);
                    Console.WriteLine("Brand: {0}", car.Brand);
                    Console.WriteLine("Model: {0}", car.Model);
                    Console.WriteLine("Price: {0}", car.Price);
                    Console.WriteLine("In Stock: {0}\n", car.InStock);
                }
                reader.Close();
            }
            GoBack();
            return car;
        }
        public List<Car> GetListOfCars()
        {
            Console.Clear();

            string query = "GetListOfCars";

            using (SqlConnection conn = new SqlConnection(SQLConnection()))
            {
                string model = "";
                double price = 0;
                conn.Open();
                SqlCommand com = new SqlCommand(query, conn);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Car car = new Car(model, price);
                    car.CarID = reader.GetInt32(0);
                    car.Brand = (Carbrand)Enum.ToObject(typeof(Carbrand), reader.GetInt32(1));
                    car.Model = reader.GetString(2);
                    car.Price = reader.GetInt32(3);
                    car.InStock = Convert.ToBoolean(reader.GetString(4));
                    Cars.Add(car);

                    foreach (var cars in Cars)
                    {
                        Console.WriteLine("CarID: {0}", cars.CarID);
                        Console.WriteLine("Brand: {0}", cars.Brand);
                        Console.WriteLine("Model: {0}", cars.Model);
                        Console.WriteLine("Price: {0}", cars.Price);
                        Console.WriteLine("In Stock: {0}\n", cars.InStock);
                    }
                }
                reader.Close();
            }
            GoBack();
            return Cars;
        }
        public string BuyCar(int carId, int personId) 
        {
            string query = "BuyCars", queryPrice = "CheckPrice", queryBalance = "UpdateBalance";
            double price = 0, balance = CheckBalance(personId), newBalance = 0;

            using (SqlConnection conn = new SqlConnection(SQLConnection()))
            {
                conn.Open();
                SqlCommand commandPrice = new SqlCommand(queryPrice, conn);
                commandPrice.CommandType = CommandType.StoredProcedure;
                commandPrice.Parameters.AddWithValue("@CarId", carId.ToString());
                SqlDataReader reader = commandPrice.ExecuteReader();
                while (reader.Read())
                {
                    price = reader.GetInt32(0);
                }
                reader.Close();

                if (balance >= price)
                {
                    newBalance = balance - price;
                    string instock = "False";

                    SqlCommand command = new SqlCommand(query, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CarId", carId.ToString());
                    command.Parameters.AddWithValue("@InStock", instock.ToString());
                    command.Parameters.AddWithValue("@BoughtbyId", personId.ToString());
                    command.ExecuteNonQuery();

                    SqlCommand com = new SqlCommand(queryBalance, conn);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@PersonId", personId.ToString());
                    com.Parameters.AddWithValue("@Balance", newBalance.ToString());
                    com.ExecuteNonQuery();
                    return $"You have now bought the car with ID {carId}";
                }
                else
                {
                    return "You do not have enough money";
                }
            }
        }
        public void LoadCars()
        {
            string query = "GetListOfCars";

            using (SqlConnection conn = new SqlConnection(SQLConnection()))
            {
                string model = "";
                double price = 0;
                conn.Open();
                SqlCommand com = new SqlCommand(query, conn);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Car car = new Car(model, price);
                    car.CarID = reader.GetInt32(0);
                    //car.Brand = (Carbrand)Enum.ToObject(typeof(Carbrand), reader.GetInt32(1));
                    car.Model = reader.GetString(2);
                    car.Price = reader.GetInt32(3);
                    car.InStock = Convert.ToBoolean(reader.GetString(4));
                }
                reader.Close();
            }
        }
    }
}
