using MheanMaa.Models;
using MheanMaa.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MheanMaa.Services
{
    public class DonateService
    {
        private readonly IMongoCollection<Donate> _donates;

        public DonateService(IDBSettings settings)
        {
            MongoClient client = new MongoClient(settings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(settings.DBName);

            _donates = database.GetCollection<Donate>(settings.DonatesColName);
        }

        public List<Donate> Get() =>
            _donates.Find(_ => true).ToList();

        public Donate Get(string id) =>
            _donates.Find<Donate>(don => don.Id == id).FirstOrDefault();

        public Donate Create(Donate newDon)
        {
            _donates.InsertOne(newDon);
            return newDon;
        }

        public void Update(string id, Donate donIn) =>
            _donates.ReplaceOne(don => don.Id == id, donIn);

        public void Remove(Donate donIn) =>
            _donates.DeleteOne(don => don.Id == donIn.Id);

        public void Remove(string id) =>
            _donates.DeleteOne(don => don.Id == id);
    }
}
