using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using WCF_Ajax.Models;

namespace WCF_Ajax
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServiceCar
    {
        CarDb db = new CarDb();

        [OperationContract]
        [WebGet]
        public IEnumerable<Car> GetCars()
        {
            return db.Cars.ToList();
        }

        [OperationContract]
        [WebGet] // --> http GET
        public Car GetOne(int id)
        {
            return db.Cars.Find(id);
        }

        [OperationContract]
        // WebMessageFormat.json or WebMessageFormat.xml
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void AddCars(string Name, string Country)
        {
            var car = new Car
            {
                Name = Name,
                Country = Country
            };
            db.Cars.Add(car);
            db.SaveChanges();
        }

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        public void UpdateCars(int ID, string Name, string Country)
        {
            var car = new Car
            {
                ID = ID,
                Name = Name,
                Country = Country
            };
            db.Entry(car).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        public void RemoveCars(int ID)
        {
            var car = db.Cars.Find(ID);
            db.Entry(car).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }
    }
}
