using MVC_Repository_Pattern.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace MVC_Repository_Pattern.GenericRepo
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private SchoolDB db = null;
        protected DbSet<T> Table = null;

        public Repository()
        {
            db = new SchoolDB(); //set for real db
            Table = db.Set<T>(); // set for real table
        }

        public void Add(T t)
        {
            Table.Add(t);
            Save();
        }

        public void Delete(object id)
        {
            T t = Table.Find(id);
            Table.Remove(t);
            Save();
        }

        public IEnumerable<T> GetAll()
        {
            return Table.ToList();
        }

        public T GetByID(object id)
        {
            return Table.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(T t)
        {
            db.Entry(t).State = EntityState.Modified;
            Save();
        }

        public void SendMail(object msg, object to, object from, object subject)
        {
            var body = "<p> Email From : {0} - ({1})</p><p>Message:</p><p>{2}</p> ";
            var message = new MailMessage();
            message.To.Add(new MailAddress("moayad@gmail.com")); // info@yourdomain
            message.From = new MailAddress("moayad.soft@outlook.com");
            message.Subject = "Test Suject";
            message.Body = string.Format(body, from, to, msg);
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var crd = new NetworkCredential()
                {
                    UserName = "moayad.soft@outlook.com",
                    Password = ""
                };
                smtp.Credentials = crd;
                smtp.Host = "smtp-mail.outlook.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(message);
            }
        }
    }
}