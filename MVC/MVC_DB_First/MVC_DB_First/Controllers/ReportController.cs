using Microsoft.Reporting.WebForms;
using MVC_DB_First.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MVC_DB_First.Controllers
{
    public class ReportController : Controller
    {
        restatedbEntities db = new restatedbEntities();

        // GET: Report
        public ActionResult Index(string Location23, decimal? minprice, decimal? maxprice)
        {
            ViewBag.Location = new SelectList(db.Properties.Select(x => x.Location).Distinct());

            ReportViewer rv = new ReportViewer();
            rv.ProcessingMode = ProcessingMode.Local;
            rv.SizeToReportContent = true;
            rv.Width = Unit.Percentage(80);
            rv.Height = Unit.Percentage(80);

            // 1- Establish Connction
            var strcon = ConfigurationManager.ConnectionStrings["restatedbConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            con.Open();

            // 2- Call SQl Command
            DataSet1 ds = new DataSet1();

            // Retrieve data by stored procedure
            if (maxprice != null && minprice != null)
            {
                SqlDataAdapter da = new SqlDataAdapter("dbo.sp_GetProperty", con);
                da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@minprice", minprice);
                da.SelectCommand.Parameters.AddWithValue("@maxprice", maxprice);
                da.Fill(ds, ds.Properties.TableName);
            }

            // Retrieve data by drop down list
            //if (!string.IsNullOrEmpty(Location23))
            //{
            //    SqlDataAdapter da = new SqlDataAdapter("select * from Properties where Location=@Location", con);
            //    //da.SelectCommand.CommandType = System.Data.CommandType.Text;
            //    da.SelectCommand.Parameters.AddWithValue("@Location", Location23);
            //    da.Fill(ds, ds.Properties.TableName);
            //}
            //else
            //{
            //    SqlDataAdapter da = new SqlDataAdapter("select * from Properties", con);
            //    da.Fill(ds, ds.Properties.TableName);
            //}

            // 3- bind data to report
            rv.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath + @".\Report1.rdlc");
            rv.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", ds.Tables["Properties"]));
            ViewBag.reportviewer = rv;

            return View();
        }
    }
}