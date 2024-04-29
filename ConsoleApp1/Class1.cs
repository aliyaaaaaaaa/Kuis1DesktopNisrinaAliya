using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuis1
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public bool Login(string username, string password)
        {
            return Username == username && Password == password;
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Product(string name, decimal price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }
    }
}

