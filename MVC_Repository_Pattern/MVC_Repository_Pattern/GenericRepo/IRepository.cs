using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Repository_Pattern.GenericRepo
{
    public interface IRepository<T>// where T : class
    {
        void Add(T t);

        void Update(T t);

        void Delete(object id);

        IEnumerable<T> GetAll();

        T GetByID(object id);

        void Save();

        void SendMail(object body, object to, object from, object subject);
    }
}