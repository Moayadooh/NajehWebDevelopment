using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC_DB_First.Controllers
{
    public class SyncAsyncController : Controller
    {
        // GET: SyncAsync
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetInfo()
        {
            var st1 = new Stopwatch();
            st1.Start();
            var name = GetName();
            var job = GetJob();
            st1.Stop();

            ViewBag.watchTimest1 = st1.ElapsedMilliseconds;
            return View();
        }

        public async Task<ActionResult> GetInfoAsync()
        {
            var st2 = new Stopwatch();
            st2.Start();
            var name = GetNameAsync();
            var job = GetJobAsync();
            var empname = await name;
            var empjob = await job;
            st2.Stop();

            ViewBag.watchTimest2 = st2.ElapsedMilliseconds;


            return View();
        }

        // Sync Functions
        public string GetName()
        {
            Thread.Sleep(3000);
            return "Ammar";
        }

        public string GetJob()
        {
            Thread.Sleep(5000);
            return "FullStackDeveloper";
        }

        // ASync Functions
        public async Task<string> GetNameAsync()
        {
            await Task.Delay(3000);
            return "Ammar Async";
        }

        public async Task<string> GetJobAsync()
        {
            await Task.Delay(5000);
            return "FullStackDeveloper Async";
        }
    }
}