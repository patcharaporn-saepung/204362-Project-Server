using MheanMaa.Models;
using MheanMaa.Settings;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace MheanMaa.Services
{
    public class NewsService
    {
        private readonly IMongoCollection<News> _news;
        public NewsService(IDBSettings settings)
        {
            MongoClient client = new MongoClient(settings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(settings.DBName);
            _news = database.GetCollection<News>(settings.NewsColName);
        }

        public List<News> Get() =>
            _news.Find(_ => true).ToList();

        public List<News> Get(int deptNo) =>
            _news.Find(news => news.DeptNo == deptNo).ToList();

        public News Get(string id, int deptNo) =>
            _news.Find(news => news.Id == id && news.DeptNo == deptNo).FirstOrDefault();

        public News Create(News newNews)
        {
            _news.InsertOne(newNews);
            return newNews;
        }
        public void Update(string id, News newsIn) =>
            _news.ReplaceOne(news => news.Id == id, newsIn);
        public void Remove(News newsIn) =>
            _news.DeleteOne(news => news.Id == newsIn.Id);
        public void Remove(string id) =>
            _news.DeleteOne(news => news.Id == id);
    }
}
