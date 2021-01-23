using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    CustomerDB db = new CustomerDB();
    public void AddCustomer(Customer customer)
    {
        db.Customers.Add(customer);
        db.SaveChanges();
    }

    public IEnumerable<Customer> GetAllCustomer()
    {
        return db.Customers.ToList();
    }

    public IEnumerable<Customer> SearchCustomer(string Name)
    {
        return db.Customers.Where(x => x.Name.Contains(Name)).ToList();
    }
}
