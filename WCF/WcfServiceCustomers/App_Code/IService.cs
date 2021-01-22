using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{
	[OperationContract]
	IEnumerable<Customer> GetAllCustomer();


	[OperationContract]
	void AddCustomer(Customer customer);

	[OperationContract]
	IEnumerable<Customer> SearchCustomer(string Name);
}

[DataContract]
public class Customer
{
	[DataMember]
	public int ID { get; set; }

	[DataMember]
	public string Name { get; set; }

	[DataMember]
	public string Mobile { get; set; }
}
