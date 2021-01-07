using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyWebApp.GenericRepo
{
    public interface IRepository<T>
    {
        void Add(T t);

        void Update(T t);

        void Delete(object id);

        IEnumerable<T> GetAll();

        T GetByID(object id);

        void Save();

        //void SendMail(object from, object to, object subject, object body);
    }
}
