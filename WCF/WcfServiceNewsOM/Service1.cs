using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceNewsOM
{
    public class Service1 : IService1
    {
        NewsDB db = new NewsDB();

        public void AddNews(News news)
        {
            db.News.Add(news);
            db.SaveChanges();
        }

        public void DeleteNews(int id)
        {
            var table = db.News.Find(id);
            db.News.Remove(table);
            db.SaveChanges();
        }

        public IEnumerable<News> GetAllNews()
        {
            return db.News.ToList();
        }

        public News GetOne(int id)
        {
            return db.News.Find(id);
        }

        public void UpdateNews(News news)
        {
            db.Entry(news).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
