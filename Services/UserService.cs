﻿using System.Linq;
using MheanMaa.Models;
using MheanMaa.Settings;
using MongoDB.Driver;

namespace MheanMaa.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IDBSettings settings)
        {
            MongoClient client = new MongoClient(settings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(settings.DBName);

            _users = database.GetCollection<User>(settings.UsersColName);
        }

        public User Find(string id) =>
            _users.Find(usr => usr.Id == id).FirstOrDefault();

        public User Find(string username, string password) =>
            _users.Find(usr => usr.Username == username && usr.Password == password ).FirstOrDefault();
    }
}
