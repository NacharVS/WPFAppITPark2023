using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    internal class User
    {
        public User(string name, string age, string eMail, string vac)
        {
            Name = name;
            Age = age;
            EMail = eMail;
            Vacancy = vac;
        }

        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string EMail { get; set; }
        public string Vacancy { get; set; }


        public static List<User> GetUsersList()
        {
            List<User> users = new List<User>();
            users.Add(new User("Ivan", "38", "aaa@aa.ru", "Director"));
            users.Add(new User("Andrey", "23", "ddd@aa.ru", "CreativeDirector"));
            users.Add(new User("Georgiy", "33", "ppp@aa.ru", "Manager"));
            users.Add(new User("Jack", "54", "fff@aa.ru", "Driver"));
            users.Add(new User("Robert", "22", "eee@aa.ru", "Security"));
            return users;
        }

        public static void AddUserToDataBase(User user)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("UsersDataBase");
            var collection = database.GetCollection<User>("Users");
            collection.InsertOne(user);
        }

        public static List<User> GetUsersListFromDB()
        {
            List<User> users = new List<User>();
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("UsersDataBase");
            var collection = database.GetCollection<User>("Users");
            users = collection.Find(x => true).ToList();
            return users;
        }

    }
}
