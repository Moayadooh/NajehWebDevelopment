using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using RestSharp;

namespace MVC_Payment
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        //I'm the payment service provider
        [WebMethod]
        public void GetOrder(object simpleJson, string auth)
        {
            var client = new RestClient("https://api.tap.company/v2/orders");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", auth);
            request.AddParameter("application/json", simpleJson, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
        }
    }
}
